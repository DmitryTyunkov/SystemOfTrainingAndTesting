using System;
using System.Windows.Forms;
using Npgsql;

namespace SystemOfTrainingAndTesting
{
    /// <summary>
    /// Класс реализующий подключение и отключение от базы данных
    /// </summary>
    static class ConnectionToDb
    {
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        private const string ConnectionString = "Server=192.168.1.3;Port=5432;User=postgres;Password=postgres;Database=data;";

        static readonly NpgsqlConnection NpgsqlConnection = new NpgsqlConnection(ConnectionString);
        
        /// <summary>
        /// Метод для подключения к базе данных
        /// </summary>
        /// <returns></returns>
        internal static NpgsqlConnection Connection()
        {
            try
            {
                NpgsqlConnection.Open();
            }
            catch (NpgsqlException)
            {
                MessageBox.Show(@"Неудается подключиться к серверу базы данных!" + Environment.NewLine + @"	Повторите попытку позднее.", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            return NpgsqlConnection;
        }

        /// <summary>
        /// Метод для отключения от базы данных
        /// </summary>
        /// <returns></returns>
        internal static void Disconnection()
        {
            try
            {
                NpgsqlConnection.Close();
            }
            catch (NpgsqlException)
            {
                MessageBox.Show(@"Неудается подключиться к серверу базы данных!" + Environment.NewLine + @" Повторите попытку позднее.", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }
    }
}
