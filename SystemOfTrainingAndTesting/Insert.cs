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

        /// <summary>
        /// Метод для сохранения статистики обучения пользователя
        /// </summary>
        /// <param name="idEducationTest">Идентификатор обучающего теста</param>
        /// <param name="numberOfCorrectAnswer">Количество верных ответов</param>
        internal static void InsertEducationStatistic(int idEducationTest, int numberOfCorrectAnswer)
        {
            int insertCount = InsertIntoDb.InsertEducationStatistic(Info.User.Id, idEducationTest, numberOfCorrectAnswer);
            if (insertCount == 1)
            {
                ConnectionToDb.Disconnection();
                return;
            }
            ConnectionToDb.Disconnection();
            int updateCount = UpdateToDb.UpdateEducationStatistics(Info.User.Id, idEducationTest, numberOfCorrectAnswer);
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
