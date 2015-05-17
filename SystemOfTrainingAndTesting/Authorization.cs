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
        /// <param name="loginString">_in_ Имя пользователя</param>
        /// <param name="passwordString">_in_ Пароль</param>
        /// <param name="userString">_out_ Пользователь</param>
        /// <param name="userLevel">_out_ Уровень доступа пользователя</param>
        /// <returns></returns>
        internal static bool Auth(string loginString, string passwordString, out string userString, out int userLevel)
        {
            if (loginString.Equals("root") && passwordString.Equals("root"))
            {
                userString = "User: " + loginString + " (" + passwordString + ")";
                userLevel = 0;
                return true;
            }
            else if (loginString.Equals("user") && passwordString.Equals("user"))
            {
                userString = "User: " + loginString + " (" + passwordString + ")";
                userLevel = 1;
                return true;
            }
            else
            {
                userString = "Неверное имя пользователя или пароль";
                userLevel = 2;
                return false;
            }
        }
    }
}
