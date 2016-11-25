using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Drawing;
using XO_Online.Properties;

namespace XO_Online
{
    public partial class mainForm : Form
    {
        string[] userInfo = new string[2], rivalInfo;
        JArray online_users = new JArray(), wait_users = new JArray();
        Timer generalTimer, waitTimer, gameTimer;
        bool stepPriority;
        string[,] fieldPaper = new string[3, 3];
        int gameId, timer = 60, stepId = 1;
        int[] myStep;
        string myLogo, rivalLogo;
        Panel waitPanel;
        PictureBox waitImage;
        Label waitLabel;
        public mainForm()
        {
            InitializeComponent();

            passwordTB.PasswordChar = '*';

            chatList.Enabled = false;
            messageTB.Enabled = false;
            choisePanel.Enabled = false;
            timerPanel.Visible = false;

            playField.Enabled = false;
            foreach (Button b in playField.Controls)
            {
                b.Text = "";
                b.Enabled = true;
            }

            if (File.Exists("cookie.bin"))
            {
                StreamReader reader = new StreamReader("cookie.bin");
                loginTB.Text = reader.ReadLine();
                userInfo[0] = loginTB.Text;
                passwordTB.Text = reader.ReadLine();
                userInfo[1] = passwordTB.Text;
                reader.Dispose();
            }
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            UserInformationComparator uifConparator = new UserInformationComparator(loginTB.Text, passwordTB.Text);
            try
            {
                uifConparator.compare();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return;
            }
            userInfo = Connection.signup(loginTB.Text, passwordTB.Text);
            if (userInfo[0].CompareTo(loginTB.Text) != 0)
            {
                MessageBox.Show(userInfo[0]);
            }
            else
            {
                if (remember.Checked)
                {
                    StreamWriter writer = new StreamWriter("cookie.bin");
                    writer.WriteLine(loginTB.Text);
                    writer.WriteLine(passwordTB.Text);
                    writer.Dispose();
                }
                playerLoginLabel.Text = "Пользователь: " + userInfo[0];
                playerCountOfWinsLabel.Text = "Количество побед: " + userInfo[1];
                this.Controls.Remove(enterPanel);

                chatList.Enabled = true;
                messageTB.Enabled = true;
                choisePanel.Enabled = true;

                generalTimer = new Timer();
                generalTimer.Interval = 2000;
                generalTimer.Tick += generalTimer_Tick;
                generalTimer.Start();
            }
        }

        void waitTimer_Tick(object sender, EventArgs e)
        {
            //долбим сервер в ожидании противника
            string response = Connection.setUserWait(userInfo[0]);
            if (response.CompareTo("OK") != 0 && response.CompareTo("AGAIN") != 0 && response.CompareTo("ERROR") != 0)
            {
                waitTimer.Stop();
                rivalInfo = new string[2];
                dynamic jsonObj = JObject.Parse(response);
                if (jsonObj.firstPlayer == null) // если мы первые
                {
                    rivalInfo[0] = jsonObj.secondPlayer;

                    foreach (dynamic jobj in online_users)
                    {
                        if (rivalInfo[0].CompareTo((string)jobj.login) == 0)
                        {
                            rivalInfo[1] = jobj.countOfWins;
                            break;
                        }
                    }
                    myLogo = "X";
                    rivalLogo = "O";
                    stepPriority = true;
                    priorityLabel.Text = "Ваш ход...";
                }
                else // если мы вторые
                {
                    rivalInfo[0] = jsonObj.firstPlayer;
                    foreach (dynamic jobj in online_users)
                    {
                        if (rivalInfo[0].CompareTo((string)jobj.login) == 0)
                        {
                            rivalInfo[1] = jobj.countOfWins;
                            break;
                        }
                    }
                    myLogo = "O";
                    rivalLogo = "X";
                    stepPriority = false;
                    priorityLabel.Text = "Ход противника...";
                }
                this.Controls.Remove(waitPanel);
                timerPanel.Visible = true;
                playField.Enabled = stepPriority;
                rivalLoginLabel.Text = "Противник: " + rivalInfo[0];
                rivalCountOfWinsLabel.Text = "Количество побед: " + rivalInfo[1];
                gameId = jsonObj.id;

                gameTimer = new Timer();
                gameTimer.Interval = 1000;
                gameTimer.Tick += gameTimer_Tick;
                gameTimer.Start();
            }
        }

        void gameTimer_Tick(object sender, EventArgs e)
        {
            if (timer > 0)
            {
                if (stepPriority)//если наша очередь
                {
                    if (myStep != null)//если мы только что походили
                    {
                        fieldPaper[myStep[0], myStep[1]] = myLogo;
                        myStep = null;

                        if (stepId >= 5)
                        {
                            if (Gameplay.isWin(fieldPaper, rivalLogo)) //если противник выйграл
                            {
                                gameTimer.Stop();
                                Connection.setUserLouse(userInfo[0]);
                                foreach (Button b in playField.Controls)
                                {
                                    b.Text = "";
                                    b.Enabled = true;
                                }
                                playField.Enabled = false;
                                if (MessageBox.Show("Вы проиграли! Сыграть еще раз?", "Поражение!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    Connection.clearSteps(gameId);
                                    stepId = 0;
                                    waitTimer = new Timer();
                                    waitTimer.Interval = 1000;
                                    waitTimer.Tick += waitTimer_Tick;
                                    waitTimer.Start();
                                }
                                else
                                {
                                    timerPanel.Visible = false;
                                    Connection.clearSteps(gameId);
                                    Connection.deleteGame(gameId);
                                    stepId = 0;
                                    playField.Enabled = false;
                                    fieldPaper = new string[3, 3];
                                    choisePanel.Visible = true;
                                    waitUsersList.Enabled = true;
                                }
                            }
                            else if (Gameplay.isWin(fieldPaper, myLogo)) //если мы выйграли
                            {
                                gameTimer.Stop();
                                Connection.setUserWin(userInfo[0]);
                                foreach (Button b in playField.Controls)
                                {
                                    b.Text = "";
                                    b.Enabled = true;
                                }
                                playField.Enabled = false;
                                if (MessageBox.Show("Вы выйграли! Сыграть еще раз?", "Победа!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    Connection.clearSteps(gameId);
                                    stepId = 0;
                                    waitTimer = new Timer();
                                    waitTimer.Interval = 1000;
                                    waitTimer.Tick += waitTimer_Tick;
                                    waitTimer.Start();
                                }
                                else
                                {
                                    timerPanel.Visible = false;
                                    Connection.clearSteps(gameId);
                                    Connection.deleteGame(gameId);
                                    stepId = 0;
                                    playField.Enabled = false;
                                    fieldPaper = new string[3, 3];
                                    choisePanel.Visible = true;
                                    waitUsersList.Enabled = true;
                                }
                            }
                            else if (stepId >= 9)
                            {
                                gameTimer.Stop();
                                foreach (Button b in playField.Controls)
                                {
                                    b.Text = "";
                                    b.Enabled = true;
                                }
                                playField.Enabled = false;
                                if (MessageBox.Show("Ничья! Сыграть еще раз?", "Ничья!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    Connection.clearSteps(gameId);
                                    stepId = 0;
                                    waitTimer = new Timer();
                                    waitTimer.Interval = 1000;
                                    waitTimer.Tick += waitTimer_Tick;
                                    waitTimer.Start();
                                }
                                else
                                {
                                    timerPanel.Visible = false;
                                    Connection.clearSteps(gameId);
                                    Connection.deleteGame(gameId);
                                    stepId = 0;
                                    timerPanel.Visible = false;
                                    playField.Enabled = false;
                                    fieldPaper = new string[3, 3];
                                    choisePanel.Visible = true;
                                    waitUsersList.Enabled = true;
                                }
                            }
                        }
                        stepPriority = false;
                        playField.Enabled = false;
                        stepId++;
                        timer = 60;
                        priorityLabel.Text = "Ход противника...";
                    }
                }
                else // если была не наша очередь и мы ждем хода противника
                {
                    
                    int[] rivalStep = Connection.getLastStep(stepId, gameId);
                    if (rivalStep != null)
                    {
                        fieldPaper[rivalStep[0], rivalStep[1]] = rivalLogo;
                        foreach (Button b in playField.Controls)
                        {
                            if (b.Name.CompareTo("b"+rivalStep[0]+""+rivalStep[1]) == 0)
                            {
                                b.Text = rivalLogo;
                                b.Enabled = false;
                                break;
                            }
                        }

                        if (stepId >= 5)
                        {
                            if (Gameplay.isWin(fieldPaper, rivalLogo)) //если противник выйграл
                            {
                                gameTimer.Stop();
                                Connection.setUserLouse(userInfo[0]);
                                foreach (Button b in playField.Controls)
                                {
                                    b.Text = "";
                                    b.Enabled = true;
                                }
                                playField.Enabled = false;
                                if (MessageBox.Show("Вы проиграли! Сыграть еще раз?", "Поражение!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    Connection.clearSteps(gameId);
                                    stepId = 0;
                                    waitTimer = new Timer();
                                    waitTimer.Interval = 1000;
                                    waitTimer.Tick += waitTimer_Tick;
                                    waitTimer.Start();
                                }
                                else
                                {
                                    timerPanel.Visible = false;
                                    Connection.clearSteps(gameId);
                                    Connection.deleteGame(gameId);
                                    stepId = 0;
                                    playField.Enabled = false;
                                    fieldPaper = new string[3, 3];
                                    choisePanel.Visible = true;
                                    waitUsersList.Enabled = true;
                                }
                            }
                            else if (Gameplay.isWin(fieldPaper, myLogo)) //если мы выйграли
                            {
                                gameTimer.Stop();
                                Connection.setUserWin(userInfo[0]);
                                foreach (Button b in playField.Controls)
                                {
                                    b.Text = "";
                                    b.Enabled = true;
                                }
                                playField.Enabled = false;
                                if (MessageBox.Show("Вы выйграли! Сыграть еще раз?", "Победа!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    Connection.clearSteps(gameId);
                                    stepId = 0;
                                    waitTimer = new Timer();
                                    waitTimer.Interval = 1000;
                                    waitTimer.Tick += waitTimer_Tick;
                                    waitTimer.Start();
                                }
                                else
                                {
                                    timerPanel.Visible = false;
                                    Connection.clearSteps(gameId);
                                    Connection.deleteGame(gameId);
                                    stepId = 0;
                                    playField.Enabled = false;
                                    fieldPaper = new string[3, 3];
                                    choisePanel.Visible = true;
                                    waitUsersList.Enabled = true;
                                }
                            }
                            else if (stepId >= 9)
                            {
                                gameTimer.Stop();
                                foreach (Button b in playField.Controls)
                                {
                                    b.Text = "";
                                    b.Enabled = true;
                                }
                                playField.Enabled = false;
                                if (MessageBox.Show("Ничья! Сыграть еще раз?", "Ничья!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    Connection.clearSteps(gameId);
                                    stepId = 0;
                                    waitTimer = new Timer();
                                    waitTimer.Interval = 1000;
                                    waitTimer.Tick += waitTimer_Tick;
                                    waitTimer.Start();
                                }
                                else
                                {
                                    timerPanel.Visible = false;
                                    Connection.clearSteps(gameId);
                                    Connection.deleteGame(gameId);
                                    stepId = 0;
                                    timerPanel.Visible = false;
                                    playField.Enabled = false;
                                    fieldPaper = new string[3, 3];
                                    choisePanel.Visible = true;
                                    waitUsersList.Enabled = true;
                                }
                            }
                        }
                        stepPriority = true;
                        playField.Enabled = true;
                        stepId++;
                        timer = 60;
                        priorityLabel.Text = "Ваш ход...";
                    }
                }
            }
            else
            {
                gameTimer.Stop();
                if (stepPriority)//если мы не походили
                {
                    Connection.setUserLouse(userInfo[0]);
                    MessageBox.Show("Нужно следить за временем!", "Техническое поражение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // если не походил противник, тут 2 случая: или противник просто замешкался, либо он отключился....
                {
                    string timediff = Connection.getLastActivity(rivalInfo[0], DateTime.Now.ToString("HH:mm:ss"));
                    string[] timearray = timediff.Split(':');
                    if (int.Parse(timearray[0]) > 0 || int.Parse(timearray[1]) > 0 || int.Parse(timearray[2]) > 10) Connection.setUserLouse(userInfo[0]);
                    //если юзер вылетел, то поражение сам себе он уже не поставит,... делаем это за него
                    Connection.setUserWin(userInfo[0]);
                    MessageBox.Show("Вы выйграли!", "Техническая победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                userInfo[1] = (int.Parse(userInfo[1]) - 1).ToString();
                playerCountOfWinsLabel.Text = "Количество побед: " + userInfo[1];
                timerPanel.Visible = false;
            }
            timer--;
            if (timer < 10) timerLabel.Text = "00:0" + timer;
            else timerLabel.Text = "00:" + timer;
        }

        void generalTimer_Tick(object sender, EventArgs e)
        {
            /*долбим сервер каждые 2 секунды для обновления инфы на форме*/
            online_users = Connection.getOnlineUsers(userInfo[0]);
            onlineUsersList.Items.Clear();
            foreach (dynamic jobj in online_users) onlineUsersList.Items.Add(jobj.login + " / " + jobj.countOfWins);

            wait_users = Connection.getWaitUsers();
            waitUsersList.Items.Clear();
            foreach (dynamic jobj in wait_users) waitUsersList.Items.Add(jobj.firstPlayer + " / " + jobj.countOfWins);

            bool reload = false;
            string messages = Connection.getMessages(userInfo[0]);
            if (messages != null)
            {
                try
                {
                    foreach (dynamic jobj in JArray.Parse(messages))
                    {
                        reload = false;
                        foreach (string item in chatList.Items)
                        {
                            if (item.CompareTo("Приватное от [" + jobj.userFrom + "]: " + jobj.message) == 0 || item.CompareTo("[" + jobj.userFrom + "]: " + jobj.message) == 0)
                            {
                                reload = true;
                                break;
                            }
                        }
                        if (reload) continue;
                        if (("all").CompareTo((string)jobj.userTo) != 0) chatList.Items.Add("Приватное от [" + jobj.userFrom + "]: " + jobj.message);
                        else chatList.Items.Add("[" + jobj.userFrom + "]: " + jobj.message);
                    }
                }
                catch
                {
                    reload = false;
                    dynamic jobj = JObject.Parse(messages);
                    foreach (string item in chatList.Items)
                    {
                        if (item.CompareTo("Приватное от [" + jobj.userFrom + "]: " + jobj.message) == 0 || item.CompareTo("[" + jobj.userFrom + "]: " + jobj.message) == 0)
                        {
                            reload = true;
                            break;
                        }
                    }
                    if (!reload)
                    {
                        if (("all").CompareTo((string)jobj.userTo) != 0) chatList.Items.Add("Приватное от [" + jobj.userFrom + "]: " + jobj.message);
                        else chatList.Items.Add("[" + jobj.userFrom + "]: " + jobj.message);
                    }
                }
            }
            Connection.setLastActivity(userInfo[0], DateTime.Now.ToString("HH:mm:ss"));
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Connection.exit(userInfo[0]);
                generalTimer.Stop();
                waitTimer.Stop();
                gameTimer.Stop();
            }
            catch
            {

            }
        }

        private void field_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            myStep = new int[2];
            myStep[0] = int.Parse(((Button)sender).Name[1].ToString());
            myStep[1] = int.Parse(((Button)sender).Name[2].ToString());
            Connection.step(userInfo[0], stepId, gameId, myStep[0], myStep[1]);
            ((Button)sender).Text = myLogo;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (messageTB.Text == "") return;
            string regexp = "^([0-9a-zA-Zа-яА-Я-_]*):(.*)$";
            if (Regex.IsMatch(messageTB.Text, regexp))
            {
                MatchCollection collection = Regex.Matches(messageTB.Text, regexp);
                Connection.sendMessage(userInfo[0], collection[0].Groups[1].Value, collection[0].Groups[2].Value);
            }
            else Connection.sendMessage(userInfo[0], "all", messageTB.Text);
            messageTB.Text = "";
        }

        private void randomChoise_Click(object sender, EventArgs e)
        {
            waitLabel = new Label();
            waitLabel.AutoSize = true;
            waitLabel.Location = new Point(31, 3);
            waitLabel.Size = new Size(126, 13);
            waitLabel.Text = "Ожидаем противника...";

            waitImage = new PictureBox();
            waitImage.Image = Resources.download;
            waitImage.Location = new Point(3, 19);
            waitImage.Size = new Size(172, 115);
            waitImage.SizeMode = PictureBoxSizeMode.Zoom;
            waitImage.TabStop = false;

            waitPanel = new Panel();
            waitPanel.Controls.Add(waitLabel);
            waitPanel.Controls.Add(waitImage);
            waitPanel.Location = new Point(333, 76);
            waitPanel.Size = new Size(178, 137);

            choisePanel.Visible = false;
            this.Controls.Add(waitPanel);
            waitUsersList.Enabled = false;

            waitTimer = new Timer();
            waitTimer.Interval = 1000;
            waitTimer.Tick += waitTimer_Tick;
            waitTimer.Start();
        }

        private void waitUsersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (dynamic jobj in wait_users)
            {
                if (waitUsersList.SelectedItem.ToString().CompareTo((string)(jobj.firstPlayer + " / " + jobj.countOfWins)) == 0)
                {
                    gameId = int.Parse((string)jobj.gameId);
                    rivalInfo = new string[2];
                    rivalInfo[0] = (string)jobj.firstPlayer;
                    rivalInfo[1] = (string)jobj.countOfWins;
                    break;
                }
            }
            Connection.playGame(gameId, rivalInfo[0]);
            myLogo = "O";
            rivalLogo = "X";
            priorityLabel.Text = "Ход противника...";
            timer = 60;
            stepPriority = false;
            choisePanel.Visible = false;
            timerPanel.Visible = true;
            waitUsersList.Enabled = false;
            gameTimer = new Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Start();
        }
    }
}