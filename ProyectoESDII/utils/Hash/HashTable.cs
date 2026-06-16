using ProyectoESDII.modelos;
using System.Text;

namespace ProyectoESDII.utils.Hash
{
    //Clase interna 
    internal class HashTable
    {

        //Atributos

        /// <summary>
        /// Arreglo principal que almacena las pociones de la tabla hash
        /// </summary>
        private HashNode[] tabla;
        /// <summary>
        /// Capacidad de la tabla
        /// </summary>
        private int capacidad;
        /// <summary>
        /// Cantidad de elementos almacenados
        /// </summary>
        private int cantidadElementos;

        /// <summary>
        /// Guarda el recorrido realizado en una búsqueda
        /// </summary>
        private StringBuilder recorrido;

        //Constructor
        /// <summary>
        /// Inicializa la tabla hash
        /// </summary>
        /// <param name="capacidad"></param>
        public HashTable(int capacidad)
        {
            this.capacidad = capacidad;
            tabla = new HashNode[capacidad];
            cantidadElementos = 0;
            recorrido = new StringBuilder("");
        }

        /// <summary>
        /// Método que calcula la posición correspondiente a una clave
        /// Posición donde se almacenará una nueva clave
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        private int FuncionHash(string clave)
        {

            int hash = 0;

            foreach (char c in clave)
            {
                hash = (hash * 31) + c;
            }

            return Math.Abs(hash) % capacidad;
        }

        /// <summary>
        /// Método para buscar un producto por su nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Producto? Buscar(string nombre)
        {
            //Obtiene el índice donde se realizará la búsqueda
            //Calcula la posición donde buscar
            int indice = FuncionHash(nombre);

            //Obtiene el inicio de la lista enlazada
            HashNode actual = tabla[indice];

            recorrido = new StringBuilder("");
            recorrido.Append(actual.Clave);

            //Recorre la lista enlazada en esa posición para encontrar el producto
            //Recorre la lista buscando el producto
            while (actual != null)
            {
                recorrido.Append(" -> ");
                recorrido.Append(actual.Clave);

                if (actual.Clave == nombre)
                {
                    recorrido.Append(" -> ");
                    recorrido.Append(actual.Producto.ToString());
                    return actual.Producto;
                }

                actual = actual.Siguiente;
            }

            return null;
        }


        /// <summary>
        /// Método para insertar un producto o actualizar uno existente.
        /// Si ya existe, actualiza la información
        /// </summary>
        /// <param name="producto"></param>
        public void Insertar(Producto producto)
        {
            //Calcula la posición
            //Calcula el índice donde se almacenará
            int indice = FuncionHash(producto.Nombre);
            //Obtiene el incio de la lista
            //Obtiene el inicio de la lista enlazada
            HashNode actual = tabla[indice];
            //Valida la existencia del producto
            //Verifica si el producto ya existe
            while (actual != null)
            {
                if (actual.Clave == producto.Nombre)
                {
                    actual.Producto = producto;
                    return;
                }

                actual = actual.Siguiente;
            }
            //Crea un nuevo nodo
            HashNode nuevoNodo =
                new HashNode(producto.Nombre, producto);

            //Inserta al inicio de la lista enlazada
            //Inserta el nodo al inicio de la lista
            nuevoNodo.Siguiente = tabla[indice];
            tabla[indice] = nuevoNodo;

            cantidadElementos++;
        }

        /// <summary>
        /// Método para eliminar un producto de la tabla hash
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>true si es eliminado</returns>
        public bool Eliminar(string nombre)
        {
            //Calcula el índice donde buscar
            int indice = FuncionHash(nombre);

            HashNode actual = tabla[indice];
            HashNode anterior = null;

            //Recorre la lista enlazada
            while (actual != null)
            {
                //Elimina el nodo encontrado y reconecta la lista
                if (actual.Clave == nombre)
                {
                    //Si es el primer nodo
                    if (anterior == null)
                    {
                        tabla[indice] = actual.Siguiente;
                    }
                    //Si está en medio o al final
                    else
                    {
                        anterior.Siguiente = actual.Siguiente;
                    }

                    cantidadElementos--;
                    return true;
                }

                //Continúa recorriendo la lista
                //Avanza al siguiente nodo
                anterior = actual;
                actual = actual.Siguiente;
            }

            return false;
        }

        /// <summary>
        /// Método para mostrar todos los productos almacenados en la tabla hash
        /// </summary>
        public void MostrarProductos()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine("\t Inventario Actual");
            Console.WriteLine("=====================================");

            bool existenProductos = false;

            for (int i = 0; i < capacidad; i++)
            {
                HashNode actual = tabla[i];

                while (actual != null)
                {
                    Producto producto = actual.Producto;

                    Console.WriteLine($"Código: {producto.Codigo}");
                    Console.WriteLine($"Nombre: {producto.Nombre}");
                    Console.WriteLine($"Categoría: {producto.Categoria}");
                    Console.WriteLine($"Precio: ${producto.Precio:F2}");
                    Console.WriteLine($"Stock: {producto.Stock}");
                    Console.WriteLine("-----------------------------------");

                    existenProductos = true;
                    actual = actual.Siguiente;
                }
            }

            if (!existenProductos)
            {
                Console.WriteLine("No hay productos registrados.");
            }
        }

        /// <summary>
        /// Método que devuelve el recorrido realizado en la última búsqueda
        /// </summary>
        /// <returns></returns>
        public string GetRecorrido()
        {
            return recorrido.ToString();
        }

        /// <summary>
        /// Método que muestra la tabla hash en el DataGridView
        /// </summary>
        /// <param name="gridView"></param>
        public void MostrarTablaHash(DataGridView gridView)
        {

            //if (tabla == null || tabla.Length == 0) {
            //    MessageBox.Show("No hay datos que mostrar");
            //    return;
            //}

            //Limpia el contenido anterior
            gridView.DataSource = null;
            gridView.Rows.Clear();
            gridView.Columns.Clear();

            //Configura las columnas
            gridView.Columns.Add("Index", "Indice");
            gridView.Columns.Add("Content", "Elementos");
            gridView.Columns.Add("Count", "Colisiones");

            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Recorre cada posición de la tabla
            for (int i = 0; i < tabla.Length; i++)
            {
                string contenido = "-";
                int colisiones = 0;

                if (tabla[i] != null)
                {
                    //Agrega la fila al DataGridView
                    contenido = tabla[i].Producto.Nombre;
                    int rowIndex = gridView.Rows.Add(i, contenido, colisiones);
                }
            }


        }


    }
}
