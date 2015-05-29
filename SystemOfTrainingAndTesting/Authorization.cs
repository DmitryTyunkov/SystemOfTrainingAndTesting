using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfTrainingAndTesting
{
    /// <summary>
    /// Класс реализующий авторизацию пользователя
    /// </summary>
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
        internal static bool Auth(string loginString, string passwordString, out string userString)
        {
            if (Find.FindUser(loginString.Trim().ToLower(), passwordString.Trim()))
            {
                userString = UserInfo.login + " (" + UserInfo.lastName + " " + UserInfo.name.Substring(0, 1) + ". " + UserInfo.middleName.Substring(0, 1) + ".)";
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
