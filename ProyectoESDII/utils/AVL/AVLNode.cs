using ProyectoESDII.modelos;

namespace ProyectoESDII.utils.AVL
{
    internal class AVLNode
    {
        // Producto almacenado en el nodo
        public Producto Producto;

        // Referencias a los nodos hijos izquierdo y derecho
        public AVLNode Izq;
        public AVLNode Der;

        //altura del nodo 
        public int Altura;

        //constructor
        public AVLNode(Producto producto)
        {
            Producto = producto;
            Altura = 1;
        }
    }
}
