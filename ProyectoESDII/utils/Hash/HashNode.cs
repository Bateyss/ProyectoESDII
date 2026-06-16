using ProyectoESDII.modelos;

namespace ProyectoESDII.utils.Hash
{
    //Nodo utilizado en la tabla hash
    internal class HashNode
    {
        //Atributos
        /// <summary>
        /// Clave del producto en la tabla
        /// </summary>
        public string Clave { get; set; }
        /// <summary>
        /// Producto almacenado
        /// </summary>
        public Producto Producto { get; set; }
        /// <summary>
        /// Referencia al siguiente nodo
        /// </summary>
        public HashNode Siguiente { get; set; }

        /// <summary>
        /// Constructor que inicializa el nodo con una clave y un producto
        /// </summary>
        /// <param name="clave"></param>
        /// <param name="producto"></param>
        public HashNode(string clave, Producto producto)
        {
            Clave = clave;
            Producto = producto;
            Siguiente = null;
        }
    }
}
