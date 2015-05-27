using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace SystemOfTrainingAndTesting
{
    /// <summary>
    /// Класс реализующий поиск и вобор пользователя из базы данных
    /// </summary>
    static class FindUserToDB
    {
        /// <summary>
        /// Метод для выбора пользователя из базы данных
        /// </summary>
        /// <param name="loginString">Имя пользователя</param>
        /// <param name="passwordString">Пароль</param>
        /// <returns></returns>
        internal static bool SelectUser(string loginString, string passwordString)
        {
            NpgsqlConnection npgsqlConnection;
            npgsqlConnection = ConnectionToDB.Connection();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand(string.Format("SELECT * FROM users WHERE login = '{0}' AND password = '{1}'", loginString, passwordString),npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            if (npgsqlDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in npgsqlDataReader)
                {
                    UserInfo.login = dbDataRecord["login"].ToString();
                    UserInfo.lastName = dbDataRecord["last_name"].ToString();
                    UserInfo.name = dbDataRecord["name"].ToString();
                    UserInfo.middleName = dbDataRecord["middle_name"].ToString();
                    UserInfo.post = dbDataRecord["post"].ToString();
                    UserInfo.birthday = dbDataRecord["birthday"].ToString();
                    UserInfo.level = Convert.ToInt32(dbDataRecord["level"]);
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
    }
}
