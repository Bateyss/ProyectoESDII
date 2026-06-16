using ProyectoESDII.modelos;
using ProyectoESDII.Service;
using System.ComponentModel;

namespace ProyectoESDII
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// servicio de productos de base de datos y nodos
        /// </summary>
        ProductoService service = new ProductoService();
        /// <summary>
        /// productos almacenados temporalmente para presentar en pantalla
        /// </summary>
        List<Producto> productosList = new List<Producto>();

        /// <summary>
        /// inicializador
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            CargarProductos(null);
            service.ActualizarEstructuras();
            MostrarProductos();
        }

        /// <summary>
        /// agregar productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            int cantidadAgregar = ((int)txtAgregarProducto.Value);
            if (cantidadAgregar > 0)
            {
                productosList = service.GenerarProductos(cantidadAgregar);
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Ingrese un numero valido");
            }
        }

        /// <summary>
        /// cargar los productos, para almacenar lo que se podria mostrar en pantalla,
        /// se puede alojar de filtros
        /// </summary>
        /// <param name="productos"></param>
        private void CargarProductos(List<Producto>? productos)
        {
            if (productos != null && productos.Count > 0)
            {
                productosList = productos;
            }
            else
            {
                productosList = service.ObtenerProductos();
            }
        }

        /// <summary>
        /// imprimir productos en pantalla
        /// </summary>
        public void MostrarProductos()
        {
            var bindingList = new BindingList<Producto>(productosList);
            dgvProductos.DataSource = bindingList;
        }

        /// <summary>
        /// limpiar productos de la base de datos y nodos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiarProductos_Click(object sender, EventArgs e)
        {
            service.LimpiarTodos();
            productosList = new List<Producto>();
            MostrarProductos();
        }

        /// <summary>
        /// mostrar arbol b+
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarAB_Click(object sender, EventArgs e)
        {
            if (productosList == null)
            {
                MessageBox.Show("No hay datos que mostrar");
                return;
            }

            TreeNode nodos = service.ABPlusTreeNode();
            if (nodos != null)
            {
                Form2 form2 = new Form2("Resultado Arbol B+", nodos);
                form2.ShowDialog();
            }
        }

        /// <summary>
        /// mostrar arbol AVL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarAVL_Click(object sender, EventArgs e)
        {
            if (productosList == null)
            {
                MessageBox.Show("No hay datos que mostrar");
                return;
            }

            TreeNode nodos = service.AVLTreeNode();
            if (nodos != null)
            {
                Form2 form2 = new Form2("Resultado Arbol AVL", nodos);
                form2.ShowDialog();
            }
        }

        /// <summary>
        /// buscar por codigo en arbol b+
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarBplus_Click(object sender, EventArgs e)
        {
            txtRecorrido.Text = "";
            var encontrado = service.buscarCodigo(txtBuscar.Text.Trim());
            if (encontrado.HasValue)
            {
                txtRecorrido.Text = encontrado.Value.recorrido;
            }
            else MessageBox.Show("No hay datos que mostrar");
        }

        /// <summary>
        /// buscar por existencia en arbol avl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarAVL_Click(object sender, EventArgs e)
        {
            txtRecorrido.Text = "";
            var texto = txtBuscar.Text.Trim();
            var stock = 0;
            try { stock = int.Parse(texto); } catch { MessageBox.Show("Dato de busqueda no numerico"); }
            if (stock > 0)
            {
                var encontrado = service.buscarExistencia(stock);
                if (encontrado.HasValue)
                {
                    txtRecorrido.Text = encontrado.Value.recorrido;
                }
                else MessageBox.Show("No hay datos que mostrar");
            }
        }

        /// <summary>
        /// buscar por nombre de producto en tabla hash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarHash_Click(object sender, EventArgs e)
        {
            txtRecorrido.Text = "";
            var encontrado = service.buscarNombre(txtBuscar.Text.Trim());
            if (encontrado.HasValue)
            {
                txtRecorrido.Text = encontrado.Value.recorrido;
            }
            else MessageBox.Show("No hay datos que mostrar");
        }

        /// <summary>
        /// mostrar tabla hash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarHash_Click(object sender, EventArgs e)
        {
            service.MostrarHashTable(dgvProductos);
        }

        /// <summary>
        /// mostrar productos en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dgvProductos.Rows.Clear();
            dgvProductos.Columns.Clear();
            CargarProductos(null);
            MostrarProductos();
        }

        /// <summary>
        /// eliminar un producto seleccionado de la tabla en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                int rowIndex = dgvProductos.CurrentRow.Index;
                if (dgvProductos.DataSource != null)
                {
                    Producto prod = productosList[rowIndex];
                    service.eliminar(prod);
                    CargarProductos(null);
                    MostrarProductos();
                }
                else
                {
                    MessageBox.Show("Listado no es de tipo producto");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto");
            }
        }
    }
}
