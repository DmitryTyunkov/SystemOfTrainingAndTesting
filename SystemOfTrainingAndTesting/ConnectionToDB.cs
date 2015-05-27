using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace SystemOfTrainingAndTesting
{
    /// <summary>
    /// Класс реализующий подключение и отключение от базы данных
    /// </summary>
    static class ConnectionToDB
    {
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        static string connectionString = "Server=192.168.1.3;Port=5432;User=postgres;Password=postgres;Database=vkrb;";
        static NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connectionString);
        /// <summary>
        /// Метод для подключения к базе данных
        /// </summary>
        /// <returns></returns>
        internal static NpgsqlConnection Connection()
        {
            try
            {
                npgsqlConnection.Open();
            }
            catch (Npgsql.NpgsqlException)
            {
                MessageBox.Show("Неудается подключиться к серверу базы данных!" + Environment.NewLine + "\tПовторите попытку позднее.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }
            return npgsqlConnection;
        }
        /// <summary>
        /// Метод для отключения от базы данных
        /// </summary>
        /// <returns></returns>
        internal static void Disconnection()
        {
            try
            {
                npgsqlConnection.Close();
            }
            catch (Npgsql.NpgsqlException)
            {
                MessageBox.Show("Неудается подключиться к серверу базы данных!" + Environment.NewLine + "\tПовторите попытку позднее.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }
        }
    }
}
