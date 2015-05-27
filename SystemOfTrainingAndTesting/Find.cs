using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfTrainingAndTesting
{
    /// <summary>
    /// Класс реализующий поиск и сохранение объектов
    /// </summary>
    static class Find
    {
        /// <summary>
        /// Метод для поиска пользователя
        /// </summary>
        /// <param name="loginString">Имя пользователя</param>
        /// <param name="passwordString">Пароль</param>
        /// <returns></returns>
        internal static bool FindUser(string loginString, string passwordString)
        {
            DbDataReader dbDataReader = FindToDB.FindUser(loginString, passwordString);
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации о пользователя
                    UserInfo.login = dbDataRecord["login"].ToString();
                    UserInfo.lastName = dbDataRecord["last_name"].ToString();
                    UserInfo.name = dbDataRecord["name"].ToString();
                    UserInfo.middleName = dbDataRecord["middle_name"].ToString();
                    UserInfo.post = dbDataRecord["post"].ToString();
                    UserInfo.birthday = dbDataRecord["birthday"].ToString();
                    UserInfo.level = Convert.ToInt32(dbDataRecord["level"]);
                    #endregion
                }
                ConnectionToDB.Disconnection();
                return true;
            }
            else
            {
                UserInfo.level = 3;
                ConnectionToDB.Disconnection();
                return false;
            }
        }
        /// <summary>
        /// Метод для поиска тестов
        /// </summary>
        internal static void FindTests()
        {
            DbDataReader dbDataReader = FindToDB.FindTests();
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации о тестах
                    TestsInfo.id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    TestsInfo.numberOfQuestion.Add(Convert.ToInt32(dbDataRecord["number_of_questions"]));
                    TestsInfo.titleAndDescription.Add(dbDataRecord["concat"].ToString());
                    #endregion
                }
            }
            ConnectionToDB.Disconnection();
        }
    }
}
