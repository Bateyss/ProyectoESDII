using Microsoft.Data.Sqlite;

namespace ProyectoESDII.utils.DBLite
{
    internal class SQLiteDbContext
    {
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sqlite_aplication.db");
        private static string connectionString = $"Data Soruce={dbPath}";

        public static void InicializarBaseDeDatos()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string queryTabla = @"CREATE TABLE IF NOT EXISTS Productos ("
+ "ID INTEGER PRIMARY KEY AUTOINCREMENT,"
+ "NOMBRE TEXT NOT NULL"
+ ");";

                using (var command = new SqliteCommand(queryTabla, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static SqliteConnection ObtenerConexion()
        {
            var connection = new SqliteConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
