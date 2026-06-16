using ProyectoESDII.modelos;
using System.Text;

namespace ProyectoESDII.utils.AVL
{
    internal class AVLTree
    {
        /// <summary>
        /// nodo raíz del árbol AVL
        /// </summary>
        private AVLNode raiz;

        /// <summary>
        /// texto de recorrido construido al buscar un dato
        /// </summary>
        private StringBuilder recorrido;

        /// <summary>
        /// constructor
        /// </summary>
        public AVLTree()
        {
            recorrido = new StringBuilder("");
        }

        /// <summary>
        /// altura de un nodo
        /// </summary>
        /// <param name="nodo"></param>
        /// <returns></returns>
        private int Altura(AVLNode nodo)
        {
            if (nodo == null)
                return 0;

            return nodo.Altura;
        }

        /// <summary>
        /// balance de un nodo
        /// </summary>
        /// <param name="nodo"></param>
        /// <returns>numero de desbalance</returns>
        private int Balance(AVLNode nodo)
        {
            return nodo == null ? 0 :
                Altura(nodo.Izq) - Altura(nodo.Der);
        }

        /// <summary>
        /// rotacion a la derecha
        /// </summary>
        /// <param name="y">nodo</param>
        /// <returns>nodo rotado</returns>
        private AVLNode RotacionDerecha(AVLNode y)
        {
            AVLNode x = y.Izq;
            AVLNode T2 = x.Der;

            //realizar rotación
            x.Der = y;
            y.Izq = T2;

            //actualizar alturas
            y.Altura = 1 + Math.Max(Altura(y.Izq), Altura(y.Der));
            x.Altura = 1 + Math.Max(Altura(x.Izq), Altura(x.Der));
            //retornar nueva raíz
            return x;
        }


        /// <summary>
        /// rotacion a la izquierda
        /// </summary>
        /// <param name="y">nodo</param>
        /// <returns>nodo rotado</returns>
        private AVLNode RotacionIzquierda(AVLNode x)
        {
            AVLNode y = x.Der;
            AVLNode T2 = y.Izq;

            //realizar rotación
            y.Izq = x;
            x.Der = T2;

            //actualizar alturas
            x.Altura = 1 + Math.Max(Altura(x.Izq), Altura(x.Der));
            y.Altura = 1 + Math.Max(Altura(y.Izq), Altura(y.Der));

            //retornar nueva raíz
            return y;
        }

        /// <summary>
        /// Buscar producto por id
        /// </summary>
        /// <param name="existencia"></param>
        /// <returns>Producto</returns>
        public Producto? Buscar(int existencia)
        {
            AVLNode actual = raiz;

            recorrido = new StringBuilder("");
            recorrido.Append(actual.Producto.Stock);

            while (actual != null)
            {
                //// Producto encontrado
                if (existencia == actual.Producto.Stock)
                {
                    recorrido.Append(" -> ");
                    recorrido.Append(actual.Producto.ToString());
                    return actual.Producto;
                }

                //Buscar izquierda
                if (existencia < actual.Producto.Stock)
                {
                    actual = actual.Izq;
                    recorrido.Append(" Izq-> ");
                    recorrido.Append(actual.Producto.Stock);
                }
                //Buscar derecha
                else
                {
                    actual = actual.Der;
                    recorrido.Append(" Der-> ");
                    recorrido.Append(actual.Producto.Stock);
                }

            }

            return null;
        }

        /// <summary>
        /// Insertar un producto
        /// </summary>
        /// <param name="producto"></param>
        public void Insertar(Producto producto)
        {
            raiz = Insertar(raiz, producto);
        }

        /// <summary>
        /// Método recursivo para insertar
        /// </summary>
        /// <param name="nodo"></param>
        /// <param name="producto"></param>
        /// <returns>nodo nuevo</returns>
        private AVLNode Insertar(AVLNode nodo, Producto producto)
        {
            // Si el árbol está vacío se crear un nodo
            if (nodo == null)
                return new AVLNode(producto);

            // Insertar a la izquierda
            if (producto.Stock < nodo.Producto.Stock)
                nodo.Izq = Insertar(nodo.Izq, producto);

            // Insertar a la derecha
            else if (producto.Stock > nodo.Producto.Stock)
                nodo.Der = Insertar(nodo.Der, producto);

            // No permitir id repetido
            else
                return nodo;

            // Actualizar altura
            nodo.Altura = 1 + Math.Max(
                Altura(nodo.Izq),
                Altura(nodo.Der));

            // Obtener balance
            int balance = Balance(nodo);

            //  Izquierda-Izquierda
            if (balance > 1 && producto.Stock < nodo.Izq.Producto.Stock)
                return RotacionDerecha(nodo);

            //  Derecha-Derecha
            if (balance < -1 && producto.Stock > nodo.Der.Producto.Stock)
                return RotacionIzquierda(nodo);

            //  Izquierda-Derecha
            if (balance > 1 && producto.Stock > nodo.Izq.Producto.Stock)
            {
                nodo.Izq = RotacionIzquierda(nodo.Izq);
                return RotacionDerecha(nodo);
            }

            //  Derecha-Izquierda
            if (balance < -1 && producto.Stock < nodo.Der.Producto.Stock)
            {
                nodo.Der = RotacionDerecha(nodo.Der);
                return RotacionIzquierda(nodo);
            }

            return nodo;
        }

        /// <summary>
        /// Eliminar O(log N)
        /// </summary>
        /// <param name="codigo"></param>
        public void Eliminar(int codigo)
        {
            raiz = EliminarRecursivo(raiz, codigo);
        }

        /// <summary>
        /// Eliminar recursivo para ordenar los datos
        /// </summary>
        /// <param name="nodo"></param>
        /// <param name="Stock"></param>
        /// <returns></returns>
        private AVLNode EliminarRecursivo(AVLNode nodo, int Stock)
        {
            if (nodo == null) return null;

            // Insertar a la izquierda
            if (Stock < nodo.Producto.Stock)
                nodo.Izq = EliminarRecursivo(nodo.Izq, nodo.Producto.Stock);

            // Insertar a la derecha
            else if (Stock > nodo.Producto.Stock)
                nodo.Der = EliminarRecursivo(nodo.Der, nodo.Producto.Stock);

            // No permitir id repetido
            else
            {
                // un hijo o ninguno
                if (nodo.Izq == null) return nodo.Der;
                if (nodo.Der == null) return nodo.Izq;

                // dos hijos (sucesoir in-order)
                nodo.Producto = MinimoValor(nodo.Der);
                nodo.Der = EliminarRecursivo(nodo.Der, nodo.Producto.Stock);
            }
            return nodo;
        }

        /// <summary>
        /// obtener orden in orden de un nodo
        /// </summary>
        /// <param name="nodo"></param>
        /// <returns>prodcto con id minmo</returns>
        private Producto MinimoValor(AVLNode nodo)
        {
            Producto min = nodo.Producto;

            while (nodo.Izq != null)
            {
                min = nodo.Izq.Producto;
                nodo = nodo.Izq;
            }
            return min;
        }

        /// <summary>
        /// Método para mostrar todos los productos en AVL tree
        /// </summary>
        public void MostrarProductos()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine("\t Inventario Actual");
            Console.WriteLine("=====================================");

            RecorrerInOrder(raiz);
        }

        /// <summary>
        /// Método para recorrer el nodo InOrder y para imprimir en consola
        /// </summary>
        /// <param name="nodo"></param>
        private void RecorrerInOrder(AVLNode nodo)
        {
            if (nodo != null)
            {
                RecorrerInOrder(nodo.Izq);

                Console.WriteLine($"Código: {nodo.Producto.Codigo}");
                Console.WriteLine($"Nombre: {nodo.Producto.Nombre}");
                Console.WriteLine($"Categoría: {nodo.Producto.Categoria}");
                Console.WriteLine($"Precio: ${nodo.Producto.Precio:F2}");
                Console.WriteLine($"Stock: {nodo.Producto.Stock}");
                Console.WriteLine("-----------------------------------");

                RecorrerInOrder(nodo.Der);
            }
        }

        /// <summary>
        /// recorrer el nodo rellenando un TreeNode para imprimir en pantalla
        /// </summary>
        /// <returns></returns>
        public TreeNode? Recorrer()
        {
            if (raiz == null) return null;
            return RecorrerRecursivo(raiz);
        }

        /// <summary>
        /// recorrer InOrden el nodo
        /// </summary>
        /// <param name="raix"></param>
        /// <returns></returns>
        private TreeNode RecorrerRecursivo(AVLNode raix)
        {
            TreeNode nodo = new TreeNode(raix.Producto.Stock.ToString());
            if (raix.Izq != null)
            {
                nodo.Nodes.Add(RecorrerRecursivo(raix.Izq));
            }
            if (raix.Der != null)
            {
                nodo.Nodes.Add(RecorrerRecursivo(raix.Der));
            }
            return nodo;
        }

        /// <summary>
        /// obtener el texto almacenado del recorrido al buscar
        /// </summary>
        /// <returns>texto del recorrido</returns>
        public string GetRecorrido()
        {
            return recorrido.ToString();
        }


    }
}
