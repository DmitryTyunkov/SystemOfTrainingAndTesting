using System;
using System.Data.Common;

namespace SystemOfTrainingAndTesting
{
    /// <summary>
    /// Класс реализующий выбор и сохранение объектов
    /// </summary>
    static class Select
    {
        /// <summary>
        /// Метод для выбора и сохраненния данных пользователя
        /// </summary>
        /// <param name="loginString">Имя пользователя</param>
        /// <param name="passwordString">Пароль</param>
        /// <returns></returns>
        internal static bool SelectUser(string loginString, string passwordString)
        {
            DbDataReader dbDataReader = SelectFromDb.SelectUser(loginString, passwordString);
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации о пользователя
                    Info.User.Id = Convert.ToInt32(dbDataRecord["id"]);
                    Info.User.Login = dbDataRecord["login"].ToString();
                    Info.User.LastName = dbDataRecord["last_name"].ToString();
                    Info.User.Name = dbDataRecord["name"].ToString();
                    Info.User.MiddleName = dbDataRecord["middle_name"].ToString();
                    Info.User.Post = dbDataRecord["post"].ToString();
                    Info.User.Birthday = dbDataRecord["birthday"].ToString();
                    Info.User.Level = Convert.ToInt32(dbDataRecord["level"]);
                    #endregion
                }
                ConnectionToDb.Disconnection();
                return true;
            }
            Info.User.Level = 3;
            ConnectionToDb.Disconnection();
            return false;
        }

        /// <summary>
        /// Метод для выбора и сохраненния данных о тестах
        /// </summary>
        internal static void SelectTests()
        {
            #region Удаление старой информации о тестах
            Info.Tests.Id.Clear();
            Info.Tests.NumberOfQuestion.Clear();
            Info.Tests.TitleAndDescription.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectTests();
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации о тестах
                    Info.Tests.Id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    Info.Tests.NumberOfQuestion.Add(Convert.ToInt32(dbDataRecord["number_of_questions"]));
                    Info.Tests.TitleAndDescription.Add(dbDataRecord["concat"].ToString());
                    Info.Tests.Title.Add(dbDataRecord["title"].ToString());
                    #endregion
                }
            }
            ConnectionToDb.Disconnection();
        }

        /// <summary>
        /// Метод для выбора и сохраненния данных о вопросах
        /// </summary>
        /// <param name="idTest">Идентификатор теста</param>
        internal static void SelectQuestions(int idTest)
        {
            #region Удаление старой информации о вопросах
            Info.Questions.Id.Clear();
            Info.Questions.Question.Clear();
            Info.Questions.TypeAnswer.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectQuestions(idTest);
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации о вопросах
                    Info.Questions.Id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    Info.Questions.Question.Add(dbDataRecord["question"].ToString());
                    Info.Questions.TypeAnswer.Add(Convert.ToInt32(dbDataRecord["type_answer"]));
                    #endregion
                }
            }
            ConnectionToDb.Disconnection();
        }

        /// <summary>
        /// Метод для выбора и сохраненния данных об ответах
        /// </summary>
        /// <param name="idQuestion">Идентификатор вопроса</param>
        internal static void SelectAnswers(int idQuestion)
        {
            #region Удаление старой информации об ответах
            Info.Answers.Id.Clear();
            Info.Answers.Answer.Clear();
            Info.Answers.CorrectAnswer.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectAnswers(idQuestion);
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации об ответах
                    Info.Answers.Id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    Info.Answers.Answer.Add(dbDataRecord["answer"].ToString());
                    Info.Answers.CorrectAnswer.Add(Convert.ToBoolean(dbDataRecord["correct_answer"]));
                    #endregion
                }
            }
            ConnectionToDb.Disconnection();
        }

        /// <summary>
        /// Метод для выбора статистики пользователя
        /// </summary>
        internal static void SelectStatistics()
        {
            #region Удаление старой информации о статистике
            Info.Statistics.IdTest.Clear();
            Info.Statistics.NumberOfCorrectAnswer.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectStatistics(Info.User.Id);
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации об ответах
                    Info.Statistics.IdTest.Add(Convert.ToInt32(dbDataRecord["id_test"]));
                    Info.Statistics.NumberOfCorrectAnswer.Add(Convert.ToInt32(dbDataRecord["number_of_correct_answers"]));
                    #endregion
                }
            }
            ConnectionToDb.Disconnection();

        }
    }
}
