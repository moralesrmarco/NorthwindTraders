namespace NorthwindTraders
{
    partial class FrmClientesCrud
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
            this.tabcOperacion = new System.Windows.Forms.TabControl();
            this.tbpListar = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpRegistrar = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tbpModificar = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tbpEliminar = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.grbClientes = new System.Windows.Forms.GroupBox();
            this.grbBuscar = new System.Windows.Forms.GroupBox();
            this.cboBPais = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBFax = new System.Windows.Forms.TextBox();
            this.txtBTelefono = new System.Windows.Forms.TextBox();
            this.txtBCodigoP = new System.Windows.Forms.TextBox();
            this.txtBRegion = new System.Windows.Forms.TextBox();
            this.txtBCiudad = new System.Windows.Forms.TextBox();
            this.txtBDomicilio = new System.Windows.Forms.TextBox();
            this.txtBContacto = new System.Windows.Forms.TextBox();
            this.txtBCompañia = new System.Windows.Forms.TextBox();
            this.grbCliente = new System.Windows.Forms.GroupBox();
            this.btnOperacion = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCodigoP = new System.Windows.Forms.TextBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.txtCompañia = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabcOperacion.SuspendLayout();
            this.tbpListar.SuspendLayout();
            this.tbpRegistrar.SuspendLayout();
            this.tbpModificar.SuspendLayout();
            this.tbpEliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.grbClientes.SuspendLayout();
            this.grbBuscar.SuspendLayout();
            this.grbCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabcOperacion
            // 
            this.tabcOperacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabcOperacion.Controls.Add(this.tbpListar);
            this.tabcOperacion.Controls.Add(this.tbpRegistrar);
            this.tabcOperacion.Controls.Add(this.tbpModificar);
            this.tabcOperacion.Controls.Add(this.tbpEliminar);
            this.tabcOperacion.Location = new System.Drawing.Point(16, 8);
            this.tabcOperacion.Name = "tabcOperacion";
            this.tabcOperacion.SelectedIndex = 0;
            this.tabcOperacion.Size = new System.Drawing.Size(950, 56);
            this.tabcOperacion.TabIndex = 0;
            this.tabcOperacion.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabcOperacion_Selected);
            // 
            // tbpListar
            // 
            this.tbpListar.Controls.Add(this.label1);
            this.tbpListar.Location = new System.Drawing.Point(4, 22);
            this.tbpListar.Name = "tbpListar";
            this.tbpListar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpListar.Size = new System.Drawing.Size(942, 30);
            this.tbpListar.TabIndex = 0;
            this.tbpListar.Text = "   Consultar cliente   ";
            this.tbpListar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione un cliente para ver su detalle";
            // 
            // tbpRegistrar
            // 
            this.tbpRegistrar.Controls.Add(this.label2);
            this.tbpRegistrar.Location = new System.Drawing.Point(4, 22);
            this.tbpRegistrar.Name = "tbpRegistrar";
            this.tbpRegistrar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRegistrar.Size = new System.Drawing.Size(942, 30);
            this.tbpRegistrar.TabIndex = 1;
            this.tbpRegistrar.Text = "   Registrar cliente   ";
            this.tbpRegistrar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Proporcione los datos del cliente a registrar";
            // 
            // tbpModificar
            // 
            this.tbpModificar.Controls.Add(this.label3);
            this.tbpModificar.Location = new System.Drawing.Point(4, 22);
            this.tbpModificar.Name = "tbpModificar";
            this.tbpModificar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpModificar.Size = new System.Drawing.Size(942, 30);
            this.tbpModificar.TabIndex = 2;
            this.tbpModificar.Text = "   Modificar cliente   ";
            this.tbpModificar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(451, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Busque el cliente y seleccionelo en la lista que se muestra para que pueda módifi" +
    "car sus datos";
            // 
            // tbpEliminar
            // 
            this.tbpEliminar.Controls.Add(this.label4);
            this.tbpEliminar.Location = new System.Drawing.Point(4, 22);
            this.tbpEliminar.Name = "tbpEliminar";
            this.tbpEliminar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEliminar.Size = new System.Drawing.Size(942, 30);
            this.tbpEliminar.TabIndex = 3;
            this.tbpEliminar.Text = "   Eliminar cliente   ";
            this.tbpEliminar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(661, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Busque el cliente a eliminar y seleccionelo en la lista que se muestra, no se pue" +
    "den eliminar clientes que ya estan relacionados a un pedido";
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(3, 16);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(946, 221);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // grbClientes
            // 
            this.grbClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbClientes.Controls.Add(this.dgv);
            this.grbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbClientes.Location = new System.Drawing.Point(16, 64);
            this.grbClientes.Name = "grbClientes";
            this.grbClientes.Size = new System.Drawing.Size(952, 240);
            this.grbClientes.TabIndex = 1;
            this.grbClientes.TabStop = false;
            this.grbClientes.Text = "»   Clientes:   «";
            this.grbClientes.Paint += new System.Windows.Forms.PaintEventHandler(this.grbPaint);
            // 
            // grbBuscar
            // 
            this.grbBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grbBuscar.Controls.Add(this.cboBPais);
            this.grbBuscar.Controls.Add(this.label14);
            this.grbBuscar.Controls.Add(this.label13);
            this.grbBuscar.Controls.Add(this.label12);
            this.grbBuscar.Controls.Add(this.label11);
            this.grbBuscar.Controls.Add(this.label10);
            this.grbBuscar.Controls.Add(this.label7);
            this.grbBuscar.Controls.Add(this.label6);
            this.grbBuscar.Controls.Add(this.label5);
            this.grbBuscar.Controls.Add(this.label9);
            this.grbBuscar.Controls.Add(this.txtBId);
            this.grbBuscar.Controls.Add(this.label8);
            this.grbBuscar.Controls.Add(this.btnLimpiar);
            this.grbBuscar.Controls.Add(this.btnBuscar);
            this.grbBuscar.Controls.Add(this.txtBFax);
            this.grbBuscar.Controls.Add(this.txtBTelefono);
            this.grbBuscar.Controls.Add(this.txtBCodigoP);
            this.grbBuscar.Controls.Add(this.txtBRegion);
            this.grbBuscar.Controls.Add(this.txtBCiudad);
            this.grbBuscar.Controls.Add(this.txtBDomicilio);
            this.grbBuscar.Controls.Add(this.txtBContacto);
            this.grbBuscar.Controls.Add(this.txtBCompañia);
            this.grbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBuscar.Location = new System.Drawing.Point(16, 312);
            this.grbBuscar.Name = "grbBuscar";
            this.grbBuscar.Size = new System.Drawing.Size(304, 304);
            this.grbBuscar.TabIndex = 2;
            this.grbBuscar.TabStop = false;
            this.grbBuscar.Text = "»   Buscar un cliente:   «";
            this.grbBuscar.Paint += new System.Windows.Forms.PaintEventHandler(this.grbPaint);
            // 
            // cboBPais
            // 
            this.cboBPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBPais.FormattingEnabled = true;
            this.cboBPais.Location = new System.Drawing.Point(96, 192);
            this.cboBPais.Name = "cboBPais";
            this.cboBPais.Size = new System.Drawing.Size(200, 21);
            this.cboBPais.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(56, 243);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Fax:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 219);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Teléfono:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 195);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "País:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Código postal:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Región";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Domicilio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ciudad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Contacto:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Compañía:";
            // 
            // txtBId
            // 
            this.txtBId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBId.Location = new System.Drawing.Point(96, 24);
            this.txtBId.MaxLength = 5;
            this.txtBId.Name = "txtBId";
            this.txtBId.Size = new System.Drawing.Size(100, 20);
            this.txtBId.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Id:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(96, 272);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(99, 23);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(200, 272);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(99, 23);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBFax
            // 
            this.txtBFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBFax.Location = new System.Drawing.Point(96, 240);
            this.txtBFax.MaxLength = 24;
            this.txtBFax.Name = "txtBFax";
            this.txtBFax.Size = new System.Drawing.Size(201, 20);
            this.txtBFax.TabIndex = 9;
            // 
            // txtBTelefono
            // 
            this.txtBTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBTelefono.Location = new System.Drawing.Point(96, 216);
            this.txtBTelefono.MaxLength = 24;
            this.txtBTelefono.Name = "txtBTelefono";
            this.txtBTelefono.Size = new System.Drawing.Size(201, 20);
            this.txtBTelefono.TabIndex = 8;
            // 
            // txtBCodigoP
            // 
            this.txtBCodigoP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCodigoP.Location = new System.Drawing.Point(96, 168);
            this.txtBCodigoP.MaxLength = 10;
            this.txtBCodigoP.Name = "txtBCodigoP";
            this.txtBCodigoP.Size = new System.Drawing.Size(120, 20);
            this.txtBCodigoP.TabIndex = 6;
            // 
            // txtBRegion
            // 
            this.txtBRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBRegion.Location = new System.Drawing.Point(96, 144);
            this.txtBRegion.MaxLength = 15;
            this.txtBRegion.Name = "txtBRegion";
            this.txtBRegion.Size = new System.Drawing.Size(120, 20);
            this.txtBRegion.TabIndex = 5;
            // 
            // txtBCiudad
            // 
            this.txtBCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCiudad.Location = new System.Drawing.Point(96, 120);
            this.txtBCiudad.MaxLength = 15;
            this.txtBCiudad.Name = "txtBCiudad";
            this.txtBCiudad.Size = new System.Drawing.Size(120, 20);
            this.txtBCiudad.TabIndex = 4;
            // 
            // txtBDomicilio
            // 
            this.txtBDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDomicilio.Location = new System.Drawing.Point(96, 96);
            this.txtBDomicilio.MaxLength = 60;
            this.txtBDomicilio.Name = "txtBDomicilio";
            this.txtBDomicilio.Size = new System.Drawing.Size(201, 20);
            this.txtBDomicilio.TabIndex = 3;
            // 
            // txtBContacto
            // 
            this.txtBContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBContacto.Location = new System.Drawing.Point(96, 72);
            this.txtBContacto.MaxLength = 30;
            this.txtBContacto.Name = "txtBContacto";
            this.txtBContacto.Size = new System.Drawing.Size(201, 20);
            this.txtBContacto.TabIndex = 2;
            // 
            // txtBCompañia
            // 
            this.txtBCompañia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCompañia.Location = new System.Drawing.Point(96, 48);
            this.txtBCompañia.MaxLength = 40;
            this.txtBCompañia.Name = "txtBCompañia";
            this.txtBCompañia.Size = new System.Drawing.Size(201, 20);
            this.txtBCompañia.TabIndex = 1;
            // 
            // grbCliente
            // 
            this.grbCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbCliente.Controls.Add(this.btnOperacion);
            this.grbCliente.Controls.Add(this.label15);
            this.grbCliente.Controls.Add(this.label16);
            this.grbCliente.Controls.Add(this.label17);
            this.grbCliente.Controls.Add(this.label18);
            this.grbCliente.Controls.Add(this.label19);
            this.grbCliente.Controls.Add(this.label20);
            this.grbCliente.Controls.Add(this.label21);
            this.grbCliente.Controls.Add(this.label25);
            this.grbCliente.Controls.Add(this.label22);
            this.grbCliente.Controls.Add(this.label23);
            this.grbCliente.Controls.Add(this.txtId);
            this.grbCliente.Controls.Add(this.label24);
            this.grbCliente.Controls.Add(this.txtFax);
            this.grbCliente.Controls.Add(this.txtPais);
            this.grbCliente.Controls.Add(this.txtTelefono);
            this.grbCliente.Controls.Add(this.txtCodigoP);
            this.grbCliente.Controls.Add(this.txtRegion);
            this.grbCliente.Controls.Add(this.txtCiudad);
            this.grbCliente.Controls.Add(this.txtDomicilio);
            this.grbCliente.Controls.Add(this.txtTitulo);
            this.grbCliente.Controls.Add(this.txtContacto);
            this.grbCliente.Controls.Add(this.txtCompañia);
            this.grbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCliente.Location = new System.Drawing.Point(344, 312);
            this.grbCliente.Name = "grbCliente";
            this.grbCliente.Size = new System.Drawing.Size(624, 304);
            this.grbCliente.TabIndex = 3;
            this.grbCliente.TabStop = false;
            this.grbCliente.Text = "»   Cliente:   «";
            this.grbCliente.Paint += new System.Windows.Forms.PaintEventHandler(this.grbPaint);
            // 
            // btnOperacion
            // 
            this.btnOperacion.Enabled = false;
            this.btnOperacion.Location = new System.Drawing.Point(400, 266);
            this.btnOperacion.Name = "btnOperacion";
            this.btnOperacion.Size = new System.Drawing.Size(167, 23);
            this.btnOperacion.TabIndex = 11;
            this.btnOperacion.Text = "Registrar cliente";
            this.btnOperacion.UseVisualStyleBackColor = true;
            this.btnOperacion.Visible = false;
            this.btnOperacion.Click += new System.EventHandler(this.btnOperacion_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(120, 270);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "Fax:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(96, 246);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Teléfono:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(120, 222);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 22;
            this.label17.Text = "País:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(69, 198);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 13);
            this.label18.TabIndex = 21;
            this.label18.Text = "Código postal:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(110, 174);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 20;
            this.label19.Text = "Región";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(95, 126);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = "Domicilio:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(107, 150);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 13);
            this.label21.TabIndex = 18;
            this.label21.Text = "Ciudad:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(41, 102);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(117, 13);
            this.label25.TabIndex = 25;
            this.label25.Text = "Título de contacto:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(31, 78);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(126, 13);
            this.label22.TabIndex = 25;
            this.label22.Text = "Nombre de contacto:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(26, 54);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(132, 13);
            this.label23.TabIndex = 17;
            this.label23.Text = "Nombre de compañía:";
            // 
            // txtId
            // 
            this.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(160, 27);
            this.txtId.MaxLength = 5;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 0;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(135, 30);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(22, 13);
            this.label24.TabIndex = 15;
            this.label24.Text = "Id:";
            // 
            // txtFax
            // 
            this.txtFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(160, 267);
            this.txtFax.MaxLength = 24;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(201, 20);
            this.txtFax.TabIndex = 10;
            // 
            // txtPais
            // 
            this.txtPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPais.Location = new System.Drawing.Point(160, 219);
            this.txtPais.MaxLength = 15;
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(201, 20);
            this.txtPais.TabIndex = 8;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(160, 243);
            this.txtTelefono.MaxLength = 24;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(201, 20);
            this.txtTelefono.TabIndex = 9;
            // 
            // txtCodigoP
            // 
            this.txtCodigoP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoP.Location = new System.Drawing.Point(160, 195);
            this.txtCodigoP.MaxLength = 10;
            this.txtCodigoP.Name = "txtCodigoP";
            this.txtCodigoP.Size = new System.Drawing.Size(150, 20);
            this.txtCodigoP.TabIndex = 7;
            // 
            // txtRegion
            // 
            this.txtRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegion.Location = new System.Drawing.Point(160, 171);
            this.txtRegion.MaxLength = 15;
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(150, 20);
            this.txtRegion.TabIndex = 6;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiudad.Location = new System.Drawing.Point(160, 147);
            this.txtCiudad.MaxLength = 15;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(150, 20);
            this.txtCiudad.TabIndex = 5;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomicilio.Location = new System.Drawing.Point(160, 123);
            this.txtDomicilio.MaxLength = 60;
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(300, 20);
            this.txtDomicilio.TabIndex = 4;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(160, 99);
            this.txtTitulo.MaxLength = 30;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(260, 20);
            this.txtTitulo.TabIndex = 3;
            // 
            // txtContacto
            // 
            this.txtContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContacto.Location = new System.Drawing.Point(160, 75);
            this.txtContacto.MaxLength = 30;
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(300, 20);
            this.txtContacto.TabIndex = 2;
            // 
            // txtCompañia
            // 
            this.txtCompañia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompañia.Location = new System.Drawing.Point(160, 51);
            this.txtCompañia.MaxLength = 40;
            this.txtCompañia.Name = "txtCompañia";
            this.txtCompañia.Size = new System.Drawing.Size(300, 20);
            this.txtCompañia.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmClientesCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.ControlBox = false;
            this.Controls.Add(this.grbCliente);
            this.Controls.Add(this.grbBuscar);
            this.Controls.Add(this.grbClientes);
            this.Controls.Add(this.tabcOperacion);
            this.Name = "FrmClientesCrud";
            this.Text = "Mantenimiento de clientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmClientesCrud_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmClientesCrud_FormClosed);
            this.Load += new System.EventHandler(this.FrmClientesCrud_Load);
            this.tabcOperacion.ResumeLayout(false);
            this.tbpListar.ResumeLayout(false);
            this.tbpListar.PerformLayout();
            this.tbpRegistrar.ResumeLayout(false);
            this.tbpRegistrar.PerformLayout();
            this.tbpModificar.ResumeLayout(false);
            this.tbpModificar.PerformLayout();
            this.tbpEliminar.ResumeLayout(false);
            this.tbpEliminar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.grbClientes.ResumeLayout(false);
            this.grbBuscar.ResumeLayout(false);
            this.grbBuscar.PerformLayout();
            this.grbCliente.ResumeLayout(false);
            this.grbCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabcOperacion;
        private System.Windows.Forms.TabPage tbpListar;
        private System.Windows.Forms.TabPage tbpRegistrar;
        private System.Windows.Forms.TabPage tbpModificar;
        private System.Windows.Forms.TabPage tbpEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox grbClientes;
        private System.Windows.Forms.GroupBox grbBuscar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBCompañia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBDomicilio;
        private System.Windows.Forms.TextBox txtBContacto;
        private System.Windows.Forms.TextBox txtBCodigoP;
        private System.Windows.Forms.TextBox txtBRegion;
        private System.Windows.Forms.TextBox txtBCiudad;
        private System.Windows.Forms.ComboBox cboBPais;
        private System.Windows.Forms.TextBox txtBFax;
        private System.Windows.Forms.TextBox txtBTelefono;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox grbCliente;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCodigoP;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.TextBox txtCompañia;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Button btnOperacion;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}