namespace NorthwindTraders
{
    partial class FrmEmpleadosCrud
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
            this.grbEmpleados = new System.Windows.Forms.GroupBox();
            this.grbBuscar = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboBPais = new System.Windows.Forms.ComboBox();
            this.txtBTitulo = new System.Windows.Forms.TextBox();
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
            this.txtBTelefono = new System.Windows.Forms.TextBox();
            this.txtBCodigoP = new System.Windows.Forms.TextBox();
            this.txtBRegion = new System.Windows.Forms.TextBox();
            this.txtBCiudad = new System.Windows.Forms.TextBox();
            this.txtBDomicilio = new System.Windows.Forms.TextBox();
            this.txtBApellido = new System.Windows.Forms.TextBox();
            this.txtBNombre = new System.Windows.Forms.TextBox();
            this.grbEmpleado = new System.Windows.Forms.GroupBox();
            this.btnOperacion = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
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
            this.txtTitCortesia = new System.Windows.Forms.TextBox();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCodigoP = new System.Windows.Forms.TextBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.dtpFNacimiento = new System.Windows.Forms.DateTimePicker();
            this.dtpFContratacion = new System.Windows.Forms.DateTimePicker();
            this.cboReporta = new System.Windows.Forms.ComboBox();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.tabcOperacion.SuspendLayout();
            this.tbpListar.SuspendLayout();
            this.tbpRegistrar.SuspendLayout();
            this.tbpModificar.SuspendLayout();
            this.tbpEliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.grbEmpleados.SuspendLayout();
            this.grbBuscar.SuspendLayout();
            this.grbEmpleado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
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
            this.tbpListar.Text = "   Consultar empleado   ";
            this.tbpListar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione un empleado para ver su detalle";
            // 
            // tbpRegistrar
            // 
            this.tbpRegistrar.Controls.Add(this.label2);
            this.tbpRegistrar.Location = new System.Drawing.Point(4, 22);
            this.tbpRegistrar.Name = "tbpRegistrar";
            this.tbpRegistrar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRegistrar.Size = new System.Drawing.Size(942, 30);
            this.tbpRegistrar.TabIndex = 1;
            this.tbpRegistrar.Text = "   Registrar empleado   ";
            this.tbpRegistrar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Proporcione los datos del empleado a registrar";
            // 
            // tbpModificar
            // 
            this.tbpModificar.Controls.Add(this.label3);
            this.tbpModificar.Location = new System.Drawing.Point(4, 22);
            this.tbpModificar.Name = "tbpModificar";
            this.tbpModificar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpModificar.Size = new System.Drawing.Size(942, 30);
            this.tbpModificar.TabIndex = 2;
            this.tbpModificar.Text = "   Modificar empleado   ";
            this.tbpModificar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(466, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Busque el empleado y seleccionelo en la lista que se muestra para que pueda módif" +
    "icar sus datos";
            // 
            // tbpEliminar
            // 
            this.tbpEliminar.Controls.Add(this.label4);
            this.tbpEliminar.Location = new System.Drawing.Point(4, 22);
            this.tbpEliminar.Name = "tbpEliminar";
            this.tbpEliminar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEliminar.Size = new System.Drawing.Size(942, 30);
            this.tbpEliminar.TabIndex = 3;
            this.tbpEliminar.Text = "   Eliminar empleado   ";
            this.tbpEliminar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(691, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Busque el empleado a eliminar y seleccionelo en la lista que se muestra, no se pu" +
    "eden eliminar empleados que ya estan relacionados a un pedido";
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
            // grbEmpleados
            // 
            this.grbEmpleados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbEmpleados.Controls.Add(this.dgv);
            this.grbEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbEmpleados.Location = new System.Drawing.Point(16, 64);
            this.grbEmpleados.Name = "grbEmpleados";
            this.grbEmpleados.Size = new System.Drawing.Size(952, 240);
            this.grbEmpleados.TabIndex = 1;
            this.grbEmpleados.TabStop = false;
            this.grbEmpleados.Text = "»   Empleados:   «";
            this.grbEmpleados.Paint += new System.Windows.Forms.PaintEventHandler(this.grbPaint);
            // 
            // grbBuscar
            // 
            this.grbBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grbBuscar.Controls.Add(this.label14);
            this.grbBuscar.Controls.Add(this.cboBPais);
            this.grbBuscar.Controls.Add(this.txtBTitulo);
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
            this.grbBuscar.Controls.Add(this.txtBTelefono);
            this.grbBuscar.Controls.Add(this.txtBCodigoP);
            this.grbBuscar.Controls.Add(this.txtBRegion);
            this.grbBuscar.Controls.Add(this.txtBCiudad);
            this.grbBuscar.Controls.Add(this.txtBDomicilio);
            this.grbBuscar.Controls.Add(this.txtBApellido);
            this.grbBuscar.Controls.Add(this.txtBNombre);
            this.grbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBuscar.Location = new System.Drawing.Point(16, 312);
            this.grbBuscar.Name = "grbBuscar";
            this.grbBuscar.Size = new System.Drawing.Size(304, 304);
            this.grbBuscar.TabIndex = 2;
            this.grbBuscar.TabStop = false;
            this.grbBuscar.Text = "»   Buscar un empleado:   «";
            this.grbBuscar.Paint += new System.Windows.Forms.PaintEventHandler(this.grbPaint);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(48, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Título:";
            // 
            // cboBPais
            // 
            this.cboBPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBPais.FormattingEnabled = true;
            this.cboBPais.Location = new System.Drawing.Point(96, 216);
            this.cboBPais.Name = "cboBPais";
            this.cboBPais.Size = new System.Drawing.Size(200, 21);
            this.cboBPais.TabIndex = 8;
            // 
            // txtBTitulo
            // 
            this.txtBTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBTitulo.Location = new System.Drawing.Point(96, 96);
            this.txtBTitulo.MaxLength = 30;
            this.txtBTitulo.Name = "txtBTitulo";
            this.txtBTitulo.Size = new System.Drawing.Size(201, 20);
            this.txtBTitulo.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 243);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Teléfono:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 219);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "País:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Código postal:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Región:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Domicilio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ciudad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Apellido:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Nombre:";
            // 
            // txtBId
            // 
            this.txtBId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBId.Location = new System.Drawing.Point(96, 24);
            this.txtBId.MaxLength = 10;
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
            // txtBTelefono
            // 
            this.txtBTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBTelefono.Location = new System.Drawing.Point(96, 240);
            this.txtBTelefono.MaxLength = 24;
            this.txtBTelefono.Name = "txtBTelefono";
            this.txtBTelefono.Size = new System.Drawing.Size(201, 20);
            this.txtBTelefono.TabIndex = 9;
            // 
            // txtBCodigoP
            // 
            this.txtBCodigoP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCodigoP.Location = new System.Drawing.Point(96, 192);
            this.txtBCodigoP.MaxLength = 10;
            this.txtBCodigoP.Name = "txtBCodigoP";
            this.txtBCodigoP.Size = new System.Drawing.Size(120, 20);
            this.txtBCodigoP.TabIndex = 7;
            // 
            // txtBRegion
            // 
            this.txtBRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBRegion.Location = new System.Drawing.Point(96, 168);
            this.txtBRegion.MaxLength = 15;
            this.txtBRegion.Name = "txtBRegion";
            this.txtBRegion.Size = new System.Drawing.Size(120, 20);
            this.txtBRegion.TabIndex = 6;
            // 
            // txtBCiudad
            // 
            this.txtBCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCiudad.Location = new System.Drawing.Point(96, 144);
            this.txtBCiudad.MaxLength = 15;
            this.txtBCiudad.Name = "txtBCiudad";
            this.txtBCiudad.Size = new System.Drawing.Size(120, 20);
            this.txtBCiudad.TabIndex = 5;
            // 
            // txtBDomicilio
            // 
            this.txtBDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDomicilio.Location = new System.Drawing.Point(96, 120);
            this.txtBDomicilio.MaxLength = 60;
            this.txtBDomicilio.Name = "txtBDomicilio";
            this.txtBDomicilio.Size = new System.Drawing.Size(201, 20);
            this.txtBDomicilio.TabIndex = 4;
            // 
            // txtBApellido
            // 
            this.txtBApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBApellido.Location = new System.Drawing.Point(96, 72);
            this.txtBApellido.MaxLength = 20;
            this.txtBApellido.Name = "txtBApellido";
            this.txtBApellido.Size = new System.Drawing.Size(201, 20);
            this.txtBApellido.TabIndex = 2;
            // 
            // txtBNombre
            // 
            this.txtBNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBNombre.Location = new System.Drawing.Point(96, 48);
            this.txtBNombre.MaxLength = 10;
            this.txtBNombre.Name = "txtBNombre";
            this.txtBNombre.Size = new System.Drawing.Size(201, 20);
            this.txtBNombre.TabIndex = 1;
            // 
            // grbEmpleado
            // 
            this.grbEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbEmpleado.Controls.Add(this.btnCargar);
            this.grbEmpleado.Controls.Add(this.picFoto);
            this.grbEmpleado.Controls.Add(this.label31);
            this.grbEmpleado.Controls.Add(this.txtNotas);
            this.grbEmpleado.Controls.Add(this.cboReporta);
            this.grbEmpleado.Controls.Add(this.dtpFContratacion);
            this.grbEmpleado.Controls.Add(this.dtpFNacimiento);
            this.grbEmpleado.Controls.Add(this.label30);
            this.grbEmpleado.Controls.Add(this.label29);
            this.grbEmpleado.Controls.Add(this.label28);
            this.grbEmpleado.Controls.Add(this.label27);
            this.grbEmpleado.Controls.Add(this.btnOperacion);
            this.grbEmpleado.Controls.Add(this.label15);
            this.grbEmpleado.Controls.Add(this.label26);
            this.grbEmpleado.Controls.Add(this.label16);
            this.grbEmpleado.Controls.Add(this.label17);
            this.grbEmpleado.Controls.Add(this.label18);
            this.grbEmpleado.Controls.Add(this.label19);
            this.grbEmpleado.Controls.Add(this.label20);
            this.grbEmpleado.Controls.Add(this.label21);
            this.grbEmpleado.Controls.Add(this.label25);
            this.grbEmpleado.Controls.Add(this.label22);
            this.grbEmpleado.Controls.Add(this.label23);
            this.grbEmpleado.Controls.Add(this.txtId);
            this.grbEmpleado.Controls.Add(this.label24);
            this.grbEmpleado.Controls.Add(this.txtTitCortesia);
            this.grbEmpleado.Controls.Add(this.txtPais);
            this.grbEmpleado.Controls.Add(this.txtExtension);
            this.grbEmpleado.Controls.Add(this.txtTelefono);
            this.grbEmpleado.Controls.Add(this.txtCodigoP);
            this.grbEmpleado.Controls.Add(this.txtRegion);
            this.grbEmpleado.Controls.Add(this.txtCiudad);
            this.grbEmpleado.Controls.Add(this.txtDomicilio);
            this.grbEmpleado.Controls.Add(this.txtTitulo);
            this.grbEmpleado.Controls.Add(this.txtApellido);
            this.grbEmpleado.Controls.Add(this.txtNombre);
            this.grbEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbEmpleado.Location = new System.Drawing.Point(344, 312);
            this.grbEmpleado.Name = "grbEmpleado";
            this.grbEmpleado.Size = new System.Drawing.Size(624, 304);
            this.grbEmpleado.TabIndex = 3;
            this.grbEmpleado.TabStop = false;
            this.grbEmpleado.Text = "»   Empleado:   «";
            this.grbEmpleado.Paint += new System.Windows.Forms.PaintEventHandler(this.grbPaint);
            // 
            // btnOperacion
            // 
            this.btnOperacion.Enabled = false;
            this.btnOperacion.Location = new System.Drawing.Point(488, 280);
            this.btnOperacion.Name = "btnOperacion";
            this.btnOperacion.Size = new System.Drawing.Size(128, 23);
            this.btnOperacion.TabIndex = 11;
            this.btnOperacion.Text = "Registrar empleado";
            this.btnOperacion.UseVisualStyleBackColor = true;
            this.btnOperacion.Visible = false;
            this.btnOperacion.Click += new System.EventHandler(this.btnOperacion_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(10, 114);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 12);
            this.label15.TabIndex = 24;
            this.label15.Text = "Título de cortesia:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(43, 282);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(66, 13);
            this.label26.TabIndex = 23;
            this.label26.Text = "Extensión:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(46, 257);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Teléfono:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(70, 233);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 22;
            this.label17.Text = "País:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 209);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 13);
            this.label18.TabIndex = 21;
            this.label18.Text = "Código postal:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(60, 185);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 20;
            this.label19.Text = "Región";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(45, 137);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = "Domicilio:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(57, 161);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 13);
            this.label21.TabIndex = 18;
            this.label21.Text = "Ciudad:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(62, 89);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(45, 13);
            this.label25.TabIndex = 25;
            this.label25.Text = "Título:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(51, 65);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 13);
            this.label22.TabIndex = 25;
            this.label22.Text = "Apellido:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(53, 41);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(54, 13);
            this.label23.TabIndex = 17;
            this.label23.Text = "Nombre:";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(110, 14);
            this.txtId.MaxLength = 10;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(80, 20);
            this.txtId.TabIndex = 0;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(85, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(22, 13);
            this.label24.TabIndex = 15;
            this.label24.Text = "Id:";
            // 
            // txtTitCortesia
            // 
            this.txtTitCortesia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitCortesia.Location = new System.Drawing.Point(110, 110);
            this.txtTitCortesia.MaxLength = 25;
            this.txtTitCortesia.Name = "txtTitCortesia";
            this.txtTitCortesia.Size = new System.Drawing.Size(128, 20);
            this.txtTitCortesia.TabIndex = 4;
            // 
            // txtPais
            // 
            this.txtPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPais.Location = new System.Drawing.Point(110, 230);
            this.txtPais.MaxLength = 15;
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(96, 20);
            this.txtPais.TabIndex = 9;
            // 
            // txtExtension
            // 
            this.txtExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtension.Location = new System.Drawing.Point(110, 278);
            this.txtExtension.MaxLength = 4;
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(34, 20);
            this.txtExtension.TabIndex = 11;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(110, 254);
            this.txtTelefono.MaxLength = 24;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(128, 20);
            this.txtTelefono.TabIndex = 10;
            // 
            // txtCodigoP
            // 
            this.txtCodigoP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoP.Location = new System.Drawing.Point(110, 206);
            this.txtCodigoP.MaxLength = 10;
            this.txtCodigoP.Name = "txtCodigoP";
            this.txtCodigoP.Size = new System.Drawing.Size(80, 20);
            this.txtCodigoP.TabIndex = 8;
            // 
            // txtRegion
            // 
            this.txtRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegion.Location = new System.Drawing.Point(110, 182);
            this.txtRegion.MaxLength = 15;
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(96, 20);
            this.txtRegion.TabIndex = 7;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiudad.Location = new System.Drawing.Point(110, 158);
            this.txtCiudad.MaxLength = 15;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(96, 20);
            this.txtCiudad.TabIndex = 6;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomicilio.Location = new System.Drawing.Point(110, 134);
            this.txtDomicilio.MaxLength = 60;
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(128, 20);
            this.txtDomicilio.TabIndex = 5;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(110, 86);
            this.txtTitulo.MaxLength = 30;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(128, 20);
            this.txtTitulo.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(110, 62);
            this.txtApellido.MaxLength = 20;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(128, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(110, 38);
            this.txtNombre.MaxLength = 10;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(80, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(296, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(129, 13);
            this.label27.TabIndex = 26;
            this.label27.Text = "Fecha de nacimiento:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(440, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(139, 13);
            this.label28.TabIndex = 27;
            this.label28.Text = "Fecha de contratación:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(264, 176);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(44, 13);
            this.label29.TabIndex = 28;
            this.label29.Text = "Notas:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(264, 280);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(67, 13);
            this.label30.TabIndex = 29;
            this.label30.Text = "Reporta a:";
            // 
            // dtpFNacimiento
            // 
            this.dtpFNacimiento.CustomFormat = "dd/MMM/yy";
            this.dtpFNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFNacimiento.Location = new System.Drawing.Point(304, 32);
            this.dtpFNacimiento.Name = "dtpFNacimiento";
            this.dtpFNacimiento.Size = new System.Drawing.Size(112, 20);
            this.dtpFNacimiento.TabIndex = 30;
            // 
            // dtpFContratacion
            // 
            this.dtpFContratacion.CustomFormat = "dd/MMM/yy";
            this.dtpFContratacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFContratacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFContratacion.Location = new System.Drawing.Point(456, 32);
            this.dtpFContratacion.Name = "dtpFContratacion";
            this.dtpFContratacion.Size = new System.Drawing.Size(112, 20);
            this.dtpFContratacion.TabIndex = 31;
            // 
            // cboReporta
            // 
            this.cboReporta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReporta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReporta.FormattingEnabled = true;
            this.cboReporta.Location = new System.Drawing.Point(331, 277);
            this.cboReporta.Name = "cboReporta";
            this.cboReporta.Size = new System.Drawing.Size(144, 21);
            this.cboReporta.TabIndex = 32;
            // 
            // txtNotas
            // 
            this.txtNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotas.Location = new System.Drawing.Point(264, 192);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(352, 80);
            this.txtNotas.TabIndex = 33;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(320, 64);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(36, 13);
            this.label31.TabIndex = 34;
            this.label31.Text = "Foto:";
            // 
            // picFoto
            // 
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.Location = new System.Drawing.Point(360, 56);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(128, 128);
            this.picFoto.TabIndex = 35;
            this.picFoto.TabStop = false;
            // 
            // btnCargar
            // 
            this.btnCargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.Location = new System.Drawing.Point(504, 160);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(112, 23);
            this.btnCargar.TabIndex = 36;
            this.btnCargar.Text = "Cargar imagen...";
            this.btnCargar.UseVisualStyleBackColor = true;
            // 
            // FrmEmpleadosCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.ControlBox = false;
            this.Controls.Add(this.grbEmpleado);
            this.Controls.Add(this.grbBuscar);
            this.Controls.Add(this.grbEmpleados);
            this.Controls.Add(this.tabcOperacion);
            this.Name = "FrmEmpleadosCrud";
            this.Text = "Mantenimiento de empleados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEmpleadosCrud_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmEmpleadosCrud_FormClosed);
            this.Load += new System.EventHandler(this.FrmEmpleadosCrud_Load);
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
            this.grbEmpleados.ResumeLayout(false);
            this.grbBuscar.ResumeLayout(false);
            this.grbBuscar.PerformLayout();
            this.grbEmpleado.ResumeLayout(false);
            this.grbEmpleado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
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
        private System.Windows.Forms.GroupBox grbEmpleados;
        private System.Windows.Forms.GroupBox grbBuscar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBNombre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBDomicilio;
        private System.Windows.Forms.TextBox txtBApellido;
        private System.Windows.Forms.TextBox txtBCodigoP;
        private System.Windows.Forms.TextBox txtBRegion;
        private System.Windows.Forms.TextBox txtBCiudad;
        private System.Windows.Forms.ComboBox cboBPais;
        private System.Windows.Forms.TextBox txtBTitulo;
        private System.Windows.Forms.TextBox txtBTelefono;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox grbEmpleado;
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
        private System.Windows.Forms.TextBox txtTitCortesia;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCodigoP;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Button btnOperacion;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DateTimePicker dtpFNacimiento;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cboReporta;
        private System.Windows.Forms.DateTimePicker dtpFContratacion;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.PictureBox picFoto;
    }
}