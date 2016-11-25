<?php

	$mysqli = new mysqli("xo.online", "root", "", "xo");
	if ($mysqli->connect_errno)
	{
		echo "Ошибка соединения: ", $mysqli->connect_error;
		return;
	}
	if (!$mysqli->set_charset("utf8"))
	{
		echo "Ошибка при загрузке набора символов utf8: %s\n", $mysqli->error;
		return;
	}
	
	function getUser($login, $password) //получает данные пользователя !
	{
		global $mysqli;
		$query = sprintf("select users.login, users.countOfWins, users.isOnline from users where users.login = '%s' and users.password = '%s';", $login, $password);
		if ($result = $mysqli->query($query))
		{
			if ($row = $result->fetch_assoc()) return $row;
			$result->free();
			return 0;
		}
	}
	
	function clearSteps($gameId)
	{
		global $mysqli;
		$query = sprintf("delete from steps where steps.gameId = %s;", $gameId);
		if (!$mysqli->query($query)) return -1;
		else return 0;
	}
	
	function deleteGame($gameId)
	{
		global $mysqli;
		$query = sprintf("delete from games where games.id = %s;", $gameId);
		if (!$mysqli->query($query)) return -1;
		else return 0;
	}
	
	function getOnlineUsers($login) //получает пользователей онлайн относительно юзера !
	{
		global $mysqli;
		$query = sprintf("select users.login, users.countOfWins from users where users.isOnline = 1 and users.login != '%s';", $login);
		$report = array();
		if ($result = $mysqli->query($query))
		{
			$i = 0;
			while ($row = $result->fetch_assoc())
			{
				$report[$i] = $row;
				$i++;
			}
			$result->free();
			return $report;
		}
		else return 0;
	}
	
	function loginComparator($login, $password) //проверяет наличие логина !
	{
		global $mysqli;
		$query = sprintf("select users.password from users where users.login = '%s';", $login);
		if ($result = $mysqli->query($query))
		{
			if ($row = $result->fetch_assoc())
			{
				if ($row['password'] != $password) return -1;
				else return 1;
			}
			$result->free();
			return 0;
		}
	}
	
	function setUserOnline($login) //включает юзеру флаг "в сети" !
	{
		global $mysqli;
		$query = sprintf("update xo.users set isOnline = 1 where login = '%s'", $login);
		if (!$mysqli->query($query)) return -1;
		else return 0;
	}
	
	function setUserOffline($login) //выключает флаг "в сети" !
	{
		global $mysqli;
		$query = sprintf("update xo.users set isOnline = NULL where login = '%s'", $login);
		if (!$mysqli->query($query)) return -1;
		else return 0;
	}
	
	function addUser($login, $password) //добавляем нового юзера !
	{
		global $mysqli;
		$query = sprintf("insert into `xo`.`users` ( `login` , `password` , `countOfWins` , `isOnline` ) values ('%s' , '%s' , '0' , null);", $login, $password);
		if (!$mysqli->query($query)) return -1;
		else return 0;
	}
	
	function sendMessage($userFrom, $userTo, $message) //отправляем сообщение !
	{
		global $mysqli;
		$query = sprintf("insert into `xo`.`messages` ( `id` , `userFrom` , `userTo` , `message`, `countOfReaders`) values (null , '%s' , '%s' , '%s', 0);", $userFrom, $userTo, $message);
		if (!$mysqli->query($query)) return -1;
		else return 0;
	}
	
	function getMessages($login) //получаем все непрочитанные сообщения для юзера !
	{
		global $mysqli;
		$query = sprintf("select messages.userFrom, messages.userTo, messages.message from messages where messages.userTo = '%s' or messages.userTo = 'all';", $login);
		if ($result = $mysqli->query($query))
		{
			if ($row = $result->fetch_assoc()) return $row;
			$result->free();
			return 0;
		}
	}
	
	function incrementReaders($login) //!
	{
		global $mysqli;
		$query = sprintf("update xo.messages set countOfReaders = messages.countOfReaders + 1 where messages.userTo = '%s' or messages.userTo = 'all';", $login);
		if (!$mysqli->query($query)) return -1;
		else return 0;
	}		  
	
	function deletePrivateMessages() //!
	{
		global $mysqli;
		$query = sprintf("delete from messages where messages.userTo !='all' and messages.countOfReaders = 2;");
		if (!$mysqli->query($query)) return -1;
		else return 0;
	}
	
	function deletePublicMessages() //!
	{
		global $mysqli;
		$query = sprintf("delete from messages where messages.userTo = 'all' and messages.countOfReaders >= (select count(*) from users where users.isOnline = 1);");
		if (!$mysqli->query($query)) return -1;
		else return 0;
	}
	
	function deleteMessages() //!
	{
		deletePrivateMessages();
		deletePublicMessages();
	}
	
	function setUserWait($login) //включает юзеру флаг "в ожидании" !
	{
		global $mysqli;
		$waits = getWaitUsers($login);
		if ($waits == 0)
		{
			$query = sprintf("insert into `xo`.`games` (`id`, `firstPlayer`, `secondPlayer`) values (null, '%s', null)", $login);
			if (!$mysqli->query($query)) return -1;
			else return 0;
		}
		else
		{
			$query = sprintf("update xo.games set secondPlayer = '%s' where id = '%s'", $login, $waits['id']);
			if (!$mysqli->query($query)) return -1;
			else return $waits;
		}
	}
	
	function compareRival($login) //проверяем, не пришел ли к нам противник !
	{
		global $mysqli;
		$query = sprintf("select games.id, games.secondPlayer from games where games.firstPlayer = '%s';", $login);
		if ($result = $mysqli->query($query))
		{
			if ($row = $result->fetch_assoc()) return $row;
			$result->free();
			return 0;
		}
	}
	
	function getWaitUsers($login) //ищем ждущих пользователей !
	{
		global $mysqli;
		if ($login != null)
		{
			$query = sprintf("select games.id, games.firstPlayer from games where games.secondPlayer is null or games.secondPlayer='%s' limit 1;", $login);
			if ($result = $mysqli->query($query))
			{
				if ($row = $result->fetch_assoc()) return $row;
				$result->free();
				return 0;
			}
		}
		else
		{
			$query = sprintf("select games.id as gameId, games.firstPlayer, users.countOfWins from games inner join users on games.firstPlayer = users.login where games.secondPlayer is null;");
			$report = array();
			if ($result = $mysqli->query($query))
			{
				$i = 0;
				while ($row = $result->fetch_assoc())
				{
					$report[$i] = $row;
					$i++;
				}
				$result->free();
				return $report;
			}
			else return 0;
		}
	}
	
	/*function getWaitUsers() //ищем ждущих пользователей !
	{
		global $mysqli;
		$query = sprintf("select games.id as gameId, games.firstPlayer, users.countOfWins from games inner join users on games.firstPlayer = users.login where games.secondPlayer is null;");
		if ($result = $mysqli->query($query))
		{
			if ($row = $result->fetch_assoc()) return $row;
			$result->free();
			return 0;
		}
	}*/
	
	function playGame($gameId, $login)
	{
		global $mysqli;
		$query = sprintf("update games set secondPlayer = '%s' where games.id = %s;", $login, $gameId);
		if (!$mysqli->query($query)) return -1;
		else return 0;
	}
	
	function addStep($login, $stepId, $gameId, $x, $y) //добавляем новый шаг !
	{
		global $mysqli;
		$query = sprintf("insert into `xo`.`steps` ( `id` , `gameId` , `x` , `y` , `user`) values (%s , %s , %s , %s , '%s');", $stepId, $gameId, $x, $y, $login);
		if (!$mysqli->query($query)) return -1;
		else return 0;
	}
	
	function getLastStep($stepId, $gameId) //получаем последний шаг !
	{
		global $mysqli;
		$query = sprintf("select steps.x, steps.y from steps where steps.id = '%s' and steps.gameId='%s';", $stepId, $gameId);
		if ($result = $mysqli->query($query))
		{
			if ($row = $result->fetch_assoc()) return $row;
			$result->free();
			return 0;
		}
	}
	
	function setUserWin($login) //добавляем выйгрыш пользователю !
	{
		global $mysqli;
		$query = sprintf("update users set countOfWins = countOfWins + 1 where users.login = '%s';", $login);
		if (!$mysqli->query($query)) return -1;
		else return 0;
	}
	
	function setUserLouse($login) //добавляем проигрыш пользователю // <= не нужна
	{
		global $mysqli;
		$query = sprintf("update users set countOfWins = countOfWins - 1 where users.login = '%s';", $login);
		if (!$mysqli->query($query)) return -1;
		else return 0;
	}
	
	function setLastActivity($login, $time) //!
	{
		global $mysqli;
		$query = sprintf("update users set lastActivity = '%s' where users.login = '%s';", $time, $login);
		if (!$mysqli->query($query)) return -1;
		else return 0;
	}
	
	function getLastActivity($login, $timeNow) //!
	{
		global $mysqli;
		$query = sprintf("select timediff('%s', users.lastActivity) as timediff from users where users.login = '%s';", $timeNow, $login);
		if ($result = $mysqli->query($query))
		{
			if ($row = $result->fetch_assoc()) return $row;
			$result->free();
			return -1;
		}
	}
?>