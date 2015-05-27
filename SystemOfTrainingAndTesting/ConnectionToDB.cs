using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SystemOfTrainingAndTesting
{
    /// <summary>
    /// Класс реализующий подключение и отключение от базы данных
    /// </summary>
    static class ConnectionToDB
    {
        static string connectionString = "Server=localhost;Port=5432;User=postgres;Password=postgres;Database=vkrb;";
        static NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connectionString);
        /// <summary>
        /// Метод для подключения к базе данных
        /// </summary>
        /// <returns></returns>
        internal static NpgsqlConnection Connection()
        {
            npgsqlConnection.Open();
            return npgsqlConnection;
        }
        /// <summary>
        /// Метод для отключения от базы данных
        /// </summary>
        /// <returns></returns>
        internal static void Disconnection()
        {
            npgsqlConnection.Close();
        }
    }
}
