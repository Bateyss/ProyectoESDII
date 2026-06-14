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

        public ABPlusNode(bool esHoja)
        {
            EsHoja = esHoja;
            Claves = new List<string>();
            Siguiente = null;

            if (esHoja)
            {
                Valores = new List<Producto>();
                Hijos = null;
            }
            else
            {
                Valores = null;
                Hijos = new List<ABPlusNode>();
            }
        }

    }
}
