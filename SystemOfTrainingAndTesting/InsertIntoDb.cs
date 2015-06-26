using System;
using Npgsql;

namespace SystemOfTrainingAndTesting
{
    /// <summary>
    /// Класс реализующий сохранение записей в базе данных
    /// </summary>
    static class InsertIntoDb
    {
        /// <summary>
        /// Метод для сохранения статистики пользователя в базе данных
        /// </summary>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <param name="idTest">Идентификатор теста</param>
        /// <param name="numberOfCorrectAnswer">Количество верных ответов</param>
        /// <returns></returns>
        internal static int InsertStatistic(int idUser, int idTest, int numberOfCorrectAnswer)
        {
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand(string.Format("INSERT INTO statistics(id_user, id_test, number_of_correct_answers) VALUES ({0}, {1}, {2})", idUser, idTest, numberOfCorrectAnswer), npgsqlConnection);
            int count;
            try
            {
                count = npgsqlCommand.ExecuteNonQuery();
            }
            catch (NotSupportedException)
            {
                count = 0;
            }
            return count;
        }

        /// <summary>
        /// Метод для сохранения статистики пользователя в базе данных
        /// </summary>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <param name="idEducationTest">Идентификатор теста</param>
        /// <param name="numberOfCorrectAnswer">Количество верных ответов</param>
        /// <returns></returns>
        internal static int InsertEducationStatistic(int idUser, int idEducationTest, int numberOfCorrectAnswer)
        {
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand(string.Format("INSERT INTO education_statistics(id_user, id_education_test, number_of_correct_answers) VALUES ({0}, {1}, {2})", idUser, idEducationTest, numberOfCorrectAnswer), npgsqlConnection);
            int count;
            try
            {
                count = npgsqlCommand.ExecuteNonQuery();
            }
            catch (NotSupportedException)
            {
                count = 0;
            }
            return count;
        }
    }
}
