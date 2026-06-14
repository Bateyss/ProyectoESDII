using Microsoft.VisualBasic.Logging;
using ProyectoESDII.modelos;
using System.Text;

namespace ProyectoESDII.utils.ABPlus
{
    internal class ABPlusTree
    {
        private ABPlusNode raiz;
        private const int MAX_KEYS = 6;
        private StringBuilder recorrido;

        public ABPlusTree()
        {
            raiz = new ABPlusNode(true);
            recorrido = new StringBuilder("");
        }

        // BUSCAR
        public Producto? Buscar(string codigo)
        {
            //Log log = new Log();
            
            ABPlusNode actual = raiz;

            //log.WriteEntry("buscando " + codigo);

            recorrido = new StringBuilder("");
            foreach (var item in actual.Claves)
            {
                recorrido.Append(item);
                recorrido.Append(", ");
            }

            // buscar hoja
            while (!actual.EsHoja)
            {
                int i = 0;
                while (i < actual.Claves.Count && string.Compare(codigo, actual.Claves[i]) >= 0) {
                    recorrido.Append(" -> ");
                    recorrido.Append(actual.Claves[i]);
                    i++; }
                actual = actual.Hijos[i];

                recorrido.Append(" -> ");
                foreach (var item in actual.Claves)
                {
                    recorrido.Append(item);
                    recorrido.Append(", ");
                }
            }

            // Buscar en la hoja
            for (int i = 0; i < actual.Claves.Count; i++)
            {
                //log.WriteEntry("clave " + actual.Claves[i]);
                //log.WriteEntry("codigo " + codigo);
                if (string.Compare(codigo, actual.Claves[i]) == 0) {
                    recorrido.Append(" -> ");
                    recorrido.Append(actual.Claves[i]);

                    recorrido.Append(" -> ");
                    recorrido.Append(actual.Valores[i].ToString());
                    return actual.Valores[i]; }
            }

            return null;
        }

        public bool Eliminar(string codigo)
        {
            ABPlusNode actual = raiz;

            // buscar hoja
            while (!actual.EsHoja)
            {
                int i = 0;
                while (i < actual.Claves.Count && string.Compare(codigo, actual.Claves[i]) >= 0) i++;
                actual = actual.Hijos[i];
            }

            // Buscar y eliminar dato
            // Buscar en la hoja
            for (int i = 0; i < actual.Claves.Count; i++)
            {
                if (codigo == actual.Claves[i])
                {
                    actual.Claves.RemoveAt(i);
                    actual.Valores.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }


        public void Insertar(Producto producto)
        {
            // recursividad
            var resultadoInsertar = InsertarRecursivo(raiz, producto);
            if (resultadoInsertar.HasValue)
            {
                var nuevaRaiz = new ABPlusNode(false);
                nuevaRaiz.Claves.Add(resultadoInsertar.Value.Clave);
                nuevaRaiz.Hijos.Add(raiz);
                nuevaRaiz.Hijos.Add(resultadoInsertar.Value.Der);
                raiz = nuevaRaiz;
            }
        }

        private (string Clave, ABPlusNode Der)? InsertarRecursivo(ABPlusNode nodo, Producto producto)
        {
            if (nodo.EsHoja)
            {

                // insertar ordenando en la hoja
                int i = 0;
                while (i < nodo.Claves.Count && string.Compare(producto.Codigo, nodo.Claves[i]) > 0) i++;

                if (nodo.Claves.Count > 0 && nodo.Claves.Contains(producto.Codigo))
                {
                    return null;
                }
                nodo.Claves.Insert(i, producto.Codigo);
                nodo.Valores.Insert(i, producto);

                // validar orden
                if (nodo.Claves.Count > MAX_KEYS) return DividirHoja(nodo);
            }
            else
            {
                // buscar hijo
                int i = 0;
                while (i < nodo.Claves.Count && string.Compare(producto.Codigo, nodo.Claves[i]) >= 0) i++;

                var division = InsertarRecursivo(nodo.Hijos[i], producto);

                if (division.HasValue)
                {
                    nodo.Claves.Insert(i, division.Value.Clave);
                    nodo.Hijos.Insert(i + 1, division.Value.Der);

                    // validar orden
                    if (nodo.Claves.Count > MAX_KEYS) return DividirPadre(nodo);
                }
            }
            return null;
        }

        private (string Clave, ABPlusNode Der)? DividirHoja(ABPlusNode hoja)
        {

            int count = hoja.Claves.Count;
            int mitad = count / 2;
            ABPlusNode nuevoNodo = new ABPlusNode(true);

            // mover la mitad derecha
            for (int i = mitad; i < count; i++)
            {
                nuevoNodo.Claves.Add(hoja.Claves[mitad]);
                nuevoNodo.Valores.Add(hoja.Valores[mitad]);
                hoja.Claves.RemoveAt(mitad);
                hoja.Valores.RemoveAt(mitad);
            }

            // ajustar punteros de enlace
            nuevoNodo.Siguiente = hoja.Siguiente;
            hoja.Siguiente = nuevoNodo;

            return (nuevoNodo.Claves[0], nuevoNodo);
        }

        private (string Clave, ABPlusNode Der)? DividirPadre(ABPlusNode nodo)
        {

            int count = nodo.Claves.Count;
            int mitad = count / 2;
            ABPlusNode nuevoNodo = new ABPlusNode(false);

            string clavePromocion = nodo.Claves[mitad];

            // mover la mitad derecha
            for (int i = mitad + 1; i < count; i++)
            {
                nuevoNodo.Claves.Add(nodo.Claves[i]);
                nuevoNodo.Hijos.Add(nodo.Hijos[i]);
            }
            nuevoNodo.Hijos.Add(nodo.Hijos[nodo.Hijos.Count - 1]);

            // ajustar punteros de enlace
            nodo.Claves.RemoveRange(mitad, nodo.Claves.Count - mitad);
            nodo.Hijos.RemoveRange(mitad+1 , nodo.Hijos.Count - (mitad+1));

            return (clavePromocion, nuevoNodo);
        }


        //Método para mostrar todos los productos en B+ tree
        // recorrer
        private void MostrarProductos()
        {
            ABPlusNode actual = raiz;

            // buscar hoja
            while (!actual.EsHoja)
            {
                actual = actual.Hijos[0];
            }

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine("\t Inventario Actual");
            Console.WriteLine("=====================================");

            while (actual != null)
            {
                foreach (var producto in actual.Valores)
                {
                    Console.WriteLine($"Código: {producto.Codigo}");
                    Console.WriteLine($"Nombre: {producto.Nombre}");
                    Console.WriteLine($"Categoría: {producto.Categoria}");
                    Console.WriteLine($"Precio: ${producto.Precio:F2}");
                    Console.WriteLine($"Stock: {producto.Stock}");
                    Console.WriteLine("-----------------------------------");
                }
                actual = actual.Siguiente;
            }
        }

        // recorrer
        public TreeNode? Recorrer()
        {
            if (raiz == null) return null;

            ABPlusNode actual = raiz;

            string claves_padre = "[" + string.Join("|", actual.Claves) + "]";

            // buscar hoja
            while (!actual.EsHoja)
            {
                actual = actual.Hijos[0];
            }

            if (raiz.Claves.Count > 0)
            {

                TreeNode nodo = new TreeNode(claves_padre);
                

                while (actual != null)
                {
                    string claves_hijo = "[" + string.Join("|", actual.Claves) + "]";
                    TreeNode nodoHijo = new TreeNode(claves_hijo);
                    nodo.Nodes.Add(nodoHijo);
                    actual = actual.Siguiente;
                }

                return nodo;
            }

            return null;
        }

        public string GetRecorrido() { 
        return recorrido.ToString();
        }

    }
}
