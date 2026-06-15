using Microsoft.VisualBasic.Logging;
using ProyectoESDII.modelos;
using ProyectoESDII.Service;
using System.ComponentModel;

namespace ProyectoESDII
{
    public partial class Form1 : Form
    {

        ProductoService service = new ProductoService();
        List<Producto> productosList = new List<Producto>();

        public Form1()
        {
            InitializeComponent();
            CargarProductos(null);
            service.ActualizarEstructuras();
            MostrarProductos();
        }

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

        public void MostrarProductos()
        {
            var bindingList = new BindingList<Producto>(productosList);
            dgvProductos.DataSource = bindingList;
        }

        private void btnLimpiarProductos_Click(object sender, EventArgs e)
        {
            service.LimpiarTodos();
            productosList = new List<Producto>();
            MostrarProductos();
        }

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

        private void btnMostrarHash_Click(object sender, EventArgs e)
        {
            service.MostrarHashTable(dgvProductos);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dgvProductos.Rows.Clear();
            dgvProductos.Columns.Clear();
            CargarProductos(null);
            MostrarProductos();
        }

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
                else {
                    MessageBox.Show("Listado no es de tipo producto");
                }
            }
            else {
                MessageBox.Show("Seleccione un producto");
            }
        }
    }
}
