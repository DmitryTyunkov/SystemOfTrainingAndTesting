using System;
using System.Collections.Generic;
using System.Data;

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
            internal static DateTime Birthday = new DateTime();

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

            /// <summary>
            /// Название
            /// </summary>
            internal static List<string> Title = new List<string>();

            /// <summary>
            /// Описание
            /// </summary>
            internal static List<string> Description = new List<string>(); 
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

        /// <summary>
        /// Структура для хранения информации о статистике
        /// </summary>
        internal struct Statistics
        {
            /// <summary>
            /// Идентификатор теста
            /// </summary>
            internal static List<int> IdTest = new List<int>();

            /// <summary>
            /// Количество верных ответов
            /// </summary>
            internal static List<int> NumberOfCorrectAnswer = new List<int>();
        }

        /// <summary>
        /// Структура для хранения информации о пользователях
        /// </summary>
        internal struct Users
        {
            /// <summary>
            /// Фамилия
            /// </summary>
            internal static List<string> LastName = new List<string>();

            /// <summary>
            /// Имя
            /// </summary>
            internal static List<string> Name = new List<string>();

            /// <summary>
            /// Отчество
            /// </summary>
            internal static List<string> MiddleName = new List<string>();

            /// <summary>
            /// День рождения
            /// </summary>
            internal static List<DateTime> Birthday = new List<DateTime>();
            
            /// <summary>
            /// Имя пользователя
            /// </summary>
            internal static List<string> Login = new List<string>();

            /// <summary>
            /// Должность
            /// </summary>
            internal static List<string> Post = new List<string>();

            /// <summary>
            /// Идентификатор
            /// </summary>
            internal static List<int> Id = new List<int>();
        }

        /// <summary>
        /// Структура для хранения информации о темах
        /// </summary>
        internal struct Themes
        {
            /// <summary>
            /// Идентификатор
            /// </summary>
            internal static List<int> Id = new List<int>();

            /// <summary>
            /// Название
            /// </summary>
            internal static List<string> Title = new List<string>();

            /// <summary>
            /// Описание
            /// </summary>
            internal static List<string> Description = new List<string>();

            /// <summary>
            /// Название и описание
            /// </summary>
            internal static List<string> TitleAndDescription = new List<string>();
        }

        /// <summary>
        /// Структура для обучающих тестов
        /// </summary>
        internal struct EducationTests
        {
            /// <summary>
            /// Идентифекатор
            /// </summary>
            internal static List<int> Id = new List<int>();

            /// <summary>
            /// Идентификатор темы
            /// </summary>
            internal static List<int> IdTheme = new List<int>(); 

            /// <summary>
            /// Название и описание
            /// </summary>
            internal static List<string> TitleAndDescription = new List<string>();

            /// <summary>
            /// Количество вопросов
            /// </summary>
            internal static List<int> NumberOfQuestion = new List<int>();

            /// <summary>
            /// Название
            /// </summary>
            internal static List<string> Title = new List<string>();

            /// <summary>
            /// Описание
            /// </summary>
            internal static List<string> Description = new List<string>(); 

        }

        /// <summary>
        /// Структура для инструкций
        /// </summary>
        internal struct Instructions
        {
            /// <summary>
            /// Идентификатор
            /// </summary>
            internal static List<int> Id = new List<int>();

            /// <summary>
            /// Идентификатор темы
            /// </summary>
            internal static List<int> IdTheme = new List<int>(); 

            /// <summary>
            /// Название
            /// </summary>
            internal static List<string> Title = new List<string>();

            /// <summary>
            /// Описание
            /// </summary>
            internal static List<string> Description = new List<string>();

            /// <summary>
            /// Ссылка
            /// </summary>
            internal static List<string> Link = new List<string>();

            /// <summary>
            /// Название и описание
            /// </summary>
            internal static List<string> TitleAndDescription = new List<string>();
        }

        /// <summary>
        /// Структура для хранения информации об обучающих вопросах
        /// </summary>
        internal struct EducationQuestions
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

            /// <summary>
            /// Описание верного ответа
            /// </summary>
            internal static List<string> DescriptionCorrectAnswer = new List<string>();
        }

        /// <summary>
        /// Структура для хранения информации об обучающих ответах
        /// </summary>
        internal struct EducationAnswers
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

        /// <summary>
        /// Структура для хранения информации о статистике обучения
        /// </summary>
        internal struct EducationStatistics
        {
            /// <summary>
            /// Идентификатор теста
            /// </summary>
            internal static List<int> IdTest = new List<int>();

            /// <summary>
            /// Количество верных ответов
            /// </summary>
            internal static List<int> NumberOfCorrectAnswer = new List<int>();
        }
    }
}
