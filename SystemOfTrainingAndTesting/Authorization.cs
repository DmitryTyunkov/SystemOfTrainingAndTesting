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
        /// <returns></returns>
        internal static bool Auth(string loginString, string passwordString, out string userString)
        {
            if (Select.SelectUser(loginString.Trim().ToLower(), passwordString.Trim()))
            {
                userString = UserInfo.Login + " (" + UserInfo.LastName + " " + UserInfo.Name.Substring(0, 1) + ". " + UserInfo.MiddleName.Substring(0, 1) + ".)";
                return true;
            }
            userString = "Неверное имя пользователя или пароль";
            return false;
        }
    }
}
