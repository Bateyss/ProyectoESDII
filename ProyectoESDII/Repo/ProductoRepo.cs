using ProyectoESDII.modelos;
using ProyectoESDII.utils.DBLite;

namespace ProyectoESDII.Repo
{
    internal class ProductoRepo
    {
        /// <summary>
        /// nombre de la tabla en el repo
        /// </summary>
        public static string REPO_ID = "PRODUCTOS";

        /// <summary>
        /// obtener productos de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Producto> List()
        {
            using (var db = LiteDbContext.ObtenerBaseDeDatos())
            {
                var coleccion = db.GetCollection<Producto>(REPO_ID);

                List<Producto> productos = coleccion.FindAll().ToList();
                return productos;
            }
        }

        /// <summary>
        /// guardar producto en la base de datos
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public Producto Guardar(Producto producto)
        {
            using (var db = LiteDbContext.ObtenerBaseDeDatos())
            {
                var coleccion = db.GetCollection<Producto>(REPO_ID);
                producto.Id = coleccion.Insert(producto);
                return producto;
            }
        }

        /// <summary>
        /// buscar productos de la base de datos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Producto FindById(int id)
        {
            using (var db = LiteDbContext.ObtenerBaseDeDatos())
            {
                var coleccion = db.GetCollection<Producto>(REPO_ID);

                Producto producto = coleccion.FindById(id);
                return producto;
            }
        }

        /// <summary>
        /// buscar productos de la base de datos por codigo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public Producto FindByCodigo(string codigo)
        {
            using (var db = LiteDbContext.ObtenerBaseDeDatos())
            {
                var coleccion = db.GetCollection<Producto>(REPO_ID);

                Producto producto = coleccion.FindOne(x => string.Compare(x.Codigo, codigo) == 0);
                return producto;
            }
        }

        /// <summary>
        /// limpiar base de datos de productos
        /// </summary>
        public void Limpiar()
        {
            using (var db = LiteDbContext.ObtenerBaseDeDatos())
            {
                var coleccion = db.GetCollection<Producto>(REPO_ID);

                coleccion.DeleteAll();

            }
        }

        /// <summary>
        /// eliminar un producto en la base de datos
        /// </summary>
        /// <param name="producto"></param>
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
