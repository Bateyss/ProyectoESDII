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

        ProductoRepo repo = new ProductoRepo();
        Random random = new Random();
        string caracteresRandom = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        ABPlusTree aBPlusTree = new ABPlusTree();
        AVLTree aVLTree = new AVLTree();
        HashTable hashTable;

        public ProductoService()
        {
            ComprobarStructuras();
        }

        public List<Producto> ObtenerProductos()
        {
            List<Producto> productos = repo.List();
            return productos;
        }

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

        public void LimpiarTodos()
        {
            repo.Limpiar();
            aBPlusTree = new ABPlusTree();
            aVLTree = new AVLTree();
            hashTable = null;
        }

        public Producto Insertar(Producto producto)
        {
            producto = repo.Guardar(producto);
            aBPlusTree.Insertar(producto);
            hashTable.Insertar(producto);
            aVLTree.Insertar(producto);
            return producto;
        }

        private void ComprobarStructuras()
        {
            if (hashTable == null)
            {
                ActualizarEstructuras();
            }
        }

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

        public (string recorrido, Producto producto)? buscarCodigo(string codigo)
        {
            Producto producto = new Producto();
            var prd = aBPlusTree.Buscar(codigo);
            if (prd != null)
            {
                producto = prd;
                return (aBPlusTree.getRecorrido(), producto);
            }
            return null;
        }

        public (string recorrido, Producto producto)? buscarNombre(string nombre)
        {
            Producto producto = new Producto();
            var prd = hashTable.Buscar(nombre);
            if (prd != null)
            {
                producto = prd;
                return (hashTable.getRecorrido(), producto);
            }
            return null;
        }

        public (string recorrido, Producto producto)? buscarExistencia(int stock)
        {
            Producto producto = new Producto();
            var prd = aVLTree.Buscar(stock);
            if (prd != null)
            {
                producto = prd;
                return (aVLTree.getRecorrido(), producto);
            }
            return null;
        }

        public async void eliminar(Producto producto)
        {
            repo.Eliminar(producto);
            aBPlusTree.Eliminar(producto.Codigo);
            hashTable.Eliminar(producto.Nombre);
            aVLTree.Eliminar(producto.Stock);
        }

        public TreeNode? ABPlusTreeNode()
        {
            return aBPlusTree.Recorrer();
        }

        public TreeNode? AVLTreeNode()
        {
            return aVLTree.Recorrer();
        }
    }
}
