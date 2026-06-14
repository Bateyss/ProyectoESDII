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

        //Constructor
        public Producto(string codigo, string nombre, string categoria, double precio, int stock)
        {
            Codigo = codigo;
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
            Stock = stock;
        }

        public Producto()
        {
            Codigo = "";
            Nombre = "";
            Categoria = "";
            Precio = 0;
            Stock = 0;
        }

        //Sobreescritura de ToString 
        public override string ToString()
        {
            return $"Código: {Codigo}, Nombre: {Nombre}, Categoría: {Categoria}, Precio: {Precio}, Stock: {Stock}";
        }

    }
}
