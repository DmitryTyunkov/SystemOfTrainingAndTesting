using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemOfTrainingAndTesting
{
    /// <summary>
    /// Класс реализующий сохранение записей
    /// </summary>
    static class Insert
    {
        /// <summary>
        /// Метод для сохранения статистики пользователя
        /// </summary>
        /// <param name="idTest">Идентификатор теста</param>
        /// <param name="numberOfCorrectAnswer">Количество верных ответов</param>
        internal static void InsertStatistic(int idTest, int numberOfCorrectAnswer)
        {
            int insertCount = InsertIntoDb.InsertStatistic(Info.User.Id, idTest, numberOfCorrectAnswer);
            if (insertCount == 1)
            {
                ConnectionToDb.Disconnection();
                return;
            }
            ConnectionToDb.Disconnection();
            int updateCount = UpdateToDb.UpdateStatistics(Info.User.Id, idTest, numberOfCorrectAnswer);
            if (updateCount == 1)
            {
                ConnectionToDb.Disconnection();
                return;
            }
            ConnectionToDb.Disconnection();
            MessageBox.Show(@"Не удалось сохранить результат", @"Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
