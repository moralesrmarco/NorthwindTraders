namespace NorthwindTraders
{
    partial class FrmPedidosDetalleCrud
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbAgregarProducto = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.grbDetalle = new System.Windows.Forms.GroupBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ProductoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbPedido = new System.Windows.Forms.GroupBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.grbBuscar = new System.Windows.Forms.GroupBox();
            this.chkBFEnvioNull = new System.Windows.Forms.CheckBox();
            this.chkBFRequeridoNull = new System.Windows.Forms.CheckBox();
            this.chkBFPedidoNull = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtBDirigidoa = new System.Windows.Forms.TextBox();
            this.txtBCompañiaT = new System.Windows.Forms.TextBox();
            this.dtpBFEnvioFin = new System.Windows.Forms.DateTimePicker();
            this.dtpBFRequeridoFin = new System.Windows.Forms.DateTimePicker();
            this.dtpBFPedidoFin = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpBFEnvioIni = new System.Windows.Forms.DateTimePicker();
            this.dtpBFRequeridoIni = new System.Windows.Forms.DateTimePicker();
            this.dtpBFPedidoIni = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBIdFinal = new System.Windows.Forms.TextBox();
            this.txtBIdInicial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBEmpleado = new System.Windows.Forms.TextBox();
            this.txtBCliente = new System.Windows.Forms.TextBox();
            this.grbPedidos = new System.Windows.Forms.GroupBox();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.grbAgregarProducto.SuspendLayout();
            this.grbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.grbPedido.SuspendLayout();
            this.grbBuscar.SuspendLayout();
            this.grbPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.grbAgregarProducto);
            this.panel1.Controls.Add(this.grbDetalle);
            this.panel1.Controls.Add(this.grbPedido);
            this.panel1.Controls.Add(this.grbBuscar);
            this.panel1.Controls.Add(this.grbPedidos);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 761);
            this.panel1.TabIndex = 0;
            // 
            // grbAgregarProducto
            // 
            this.grbAgregarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbAgregarProducto.Controls.Add(this.btnAgregar);
            this.grbAgregarProducto.Controls.Add(this.txtDescuento);
            this.grbAgregarProducto.Controls.Add(this.txtCantidad);
            this.grbAgregarProducto.Controls.Add(this.txtPrecio);
            this.grbAgregarProducto.Controls.Add(this.label38);
            this.grbAgregarProducto.Controls.Add(this.label39);
            this.grbAgregarProducto.Controls.Add(this.label40);
            this.grbAgregarProducto.Controls.Add(this.cboProducto);
            this.grbAgregarProducto.Controls.Add(this.cboCategoria);
            this.grbAgregarProducto.Controls.Add(this.label37);
            this.grbAgregarProducto.Controls.Add(this.label36);
            this.grbAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbAgregarProducto.Location = new System.Drawing.Point(344, 671);
            this.grbAgregarProducto.Name = "grbAgregarProducto";
            this.grbAgregarProducto.Size = new System.Drawing.Size(833, 80);
            this.grbAgregarProducto.TabIndex = 3;
            this.grbAgregarProducto.TabStop = false;
            this.grbAgregarProducto.Text = "»   Agregar producto:   «";
            this.grbAgregarProducto.Paint += new System.Windows.Forms.PaintEventHandler(this.grbPaint);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(672, 43);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(30, 30);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "+";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(504, 48);
            this.txtDescuento.MaxLength = 4;
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(124, 20);
            this.txtDescuento.TabIndex = 4;
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(296, 48);
            this.txtCantidad.MaxLength = 15;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(128, 20);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidad_Validating);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(96, 48);
            this.txtPrecio.MaxLength = 15;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(128, 20);
            this.txtPrecio.TabIndex = 2;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(432, 52);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(72, 13);
            this.label38.TabIndex = 7;
            this.label38.Text = "Descuento:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(232, 52);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(61, 13);
            this.label39.TabIndex = 6;
            this.label39.Text = "Cantidad:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(45, 52);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(47, 13);
            this.label40.TabIndex = 5;
            this.label40.Text = "Precio:";
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(504, 16);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(296, 21);
            this.cboProducto.TabIndex = 1;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
            // 
            // cboCategoria
            // 
            this.cboCategoria.BackColor = System.Drawing.SystemColors.Window;
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(96, 16);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(296, 21);
            this.cboCategoria.TabIndex = 0;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(442, 20);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(62, 13);
            this.label37.TabIndex = 0;
            this.label37.Text = "Producto:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(25, 20);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(67, 13);
            this.label36.TabIndex = 0;
            this.label36.Text = "Categoría:";
            // 
            // grbDetalle
            // 
            this.grbDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDetalle.Controls.Add(this.dgvDetalle);
            this.grbDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDetalle.Location = new System.Drawing.Point(344, 416);
            this.grbDetalle.Name = "grbDetalle";
            this.grbDetalle.Size = new System.Drawing.Size(832, 240);
            this.grbDetalle.TabIndex = 4;
            this.grbDetalle.TabStop = false;
            this.grbDetalle.Text = "»   Detalle del pedido:   «";
            this.grbDetalle.Paint += new System.Windows.Forms.PaintEventHandler(this.grbPaint);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Producto,
            this.Precio,
            this.Cantidad,
            this.Descuento,
            this.Importe,
            this.Modificar,
            this.Eliminar,
            this.ProductoId});
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(3, 16);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(826, 221);
            this.dgvDetalle.TabIndex = 0;
            this.dgvDetalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellClick);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 43;
            // 
            // Producto
            // 
            this.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.Width = 68;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 82;
            // 
            // Descuento
            // 
            this.Descuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            this.Descuento.Width = 93;
            // 
            // Importe
            // 
            this.Importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.Width = 74;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar producto";
            this.Modificar.Name = "Modificar";
            this.Modificar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Modificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Eliminar
            // 
            this.Eliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Eliminar.HeaderText = "Eliminar producto";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ProductoId
            // 
            this.ProductoId.HeaderText = "ProductoId";
            this.ProductoId.Name = "ProductoId";
            this.ProductoId.Visible = false;
            // 
            // grbPedido
            // 
            this.grbPedido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPedido.Controls.Add(this.txtTotal);
            this.grbPedido.Controls.Add(this.txtCliente);
            this.grbPedido.Controls.Add(this.txtId);
            this.grbPedido.Controls.Add(this.label3);
            this.grbPedido.Controls.Add(this.label20);
            this.grbPedido.Controls.Add(this.label19);
            this.grbPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPedido.Location = new System.Drawing.Point(344, 304);
            this.grbPedido.Name = "grbPedido";
            this.grbPedido.Size = new System.Drawing.Size(833, 104);
            this.grbPedido.TabIndex = 2;
            this.grbPedido.TabStop = false;
            this.grbPedido.Text = "»   Pedido:   «";
            this.grbPedido.Paint += new System.Windows.Forms.PaintEventHandler(this.grbPaint);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Location = new System.Drawing.Point(104, 72);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(256, 20);
            this.txtTotal.TabIndex = 2;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.White;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(104, 48);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(696, 20);
            this.txtCliente.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(104, 24);
            this.txtId.MaxLength = 10;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Total:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(52, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 13);
            this.label20.TabIndex = 12;
            this.label20.Text = "Cliente:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(80, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(22, 13);
            this.label19.TabIndex = 13;
            this.label19.Text = "Id:";
            // 
            // grbBuscar
            // 
            this.grbBuscar.Controls.Add(this.chkBFEnvioNull);
            this.grbBuscar.Controls.Add(this.chkBFRequeridoNull);
            this.grbBuscar.Controls.Add(this.chkBFPedidoNull);
            this.grbBuscar.Controls.Add(this.btnBuscar);
            this.grbBuscar.Controls.Add(this.btnLimpiar);
            this.grbBuscar.Controls.Add(this.txtBDirigidoa);
            this.grbBuscar.Controls.Add(this.txtBCompañiaT);
            this.grbBuscar.Controls.Add(this.dtpBFEnvioFin);
            this.grbBuscar.Controls.Add(this.dtpBFRequeridoFin);
            this.grbBuscar.Controls.Add(this.dtpBFPedidoFin);
            this.grbBuscar.Controls.Add(this.label17);
            this.grbBuscar.Controls.Add(this.label15);
            this.grbBuscar.Controls.Add(this.label13);
            this.grbBuscar.Controls.Add(this.dtpBFEnvioIni);
            this.grbBuscar.Controls.Add(this.dtpBFRequeridoIni);
            this.grbBuscar.Controls.Add(this.dtpBFPedidoIni);
            this.grbBuscar.Controls.Add(this.label16);
            this.grbBuscar.Controls.Add(this.label14);
            this.grbBuscar.Controls.Add(this.label12);
            this.grbBuscar.Controls.Add(this.label11);
            this.grbBuscar.Controls.Add(this.label10);
            this.grbBuscar.Controls.Add(this.label7);
            this.grbBuscar.Controls.Add(this.label6);
            this.grbBuscar.Controls.Add(this.label5);
            this.grbBuscar.Controls.Add(this.label18);
            this.grbBuscar.Controls.Add(this.label9);
            this.grbBuscar.Controls.Add(this.txtBIdFinal);
            this.grbBuscar.Controls.Add(this.txtBIdInicial);
            this.grbBuscar.Controls.Add(this.label4);
            this.grbBuscar.Controls.Add(this.label8);
            this.grbBuscar.Controls.Add(this.txtBEmpleado);
            this.grbBuscar.Controls.Add(this.txtBCliente);
            this.grbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBuscar.Location = new System.Drawing.Point(24, 304);
            this.grbBuscar.Name = "grbBuscar";
            this.grbBuscar.Size = new System.Drawing.Size(304, 448);
            this.grbBuscar.TabIndex = 1;
            this.grbBuscar.TabStop = false;
            this.grbBuscar.Text = "»   Buscar un pedido:   «";
            this.grbBuscar.Paint += new System.Windows.Forms.PaintEventHandler(this.grbPaint);
            // 
            // chkBFEnvioNull
            // 
            this.chkBFEnvioNull.AutoSize = true;
            this.chkBFEnvioNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBFEnvioNull.Location = new System.Drawing.Point(193, 159);
            this.chkBFEnvioNull.Name = "chkBFEnvioNull";
            this.chkBFEnvioNull.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBFEnvioNull.Size = new System.Drawing.Size(85, 16);
            this.chkBFEnvioNull.TabIndex = 9;
            this.chkBFEnvioNull.Text = "Fecha = null";
            this.chkBFEnvioNull.UseVisualStyleBackColor = true;
            this.chkBFEnvioNull.CheckedChanged += new System.EventHandler(this.chkBFEnvioNull_CheckedChanged);
            // 
            // chkBFRequeridoNull
            // 
            this.chkBFRequeridoNull.AutoSize = true;
            this.chkBFRequeridoNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBFRequeridoNull.Location = new System.Drawing.Point(193, 117);
            this.chkBFRequeridoNull.Name = "chkBFRequeridoNull";
            this.chkBFRequeridoNull.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBFRequeridoNull.Size = new System.Drawing.Size(85, 16);
            this.chkBFRequeridoNull.TabIndex = 6;
            this.chkBFRequeridoNull.Text = "Fecha = null";
            this.chkBFRequeridoNull.UseVisualStyleBackColor = true;
            this.chkBFRequeridoNull.CheckedChanged += new System.EventHandler(this.chkBFRequeridoNull_CheckedChanged);
            // 
            // chkBFPedidoNull
            // 
            this.chkBFPedidoNull.AutoSize = true;
            this.chkBFPedidoNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBFPedidoNull.Location = new System.Drawing.Point(193, 71);
            this.chkBFPedidoNull.Name = "chkBFPedidoNull";
            this.chkBFPedidoNull.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBFPedidoNull.Size = new System.Drawing.Size(85, 16);
            this.chkBFPedidoNull.TabIndex = 3;
            this.chkBFPedidoNull.Text = "Fecha = null";
            this.chkBFPedidoNull.UseVisualStyleBackColor = true;
            this.chkBFPedidoNull.CheckedChanged += new System.EventHandler(this.chkBFPedidoNull_CheckedChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(216, 309);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(128, 309);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtBDirigidoa
            // 
            this.txtBDirigidoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDirigidoa.Location = new System.Drawing.Point(88, 277);
            this.txtBDirigidoa.MaxLength = 40;
            this.txtBDirigidoa.Name = "txtBDirigidoa";
            this.txtBDirigidoa.Size = new System.Drawing.Size(200, 20);
            this.txtBDirigidoa.TabIndex = 14;
            // 
            // txtBCompañiaT
            // 
            this.txtBCompañiaT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCompañiaT.Location = new System.Drawing.Point(88, 253);
            this.txtBCompañiaT.MaxLength = 40;
            this.txtBCompañiaT.Name = "txtBCompañiaT";
            this.txtBCompañiaT.Size = new System.Drawing.Size(200, 20);
            this.txtBCompañiaT.TabIndex = 13;
            // 
            // dtpBFEnvioFin
            // 
            this.dtpBFEnvioFin.Checked = false;
            this.dtpBFEnvioFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFEnvioFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFEnvioFin.Location = new System.Drawing.Point(192, 176);
            this.dtpBFEnvioFin.Name = "dtpBFEnvioFin";
            this.dtpBFEnvioFin.ShowCheckBox = true;
            this.dtpBFEnvioFin.Size = new System.Drawing.Size(96, 20);
            this.dtpBFEnvioFin.TabIndex = 11;
            this.dtpBFEnvioFin.ValueChanged += new System.EventHandler(this.dtpBFEnvioFin_ValueChanged);
            // 
            // dtpBFRequeridoFin
            // 
            this.dtpBFRequeridoFin.Checked = false;
            this.dtpBFRequeridoFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFRequeridoFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFRequeridoFin.Location = new System.Drawing.Point(192, 136);
            this.dtpBFRequeridoFin.Name = "dtpBFRequeridoFin";
            this.dtpBFRequeridoFin.ShowCheckBox = true;
            this.dtpBFRequeridoFin.Size = new System.Drawing.Size(96, 20);
            this.dtpBFRequeridoFin.TabIndex = 8;
            this.dtpBFRequeridoFin.ValueChanged += new System.EventHandler(this.dtpBFRequeridoFin_ValueChanged);
            // 
            // dtpBFPedidoFin
            // 
            this.dtpBFPedidoFin.Checked = false;
            this.dtpBFPedidoFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFPedidoFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFPedidoFin.Location = new System.Drawing.Point(192, 95);
            this.dtpBFPedidoFin.Name = "dtpBFPedidoFin";
            this.dtpBFPedidoFin.ShowCheckBox = true;
            this.dtpBFPedidoFin.Size = new System.Drawing.Size(96, 20);
            this.dtpBFPedidoFin.TabIndex = 5;
            this.dtpBFPedidoFin.ValueChanged += new System.EventHandler(this.dtpBFPedidoFin_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(152, 176);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 12);
            this.label17.TabIndex = 26;
            this.label17.Text = "Fecha";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(152, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 12);
            this.label15.TabIndex = 26;
            this.label15.Text = "Fecha";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(152, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 12);
            this.label13.TabIndex = 26;
            this.label13.Text = "Fecha";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpBFEnvioIni
            // 
            this.dtpBFEnvioIni.Checked = false;
            this.dtpBFEnvioIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFEnvioIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFEnvioIni.Location = new System.Drawing.Point(56, 176);
            this.dtpBFEnvioIni.Name = "dtpBFEnvioIni";
            this.dtpBFEnvioIni.ShowCheckBox = true;
            this.dtpBFEnvioIni.Size = new System.Drawing.Size(95, 20);
            this.dtpBFEnvioIni.TabIndex = 10;
            this.dtpBFEnvioIni.ValueChanged += new System.EventHandler(this.dtpBFEnvioIni_ValueChanged);
            // 
            // dtpBFRequeridoIni
            // 
            this.dtpBFRequeridoIni.Checked = false;
            this.dtpBFRequeridoIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFRequeridoIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFRequeridoIni.Location = new System.Drawing.Point(56, 136);
            this.dtpBFRequeridoIni.Name = "dtpBFRequeridoIni";
            this.dtpBFRequeridoIni.ShowCheckBox = true;
            this.dtpBFRequeridoIni.Size = new System.Drawing.Size(95, 20);
            this.dtpBFRequeridoIni.TabIndex = 7;
            this.dtpBFRequeridoIni.ValueChanged += new System.EventHandler(this.dtpBFRequeridoIni_ValueChanged);
            // 
            // dtpBFPedidoIni
            // 
            this.dtpBFPedidoIni.Checked = false;
            this.dtpBFPedidoIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFPedidoIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFPedidoIni.Location = new System.Drawing.Point(56, 94);
            this.dtpBFPedidoIni.Name = "dtpBFPedidoIni";
            this.dtpBFPedidoIni.ShowCheckBox = true;
            this.dtpBFPedidoIni.Size = new System.Drawing.Size(95, 20);
            this.dtpBFPedidoIni.TabIndex = 4;
            this.dtpBFPedidoIni.ValueChanged += new System.EventHandler(this.dtpBFPedidoIni_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(16, 176);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 12);
            this.label16.TabIndex = 24;
            this.label16.Text = "Fecha";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(16, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 12);
            this.label14.TabIndex = 24;
            this.label14.Text = "Fecha";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "Fecha";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 280);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Dirigido a:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Compañía transportista:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Fecha de envío:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Fecha requerido:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Fecha de pedido:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 211);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "Empleado:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Cliente:";
            // 
            // txtBIdFinal
            // 
            this.txtBIdFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBIdFinal.Location = new System.Drawing.Point(189, 24);
            this.txtBIdFinal.MaxLength = 10;
            this.txtBIdFinal.Name = "txtBIdFinal";
            this.txtBIdFinal.Size = new System.Drawing.Size(100, 20);
            this.txtBIdFinal.TabIndex = 1;
            this.txtBIdFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBIdFinal_KeyPress);
            // 
            // txtBIdInicial
            // 
            this.txtBIdInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBIdInicial.Location = new System.Drawing.Point(54, 24);
            this.txtBIdInicial.MaxLength = 10;
            this.txtBIdInicial.Name = "txtBIdInicial";
            this.txtBIdInicial.Size = new System.Drawing.Size(100, 20);
            this.txtBIdInicial.TabIndex = 0;
            this.txtBIdInicial.TextChanged += new System.EventHandler(this.txtBIdInicial_TextChanged);
            this.txtBIdInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBIdInicial_KeyPress);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(157, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 26);
            this.label4.TabIndex = 21;
            this.label4.Text = "Id final:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 26);
            this.label8.TabIndex = 21;
            this.label8.Text = "Id inicial:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBEmpleado
            // 
            this.txtBEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBEmpleado.Location = new System.Drawing.Point(88, 208);
            this.txtBEmpleado.MaxLength = 40;
            this.txtBEmpleado.Name = "txtBEmpleado";
            this.txtBEmpleado.Size = new System.Drawing.Size(201, 20);
            this.txtBEmpleado.TabIndex = 12;
            // 
            // txtBCliente
            // 
            this.txtBCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCliente.Location = new System.Drawing.Point(88, 48);
            this.txtBCliente.MaxLength = 40;
            this.txtBCliente.Name = "txtBCliente";
            this.txtBCliente.Size = new System.Drawing.Size(201, 20);
            this.txtBCliente.TabIndex = 2;
            // 
            // grbPedidos
            // 
            this.grbPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPedidos.Controls.Add(this.dgvPedidos);
            this.grbPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPedidos.Location = new System.Drawing.Point(22, 48);
            this.grbPedidos.Name = "grbPedidos";
            this.grbPedidos.Size = new System.Drawing.Size(1157, 240);
            this.grbPedidos.TabIndex = 0;
            this.grbPedidos.TabStop = false;
            this.grbPedidos.Text = "»   Pedidos:   «";
            this.grbPedidos.Paint += new System.Windows.Forms.PaintEventHandler(this.grbPaint);
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidos.Location = new System.Drawing.Point(3, 16);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.Size = new System.Drawing.Size(1151, 221);
            this.dgvPedidos.TabIndex = 0;
            this.dgvPedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(40, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Busque el pedido y seleccionelo en la lista que se muestra";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(24, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1153, 32);
            this.label1.TabIndex = 2;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmPedidosDetalleCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "FrmPedidosDetalleCrud";
            this.Text = "Mantenimiento de detalle de pedidos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPedidosDetalleCrud_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPedidosDetalleCrud_FormClosed);
            this.Load += new System.EventHandler(this.FrmPedidosDetalleCrud_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbAgregarProducto.ResumeLayout(false);
            this.grbAgregarProducto.PerformLayout();
            this.grbDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.grbPedido.ResumeLayout(false);
            this.grbPedido.PerformLayout();
            this.grbBuscar.ResumeLayout(false);
            this.grbBuscar.PerformLayout();
            this.grbPedidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbPedidos;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.GroupBox grbBuscar;
        private System.Windows.Forms.CheckBox chkBFEnvioNull;
        private System.Windows.Forms.CheckBox chkBFRequeridoNull;
        private System.Windows.Forms.CheckBox chkBFPedidoNull;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtBDirigidoa;
        private System.Windows.Forms.TextBox txtBCompañiaT;
        private System.Windows.Forms.DateTimePicker dtpBFEnvioFin;
        private System.Windows.Forms.DateTimePicker dtpBFRequeridoFin;
        private System.Windows.Forms.DateTimePicker dtpBFPedidoFin;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpBFEnvioIni;
        private System.Windows.Forms.DateTimePicker dtpBFRequeridoIni;
        private System.Windows.Forms.DateTimePicker dtpBFPedidoIni;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBIdInicial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBEmpleado;
        private System.Windows.Forms.TextBox txtBCliente;
        private System.Windows.Forms.GroupBox grbPedido;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox grbDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.GroupBox grbAgregarProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtBIdFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoId;
    }
}