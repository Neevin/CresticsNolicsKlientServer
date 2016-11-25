using System;
using System.Text.RegularExpressions;

namespace XO_Online
{
    class UserInformationComparator
    {
        private string login { get; set; }
        private string password { get; set; }
        public UserInformationComparator(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        public void compare()
        {
            if (login == "" || password == "") throw new Exception("Все поля должны быть заполнены!");

            //string regexp = "[select|insert|delete|drop|truncate|update]?|<//?[a-z0-9]*//?/>[a-z0-9]*/<//?[a-z0-9]*//?>";

            /*if (Regex.IsMatch(login, regexp)) throw new Exception("Логин содержит запрещенные данные!");
            if (Regex.IsMatch(password, regexp)) throw new Exception("Пароль содержит запрещенные данные!");*/
        }
    }
}
