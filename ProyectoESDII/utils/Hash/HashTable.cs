using ProyectoESDII.modelos;
using System.Text;

namespace ProyectoESDII.utils.Hash
{
    internal class HashTable
    {

        //Atributos
        //Arreglo principal que almacena las pociones de la tabla hash
        private HashNode[] tabla;
        //Tamaño total de la tabla
        private int capacidad;
        private int cantidadElementos;

        private StringBuilder recorrido;

        //Constructor
        public HashTable(int capacidad)
        {
            this.capacidad = capacidad;
            tabla = new HashNode[capacidad];
            cantidadElementos = 0;
            recorrido = new StringBuilder("");
        }

        //Métodos de la clase
        //Posición donde se almacenará una nueva clave
        private int FuncionHash(string clave)
        {

            int hash = 0;

            foreach (char c in clave)
            {
                hash = (hash * 31) + c;
            }

            return Math.Abs(hash) % capacidad;
        }

        //Método Buscar Producto por código
        public Producto? Buscar(string nombre)
        {
            //Calcula la posición donde buscar
            int indice = FuncionHash(nombre);

            HashNode actual = tabla[indice];

            recorrido = new StringBuilder("");
            recorrido.Append(actual.Clave);

            //Recorre la lista enlazada en esa posición para encontrar el producto
            while (actual != null)
            {
                if (actual.Clave == nombre)
                {
                    recorrido.Append(" -> ");
                    recorrido.Append(actual.Producto.ToString());
                    return actual.Producto;
                }

                actual = actual.Siguiente;

                if (actual != null)
                {
                    recorrido.Append(" -> ");
                    recorrido.Append(actual.Clave);
                }
            }

            return null;
        }

        //Método Insertar Producto.
        //Si ya existe, actualiza la información.
        public void Insertar(Producto producto)
        {
            //Calcula la posición
            int indice = FuncionHash(producto.Nombre);
            //Obtiene el incio de la lista
            HashNode actual = tabla[indice];
            //Valida la existencia del producto
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
            nuevoNodo.Siguiente = tabla[indice];
            tabla[indice] = nuevoNodo;

            cantidadElementos++;
        }

        //Método para eliminar un producto de la tabla hash
        public bool Eliminar(string nombre)
        {
            int indice = FuncionHash(nombre);

            HashNode actual = tabla[indice];
            HashNode anterior = null;

            //Recorre la lista enlazada
            while (actual != null)
            {
                //Elimina el nodo encontrado y reconecta la lista
                if (actual.Clave == nombre)
                {
                    if (anterior == null)
                    {
                        tabla[indice] = actual.Siguiente;
                    }
                    else
                    {
                        anterior.Siguiente = actual.Siguiente;
                    }

                    cantidadElementos--;
                    return true;
                }

                //Continúa recorriendo la lista
                anterior = actual;
                actual = actual.Siguiente;
            }

            return false;
        }

        //Método para mostrar todos los productos en la tabla hash
        public void mostrarProductos()
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

        public string getRecorrido() {
            return recorrido.ToString();
        }


    }
}
