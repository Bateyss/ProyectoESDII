using LiteDB;

namespace ProyectoESDII.utils.DBLite
{
    internal class LiteDbContext
    {
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "litedb_aplication.db");

        public static LiteDatabase ObtenerBaseDeDatos()
        {
            return new LiteDatabase(dbPath);
        }

    }
}
