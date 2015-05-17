using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfTrainingAndTesting
{
    static class Authorization
    {
        /// <summary>
        /// Метод для авторизации пользователя в системе
        /// </summary>
        /// <param name="loginString">Введенный логин пользователя</param>
        /// <param name="passwordString">Введенный пароль пользователя</param>
        internal static bool Auth(string loginString, string passwordString, out string userString)
        {
            if (loginString.Equals("root") && passwordString.Equals("root"))
            {
                userString = "User: " + loginString + " (" + passwordString + ")";
                return true;
            }
            else
            {
                userString = "Неверное имя пользователя или пароль";
                return false;
            }
        }
    }
}
