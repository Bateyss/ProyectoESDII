namespace ProyectoESDII
{
    public partial class Form2 : Form
    {
        /// <summary>
        /// constructor con datos vacios
        /// </summary>
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructor con datos a imprimir
        /// </summary>
        /// <param name="label"></param>
        /// <param name="nodo"></param>
        public Form2(string label, TreeNode nodo)
        {
            InitializeComponent();
            label1.Text = label;
            dibujarArbol(nodo);

            this.Text = label;
        }

        /// <summary>
        /// imprimiar arbol en pantalla
        /// </summary>
        /// <param name="nodo"></param>
        private void dibujarArbol(TreeNode nodo)
        {
            // limpiar cuadro en pantalla
            treeView1.Nodes.Clear();

            // validar que el nodo tenga datos
            if (nodo != null)
            {
                treeView1.Nodes.Add(nodo);
                treeView1.ExpandAll();
            }
        }
    }
}
