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
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
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
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id, title, description, concat(title,'. ',description), number_of_questions FROM tests"),
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
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
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
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id, answer, correct_answer FROM answers WHERE id_question = {0}", idQuestion),
                    npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;
        }

        /// <summary>
        /// Метод для выбора статистики пользователя из базы данных
        /// </summary>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns></returns>
        internal static DbDataReader SelectStatistics(int idUser)
        {
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id_test, number_of_correct_answers FROM statistics WHERE id_user = {0}", idUser),
                    npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;

        }

        /// <summary>
        /// Метод для выбора пользователей из базы данных
        /// </summary>
        /// <returns></returns>
        internal static DbDataReader SelectUsers()
        {
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id, login, name, middle_name, last_name, birthday, post FROM users"), npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;
        }

        /// <summary>
        /// Метод для выбора тем из базы данных
        /// </summary>
        /// <returns></returns>
        internal static DbDataReader SelectThemes()
        {
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id, title, description, concat(title,'. ',description) FROM themes"), npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;
        }

        /// <summary>
        /// Метод для выбора обучающих тестов из базы данных
        /// </summary>
        /// <returns></returns>
        internal static DbDataReader SelectEducationTests()
        {
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id, id_theme, title, description, concat(title,'. ',description), number_of_questions FROM education_tests"),
                    npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;
        }

        /// <summary>
        /// Метод для выбора инструкций из базы данных
        /// </summary>
        /// <returns></returns>
        internal static DbDataReader SelectInstruction()
        {
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id, title, description, id_theme, link FROM instructions"),
                    npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;

        }

        /// <summary>
        /// Метод для выбора обучающих тестов из базы данных
        /// </summary>
        /// <param name="idTheme">Идентификатор темы</param>
        /// <returns></returns>
        internal static DbDataReader SelectEducationTests(int idTheme)
        {
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id, title, description, concat(title,'. ',description), number_of_questions FROM education_tests WHERE id_theme={0}",idTheme),
                    npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;
        }

        /// <summary>
        /// Метод для выбора инструкций из базы данных
        /// </summary>
        /// <returns></returns>
        internal static DbDataReader SelectInstruction(int idTheme)
        {
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id, title, description, link, concat(title,'. ',description) FROM instructions WHERE id_theme={0}", idTheme),
                    npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;

        }

        /// <summary>
        /// Метод для выбора обучающих вопросов в базе данных
        /// </summary>
        /// <param name="idEducationTest">Идентификатор обучающего теста</param>
        /// <returns></returns>
        internal static DbDataReader SelectEducationQuestions(int idEducationTest)
        {
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id, question, description_correct_answer, type_answer FROM education_questions WHERE id_education_test = {0}", idEducationTest),
                    npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;
        }

        /// <summary>
        /// Метод для выбора обучающих ответов в базе данных
        /// </summary>
        /// <param name="idEducationQuestion">Идентификатор ответа</param>
        /// <returns></returns>
        internal static DbDataReader SelectEducationAnswers(int idEducationQuestion)
        {
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id, answer, correct_answer FROM education_answers WHERE id_education_question = {0}", idEducationQuestion),
                    npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;
        }

        /// <summary>
        /// Метод для выбора статистики обучения пользователя из базы данных
        /// </summary>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns></returns>
        internal static DbDataReader SelectEducationStatistics(int idUser)
        {
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand =
                new NpgsqlCommand(
                    string.Format("SELECT id_education_test, number_of_correct_answers FROM education_statistics WHERE id_user = {0}", idUser),
                    npgsqlConnection);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            DbDataReader dbDataReader = npgsqlDataReader;
            return dbDataReader;
        }
    }
}
