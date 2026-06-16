using LiteDB;

namespace ProyectoESDII.utils.DBLite
{
    internal class LiteDbContext
    {
        /// <summary>
        /// ubicacion de la base de datos,
        /// si no existe la crea
        /// </summary>
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "litedb_aplication.db");

        /// <summary>
        /// acceder al servicio de base de datos.
        /// </summary>
        /// <returns></returns>
        public static LiteDatabase ObtenerBaseDeDatos()
        {
            return new LiteDatabase(dbPath);
        }

    }
}
