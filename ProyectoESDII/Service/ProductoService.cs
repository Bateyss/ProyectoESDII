using ProyectoESDII.modelos;
using ProyectoESDII.Repo;
using ProyectoESDII.utils.ABPlus;
using ProyectoESDII.utils.AVL;
using ProyectoESDII.utils.Hash;
using System.Text;

namespace ProyectoESDII.Service
{
    internal class ProductoService
    {

        /// <summary>
        /// repositorio de base de datos
        /// </summary>
        ProductoRepo repo = new ProductoRepo();

        /// <summary>
        /// objeto para crear numero y texto random.
        /// se usara para generar productos
        /// </summary>
        Random random = new Random();
        string caracteresRandom = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        /// <summary>
        /// arbol B+
        /// </summary>
        ABPlusTree aBPlusTree = new ABPlusTree();
        /// <summary>
        /// arbol AVL
        /// </summary>
        AVLTree aVLTree = new AVLTree();

        /// <summary>
        /// tabla hash
        /// </summary>
        HashTable hashTable;

        public ProductoService()
        {
            ComprobarStructuras();
        }

        /// <summary>
        /// obtener productos almacenados en la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Producto> ObtenerProductos()
        {
            List<Producto> productos = repo.List();
            return productos;
        }

        /// <summary>
        /// genera prpductos con textos y numeros random,
        /// la cantidad depende de cuantas se solicite en pantalla
        /// </summary>
        /// <param name="cantidad"></param>
        /// <returns>listado de productos generados</returns>
        public List<Producto> GenerarProductos(int cantidad)
        {
            if (hashTable == null) hashTable = new HashTable(cantidad);

            List<Producto> productos = repo.List();
            for (int i = 0; i < cantidad; i++)
            {
                Producto producto = new Producto();
                producto.Nombre = TextoRandom("Prod_", 6);
                producto.Codigo = TextoRandom("P", 5);
                producto.Categoria = TextoRandom("Cat_", 4);
                producto.Precio = Math.Round(random.NextDouble() * 100, 2);
                producto.Stock = random.Next(0, 1000);

                producto = Insertar(producto);
                productos.Add(producto);
            }
            ComprobarStructuras();
            return productos;
        }

        /// <summary>
        /// metodo que genera un texto con un pefix y segun la cantidad de caracteres solicitados
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="cantidad"></param>
        /// <returns>el texto</returns>
        private string TextoRandom(string prefix, int cantidad)
        {
            StringBuilder texto = new StringBuilder(prefix);
            for (int i = 0; i < cantidad; i++)
            {
                int indice = random.Next(caracteresRandom.Length);
                texto.Append(caracteresRandom[indice]);
            }
            return texto.ToString();
        }

        /// <summary>
        /// metodo que borra todos los produtos de la base de datos y reinicia los nodos
        /// </summary>
        public void LimpiarTodos()
        {
            repo.Limpiar();
            aBPlusTree = new ABPlusTree();
            aVLTree = new AVLTree();
            hashTable = null;
        }

        /// <summary>
        ///  metodo que inserta en la base de datos y nodos
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public Producto Insertar(Producto producto)
        {
            producto = repo.Guardar(producto);
            aBPlusTree.Insertar(producto);
            hashTable.Insertar(producto);
            aVLTree.Insertar(producto);
            return producto;
        }

        /// <summary>
        /// metodo que comprueba y actualiza estructuras
        /// </summary>
        private void ComprobarStructuras()
        {
            if (hashTable == null)
            {
                ActualizarEstructuras();
            }
        }

        /// <summary>
        /// metodo que actualiza estructiras de forma en segundo plano
        /// </summary>
        public async void ActualizarEstructuras()
        {
            List<Producto> productos = this.ObtenerProductos();

            if (productos.Count > 0)
            {
                hashTable = new HashTable(productos.Count);

                foreach (Producto prod in productos)
                {
                    aBPlusTree.Insertar(prod);
                    hashTable.Insertar(prod);
                    aVLTree.Insertar(prod);
                }
            }

        }

        /// <summary>
        /// busca productos por codigo en arbol b+
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns>producto</returns>
        public (string recorrido, Producto producto)? buscarCodigo(string codigo)
        {
            Producto producto = new Producto();
            var prd = aBPlusTree.Buscar(codigo);
            if (prd != null)
            {
                producto = prd;
                return (aBPlusTree.GetRecorrido(), producto);
            }
            return null;
        }

        /// <summary>
        /// buscar productos por nombre en tabla HASH
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>producto</returns>
        public (string recorrido, Producto producto)? buscarNombre(string nombre)
        {
            Producto producto = new Producto();
            var prd = hashTable.Buscar(nombre);
            if (prd != null)
            {
                producto = prd;
                return (hashTable.GetRecorrido(), producto);
            }
            return null;
        }

        /// <summary>
        /// busca productos por existencia en arbol AVL
        /// </summary>
        /// <param name="stock"></param>
        /// <returns>producto</returns>
        public (string recorrido, Producto producto)? buscarExistencia(int stock)
        {
            Producto producto = new Producto();
            var prd = aVLTree.Buscar(stock);
            if (prd != null)
            {
                producto = prd;
                return (aVLTree.GetRecorrido(), producto);
            }
            return null;
        }

        /// <summary>
        /// metodo para eliminar un producto y eliminarlo de los nodos
        /// </summary>
        /// <param name="producto"></param>
        public async void eliminar(Producto producto)
        {
            repo.Eliminar(producto);
            aBPlusTree.Eliminar(producto.Codigo);
            hashTable.Eliminar(producto.Nombre);
            aVLTree.Eliminar(producto.Stock);
        }

        /// <summary>
        /// obtener recorrido en TreeNode de arbol b+
        /// </summary>
        /// <returns></returns>
        public TreeNode? ABPlusTreeNode()
        {
            return aBPlusTree.Recorrer();
        }

        /// <summary>
        /// obtener recorrido en TreeNode de arbol AVL
        /// </summary>
        /// <returns></returns>
        public TreeNode? AVLTreeNode()
        {
            return aVLTree.Recorrer();
        }

        /// <summary>
        /// obtener recorrido y mostrarlo en un grid view en pantalla
        /// </summary>
        /// <param name="gridView"></param>
        public void MostrarHashTable(DataGridView gridView)
        {
            if (hashTable == null)
            {
                MessageBox.Show("No hay datos que mostrar");
                return;
            }
            hashTable.MostrarTablaHash(gridView);
        }
    }
}
