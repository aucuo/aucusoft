using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDB.Database
{
    internal class DatabaseManager
    {
        private static MySqlConnection connection;
        private static string connectionString;
        private static string server = "127.0.0.2";
        private static string port = "3306";
        private static string database = "university";
        private static string userId = "root";
        private static string password = "";

        public DatabaseManager()
        {
            connectionString = $"server={server};port={port};user={userId};database={database};password={password};";
            connection = new MySqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query, List<MySqlParameter> parameters = null)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных ({database}): {ex.Message}");
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return dataTable;
        }
    }
}
