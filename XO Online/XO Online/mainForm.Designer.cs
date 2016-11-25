namespace XO_Online
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playerPanel = new System.Windows.Forms.Panel();
            this.playerCountOfWinsLabel = new System.Windows.Forms.Label();
            this.playerLoginLabel = new System.Windows.Forms.Label();
            this.playField = new System.Windows.Forms.Panel();
            this.b22 = new System.Windows.Forms.Button();
            this.b01 = new System.Windows.Forms.Button();
            this.b12 = new System.Windows.Forms.Button();
            this.b11 = new System.Windows.Forms.Button();
            this.b02 = new System.Windows.Forms.Button();
            this.b21 = new System.Windows.Forms.Button();
            this.b20 = new System.Windows.Forms.Button();
            this.b10 = new System.Windows.Forms.Button();
            this.b00 = new System.Windows.Forms.Button();
            this.rivalPanel = new System.Windows.Forms.Panel();
            this.rivalCountOfWinsLabel = new System.Windows.Forms.Label();
            this.rivalLoginLabel = new System.Windows.Forms.Label();
            this.onlineUsersList = new System.Windows.Forms.ListBox();
            this.chatList = new System.Windows.Forms.ListBox();
            this.messageTB = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.enterPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.enterButton = new System.Windows.Forms.Button();
            this.remember = new System.Windows.Forms.CheckBox();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.loginTB = new System.Windows.Forms.TextBox();
            this.choisePanel = new System.Windows.Forms.Panel();
            this.timerLabel = new System.Windows.Forms.Label();
            this.priorityLabel = new System.Windows.Forms.Label();
            this.timerPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.waitUsersList = new System.Windows.Forms.ListBox();
            this.randomChoise = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.playerPanel.SuspendLayout();
            this.playField.SuspendLayout();
            this.rivalPanel.SuspendLayout();
            this.enterPanel.SuspendLayout();
            this.choisePanel.SuspendLayout();
            this.timerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerPanel
            // 
            this.playerPanel.Controls.Add(this.playerCountOfWinsLabel);
            this.playerPanel.Controls.Add(this.playerLoginLabel);
            this.playerPanel.Location = new System.Drawing.Point(12, 12);
            this.playerPanel.Name = "playerPanel";
            this.playerPanel.Size = new System.Drawing.Size(179, 60);
            this.playerPanel.TabIndex = 0;
            // 
            // playerCountOfWinsLabel
            // 
            this.playerCountOfWinsLabel.AutoSize = true;
            this.playerCountOfWinsLabel.Location = new System.Drawing.Point(3, 32);
            this.playerCountOfWinsLabel.Name = "playerCountOfWinsLabel";
            this.playerCountOfWinsLabel.Size = new System.Drawing.Size(102, 13);
            this.playerCountOfWinsLabel.TabIndex = 1;
            this.playerCountOfWinsLabel.Text = "Количество побед:";
            // 
            // playerLoginLabel
            // 
            this.playerLoginLabel.AutoSize = true;
            this.playerLoginLabel.Location = new System.Drawing.Point(3, 9);
            this.playerLoginLabel.Name = "playerLoginLabel";
            this.playerLoginLabel.Size = new System.Drawing.Size(83, 13);
            this.playerLoginLabel.TabIndex = 0;
            this.playerLoginLabel.Text = "Пользователь:";
            // 
            // playField
            // 
            this.playField.Controls.Add(this.b22);
            this.playField.Controls.Add(this.b01);
            this.playField.Controls.Add(this.b12);
            this.playField.Controls.Add(this.b11);
            this.playField.Controls.Add(this.b02);
            this.playField.Controls.Add(this.b21);
            this.playField.Controls.Add(this.b20);
            this.playField.Controls.Add(this.b10);
            this.playField.Controls.Add(this.b00);
            this.playField.Location = new System.Drawing.Point(192, 76);
            this.playField.Name = "playField";
            this.playField.Size = new System.Drawing.Size(139, 137);
            this.playField.TabIndex = 1;
            // 
            // b22
            // 
            this.b22.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b22.Location = new System.Drawing.Point(95, 93);
            this.b22.Name = "b22";
            this.b22.Size = new System.Drawing.Size(40, 40);
            this.b22.TabIndex = 4;
            this.b22.Text = "X";
            this.b22.UseVisualStyleBackColor = false;
            this.b22.Click += new System.EventHandler(this.field_Click);
            // 
            // b01
            // 
            this.b01.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b01.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b01.Location = new System.Drawing.Point(3, 49);
            this.b01.Name = "b01";
            this.b01.Size = new System.Drawing.Size(40, 40);
            this.b01.TabIndex = 5;
            this.b01.Text = "O";
            this.b01.UseVisualStyleBackColor = false;
            this.b01.Click += new System.EventHandler(this.field_Click);
            // 
            // b12
            // 
            this.b12.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b12.Location = new System.Drawing.Point(49, 93);
            this.b12.Name = "b12";
            this.b12.Size = new System.Drawing.Size(40, 40);
            this.b12.TabIndex = 3;
            this.b12.Text = "O";
            this.b12.UseVisualStyleBackColor = false;
            this.b12.Click += new System.EventHandler(this.field_Click);
            // 
            // b11
            // 
            this.b11.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b11.Location = new System.Drawing.Point(49, 49);
            this.b11.Name = "b11";
            this.b11.Size = new System.Drawing.Size(40, 40);
            this.b11.TabIndex = 4;
            this.b11.Text = "X";
            this.b11.UseVisualStyleBackColor = false;
            this.b11.Click += new System.EventHandler(this.field_Click);
            // 
            // b02
            // 
            this.b02.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b02.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b02.Location = new System.Drawing.Point(3, 93);
            this.b02.Name = "b02";
            this.b02.Size = new System.Drawing.Size(40, 40);
            this.b02.TabIndex = 2;
            this.b02.Text = "X";
            this.b02.UseVisualStyleBackColor = false;
            this.b02.Click += new System.EventHandler(this.field_Click);
            // 
            // b21
            // 
            this.b21.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b21.Location = new System.Drawing.Point(95, 49);
            this.b21.Name = "b21";
            this.b21.Size = new System.Drawing.Size(40, 40);
            this.b21.TabIndex = 3;
            this.b21.Text = "O";
            this.b21.UseVisualStyleBackColor = false;
            this.b21.Click += new System.EventHandler(this.field_Click);
            // 
            // b20
            // 
            this.b20.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b20.Location = new System.Drawing.Point(95, 3);
            this.b20.Name = "b20";
            this.b20.Size = new System.Drawing.Size(40, 40);
            this.b20.TabIndex = 2;
            this.b20.Text = "X";
            this.b20.UseVisualStyleBackColor = false;
            this.b20.Click += new System.EventHandler(this.field_Click);
            // 
            // b10
            // 
            this.b10.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b10.Location = new System.Drawing.Point(49, 3);
            this.b10.Name = "b10";
            this.b10.Size = new System.Drawing.Size(40, 40);
            this.b10.TabIndex = 1;
            this.b10.Text = "O";
            this.b10.UseVisualStyleBackColor = false;
            this.b10.Click += new System.EventHandler(this.field_Click);
            // 
            // b00
            // 
            this.b00.BackColor = System.Drawing.SystemColors.ControlDark;
            this.b00.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b00.Location = new System.Drawing.Point(3, 3);
            this.b00.Name = "b00";
            this.b00.Size = new System.Drawing.Size(40, 40);
            this.b00.TabIndex = 0;
            this.b00.Text = "X";
            this.b00.UseVisualStyleBackColor = false;
            this.b00.Click += new System.EventHandler(this.field_Click);
            // 
            // rivalPanel
            // 
            this.rivalPanel.Controls.Add(this.rivalCountOfWinsLabel);
            this.rivalPanel.Controls.Add(this.rivalLoginLabel);
            this.rivalPanel.Location = new System.Drawing.Point(332, 12);
            this.rivalPanel.Name = "rivalPanel";
            this.rivalPanel.Size = new System.Drawing.Size(179, 60);
            this.rivalPanel.TabIndex = 2;
            // 
            // rivalCountOfWinsLabel
            // 
            this.rivalCountOfWinsLabel.AutoSize = true;
            this.rivalCountOfWinsLabel.Location = new System.Drawing.Point(3, 32);
            this.rivalCountOfWinsLabel.Name = "rivalCountOfWinsLabel";
            this.rivalCountOfWinsLabel.Size = new System.Drawing.Size(102, 13);
            this.rivalCountOfWinsLabel.TabIndex = 1;
            this.rivalCountOfWinsLabel.Text = "Количество побед:";
            // 
            // rivalLoginLabel
            // 
            this.rivalLoginLabel.AutoSize = true;
            this.rivalLoginLabel.Location = new System.Drawing.Point(3, 9);
            this.rivalLoginLabel.Name = "rivalLoginLabel";
            this.rivalLoginLabel.Size = new System.Drawing.Size(65, 13);
            this.rivalLoginLabel.TabIndex = 0;
            this.rivalLoginLabel.Text = "Противник:";
            // 
            // onlineUsersList
            // 
            this.onlineUsersList.FormattingEnabled = true;
            this.onlineUsersList.Location = new System.Drawing.Point(517, 32);
            this.onlineUsersList.Name = "onlineUsersList";
            this.onlineUsersList.Size = new System.Drawing.Size(120, 160);
            this.onlineUsersList.TabIndex = 3;
            // 
            // chatList
            // 
            this.chatList.FormattingEnabled = true;
            this.chatList.Location = new System.Drawing.Point(12, 216);
            this.chatList.Name = "chatList";
            this.chatList.Size = new System.Drawing.Size(499, 121);
            this.chatList.TabIndex = 4;
            // 
            // messageTB
            // 
            this.messageTB.Location = new System.Drawing.Point(12, 340);
            this.messageTB.Name = "messageTB";
            this.messageTB.Size = new System.Drawing.Size(413, 20);
            this.messageTB.TabIndex = 5;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(431, 338);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(80, 23);
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(537, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Сейчас в сети";
            // 
            // enterPanel
            // 
            this.enterPanel.BackColor = System.Drawing.Color.RosyBrown;
            this.enterPanel.Controls.Add(this.label6);
            this.enterPanel.Controls.Add(this.label3);
            this.enterPanel.Controls.Add(this.label2);
            this.enterPanel.Controls.Add(this.enterButton);
            this.enterPanel.Controls.Add(this.remember);
            this.enterPanel.Controls.Add(this.passwordTB);
            this.enterPanel.Controls.Add(this.loginTB);
            this.enterPanel.Location = new System.Drawing.Point(12, 76);
            this.enterPanel.Name = "enterPanel";
            this.enterPanel.Size = new System.Drawing.Size(179, 137);
            this.enterPanel.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Зарегистрируйтесь или войдите";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Логин:";
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(6, 110);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(170, 23);
            this.enterButton.TabIndex = 3;
            this.enterButton.Text = "Играть";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // remember
            // 
            this.remember.AutoSize = true;
            this.remember.Location = new System.Drawing.Point(52, 87);
            this.remember.Name = "remember";
            this.remember.Size = new System.Drawing.Size(82, 17);
            this.remember.TabIndex = 2;
            this.remember.Text = "Запомнить";
            this.remember.UseVisualStyleBackColor = true;
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(52, 61);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(122, 20);
            this.passwordTB.TabIndex = 1;
            // 
            // loginTB
            // 
            this.loginTB.Location = new System.Drawing.Point(52, 35);
            this.loginTB.Name = "loginTB";
            this.loginTB.Size = new System.Drawing.Size(122, 20);
            this.loginTB.TabIndex = 0;
            // 
            // choisePanel
            // 
            this.choisePanel.Controls.Add(this.label4);
            this.choisePanel.Controls.Add(this.randomChoise);
            this.choisePanel.Location = new System.Drawing.Point(333, 76);
            this.choisePanel.Name = "choisePanel";
            this.choisePanel.Size = new System.Drawing.Size(178, 137);
            this.choisePanel.TabIndex = 9;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(49, 9);
            this.timerLabel.MinimumSize = new System.Drawing.Size(40, 0);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(40, 13);
            this.timerLabel.TabIndex = 10;
            this.timerLabel.Text = "00:59";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // priorityLabel
            // 
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Location = new System.Drawing.Point(28, 32);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(25, 13);
            this.priorityLabel.TabIndex = 11;
            this.priorityLabel.Text = "      ";
            // 
            // timerPanel
            // 
            this.timerPanel.Controls.Add(this.timerLabel);
            this.timerPanel.Controls.Add(this.priorityLabel);
            this.timerPanel.Location = new System.Drawing.Point(192, 12);
            this.timerPanel.Name = "timerPanel";
            this.timerPanel.Size = new System.Drawing.Size(139, 60);
            this.timerPanel.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(528, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Ждут противника";
            // 
            // waitUsersList
            // 
            this.waitUsersList.FormattingEnabled = true;
            this.waitUsersList.Location = new System.Drawing.Point(517, 213);
            this.waitUsersList.Name = "waitUsersList";
            this.waitUsersList.Size = new System.Drawing.Size(120, 147);
            this.waitUsersList.TabIndex = 14;
            this.waitUsersList.SelectedIndexChanged += new System.EventHandler(this.waitUsersList_SelectedIndexChanged);
            // 
            // randomChoise
            // 
            this.randomChoise.Location = new System.Drawing.Point(5, 61);
            this.randomChoise.Name = "randomChoise";
            this.randomChoise.Size = new System.Drawing.Size(170, 43);
            this.randomChoise.TabIndex = 0;
            this.randomChoise.Text = "Выбрать случайного игрока";
            this.randomChoise.UseVisualStyleBackColor = true;
            this.randomChoise.Click += new System.EventHandler(this.randomChoise_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 39);
            this.label4.TabIndex = 1;
            this.label4.Text = "Выберите противника\r\nиз списка ждущих\r\nили воспользуйтесь функцией";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(12, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(411, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "P.S.: чтобы отправить приватное сообщение, введите в формате login: message";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 388);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.waitUsersList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.timerPanel);
            this.Controls.Add(this.choisePanel);
            this.Controls.Add(this.enterPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageTB);
            this.Controls.Add(this.chatList);
            this.Controls.Add(this.onlineUsersList);
            this.Controls.Add(this.rivalPanel);
            this.Controls.Add(this.playField);
            this.Controls.Add(this.playerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Крестики-нолики Online";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.playerPanel.ResumeLayout(false);
            this.playerPanel.PerformLayout();
            this.playField.ResumeLayout(false);
            this.rivalPanel.ResumeLayout(false);
            this.rivalPanel.PerformLayout();
            this.enterPanel.ResumeLayout(false);
            this.enterPanel.PerformLayout();
            this.choisePanel.ResumeLayout(false);
            this.choisePanel.PerformLayout();
            this.timerPanel.ResumeLayout(false);
            this.timerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel playerPanel;
        private System.Windows.Forms.Label playerCountOfWinsLabel;
        private System.Windows.Forms.Label playerLoginLabel;
        private System.Windows.Forms.Panel playField;
        private System.Windows.Forms.Button b22;
        private System.Windows.Forms.Button b01;
        private System.Windows.Forms.Button b12;
        private System.Windows.Forms.Button b11;
        private System.Windows.Forms.Button b02;
        private System.Windows.Forms.Button b21;
        private System.Windows.Forms.Button b20;
        private System.Windows.Forms.Button b10;
        private System.Windows.Forms.Button b00;
        private System.Windows.Forms.Panel rivalPanel;
        private System.Windows.Forms.Label rivalCountOfWinsLabel;
        private System.Windows.Forms.Label rivalLoginLabel;
        private System.Windows.Forms.ListBox onlineUsersList;
        private System.Windows.Forms.ListBox chatList;
        private System.Windows.Forms.TextBox messageTB;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel enterPanel;
        private System.Windows.Forms.Panel choisePanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.CheckBox remember;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.TextBox loginTB;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label priorityLabel;
        private System.Windows.Forms.Panel timerPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox waitUsersList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button randomChoise;
        private System.Windows.Forms.Label label7;
    }
}

