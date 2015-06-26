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
                    Info.User.Birthday = Convert.ToDateTime(dbDataRecord["birthday"]);
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
            Info.Tests.Description.Clear();
            Info.Tests.Title.Clear();
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
                    Info.Tests.Description.Add(dbDataRecord["description"].ToString());
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

        /// <summary>
        /// Метод для выбора пользователей
        /// </summary>
        internal static void SelectUsers()
        {
            #region Удаление старой информации о статистике
            Info.Users.Birthday.Clear();
            Info.Users.Id.Clear();
            Info.Users.LastName.Clear();
            Info.Users.Login.Clear();
            Info.Users.MiddleName.Clear();
            Info.Users.Name.Clear();
            Info.Users.Post.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectUsers();
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации об ответах
                    Info.Users.Birthday.Add(Convert.ToDateTime(dbDataRecord["birthday"]));
                    Info.Users.Id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    Info.Users.LastName.Add(dbDataRecord["last_name"].ToString());
                    Info.Users.Login.Add(dbDataRecord["login"].ToString());
                    Info.Users.MiddleName.Add(dbDataRecord["middle_name"].ToString());
                    Info.Users.Name.Add(dbDataRecord["name"].ToString());
                    Info.Users.Post.Add(dbDataRecord["post"].ToString());
                    #endregion
                }
            }
            ConnectionToDb.Disconnection();
        }

        /// <summary>
        /// Метод для выбора тем
        /// </summary>
        internal static void SelectThemes()
        {
            #region Удаление старой информации о статистике
            Info.Themes.Id.Clear();
            Info.Themes.Title.Clear();
            Info.Themes.Description.Clear();
            Info.Themes.TitleAndDescription.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectThemes();
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации об ответах
                    Info.Themes.Id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    Info.Themes.Title.Add(dbDataRecord["title"].ToString());
                    Info.Themes.Description.Add(dbDataRecord["description"].ToString());
                    Info.Themes.TitleAndDescription.Add(dbDataRecord["concat"].ToString());
                    #endregion
                }
            }
            ConnectionToDb.Disconnection();
        }

        /// <summary>
        /// Метод для выбора обучающих тестов
        /// </summary>
        internal static void SelectEducationTests()
        {
            #region Удаление старой информации о тестах
            Info.EducationTests.Id.Clear();
            Info.EducationTests.NumberOfQuestion.Clear();
            Info.EducationTests.TitleAndDescription.Clear();
            Info.EducationTests.Description.Clear();
            Info.EducationTests.IdTheme.Clear();
            Info.EducationTests.Title.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectEducationTests();
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации о тестах
                    Info.EducationTests.Id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    Info.EducationTests.NumberOfQuestion.Add(Convert.ToInt32(dbDataRecord["number_of_questions"]));
                    Info.EducationTests.TitleAndDescription.Add(dbDataRecord["concat"].ToString());
                    Info.EducationTests.Description.Add(dbDataRecord["description"].ToString());
                    Info.EducationTests.IdTheme.Add(Convert.ToInt32(dbDataRecord["id_theme"]));
                    Info.EducationTests.Title.Add(dbDataRecord["title"].ToString());
                    #endregion
                }
            }
            ConnectionToDb.Disconnection();
        }

        /// <summary>
        /// Метод для выбора инструкций
        /// </summary>
        internal static void SelectInstructions()
        {
            #region Удаление старой информации о тестах
            Info.Instructions.Id.Clear();
            Info.Instructions.Link.Clear();
            Info.Instructions.Description.Clear();
            Info.Instructions.IdTheme.Clear();
            Info.Instructions.Title.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectInstruction();
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации о тестах
                    Info.Instructions.Id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    Info.Instructions.Link.Add(dbDataRecord["link"].ToString());
                    Info.Instructions.Description.Add(dbDataRecord["description"].ToString());
                    Info.Instructions.IdTheme.Add(Convert.ToInt32(dbDataRecord["id_theme"]));
                    Info.Instructions.Title.Add(dbDataRecord["title"].ToString());
                    #endregion
                }
            }
            ConnectionToDb.Disconnection();
        }

        /// <summary>
        /// Метод для выбора обучающих тестов
        /// </summary>
        internal static void SelectEducationTests(int idTheme)
        {
            #region Удаление старой информации о тестах
            Info.EducationTests.Id.Clear();
            Info.EducationTests.NumberOfQuestion.Clear();
            Info.EducationTests.TitleAndDescription.Clear();
            Info.EducationTests.Description.Clear();
            Info.EducationTests.IdTheme.Clear();
            Info.EducationTests.Title.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectEducationTests(idTheme);
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации о тестах
                    Info.EducationTests.Id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    Info.EducationTests.NumberOfQuestion.Add(Convert.ToInt32(dbDataRecord["number_of_questions"]));
                    Info.EducationTests.TitleAndDescription.Add(dbDataRecord["concat"].ToString());
                    Info.EducationTests.Description.Add(dbDataRecord["description"].ToString());
                    Info.EducationTests.IdTheme.Add(idTheme);
                    Info.EducationTests.Title.Add(dbDataRecord["title"].ToString());
                    #endregion
                }
            }
            ConnectionToDb.Disconnection();
        }

        /// <summary>
        /// Метод для выбора инструкций
        /// </summary>
        internal static void SelectInstructions(int idTheme)
        {
            #region Удаление старой информации о тестах
            Info.Instructions.Id.Clear();
            Info.Instructions.Link.Clear();
            Info.Instructions.Description.Clear();
            Info.Instructions.IdTheme.Clear();
            Info.Instructions.Title.Clear();
            Info.Instructions.TitleAndDescription.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectInstruction(idTheme);
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации о тестах
                    Info.Instructions.Id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    Info.Instructions.Link.Add(dbDataRecord["link"].ToString());
                    Info.Instructions.Description.Add(dbDataRecord["description"].ToString());
                    Info.Instructions.IdTheme.Add(idTheme);
                    Info.Instructions.Title.Add(dbDataRecord["title"].ToString());
                    Info.Instructions.TitleAndDescription.Add(dbDataRecord["concat"].ToString());
                    #endregion
                }
            }
            ConnectionToDb.Disconnection();
        }

        /// <summary>
        /// Метод для выбора и сохраненния данных об обучающих вопросах
        /// </summary>
        /// <param name="idEducationTest">Идентификатор теста</param>
        internal static void SelectEducationQuestions(int idEducationTest)
        {
            #region Удаление старой информации о вопросах
            Info.EducationQuestions.Id.Clear();
            Info.EducationQuestions.Question.Clear();
            Info.EducationQuestions.TypeAnswer.Clear();
            Info.EducationQuestions.DescriptionCorrectAnswer.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectEducationQuestions(idEducationTest);
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации о вопросах
                    Info.EducationQuestions.Id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    Info.EducationQuestions.Question.Add(dbDataRecord["question"].ToString());
                    Info.EducationQuestions.TypeAnswer.Add(Convert.ToInt32(dbDataRecord["type_answer"]));
                    Info.EducationQuestions.DescriptionCorrectAnswer.Add(dbDataRecord["description_correct_answer"].ToString());
                    #endregion
                }
            }
            ConnectionToDb.Disconnection();
        }

        /// <summary>
        /// Метод для выбора и сохраненния данных об обучающих ответах
        /// </summary>
        /// <param name="idEducationQuestion">Идентификатор вопроса</param>
        internal static void SelectEducationAnswers(int idEducationQuestion)
        {
            #region Удаление старой информации об ответах
            Info.EducationAnswers.Id.Clear();
            Info.EducationAnswers.Answer.Clear();
            Info.EducationAnswers.CorrectAnswer.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectEducationAnswers(idEducationQuestion);
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации об ответах
                    Info.EducationAnswers.Id.Add(Convert.ToInt32(dbDataRecord["id"]));
                    Info.EducationAnswers.Answer.Add(dbDataRecord["answer"].ToString());
                    Info.EducationAnswers.CorrectAnswer.Add(Convert.ToBoolean(dbDataRecord["correct_answer"]));
                    #endregion
                }
            }
            ConnectionToDb.Disconnection();
        }

        /// <summary>
        /// Метод для выбора статистики обучения пользователя
        /// </summary>
        internal static void SelectEducationStatistics()
        {
            #region Удаление старой информации о статистике
            Info.EducationStatistics.IdTest.Clear();
            Info.EducationStatistics.NumberOfCorrectAnswer.Clear();
            #endregion
            DbDataReader dbDataReader = SelectFromDb.SelectEducationStatistics(Info.User.Id);
            if (dbDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in dbDataReader)
                {
                    #region Сохранение информации об ответах
                    Info.EducationStatistics.IdTest.Add(Convert.ToInt32(dbDataRecord["id_education_test"]));
                    Info.EducationStatistics.NumberOfCorrectAnswer.Add(Convert.ToInt32(dbDataRecord["number_of_correct_answers"]));
                    #endregion
                }
            }
            ConnectionToDb.Disconnection();
        }
    }
}
