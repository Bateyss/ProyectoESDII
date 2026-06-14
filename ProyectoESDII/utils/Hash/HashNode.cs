using ProyectoESDII.modelos;

namespace ProyectoESDII.utils.Hash
{
    internal class HashNode
    {
        //Atributos
        public string Clave { get; set; }
        public Producto Producto { get; set; }
        public HashNode Siguiente { get; set; }

        //Constructor
        public HashNode(string clave, Producto producto)
        {
            Clave = clave;
            Producto = producto;
            Siguiente = null;
        }
    }
}
