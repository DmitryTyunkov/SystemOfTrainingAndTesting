using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        internal static List<int> id = new List<int>();
        /// <summary>
        /// Вопрос
        /// </summary>
        internal static List<string> question = new List<string>();
        /// <summary>
        /// Тип ответа
        /// </summary>
        internal static List<int> typeAnswer = new List<int>();
    }
}
