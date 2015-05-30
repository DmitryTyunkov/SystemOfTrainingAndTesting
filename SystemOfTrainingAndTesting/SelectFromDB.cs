using System.Data.Common;
using Npgsql;

namespace SystemOfTrainingAndTesting
{
    /// <summary>
    /// Класс реализующий поиск объектов в базе данных
    /// </summary>
    static class SelectFromDb
    {
        /// <summary>
        /// Метод для выбора пользователя в базе данных
        /// </summary>
        /// <param name="loginString">Имя пользователя</param>
        /// <param name="passwordString">Пароль</param>
        /// <returns></returns>
        internal static DbDataReader SelectUser(string loginString, string passwordString)
        {
            NpgsqlConnection npgsqlConnection;
            npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT * FROM users WHERE login = '{0}' AND password = '{1}'", loginString,
                        passwordString), npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;
        }

        /// <summary>
        /// Метод для выбора тестов в базе данных
        /// </summary>
        internal static DbDataReader SelectTests()
        {
            NpgsqlConnection npgsqlConnection;
            npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id, concat(title,'. ',description), number_of_questions FROM tests"),
                    npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;
        }

        /// <summary>
        /// Метод для выбора вопросов в базе данных
        /// </summary>
        /// <param name="idTest">Идентификатор теста</param>
        /// <returns></returns>
        internal static DbDataReader SelectQuestions(int idTest)
        {
            NpgsqlConnection npgsqlConnection;
            npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id, question, type_answer FROM questions WHERE id_test = {0}", idTest),
                    npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;
        }

        /// <summary>
        /// Метод для выбора ответов в базе данных
        /// </summary>
        /// <param name="idQuestion">Идентификатор ответа</param>
        /// <returns></returns>
        internal static DbDataReader SelectAnswers(int idQuestion)
        {
            NpgsqlConnection npgsqlConnection;
            npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id, answer, correct_answer FROM answers WHERE id_question = {0}", idQuestion),
                    npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;
        }
    }
}
