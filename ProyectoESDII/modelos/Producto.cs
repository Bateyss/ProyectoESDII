namespace ProyectoESDII.modelos
{
    internal class Producto
    {
        //Atributos
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        /// <summary>
        /// Constructor de datos llenos
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="nombre"></param>
        /// <param name="categoria"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        public Producto(string codigo, string nombre, string categoria, double precio, int stock)
        {
            Codigo = codigo;
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
            Stock = stock;
        }

        /// <summary>
        /// constructor de datos vacios
        /// </summary>
        public Producto()
        {
            Codigo = "";
            Nombre = "";
            Categoria = "";
            Precio = 0;
            Stock = 0;
        }

        /// <summary>
        /// Sobreescritura de ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Código: {Codigo}, Nombre: {Nombre}, Categoría: {Categoria}, Precio: {Precio}, Stock: {Stock}";
        }

    }
}
