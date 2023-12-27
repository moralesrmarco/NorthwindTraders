namespace NorthwindTraders
{
    partial class FrmProveedoresCrud
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
            this.tabcOperacion = new System.Windows.Forms.TabControl();
            this.tbpConsultar = new System.Windows.Forms.TabPage();
            this.tbpRegistrar = new System.Windows.Forms.TabPage();
            this.tbpModificar = new System.Windows.Forms.TabPage();
            this.tbpEliminar = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grbProveedores = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.grbBuscar = new System.Windows.Forms.GroupBox();
            this.grbProveedor = new System.Windows.Forms.GroupBox();
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
            this.tabcOperacion.SuspendLayout();
            this.tbpConsultar.SuspendLayout();
            this.tbpRegistrar.SuspendLayout();
            this.tbpModificar.SuspendLayout();
            this.tbpEliminar.SuspendLayout();
            this.grbProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.grbBuscar.SuspendLayout();
            this.grbProveedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabcOperacion
            // 
            this.tabcOperacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabcOperacion.Controls.Add(this.tbpConsultar);
            this.tabcOperacion.Controls.Add(this.tbpRegistrar);
            this.tabcOperacion.Controls.Add(this.tbpModificar);
            this.tabcOperacion.Controls.Add(this.tbpEliminar);
            this.tabcOperacion.Location = new System.Drawing.Point(16, 8);
            this.tabcOperacion.Name = "tabcOperacion";
            this.tabcOperacion.SelectedIndex = 0;
            this.tabcOperacion.Size = new System.Drawing.Size(960, 56);
            this.tabcOperacion.TabIndex = 0;
            // 
            // tbpConsultar
            // 
            this.tbpConsultar.Controls.Add(this.label1);
            this.tbpConsultar.Location = new System.Drawing.Point(4, 22);
            this.tbpConsultar.Name = "tbpConsultar";
            this.tbpConsultar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpConsultar.Size = new System.Drawing.Size(952, 30);
            this.tbpConsultar.TabIndex = 0;
            this.tbpConsultar.Text = "   Consultar proveedor   ";
            this.tbpConsultar.UseVisualStyleBackColor = true;
            // 
            // tbpRegistrar
            // 
            this.tbpRegistrar.Controls.Add(this.label2);
            this.tbpRegistrar.Location = new System.Drawing.Point(4, 22);
            this.tbpRegistrar.Name = "tbpRegistrar";
            this.tbpRegistrar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRegistrar.Size = new System.Drawing.Size(952, 30);
            this.tbpRegistrar.TabIndex = 1;
            this.tbpRegistrar.Text = "   Registrar proveedor   ";
            this.tbpRegistrar.UseVisualStyleBackColor = true;
            // 
            // tbpModificar
            // 
            this.tbpModificar.Controls.Add(this.label3);
            this.tbpModificar.Location = new System.Drawing.Point(4, 22);
            this.tbpModificar.Name = "tbpModificar";
            this.tbpModificar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpModificar.Size = new System.Drawing.Size(952, 30);
            this.tbpModificar.TabIndex = 2;
            this.tbpModificar.Text = "   Modificar proveedor   ";
            this.tbpModificar.UseVisualStyleBackColor = true;
            // 
            // tbpEliminar
            // 
            this.tbpEliminar.Controls.Add(this.label4);
            this.tbpEliminar.Location = new System.Drawing.Point(4, 22);
            this.tbpEliminar.Name = "tbpEliminar";
            this.tbpEliminar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEliminar.Size = new System.Drawing.Size(952, 30);
            this.tbpEliminar.TabIndex = 3;
            this.tbpEliminar.Text = "   Eliminar proveedor   ";
            this.tbpEliminar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Busque el proveedor y seleccionelo en la lista que se muestra para ver su detalle" +
    "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Proporcione los datos del proveedor a registrar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(468, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Busque el proveedor y seleccionelo en la lista que se muestra para que pueda modi" +
    "ficar sus datos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(711, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Busque el proveedor a eliminar y seleccionelo en la lista que se muestra, no se p" +
    "ueden eliminar proveedores que ya estan relacionados a un producto";
            // 
            // grbProveedores
            // 
            this.grbProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbProveedores.Controls.Add(this.dgv);
            this.grbProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbProveedores.Location = new System.Drawing.Point(16, 64);
            this.grbProveedores.Name = "grbProveedores";
            this.grbProveedores.Size = new System.Drawing.Size(952, 240);
            this.grbProveedores.TabIndex = 1;
            this.grbProveedores.TabStop = false;
            this.grbProveedores.Text = "»   Proveedores:   «";
            this.grbProveedores.Paint += new System.Windows.Forms.PaintEventHandler(this.grbPaint);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(3, 16);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(946, 221);
            this.dgv.TabIndex = 0;
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
            this.grbBuscar.Text = "»   Buscar un proveedor:   «";
            this.grbBuscar.Paint += new System.Windows.Forms.PaintEventHandler(this.grbPaint);
            // 
            // grbProveedor
            // 
            this.grbProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbProveedor.Controls.Add(this.btnOperacion);
            this.grbProveedor.Controls.Add(this.label15);
            this.grbProveedor.Controls.Add(this.label16);
            this.grbProveedor.Controls.Add(this.label17);
            this.grbProveedor.Controls.Add(this.label18);
            this.grbProveedor.Controls.Add(this.label19);
            this.grbProveedor.Controls.Add(this.label20);
            this.grbProveedor.Controls.Add(this.label21);
            this.grbProveedor.Controls.Add(this.label25);
            this.grbProveedor.Controls.Add(this.label22);
            this.grbProveedor.Controls.Add(this.label23);
            this.grbProveedor.Controls.Add(this.txtId);
            this.grbProveedor.Controls.Add(this.label24);
            this.grbProveedor.Controls.Add(this.txtFax);
            this.grbProveedor.Controls.Add(this.txtPais);
            this.grbProveedor.Controls.Add(this.txtTelefono);
            this.grbProveedor.Controls.Add(this.txtCodigoP);
            this.grbProveedor.Controls.Add(this.txtRegion);
            this.grbProveedor.Controls.Add(this.txtCiudad);
            this.grbProveedor.Controls.Add(this.txtDomicilio);
            this.grbProveedor.Controls.Add(this.txtTitulo);
            this.grbProveedor.Controls.Add(this.txtContacto);
            this.grbProveedor.Controls.Add(this.txtCompañia);
            this.grbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbProveedor.Location = new System.Drawing.Point(344, 312);
            this.grbProveedor.Name = "grbProveedor";
            this.grbProveedor.Size = new System.Drawing.Size(624, 304);
            this.grbProveedor.TabIndex = 3;
            this.grbProveedor.TabStop = false;
            this.grbProveedor.Text = "»   Proveedor:   «";
            this.grbProveedor.Paint += new System.Windows.Forms.PaintEventHandler(this.grbPaint);
            // 
            // cboBPais
            // 
            this.cboBPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBPais.FormattingEnabled = true;
            this.cboBPais.Location = new System.Drawing.Point(96, 192);
            this.cboBPais.Name = "cboBPais";
            this.cboBPais.Size = new System.Drawing.Size(200, 21);
            this.cboBPais.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(56, 243);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Fax:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 219);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Teléfono:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 195);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "País:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Código postal:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Región:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Domicilio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Ciudad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Contacto:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 18;
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
            this.txtBId.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Id:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(96, 272);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(99, 23);
            this.btnLimpiar.TabIndex = 33;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(200, 272);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(99, 23);
            this.btnBuscar.TabIndex = 32;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBFax
            // 
            this.txtBFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBFax.Location = new System.Drawing.Point(96, 240);
            this.txtBFax.MaxLength = 24;
            this.txtBFax.Name = "txtBFax";
            this.txtBFax.Size = new System.Drawing.Size(201, 20);
            this.txtBFax.TabIndex = 31;
            // 
            // txtBTelefono
            // 
            this.txtBTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBTelefono.Location = new System.Drawing.Point(96, 216);
            this.txtBTelefono.MaxLength = 24;
            this.txtBTelefono.Name = "txtBTelefono";
            this.txtBTelefono.Size = new System.Drawing.Size(201, 20);
            this.txtBTelefono.TabIndex = 30;
            // 
            // txtBCodigoP
            // 
            this.txtBCodigoP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCodigoP.Location = new System.Drawing.Point(96, 168);
            this.txtBCodigoP.MaxLength = 10;
            this.txtBCodigoP.Name = "txtBCodigoP";
            this.txtBCodigoP.Size = new System.Drawing.Size(120, 20);
            this.txtBCodigoP.TabIndex = 28;
            // 
            // txtBRegion
            // 
            this.txtBRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBRegion.Location = new System.Drawing.Point(96, 144);
            this.txtBRegion.MaxLength = 15;
            this.txtBRegion.Name = "txtBRegion";
            this.txtBRegion.Size = new System.Drawing.Size(120, 20);
            this.txtBRegion.TabIndex = 19;
            // 
            // txtBCiudad
            // 
            this.txtBCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCiudad.Location = new System.Drawing.Point(96, 120);
            this.txtBCiudad.MaxLength = 15;
            this.txtBCiudad.Name = "txtBCiudad";
            this.txtBCiudad.Size = new System.Drawing.Size(120, 20);
            this.txtBCiudad.TabIndex = 17;
            // 
            // txtBDomicilio
            // 
            this.txtBDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDomicilio.Location = new System.Drawing.Point(96, 96);
            this.txtBDomicilio.MaxLength = 60;
            this.txtBDomicilio.Name = "txtBDomicilio";
            this.txtBDomicilio.Size = new System.Drawing.Size(201, 20);
            this.txtBDomicilio.TabIndex = 16;
            // 
            // txtBContacto
            // 
            this.txtBContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBContacto.Location = new System.Drawing.Point(96, 72);
            this.txtBContacto.MaxLength = 30;
            this.txtBContacto.Name = "txtBContacto";
            this.txtBContacto.Size = new System.Drawing.Size(201, 20);
            this.txtBContacto.TabIndex = 15;
            // 
            // txtBCompañia
            // 
            this.txtBCompañia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCompañia.Location = new System.Drawing.Point(96, 48);
            this.txtBCompañia.MaxLength = 40;
            this.txtBCompañia.Name = "txtBCompañia";
            this.txtBCompañia.Size = new System.Drawing.Size(201, 20);
            this.txtBCompañia.TabIndex = 13;
            // 
            // btnOperacion
            // 
            this.btnOperacion.Enabled = false;
            this.btnOperacion.Location = new System.Drawing.Point(416, 264);
            this.btnOperacion.Name = "btnOperacion";
            this.btnOperacion.Size = new System.Drawing.Size(167, 23);
            this.btnOperacion.TabIndex = 37;
            this.btnOperacion.Text = "Registrar proveedor";
            this.btnOperacion.UseVisualStyleBackColor = true;
            this.btnOperacion.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(136, 268);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 46;
            this.label15.Text = "Fax:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(112, 244);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 13);
            this.label16.TabIndex = 45;
            this.label16.Text = "Teléfono:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(136, 220);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 44;
            this.label17.Text = "País:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(85, 196);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 13);
            this.label18.TabIndex = 43;
            this.label18.Text = "Código postal:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(126, 172);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 42;
            this.label19.Text = "Región";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(111, 124);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 13);
            this.label20.TabIndex = 41;
            this.label20.Text = "Domicilio:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(123, 148);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 13);
            this.label21.TabIndex = 40;
            this.label21.Text = "Ciudad:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(57, 100);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(117, 13);
            this.label25.TabIndex = 48;
            this.label25.Text = "Título de contacto:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(47, 76);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(126, 13);
            this.label22.TabIndex = 47;
            this.label22.Text = "Nombre de contacto:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(42, 52);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(132, 13);
            this.label23.TabIndex = 39;
            this.label23.Text = "Nombre de compañía:";
            // 
            // txtId
            // 
            this.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(176, 25);
            this.txtId.MaxLength = 5;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 26;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(151, 28);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(22, 13);
            this.label24.TabIndex = 38;
            this.label24.Text = "Id:";
            // 
            // txtFax
            // 
            this.txtFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(176, 265);
            this.txtFax.MaxLength = 24;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(201, 20);
            this.txtFax.TabIndex = 36;
            // 
            // txtPais
            // 
            this.txtPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPais.Location = new System.Drawing.Point(176, 217);
            this.txtPais.MaxLength = 15;
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(201, 20);
            this.txtPais.TabIndex = 34;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(176, 241);
            this.txtTelefono.MaxLength = 24;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(201, 20);
            this.txtTelefono.TabIndex = 35;
            // 
            // txtCodigoP
            // 
            this.txtCodigoP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoP.Location = new System.Drawing.Point(176, 193);
            this.txtCodigoP.MaxLength = 10;
            this.txtCodigoP.Name = "txtCodigoP";
            this.txtCodigoP.Size = new System.Drawing.Size(150, 20);
            this.txtCodigoP.TabIndex = 33;
            // 
            // txtRegion
            // 
            this.txtRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegion.Location = new System.Drawing.Point(176, 169);
            this.txtRegion.MaxLength = 15;
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(150, 20);
            this.txtRegion.TabIndex = 32;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiudad.Location = new System.Drawing.Point(176, 145);
            this.txtCiudad.MaxLength = 15;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(150, 20);
            this.txtCiudad.TabIndex = 31;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomicilio.Location = new System.Drawing.Point(176, 121);
            this.txtDomicilio.MaxLength = 60;
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(300, 20);
            this.txtDomicilio.TabIndex = 30;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(176, 97);
            this.txtTitulo.MaxLength = 30;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(260, 20);
            this.txtTitulo.TabIndex = 29;
            // 
            // txtContacto
            // 
            this.txtContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContacto.Location = new System.Drawing.Point(176, 73);
            this.txtContacto.MaxLength = 30;
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(300, 20);
            this.txtContacto.TabIndex = 28;
            // 
            // txtCompañia
            // 
            this.txtCompañia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompañia.Location = new System.Drawing.Point(176, 49);
            this.txtCompañia.MaxLength = 40;
            this.txtCompañia.Name = "txtCompañia";
            this.txtCompañia.Size = new System.Drawing.Size(300, 20);
            this.txtCompañia.TabIndex = 27;
            // 
            // FrmProveedoresCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.ControlBox = false;
            this.Controls.Add(this.grbProveedor);
            this.Controls.Add(this.grbBuscar);
            this.Controls.Add(this.grbProveedores);
            this.Controls.Add(this.tabcOperacion);
            this.Name = "FrmProveedoresCrud";
            this.Text = "Mantenimiento de proveedores";
            this.Load += new System.EventHandler(this.FrmProveedoresCrud_Load);
            this.tabcOperacion.ResumeLayout(false);
            this.tbpConsultar.ResumeLayout(false);
            this.tbpConsultar.PerformLayout();
            this.tbpRegistrar.ResumeLayout(false);
            this.tbpRegistrar.PerformLayout();
            this.tbpModificar.ResumeLayout(false);
            this.tbpModificar.PerformLayout();
            this.tbpEliminar.ResumeLayout(false);
            this.tbpEliminar.PerformLayout();
            this.grbProveedores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.grbBuscar.ResumeLayout(false);
            this.grbBuscar.PerformLayout();
            this.grbProveedor.ResumeLayout(false);
            this.grbProveedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabcOperacion;
        private System.Windows.Forms.TabPage tbpConsultar;
        private System.Windows.Forms.TabPage tbpRegistrar;
        private System.Windows.Forms.TabPage tbpModificar;
        private System.Windows.Forms.TabPage tbpEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grbProveedores;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox grbBuscar;
        private System.Windows.Forms.GroupBox grbProveedor;
        private System.Windows.Forms.ComboBox cboBPais;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBFax;
        private System.Windows.Forms.TextBox txtBTelefono;
        private System.Windows.Forms.TextBox txtBCodigoP;
        private System.Windows.Forms.TextBox txtBRegion;
        private System.Windows.Forms.TextBox txtBCiudad;
        private System.Windows.Forms.TextBox txtBDomicilio;
        private System.Windows.Forms.TextBox txtBContacto;
        private System.Windows.Forms.TextBox txtBCompañia;
        private System.Windows.Forms.Button btnOperacion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCodigoP;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.TextBox txtCompañia;
    }
}