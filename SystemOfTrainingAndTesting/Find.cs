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
            #region Удаление старой информации о тестах
            TestsInfo.id.Clear();
            TestsInfo.numberOfQuestion.Clear();
            TestsInfo.titleAndDescription.Clear();
            #endregion
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
        /// <summary>
        /// Метод для поиска вопросов
        /// </summary>
        /// <param name="idTest">Идентификатор теста</param>
        internal static void FindQuestions(int idTest)
        {
            #region Удаление старой информации о вопросах
            QuestionsInfo.id.Clear();
            QuestionsInfo.question.Clear();
            QuestionsInfo.typeAnswer.Clear();
            #endregion
            DbDataReader dbDataReader = FindToDB.FindQuestions(idTest);
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации о вопросах
                    QuestionsInfo.id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    QuestionsInfo.question.Add(dbDataRecord["question"].ToString());
                    QuestionsInfo.typeAnswer.Add(Convert.ToInt32(dbDataRecord["type_answer"]));
                    #endregion
                }
            }
            ConnectionToDB.Disconnection();
        }
        /// <summary>
        /// Метод для поиска ответов
        /// </summary>
        /// <param name="idQuestion">Идентификатор вопроса</param>
        internal static void FindAnswers(int idQuestion)
        {
            #region Удаление старой информации об ответах
            AnswersInfo.id.Clear();
            AnswersInfo.answer.Clear();
            AnswersInfo.correctAnswer.Clear();
            #endregion
            DbDataReader dbDataReader = FindToDB.FindAnswers(idQuestion);
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации об ответах
                    AnswersInfo.id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    AnswersInfo.answer.Add(dbDataRecord["answer"].ToString());
                    AnswersInfo.correctAnswer.Add(Convert.ToBoolean(dbDataRecord["correct_answer"]));
                    #endregion
                }
            }
            ConnectionToDB.Disconnection();
        }

    }
}
