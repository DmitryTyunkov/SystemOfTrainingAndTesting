using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfTrainingAndTesting
{
    /// <summary>
    /// Класс хранящий информацию об объектах
    /// </summary>
    static class Info
    {
        /// <summary>
        /// Структура для хранения информации о пользователе
        /// </summary>
        internal struct User
        {
            /// <summary>
            /// Фамилия
            /// </summary>
            internal static string LastName;

            /// <summary>
            /// Имя
            /// </summary>
            internal static string Name;

            /// <summary>
            /// Отчество
            /// </summary>
            internal static string MiddleName;

            /// <summary>
            /// День рождения
            /// </summary>
            internal static string Birthday;

            /// <summary>
            /// Имя пользователя
            /// </summary>
            internal static string Login;

            /// <summary>
            /// Должность
            /// </summary>
            internal static string Post;

            /// <summary>
            /// Уровень доступа
            /// </summary>
            internal static int Level;

            /// <summary>
            /// Идентификатор
            /// </summary>
            internal static int Id;
        }

        /// <summary>
        /// Структура для хранения информации о тестах
        /// </summary>
        internal struct Tests
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

        /// <summary>
        /// Структура для хранения информации о вопросах
        /// </summary>
        internal struct Questions
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

        /// <summary>
        /// Структура для хранения информации об ответах
        /// </summary>
        internal struct Answers
        {
            /// <summary>
            /// Идентификатор
            /// </summary>
            internal static List<int> Id = new List<int>();

            /// <summary>
            /// Ответ
            /// </summary>
            internal static List<string> Answer = new List<string>();

            /// <summary>
            /// Верный ли ответ
            /// </summary>
            internal static List<bool> CorrectAnswer = new List<bool>();

        }
    }
}
