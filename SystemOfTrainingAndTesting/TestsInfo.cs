using System.Collections.Generic;

namespace SystemOfTrainingAndTesting
{
    /// <summary>
    /// Класс хранящий информацию о тестах
    /// </summary>
    static class TestsInfo
    {
        /// <summary>
        /// Идентифекатор
        /// </summary>
        internal static List<int> Id = new List<int>();

        /// <summary>
        /// Название и описание
        /// </summary>
        internal static List<string> TitleAndDescription = new List<string>();

        /// <summary>
        /// Количество вопросов
        /// </summary>
        internal static List<int> NumberOfQuestion = new List<int>();
    }
}
