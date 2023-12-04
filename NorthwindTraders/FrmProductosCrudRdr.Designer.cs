namespace NorthwindTraders
{
    partial class FrmProductosCrudRdr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBProducto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboBCategoria = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBProveedor = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.tabOperacion = new System.Windows.Forms.TabControl();
            this.tbpRegistrar = new System.Windows.Forms.TabPage();
            this.tbpModificar = new System.Windows.Forms.TabPage();
            this.tbpEliminar = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnAccion = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.txtCantidadxU = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtUInventario = new System.Windows.Forms.TextBox();
            this.txtUPedido = new System.Windows.Forms.TextBox();
            this.txtPPedido = new System.Windows.Forms.TextBox();
            this.chkDescontinuado = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabOperacion.SuspendLayout();
            this.tbpRegistrar.SuspendLayout();
            this.tbpModificar.SuspendLayout();
            this.tbpEliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.cboBProveedor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboBCategoria);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBProducto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(208, 584);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "»   Buscar un producto:   «";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // txtBId
            // 
            this.txtBId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBId.Location = new System.Drawing.Point(16, 72);
            this.txtBId.MaxLength = 15;
            this.txtBId.Name = "txtBId";
            this.txtBId.Size = new System.Drawing.Size(100, 20);
            this.txtBId.TabIndex = 0;
            this.txtBId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBId_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Producto:";
            // 
            // txtBProducto
            // 
            this.txtBProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBProducto.Location = new System.Drawing.Point(16, 136);
            this.txtBProducto.MaxLength = 40;
            this.txtBProducto.Name = "txtBProducto";
            this.txtBProducto.Size = new System.Drawing.Size(180, 20);
            this.txtBProducto.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Categoría:";
            // 
            // cboBCategoria
            // 
            this.cboBCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBCategoria.FormattingEnabled = true;
            this.cboBCategoria.Location = new System.Drawing.Point(16, 200);
            this.cboBCategoria.Name = "cboBCategoria";
            this.cboBCategoria.Size = new System.Drawing.Size(180, 21);
            this.cboBCategoria.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Proveedor:";
            // 
            // cboBProveedor
            // 
            this.cboBProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBProveedor.FormattingEnabled = true;
            this.cboBProveedor.Location = new System.Drawing.Point(16, 264);
            this.cboBProveedor.Name = "cboBProveedor";
            this.cboBProveedor.Size = new System.Drawing.Size(180, 21);
            this.cboBProveedor.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(104, 312);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(95, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(104, 360);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(95, 23);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // tabOperacion
            // 
            this.tabOperacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabOperacion.Controls.Add(this.tbpRegistrar);
            this.tabOperacion.Controls.Add(this.tbpModificar);
            this.tabOperacion.Controls.Add(this.tbpEliminar);
            this.tabOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOperacion.Location = new System.Drawing.Point(248, 24);
            this.tabOperacion.Name = "tabOperacion";
            this.tabOperacion.SelectedIndex = 0;
            this.tabOperacion.Size = new System.Drawing.Size(728, 56);
            this.tabOperacion.TabIndex = 1;
            // 
            // tbpRegistrar
            // 
            this.tbpRegistrar.Controls.Add(this.label5);
            this.tbpRegistrar.Location = new System.Drawing.Point(4, 22);
            this.tbpRegistrar.Name = "tbpRegistrar";
            this.tbpRegistrar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRegistrar.Size = new System.Drawing.Size(720, 30);
            this.tbpRegistrar.TabIndex = 0;
            this.tbpRegistrar.Text = "     Registrar un producto     ";
            this.tbpRegistrar.UseVisualStyleBackColor = true;
            // 
            // tbpModificar
            // 
            this.tbpModificar.Controls.Add(this.label6);
            this.tbpModificar.Location = new System.Drawing.Point(4, 22);
            this.tbpModificar.Name = "tbpModificar";
            this.tbpModificar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpModificar.Size = new System.Drawing.Size(720, 30);
            this.tbpModificar.TabIndex = 1;
            this.tbpModificar.Text = "     Modificar un producto     ";
            this.tbpModificar.UseVisualStyleBackColor = true;
            // 
            // tbpEliminar
            // 
            this.tbpEliminar.Controls.Add(this.label7);
            this.tbpEliminar.Location = new System.Drawing.Point(4, 22);
            this.tbpEliminar.Name = "tbpEliminar";
            this.tbpEliminar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEliminar.Size = new System.Drawing.Size(720, 30);
            this.tbpEliminar.TabIndex = 2;
            this.tbpEliminar.Text = "     Eliminar un producto     ";
            this.tbpEliminar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Proporcione los datos del producto a registrar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(503, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Busque el producto a modificar y seleccionelo en la lista que se muestra, para qu" +
    "e pueda editar sus datos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(338, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Busque el producto a eliminar y seleccionelo en la lista que se muestra";
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(248, 88);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(724, 196);
            this.dgv.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.chkDescontinuado);
            this.groupBox2.Controls.Add(this.txtPPedido);
            this.groupBox2.Controls.Add(this.txtUPedido);
            this.groupBox2.Controls.Add(this.txtUInventario);
            this.groupBox2.Controls.Add(this.txtPrecio);
            this.groupBox2.Controls.Add(this.txtCantidadxU);
            this.groupBox2.Controls.Add(this.txtProducto);
            this.groupBox2.Controls.Add(this.cboProveedor);
            this.groupBox2.Controls.Add(this.cboCategoria);
            this.groupBox2.Controls.Add(this.txtId);
            this.groupBox2.Controls.Add(this.btnAccion);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(248, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(720, 312);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "»   Producto   «";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(274, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Id:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Categoría:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(227, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Proveedor:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(234, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Producto:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(171, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Cantidad por unidad:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(249, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Precio:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(154, 168);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(142, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Unidades en inventario:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(172, 192);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Unidades en pedido:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(192, 216);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Punto de pedido:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(200, 240);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Descontinuado:";
            // 
            // btnAccion
            // 
            this.btnAccion.Location = new System.Drawing.Point(480, 264);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(185, 23);
            this.btnAccion.TabIndex = 1;
            this.btnAccion.Text = "Registrar producto";
            this.btnAccion.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(304, 21);
            this.txtId.MaxLength = 15;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 2;
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(304, 44);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(270, 21);
            this.cboCategoria.TabIndex = 3;
            // 
            // cboProveedor
            // 
            this.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(304, 68);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(270, 21);
            this.cboProveedor.TabIndex = 3;
            // 
            // txtProducto
            // 
            this.txtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducto.Location = new System.Drawing.Point(304, 92);
            this.txtProducto.MaxLength = 40;
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(270, 20);
            this.txtProducto.TabIndex = 4;
            // 
            // txtCantidadxU
            // 
            this.txtCantidadxU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadxU.Location = new System.Drawing.Point(304, 116);
            this.txtCantidadxU.MaxLength = 20;
            this.txtCantidadxU.Name = "txtCantidadxU";
            this.txtCantidadxU.Size = new System.Drawing.Size(212, 20);
            this.txtCantidadxU.TabIndex = 5;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(304, 140);
            this.txtPrecio.MaxLength = 21;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 6;
            // 
            // txtUInventario
            // 
            this.txtUInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUInventario.Location = new System.Drawing.Point(304, 164);
            this.txtUInventario.MaxLength = 5;
            this.txtUInventario.Name = "txtUInventario";
            this.txtUInventario.Size = new System.Drawing.Size(100, 20);
            this.txtUInventario.TabIndex = 7;
            // 
            // txtUPedido
            // 
            this.txtUPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPedido.Location = new System.Drawing.Point(304, 188);
            this.txtUPedido.MaxLength = 5;
            this.txtUPedido.Name = "txtUPedido";
            this.txtUPedido.Size = new System.Drawing.Size(100, 20);
            this.txtUPedido.TabIndex = 8;
            // 
            // txtPPedido
            // 
            this.txtPPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPPedido.Location = new System.Drawing.Point(304, 212);
            this.txtPPedido.MaxLength = 5;
            this.txtPPedido.Name = "txtPPedido";
            this.txtPPedido.Size = new System.Drawing.Size(100, 20);
            this.txtPPedido.TabIndex = 9;
            // 
            // chkDescontinuado
            // 
            this.chkDescontinuado.AutoSize = true;
            this.chkDescontinuado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDescontinuado.Location = new System.Drawing.Point(304, 240);
            this.chkDescontinuado.Name = "chkDescontinuado";
            this.chkDescontinuado.Size = new System.Drawing.Size(15, 14);
            this.chkDescontinuado.TabIndex = 10;
            this.chkDescontinuado.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(416, 185);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(167, 29);
            this.label18.TabIndex = 6;
            this.label18.Text = "Cantidad mínima que se debe solicitar en un nuevo pedido";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(416, 211);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(170, 29);
            this.label19.TabIndex = 6;
            this.label19.Text = "Cantidad de unidades en el inventario en la cual se debe realizar un nuevo pedido" +
    "";
            // 
            // FrmProductosCrudRdr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.tabOperacion);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmProductosCrudRdr";
            this.Text = "Mantenimiento de productos";
            this.Load += new System.EventHandler(this.FrmProductosCrudRdr_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabOperacion.ResumeLayout(false);
            this.tbpRegistrar.ResumeLayout(false);
            this.tbpRegistrar.PerformLayout();
            this.tbpModificar.ResumeLayout(false);
            this.tbpModificar.PerformLayout();
            this.tbpEliminar.ResumeLayout(false);
            this.tbpEliminar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBProducto;
        private System.Windows.Forms.ComboBox cboBCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboBProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabOperacion;
        private System.Windows.Forms.TabPage tbpRegistrar;
        private System.Windows.Forms.TabPage tbpModificar;
        private System.Windows.Forms.TabPage tbpEliminar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAccion;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.TextBox txtCantidadxU;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.CheckBox chkDescontinuado;
        private System.Windows.Forms.TextBox txtPPedido;
        private System.Windows.Forms.TextBox txtUPedido;
        private System.Windows.Forms.TextBox txtUInventario;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
    }
}