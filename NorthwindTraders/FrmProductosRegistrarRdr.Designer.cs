﻿namespace NorthwindTraders
{
    partial class FrmProductosRegistrarRdr
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblBusque = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboBProveedor = new System.Windows.Forms.ComboBox();
            this.cboBCategoria = new System.Windows.Forms.ComboBox();
            this.txtBProducto = new System.Windows.Forms.TextBox();
            this.txtBId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.chkDescontinuado = new System.Windows.Forms.CheckBox();
            this.txtPPedido = new System.Windows.Forms.TextBox();
            this.txtUPedido = new System.Windows.Forms.TextBox();
            this.txtUInventario = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCantidadxU = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgv);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "»   Productos   «";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_Paint);
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(8, 16);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(800, 216);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblBusque);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.cboBProveedor);
            this.groupBox2.Controls.Add(this.cboBCategoria);
            this.groupBox2.Controls.Add(this.txtBProducto);
            this.groupBox2.Controls.Add(this.txtBId);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 288);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "»   Buscar un producto   «";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_Paint);
            // 
            // lblBusque
            // 
            this.lblBusque.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusque.Location = new System.Drawing.Point(16, 200);
            this.lblBusque.Name = "lblBusque";
            this.lblBusque.Size = new System.Drawing.Size(96, 40);
            this.lblBusque.TabIndex = 8;
            this.lblBusque.Text = "Busque un producto y seleccionelo en el listado de productos";
            this.lblBusque.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(112, 232);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(112, 200);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboBProveedor
            // 
            this.cboBProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBProveedor.FormattingEnabled = true;
            this.cboBProveedor.Location = new System.Drawing.Point(16, 160);
            this.cboBProveedor.Name = "cboBProveedor";
            this.cboBProveedor.Size = new System.Drawing.Size(176, 21);
            this.cboBProveedor.TabIndex = 5;
            // 
            // cboBCategoria
            // 
            this.cboBCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBCategoria.FormattingEnabled = true;
            this.cboBCategoria.Location = new System.Drawing.Point(16, 120);
            this.cboBCategoria.Name = "cboBCategoria";
            this.cboBCategoria.Size = new System.Drawing.Size(176, 21);
            this.cboBCategoria.TabIndex = 4;
            // 
            // txtBProducto
            // 
            this.txtBProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBProducto.Location = new System.Drawing.Point(16, 80);
            this.txtBProducto.MaxLength = 40;
            this.txtBProducto.Name = "txtBProducto";
            this.txtBProducto.Size = new System.Drawing.Size(176, 20);
            this.txtBProducto.TabIndex = 3;
            // 
            // txtBId
            // 
            this.txtBId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBId.Location = new System.Drawing.Point(16, 40);
            this.txtBId.Name = "txtBId";
            this.txtBId.Size = new System.Drawing.Size(100, 20);
            this.txtBId.TabIndex = 2;
            this.txtBId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBId_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Proveedor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Categoría:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Producto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnEliminar);
            this.groupBox3.Controls.Add(this.btnRegistrar);
            this.groupBox3.Controls.Add(this.btnModificar);
            this.groupBox3.Controls.Add(this.chkDescontinuado);
            this.groupBox3.Controls.Add(this.txtPPedido);
            this.groupBox3.Controls.Add(this.txtUPedido);
            this.groupBox3.Controls.Add(this.txtUInventario);
            this.groupBox3.Controls.Add(this.txtPrecio);
            this.groupBox3.Controls.Add(this.txtCantidadxU);
            this.groupBox3.Controls.Add(this.txtProducto);
            this.groupBox3.Controls.Add(this.cboProveedor);
            this.groupBox3.Controls.Add(this.cboCategoria);
            this.groupBox3.Controls.Add(this.txtId);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(232, 264);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(584, 288);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "»   Producto   «";
            this.groupBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_Paint);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(24, 254);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(176, 23);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar producto";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(384, 254);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(176, 23);
            this.btnRegistrar.TabIndex = 11;
            this.btnRegistrar.Text = "Registrar producto";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(203, 254);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(176, 23);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar producto";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Visible = false;
            // 
            // chkDescontinuado
            // 
            this.chkDescontinuado.AutoSize = true;
            this.chkDescontinuado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDescontinuado.Location = new System.Drawing.Point(280, 234);
            this.chkDescontinuado.Name = "chkDescontinuado";
            this.chkDescontinuado.Size = new System.Drawing.Size(15, 14);
            this.chkDescontinuado.TabIndex = 10;
            this.chkDescontinuado.UseVisualStyleBackColor = true;
            // 
            // txtPPedido
            // 
            this.txtPPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPPedido.Location = new System.Drawing.Point(279, 207);
            this.txtPPedido.MaxLength = 5;
            this.txtPPedido.Name = "txtPPedido";
            this.txtPPedido.Size = new System.Drawing.Size(100, 20);
            this.txtPPedido.TabIndex = 9;
            this.txtPPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPPedido_KeyPress);
            this.txtPPedido.Validating += new System.ComponentModel.CancelEventHandler(this.txtPPedido_Validating);
            // 
            // txtUPedido
            // 
            this.txtUPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPedido.Location = new System.Drawing.Point(279, 184);
            this.txtUPedido.MaxLength = 5;
            this.txtUPedido.Name = "txtUPedido";
            this.txtUPedido.Size = new System.Drawing.Size(100, 20);
            this.txtUPedido.TabIndex = 8;
            this.txtUPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUPedido_KeyPress);
            this.txtUPedido.Validating += new System.ComponentModel.CancelEventHandler(this.txtUPedido_Validating);
            // 
            // txtUInventario
            // 
            this.txtUInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUInventario.Location = new System.Drawing.Point(279, 161);
            this.txtUInventario.MaxLength = 5;
            this.txtUInventario.Name = "txtUInventario";
            this.txtUInventario.Size = new System.Drawing.Size(100, 20);
            this.txtUInventario.TabIndex = 7;
            this.txtUInventario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUInventario_KeyPress);
            this.txtUInventario.Validating += new System.ComponentModel.CancelEventHandler(this.txtUInventario_Validating);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(279, 138);
            this.txtPrecio.MaxLength = 21;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 6;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // txtCantidadxU
            // 
            this.txtCantidadxU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadxU.Location = new System.Drawing.Point(279, 115);
            this.txtCantidadxU.MaxLength = 20;
            this.txtCantidadxU.Name = "txtCantidadxU";
            this.txtCantidadxU.Size = new System.Drawing.Size(154, 20);
            this.txtCantidadxU.TabIndex = 5;
            // 
            // txtProducto
            // 
            this.txtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducto.Location = new System.Drawing.Point(279, 92);
            this.txtProducto.MaxLength = 40;
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(230, 20);
            this.txtProducto.TabIndex = 4;
            // 
            // cboProveedor
            // 
            this.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(279, 68);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(230, 21);
            this.cboProveedor.TabIndex = 3;
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(279, 44);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(230, 21);
            this.cboCategoria.TabIndex = 2;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(279, 21);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(176, 235);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Descontinuado:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(168, 211);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Punto de pedido:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(148, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Unidades en pedido:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(130, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Unidades en inventario:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(225, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Precio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(147, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Cantidad por unidad:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(210, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Producto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(203, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Proveedor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Categoría:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Id:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmProductosRegistrarRdr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmProductosRegistrarRdr";
            this.ShowIcon = false;
            this.Text = "Mantenimiento de productos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProductosRegistrarRdr_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmProductosRegistrarRdr_FormClosed);
            this.Load += new System.EventHandler(this.FrmProductosRegistrarRdr_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.ComboBox cboBCategoria;
        protected System.Windows.Forms.TextBox txtBProducto;
        protected System.Windows.Forms.TextBox txtBId;
        protected System.Windows.Forms.Label lblBusque;
        protected System.Windows.Forms.Button btnLimpiar;
        protected System.Windows.Forms.Button btnBuscar;
        protected System.Windows.Forms.ComboBox cboBProveedor;
        protected System.Windows.Forms.TextBox txtId;
        protected System.Windows.Forms.TextBox txtPrecio;
        protected System.Windows.Forms.TextBox txtCantidadxU;
        protected System.Windows.Forms.TextBox txtProducto;
        protected System.Windows.Forms.ComboBox cboProveedor;
        protected System.Windows.Forms.ComboBox cboCategoria;
        protected System.Windows.Forms.TextBox txtPPedido;
        protected System.Windows.Forms.TextBox txtUPedido;
        protected System.Windows.Forms.TextBox txtUInventario;
        protected System.Windows.Forms.Button btnRegistrar;
        protected System.Windows.Forms.CheckBox chkDescontinuado;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        protected System.Windows.Forms.GroupBox groupBox3;
        protected System.Windows.Forms.Button btnModificar;
        protected System.Windows.Forms.Button btnEliminar;
    }
}