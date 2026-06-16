using Microsoft.Data.Sqlite;

namespace ProyectoESDII.utils.DBLite
{
    internal class SQLiteDbContext
    {
        /// <summary>
        /// lugar donde se guarda la base de datos
        /// </summary>
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sqlite_aplication.db");
        private static string connectionString = $"Data Soruce={dbPath}";

        /// <summary>
        /// iniciar base de datos, no es una conexion, es un servicio
        /// </summary>
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

        /// <summary>
        /// iniciar conexion con el servicio
        /// </summary>
        /// <returns></returns>
        public static SqliteConnection ObtenerConexion()
        {
            var connection = new SqliteConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
