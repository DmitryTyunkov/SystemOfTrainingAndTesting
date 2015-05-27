using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        internal static List<int> id = new List<int>();
        /// <summary>
        /// Название и описание
        /// </summary>
        internal static List<string> titleAndDescription = new List<string>();
        /// <summary>
        /// Количество вопросов
        /// </summary>
        internal static List<int> numberOfQuestion = new List<int>();
    }
}
