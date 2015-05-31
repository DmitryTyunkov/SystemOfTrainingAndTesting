using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SystemOfTrainingAndTesting
{
    /// <summary>
    /// Класс реализующий обновление записей в базе данных
    /// </summary>
    static class UpdateToDb
    {
        /// <summary>
        /// Метод для обновления записи о статистике пользователя
        /// </summary>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <param name="idTest">Идентификатор теста</param>
        /// <param name="numberOfCorrectAnswer">Количество верных ответов</param>
        /// <returns></returns>
        internal static int UpdateStatistics(int idUser, int idTest, int numberOfCorrectAnswer)
        {
            NpgsqlConnection npgsqlConnection = ConnectionToDb.Connection();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand(string.Format("UPDATE statistics SET number_of_correct_answers = {2} WHERE id_user = {0} AND id_test = {1}", idUser, idTest, numberOfCorrectAnswer), npgsqlConnection);
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
