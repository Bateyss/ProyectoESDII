namespace ProyectoESDII
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvProductos = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            btnAgregarProductos = new Button();
            txtAgregarProducto = new NumericUpDown();
            btnLimpiarProductos = new Button();
            btnMostrarAB = new Button();
            btnMostrarAVL = new Button();
            label3 = new Label();
            txtBuscar = new TextBox();
            btnBuscarBplus = new Button();
            btnBuscarAVL = new Button();
            btnBuscarHash = new Button();
            txtRecorrido = new TextBox();
            label4 = new Label();
            btnMostrarHash = new Button();
            btnMostrar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAgregarProducto).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(55, 303);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(834, 275);
            dgvProductos.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 270);
            label1.Name = "label1";
            label1.Size = new Size(121, 17);
            label1.TabIndex = 1;
            label1.Text = "Tabla de Productos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 22);
            label2.Name = "label2";
            label2.Size = new Size(175, 17);
            label2.TabIndex = 3;
            label2.Text = "Cantidad Agregar Productos";
            // 
            // btnAgregarProductos
            // 
            btnAgregarProductos.Location = new Point(56, 92);
            btnAgregarProductos.Name = "btnAgregarProductos";
            btnAgregarProductos.Size = new Size(175, 30);
            btnAgregarProductos.TabIndex = 4;
            btnAgregarProductos.Text = "Agregar";
            btnAgregarProductos.UseVisualStyleBackColor = true;
            btnAgregarProductos.Click += btnAgregarProductos_Click;
            // 
            // txtAgregarProducto
            // 
            txtAgregarProducto.Location = new Point(55, 51);
            txtAgregarProducto.Name = "txtAgregarProducto";
            txtAgregarProducto.Size = new Size(176, 25);
            txtAgregarProducto.TabIndex = 5;
            // 
            // btnLimpiarProductos
            // 
            btnLimpiarProductos.Location = new Point(56, 137);
            btnLimpiarProductos.Name = "btnLimpiarProductos";
            btnLimpiarProductos.Size = new Size(175, 30);
            btnLimpiarProductos.TabIndex = 6;
            btnLimpiarProductos.Text = "Limpiar";
            btnLimpiarProductos.UseVisualStyleBackColor = true;
            btnLimpiarProductos.Click += btnLimpiarProductos_Click;
            // 
            // btnMostrarAB
            // 
            btnMostrarAB.Location = new Point(730, 92);
            btnMostrarAB.Name = "btnMostrarAB";
            btnMostrarAB.Size = new Size(159, 30);
            btnMostrarAB.TabIndex = 7;
            btnMostrarAB.Text = "Mostrar Arbol B+";
            btnMostrarAB.UseVisualStyleBackColor = true;
            btnMostrarAB.Click += btnMostrarAB_Click;
            // 
            // btnMostrarAVL
            // 
            btnMostrarAVL.Location = new Point(730, 137);
            btnMostrarAVL.Name = "btnMostrarAVL";
            btnMostrarAVL.Size = new Size(159, 30);
            btnMostrarAVL.TabIndex = 8;
            btnMostrarAVL.Text = "Mostrar Arbol AVL";
            btnMostrarAVL.UseVisualStyleBackColor = true;
            btnMostrarAVL.Click += btnMostrarAVL_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(296, 22);
            label3.Name = "label3";
            label3.Size = new Size(65, 17);
            label3.TabIndex = 9;
            label3.Text = "Busqueda";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(296, 51);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(177, 25);
            txtBuscar.TabIndex = 10;
            // 
            // btnBuscarBplus
            // 
            btnBuscarBplus.Location = new Point(504, 92);
            btnBuscarBplus.Name = "btnBuscarBplus";
            btnBuscarBplus.Size = new Size(204, 30);
            btnBuscarBplus.TabIndex = 11;
            btnBuscarBplus.Text = "Buscar Codigo (B+)";
            btnBuscarBplus.UseVisualStyleBackColor = true;
            btnBuscarBplus.Click += btnBuscarBplus_Click;
            // 
            // btnBuscarAVL
            // 
            btnBuscarAVL.Location = new Point(504, 137);
            btnBuscarAVL.Name = "btnBuscarAVL";
            btnBuscarAVL.Size = new Size(204, 30);
            btnBuscarAVL.TabIndex = 12;
            btnBuscarAVL.Text = "Buscar Stock (AVL)";
            btnBuscarAVL.UseVisualStyleBackColor = true;
            btnBuscarAVL.Click += btnBuscarAVL_Click;
            // 
            // btnBuscarHash
            // 
            btnBuscarHash.Location = new Point(504, 51);
            btnBuscarHash.Name = "btnBuscarHash";
            btnBuscarHash.Size = new Size(204, 30);
            btnBuscarHash.TabIndex = 13;
            btnBuscarHash.Text = "Buscar Nombre (Hash)";
            btnBuscarHash.UseVisualStyleBackColor = true;
            btnBuscarHash.Click += btnBuscarHash_Click;
            // 
            // txtRecorrido
            // 
            txtRecorrido.Location = new Point(148, 183);
            txtRecorrido.Multiline = true;
            txtRecorrido.Name = "txtRecorrido";
            txtRecorrido.ScrollBars = ScrollBars.Both;
            txtRecorrido.Size = new Size(741, 57);
            txtRecorrido.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 207);
            label4.Name = "label4";
            label4.Size = new Size(66, 17);
            label4.TabIndex = 15;
            label4.Text = "Recorrido";
            // 
            // btnMostrarHash
            // 
            btnMostrarHash.Location = new Point(730, 51);
            btnMostrarHash.Name = "btnMostrarHash";
            btnMostrarHash.Size = new Size(159, 30);
            btnMostrarHash.TabIndex = 16;
            btnMostrarHash.Text = "Mostrar Tabla Hash";
            btnMostrarHash.UseVisualStyleBackColor = true;
            btnMostrarHash.Click += btnMostrarHash_Click;
            // 
            // btnMostrar
            // 
            btnMostrar.Location = new Point(296, 92);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(177, 53);
            btnMostrar.TabIndex = 17;
            btnMostrar.Text = "Mostrar Tabla Productos";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(202, 267);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(175, 30);
            btnEliminar.TabIndex = 18;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 614);
            Controls.Add(btnEliminar);
            Controls.Add(btnMostrar);
            Controls.Add(btnMostrarHash);
            Controls.Add(label4);
            Controls.Add(txtRecorrido);
            Controls.Add(btnBuscarHash);
            Controls.Add(btnBuscarAVL);
            Controls.Add(btnBuscarBplus);
            Controls.Add(txtBuscar);
            Controls.Add(label3);
            Controls.Add(btnMostrarAVL);
            Controls.Add(btnMostrarAB);
            Controls.Add(btnLimpiarProductos);
            Controls.Add(txtAgregarProducto);
            Controls.Add(btnAgregarProductos);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvProductos);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAgregarProducto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProductos;
        private Label label1;
        private Label label2;
        private Button btnAgregarProductos;
        private NumericUpDown txtAgregarProducto;
        private Button btnLimpiarProductos;
        private Button btnMostrarAB;
        private Button btnMostrarAVL;
        private Label label3;
        private TextBox txtBuscar;
        private Button btnBuscarBplus;
        private Button btnBuscarAVL;
        private Button btnBuscarHash;
        private TextBox txtRecorrido;
        private Label label4;
        private Button btnMostrarHash;
        private Button btnMostrar;
        private Button btnEliminar;
    }
}
