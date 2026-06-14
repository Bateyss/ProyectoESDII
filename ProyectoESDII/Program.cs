using ProyectoESDII.utils.DBLite;

namespace ProyectoESDII
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // iniciar base de datos
            //SQLiteDbContext.InicializarBaseDeDatos();


            Application.Run(new Form1());
        }
    }
}