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
                    UserInfo.Id = Convert.ToInt32(dbDataRecord["id"]);
                    UserInfo.Login = dbDataRecord["login"].ToString();
                    UserInfo.LastName = dbDataRecord["last_name"].ToString();
                    UserInfo.Name = dbDataRecord["name"].ToString();
                    UserInfo.MiddleName = dbDataRecord["middle_name"].ToString();
                    UserInfo.Post = dbDataRecord["post"].ToString();
                    UserInfo.Birthday = dbDataRecord["birthday"].ToString();
                    UserInfo.Level = Convert.ToInt32(dbDataRecord["level"]);
                    #endregion
                }
                ConnectionToDb.Disconnection();
                return true;
            }
            UserInfo.Level = 3;
            ConnectionToDb.Disconnection();
            return false;
        }

        /// <summary>
        /// Метод для выбора и сохраненния данных о тестах
        /// </summary>
        internal static void SelectTests()
        {
            #region Удаление старой информации о тестах
            TestsInfo.Id.Clear();
            TestsInfo.NumberOfQuestion.Clear();
            TestsInfo.TitleAndDescription.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectTests();
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации о тестах
                    TestsInfo.Id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    TestsInfo.NumberOfQuestion.Add(Convert.ToInt32(dbDataRecord["number_of_questions"]));
                    TestsInfo.TitleAndDescription.Add(dbDataRecord["concat"].ToString());
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
            QuestionsInfo.Id.Clear();
            QuestionsInfo.Question.Clear();
            QuestionsInfo.TypeAnswer.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectQuestions(idTest);
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации о вопросах
                    QuestionsInfo.Id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    QuestionsInfo.Question.Add(dbDataRecord["question"].ToString());
                    QuestionsInfo.TypeAnswer.Add(Convert.ToInt32(dbDataRecord["type_answer"]));
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
            AnswersInfo.Id.Clear();
            AnswersInfo.Answer.Clear();
            AnswersInfo.CorrectAnswer.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectAnswers(idQuestion);
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации об ответах
                    AnswersInfo.Id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    AnswersInfo.Answer.Add(dbDataRecord["answer"].ToString());
                    AnswersInfo.CorrectAnswer.Add(Convert.ToBoolean(dbDataRecord["correct_answer"]));
                    #endregion
                }
            }
            ConnectionToDb.Disconnection();
        }
    }
}
