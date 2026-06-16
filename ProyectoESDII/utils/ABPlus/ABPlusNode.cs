using ProyectoESDII.modelos;

namespace ProyectoESDII.utils.ABPlus
{
    internal class ABPlusNode
    {
        // atributos
        public bool EsHoja { get; set; }
        public List<string> Claves { get; set; }
        public List<ABPlusNode> Hijos { get; set; }
        public List<Producto> Valores { get; set; }
        public ABPlusNode Siguiente { get; set; }

        /// <summary>
        /// constructor que requiere el dato de si el nuevo nodo es hoja o nodo interno
        /// </summary>
        /// <param name="esHoja"></param>
        public ABPlusNode(bool esHoja)
        {
            EsHoja = esHoja;
            Claves = new List<string>();
            Siguiente = null;
            Valores = new List<Producto>();
            Hijos = new List<ABPlusNode>();
        }

    }
}
