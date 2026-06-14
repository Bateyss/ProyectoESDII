using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoESDII
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string label, TreeNode nodo)
        {
            InitializeComponent();
            label1.Text = label;
            dibujarArbol(nodo);

            this.Text = label;
        }

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
