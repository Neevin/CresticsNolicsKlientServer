using System;
using NUnit.Framework;
using XO_Online;

namespace XO.Test
{
    [TestFixture]
    public class ConnectionTest
    {
        [TestCase(new[]{"vasya", "password"}, new[]{"vasya", "-1"})] 
        [TestCase(new[] { "vasya", "password1" }, new[] { "Пользователь неверно ввел пароль, или же логин уже существует!" })] 
        [TestCase(new[] { "login", "password"}, new[]{"login", "0"})] 
        [Test]
        public void testEnter(string[] userInfo, string[] result)
        {
            string[] test_result = Connection.signup(userInfo[0], userInfo[1]);
            Assert.AreEqual(test_result, result);
            Connection.exit(userInfo[0]);
        }
    }
}
