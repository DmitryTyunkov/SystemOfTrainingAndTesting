using System.Collections.Generic;

namespace SystemOfTrainingAndTesting
{
    /// <summary>
    /// Класс хранящий информацию о вопросах
    /// </summary>
    static class QuestionsInfo
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        internal static List<int> Id = new List<int>();

        /// <summary>
        /// Вопрос
        /// </summary>
        internal static List<string> Question = new List<string>();

        /// <summary>
        /// Тип ответа
        /// </summary>
        internal static List<int> TypeAnswer = new List<int>();
    }
}
