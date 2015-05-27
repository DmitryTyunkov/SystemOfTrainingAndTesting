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
    /// Класс реализующий поиск объектов в базе данных
    /// </summary>
    static class FindToDB
    {
        /// <summary>
        /// Метод для поиска пользователя в базе данных
        /// </summary>
        /// <param name="loginString">Имя пользователя</param>
        /// <param name="passwordString">Пароль</param>
        /// <returns></returns>
        internal static DbDataReader FindUser(string loginString, string passwordString)
        {
            NpgsqlConnection npgsqlConnection;
            npgsqlConnection = ConnectionToDB.Connection();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand(string.Format("SELECT * FROM users WHERE login = '{0}' AND password = '{1}'", loginString, passwordString), npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;
        }
        /// <summary>
        /// Метод для поиска тестов в базе данных
        /// </summary>
        internal static DbDataReader FindTests()
        {
            NpgsqlConnection npgsqlConnection;
            npgsqlConnection = ConnectionToDB.Connection();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand(string.Format("SELECT id, concat(title,'. ',description), number_of_questions FROM tests"), npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;
        }
    }
}
