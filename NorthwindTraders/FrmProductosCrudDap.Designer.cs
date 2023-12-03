namespace NorthwindTraders
{
    partial class FrmProductosCrudDap
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
            this.components = new System.ComponentModel.Container();
            this.grbBuscar = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboBProveedor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBCategoria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabOperacion = new System.Windows.Forms.TabControl();
            this.tbpRegistrar = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tbpModificar = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tbpEliminar = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.grbProducto = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkbDescontinuado = new System.Windows.Forms.CheckBox();
            this.txtPPedido = new System.Windows.Forms.TextBox();
            this.txtUPedido = new System.Windows.Forms.TextBox();
            this.txtUInventario = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCantidadxU = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnAccion = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbBuscar.SuspendLayout();
            this.tabOperacion.SuspendLayout();
            this.tbpRegistrar.SuspendLayout();
            this.tbpModificar.SuspendLayout();
            this.tbpEliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.grbProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBuscar
            // 
            this.grbBuscar.Controls.Add(this.btnLimpiar);
            this.grbBuscar.Controls.Add(this.btnBuscar);
            this.grbBuscar.Controls.Add(this.cboBProveedor);
            this.grbBuscar.Controls.Add(this.label4);
            this.grbBuscar.Controls.Add(this.cboBCategoria);
            this.grbBuscar.Controls.Add(this.label3);
            this.grbBuscar.Controls.Add(this.txtBNombre);
            this.grbBuscar.Controls.Add(this.label2);
            this.grbBuscar.Controls.Add(this.txtBId);
            this.grbBuscar.Controls.Add(this.label1);
            this.grbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBuscar.Location = new System.Drawing.Point(12, 20);
            this.grbBuscar.Name = "grbBuscar";
            this.grbBuscar.Size = new System.Drawing.Size(208, 595);
            this.grbBuscar.TabIndex = 0;
            this.grbBuscar.TabStop = false;
            this.grbBuscar.Text = "»   Buscar un producto:   «";
            this.grbBuscar.Paint += new System.Windows.Forms.PaintEventHandler(this.grbBuscar_Paint);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(99, 305);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(95, 23);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(99, 265);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(95, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Tag = "Buscar";
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboBProveedor
            // 
            this.cboBProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBProveedor.FormattingEnabled = true;
            this.cboBProveedor.Location = new System.Drawing.Point(14, 220);
            this.cboBProveedor.Name = "cboBProveedor";
            this.cboBProveedor.Size = new System.Drawing.Size(180, 21);
            this.cboBProveedor.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Proveedor:";
            // 
            // cboBCategoria
            // 
            this.cboBCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBCategoria.FormattingEnabled = true;
            this.cboBCategoria.Location = new System.Drawing.Point(14, 159);
            this.cboBCategoria.Name = "cboBCategoria";
            this.cboBCategoria.Size = new System.Drawing.Size(180, 21);
            this.cboBCategoria.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Categoría:";
            // 
            // txtBNombre
            // 
            this.txtBNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBNombre.Location = new System.Drawing.Point(14, 101);
            this.txtBNombre.Name = "txtBNombre";
            this.txtBNombre.Size = new System.Drawing.Size(180, 20);
            this.txtBNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            // 
            // txtBId
            // 
            this.txtBId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBId.Location = new System.Drawing.Point(14, 48);
            this.txtBId.Name = "txtBId";
            this.txtBId.Size = new System.Drawing.Size(100, 20);
            this.txtBId.TabIndex = 0;
            this.txtBId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBId_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // tabOperacion
            // 
            this.tabOperacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabOperacion.Controls.Add(this.tbpRegistrar);
            this.tabOperacion.Controls.Add(this.tbpModificar);
            this.tabOperacion.Controls.Add(this.tbpEliminar);
            this.tabOperacion.Location = new System.Drawing.Point(244, 20);
            this.tabOperacion.Name = "tabOperacion";
            this.tabOperacion.SelectedIndex = 0;
            this.tabOperacion.Size = new System.Drawing.Size(728, 56);
            this.tabOperacion.TabIndex = 1;
            this.tabOperacion.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabOperacion_Selected);
            // 
            // tbpRegistrar
            // 
            this.tbpRegistrar.Controls.Add(this.label5);
            this.tbpRegistrar.Location = new System.Drawing.Point(4, 22);
            this.tbpRegistrar.Name = "tbpRegistrar";
            this.tbpRegistrar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRegistrar.Size = new System.Drawing.Size(720, 30);
            this.tbpRegistrar.TabIndex = 0;
            this.tbpRegistrar.Text = "   Registrar un producto   ";
            this.tbpRegistrar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Proporcione los datos del producto a registrar.";
            // 
            // tbpModificar
            // 
            this.tbpModificar.Controls.Add(this.label6);
            this.tbpModificar.Location = new System.Drawing.Point(4, 22);
            this.tbpModificar.Name = "tbpModificar";
            this.tbpModificar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpModificar.Size = new System.Drawing.Size(720, 30);
            this.tbpModificar.TabIndex = 1;
            this.tbpModificar.Text = "   Modificar un producto   ";
            this.tbpModificar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(503, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Busque el producto a modificar y seleccionelo en la lista que se muestra, para qu" +
    "e pueda editar sus datos";
            // 
            // tbpEliminar
            // 
            this.tbpEliminar.Controls.Add(this.label7);
            this.tbpEliminar.Location = new System.Drawing.Point(4, 22);
            this.tbpEliminar.Name = "tbpEliminar";
            this.tbpEliminar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEliminar.Size = new System.Drawing.Size(720, 30);
            this.tbpEliminar.TabIndex = 2;
            this.tbpEliminar.Text = "   Eliminar un producto   ";
            this.tbpEliminar.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(338, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Busque el producto a eliminar y seleccionelo en la lista que se muestra";
            // 
            // dgvLista
            // 
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(244, 82);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(724, 196);
            this.dgvLista.TabIndex = 2;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            // 
            // grbProducto
            // 
            this.grbProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbProducto.Controls.Add(this.label12);
            this.grbProducto.Controls.Add(this.label11);
            this.grbProducto.Controls.Add(this.chkbDescontinuado);
            this.grbProducto.Controls.Add(this.txtPPedido);
            this.grbProducto.Controls.Add(this.txtUPedido);
            this.grbProducto.Controls.Add(this.txtUInventario);
            this.grbProducto.Controls.Add(this.txtPrecio);
            this.grbProducto.Controls.Add(this.txtCantidadxU);
            this.grbProducto.Controls.Add(this.txtProducto);
            this.grbProducto.Controls.Add(this.cboProveedor);
            this.grbProducto.Controls.Add(this.cboCategoria);
            this.grbProducto.Controls.Add(this.txtId);
            this.grbProducto.Controls.Add(this.btnAccion);
            this.grbProducto.Controls.Add(this.label10);
            this.grbProducto.Controls.Add(this.label9);
            this.grbProducto.Controls.Add(this.label8);
            this.grbProducto.Controls.Add(this.label13);
            this.grbProducto.Controls.Add(this.label14);
            this.grbProducto.Controls.Add(this.label15);
            this.grbProducto.Controls.Add(this.label16);
            this.grbProducto.Controls.Add(this.label17);
            this.grbProducto.Controls.Add(this.label18);
            this.grbProducto.Controls.Add(this.label19);
            this.grbProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbProducto.Location = new System.Drawing.Point(244, 284);
            this.grbProducto.Name = "grbProducto";
            this.grbProducto.Size = new System.Drawing.Size(724, 331);
            this.grbProducto.TabIndex = 3;
            this.grbProducto.TabStop = false;
            this.grbProducto.Text = "»   Producto   «";
            this.grbProducto.Paint += new System.Windows.Forms.PaintEventHandler(this.grbProducto_Paint);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(415, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(171, 30);
            this.label12.TabIndex = 0;
            this.label12.Text = "Cantidad mínima que se debe solicitar en un nuevo pedido";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(415, 240);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(171, 31);
            this.label11.TabIndex = 0;
            this.label11.Text = "Cantidad de unidades en el inventario en la cual se debe realizar un nuevo pedido" +
    "";
            // 
            // chkbDescontinuado
            // 
            this.chkbDescontinuado.AutoSize = true;
            this.chkbDescontinuado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbDescontinuado.Location = new System.Drawing.Point(309, 272);
            this.chkbDescontinuado.Name = "chkbDescontinuado";
            this.chkbDescontinuado.Size = new System.Drawing.Size(15, 14);
            this.chkbDescontinuado.TabIndex = 9;
            this.chkbDescontinuado.UseVisualStyleBackColor = true;
            // 
            // txtPPedido
            // 
            this.txtPPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPPedido.Location = new System.Drawing.Point(309, 243);
            this.txtPPedido.MaxLength = 5;
            this.txtPPedido.Name = "txtPPedido";
            this.txtPPedido.Size = new System.Drawing.Size(100, 20);
            this.txtPPedido.TabIndex = 8;
            this.txtPPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPPedido_KeyPress);
            this.txtPPedido.Validating += new System.ComponentModel.CancelEventHandler(this.txtPPedido_Validating);
            // 
            // txtUPedido
            // 
            this.txtUPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPedido.Location = new System.Drawing.Point(309, 215);
            this.txtUPedido.MaxLength = 5;
            this.txtUPedido.Name = "txtUPedido";
            this.txtUPedido.Size = new System.Drawing.Size(100, 20);
            this.txtUPedido.TabIndex = 7;
            this.txtUPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUPedido_KeyPress);
            this.txtUPedido.Validating += new System.ComponentModel.CancelEventHandler(this.txtUPedido_Validating);
            // 
            // txtUInventario
            // 
            this.txtUInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUInventario.Location = new System.Drawing.Point(309, 188);
            this.txtUInventario.MaxLength = 5;
            this.txtUInventario.Name = "txtUInventario";
            this.txtUInventario.Size = new System.Drawing.Size(100, 20);
            this.txtUInventario.TabIndex = 6;
            this.txtUInventario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUInventario_KeyPress);
            this.txtUInventario.Validating += new System.ComponentModel.CancelEventHandler(this.txtUInventario_Validating);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(309, 160);
            this.txtPrecio.MaxLength = 21;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(148, 20);
            this.txtPrecio.TabIndex = 5;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // txtCantidadxU
            // 
            this.txtCantidadxU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadxU.Location = new System.Drawing.Point(306, 132);
            this.txtCantidadxU.MaxLength = 20;
            this.txtCantidadxU.Name = "txtCantidadxU";
            this.txtCantidadxU.Size = new System.Drawing.Size(208, 20);
            this.txtCantidadxU.TabIndex = 4;
            // 
            // txtProducto
            // 
            this.txtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducto.Location = new System.Drawing.Point(306, 104);
            this.txtProducto.MaxLength = 40;
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(269, 20);
            this.txtProducto.TabIndex = 3;
            // 
            // cboProveedor
            // 
            this.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(306, 75);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(269, 21);
            this.cboProveedor.TabIndex = 2;
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(306, 47);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(269, 21);
            this.cboCategoria.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(306, 19);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 11;
            // 
            // btnAccion
            // 
            this.btnAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccion.Location = new System.Drawing.Point(417, 291);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(185, 23);
            this.btnAccion.TabIndex = 10;
            this.btnAccion.Text = "Registrar producto";
            this.btnAccion.UseVisualStyleBackColor = true;
            this.btnAccion.Click += new System.EventHandler(this.btnAccion_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(201, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Descontinuado:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(196, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Punto de pedido:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(176, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Unidades en pedido:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(158, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Unidades en inventario:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(253, 163);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Precio:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(172, 135);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(125, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Cantidad por unidad:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(275, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Id:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(235, 107);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Producto:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(228, 78);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Proveedor:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(230, 50);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Categoría:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmProductosCrudDap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.ControlBox = false;
            this.Controls.Add(this.grbProducto);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.tabOperacion);
            this.Controls.Add(this.grbBuscar);
            this.Name = "FrmProductosCrudDap";
            this.ShowIcon = false;
            this.Text = "Mantenimiento de productos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProductosCrudDap_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmProductosCrudDap_FormClosed);
            this.Load += new System.EventHandler(this.FrmProductosCrudDap_Load);
            this.grbBuscar.ResumeLayout(false);
            this.grbBuscar.PerformLayout();
            this.tabOperacion.ResumeLayout(false);
            this.tbpRegistrar.ResumeLayout(false);
            this.tbpRegistrar.PerformLayout();
            this.tbpModificar.ResumeLayout(false);
            this.tbpModificar.PerformLayout();
            this.tbpEliminar.ResumeLayout(false);
            this.tbpEliminar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.grbProducto.ResumeLayout(false);
            this.grbProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBuscar;
        private System.Windows.Forms.TextBox txtBId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TabControl tabOperacion;
        private System.Windows.Forms.TabPage tbpRegistrar;
        private System.Windows.Forms.TabPage tbpModificar;
        private System.Windows.Forms.TabPage tbpEliminar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.GroupBox grbProducto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkbDescontinuado;
        private System.Windows.Forms.TextBox txtPPedido;
        private System.Windows.Forms.TextBox txtUPedido;
        private System.Windows.Forms.TextBox txtUInventario;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtCantidadxU;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnAccion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}