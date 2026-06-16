using ProyectoESDII.modelos;

namespace ProyectoESDII.utils.AVL
{
    internal class AVLNode
    {
        /// <summary>
        /// Producto almacenado en el nodo
        /// </summary>
        public Producto Producto;

        /// <summary>
        /// Referencias a los nodos hijos izquierdo y derecho
        /// </summary>
        public AVLNode Izq;
        public AVLNode Der;

        ///altura del nodo 
        public int Altura;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="producto"></param>
        public AVLNode(Producto producto)
        {
            Producto = producto;
            Altura = 1;
        }
    }
}
