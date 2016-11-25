<?php
	include 'model.php';
	
	header("Content-Type: text/html; Charset: utf-8;");	
	$parts = explode('/', $_SERVER['REDIRECT_URL']);
	
	switch($parts[1])
	{
		case "user":
		{
			$result = getUser($_POST['login'], $_POST['password']);//аутентификация
			//если такого юзера нет, то
			if ($result == 0)
			{
				//проверяем на ошибочность пароля
				$result = loginComparator($_POST['login'], $_POST['password']);
				//если пользователя действительно нет
				if ($result == 0)
				{
					$result = addUser($_POST['login'], $_POST['password']);
					if ($result == 0) $result = getUser($_POST['login'], $_POST['password']);
				}
				else //иначе пользователь неправильно ввел пароль или же хочет зарегистрироваться
				{
					$result = array("Issue" => 'Пользователь неверно ввел пароль, или же логин уже существует!');
				}
			}
			// проверяем, взломали ео или нет
			if ($result['isOnline'] == 1) $result = array("Issue" => 'Данный пользователь уже в сети. Возможно, Ваш профиль взломали!');
			else setUserOnline($_POST['login']);
			echo json_encode($result);
		} break;
		
		case "get_online_users":
		{
			$result = getOnlineUsers($_GET['login']);
			if ($result != 0) echo json_encode($result);
			else echo 0;
		} break;
		
		case "exit":
		{
			$result = setUserOffline($_GET['login']);
			if ($result == 0) echo "OK";
			else echo "ERROR";
		} break;
		
		case "message"://POST message?user_from=loginfrom&user_to=loginto&message=message
		{
			$result = sendMessage($_POST['user_from'], $_POST['user_to'], $_POST['message']);
			if ($result == 0) echo "OK";
			else echo "ERROR";
		} break;
		
		case "set_user_win"://POST set_user_win?login=login
		{
			$result = setUserWin($_GET['login']);
			if ($result == 0) echo "OK";
			else echo "ERROR";
		} break;
		
		case "set_user_louse"://POST set_user_louse?login=login
		{
			$result = setUserLouse($_GET['login']);
			if ($result == 0) echo "OK";
			else echo "ERROR";
		} break;
		
		case "get_messages"://GET get_messages?login=login
		{
			$result = getMessages($_GET['login']);
			if ($result != 0) echo json_encode($result);
			else echo 0;
			incrementReaders($_GET['login']);
			deleteMessages();
		} break;
		
		case "step": //GET step?login=login&step_id=1&game_id=23&x=2&y=1
		{
			$result = addStep($_GET['login'], $_GET['step_id'], $_GET['game_id'], $_GET['x'], $_GET['y']);
			if ($result == 0) echo "OK";
			else echo "ERROR";
		} break;
		
		case "get_last_step": //GET get_last_step?step_id=1&game_id=23
		{
			$result = getLastStep($_GET['step_id'], $_GET['game_id']);
			if ($result == 0) echo "AGAIN";
			else echo json_encode($result);
		} break;
		
		case "get_last_activity": //GET get_last_activity?login=login&time_now=00:00:00
		{
			$result = getLastActivity($_GET['login'], $_GET['time_now']);
			if ($result == -1 || $result == null) echo "ERROR";
			else echo $result['timediff'];
		} break;
		
		case "set_last_activity": //GET get_last_activity?login=login&time=00:00:00
		{
			$result = setLastActivity($_GET['login'], $_GET['time']);
			if ($result == 0) echo "OK";
			else echo "ERROR";
		} break;
		
		case "clear_steps": //GET clear_steps?game_id=23
		{
			$result = clearSteps($_GET['game_id']);
			if ($result == 0) echo "AGAIN";
			else echo "ERROR";
		} break;
		
		case "delete_game": //GET get_last_step?step_id=1&game_id=23
		{
			$result = deleteGame($_GET['game_id']);
			if ($result == 0) echo "OK";
			else echo "ERROR";
		} break;
		
		case "get_wait_users": //GET
		{
			$result = getWaitUsers(null);
			if ($result != 0) echo json_encode($result);
		} break;
		
		case "play_game": //GET play_game?game_id=23&login=login
		{
			$result = playGame($_GET['game_id'], $_GET['login']);
			if ($result == 0) echo "OK";
			else echo "ERROR";
		} break;
		
		case "set_user_wait"://GET set_user_wait?login=login
		{
			$result = compareRival($_GET['login']); //проверяем, заходил ли пользователь уже
			if ($result == 0) //если нет
			{
				$result = setUserWait($_GET['login']); //ставим его в ожидание противника
				if ($result == 0) echo "OK"; //если 0, то поставили
				else if ($result == -1) echo "ERROR"; // если -1, то что-то пошло не так
				else echo json_encode($result); // иначе пришел массив с данными противника
			}
			else // если мы приходим уже не первый раз, то проверяем, есть кто или нет
			{
				if ($result['secondPlayer'] == null) echo "AGAIN"; //если нет, то выводим сообщение о повторении запроса
				else echo json_encode($result); //иначе выводим данные противника 
			}
		} break;
		
		default: echo 'Server started!';
	}
	
?>