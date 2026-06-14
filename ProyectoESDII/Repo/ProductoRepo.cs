using ProyectoESDII.modelos;
using ProyectoESDII.utils.DBLite;

namespace ProyectoESDII.Repo
{
    internal class ProductoRepo
    {

        public static string REPO_ID = "PRODUCTOS";

        public List<Producto> List()
        {
            using (var db = LiteDbContext.ObtenerBaseDeDatos())
            {
                var coleccion = db.GetCollection<Producto>(REPO_ID);

                List<Producto> productos = coleccion.FindAll().ToList();
                return productos;
            }
        }

        public Producto Guardar(Producto producto)
        {
            using (var db = LiteDbContext.ObtenerBaseDeDatos())
            {
                var coleccion = db.GetCollection<Producto>(REPO_ID);
                producto.Id = coleccion.Insert(producto);
                return producto;
            }
        }

        public Producto FindById(int id)
        {
            using (var db = LiteDbContext.ObtenerBaseDeDatos())
            {
                var coleccion = db.GetCollection<Producto>(REPO_ID);

                Producto producto = coleccion.FindById(id);
                return producto;
            }
        }

        public Producto FindByCodigo(string codigo)
        {
            using (var db = LiteDbContext.ObtenerBaseDeDatos())
            {
                var coleccion = db.GetCollection<Producto>(REPO_ID);

                Producto producto = coleccion.FindOne(x => string.Compare(x.Codigo, codigo) == 0);
                return producto;
            }
        }

        public void Limpiar() {
            using (var db = LiteDbContext.ObtenerBaseDeDatos())
            {
                var coleccion = db.GetCollection<Producto>(REPO_ID);

                coleccion.DeleteAll();

            }
        }

        public void Eliminar(Producto producto)
        {
            using (var db = LiteDbContext.ObtenerBaseDeDatos())
            {
                var coleccion = db.GetCollection<Producto>(REPO_ID);
                coleccion.Delete(producto.Id);
            }
        }
    }
}
