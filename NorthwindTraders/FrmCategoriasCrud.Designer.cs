namespace NorthwindTraders
{
    partial class FrmCategoriasCrud
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
            this.grbBuscar = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBCategoria = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.grbDetalle = new System.Windows.Forms.GroupBox();
            this.btnOperacion = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCargar = new System.Windows.Forms.Button();
            this.tabcOperacion.SuspendLayout();
            this.tbpListar.SuspendLayout();
            this.tbpRegistrar.SuspendLayout();
            this.tbpModificar.SuspendLayout();
            this.tbpEliminar.SuspendLayout();
            this.grbBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.grbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
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
            this.tabcOperacion.Location = new System.Drawing.Point(22, 12);
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
            this.tbpListar.Text = "   Listado de categorías   ";
            this.tbpListar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione una categoría para ver su detalle";
            // 
            // tbpRegistrar
            // 
            this.tbpRegistrar.Controls.Add(this.label2);
            this.tbpRegistrar.Location = new System.Drawing.Point(4, 22);
            this.tbpRegistrar.Name = "tbpRegistrar";
            this.tbpRegistrar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRegistrar.Size = new System.Drawing.Size(942, 30);
            this.tbpRegistrar.TabIndex = 1;
            this.tbpRegistrar.Text = "   Registrar categoría   ";
            this.tbpRegistrar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Proporcione los datos de la categoría a registrar";
            // 
            // tbpModificar
            // 
            this.tbpModificar.Controls.Add(this.label3);
            this.tbpModificar.Location = new System.Drawing.Point(4, 22);
            this.tbpModificar.Name = "tbpModificar";
            this.tbpModificar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpModificar.Size = new System.Drawing.Size(942, 30);
            this.tbpModificar.TabIndex = 2;
            this.tbpModificar.Text = "   Modificar categoría   ";
            this.tbpModificar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(469, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Busque la categoría y seleccionela en la lista que se muestra, para que pueda mod" +
    "ificar sus datos";
            // 
            // tbpEliminar
            // 
            this.tbpEliminar.Controls.Add(this.label4);
            this.tbpEliminar.Location = new System.Drawing.Point(4, 22);
            this.tbpEliminar.Name = "tbpEliminar";
            this.tbpEliminar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEliminar.Size = new System.Drawing.Size(942, 30);
            this.tbpEliminar.TabIndex = 3;
            this.tbpEliminar.Text = "   Eliminar categoría   ";
            this.tbpEliminar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(701, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Busque la categoría a eliminar y seleccionela en la lista que se muestra; no se p" +
    "ueden eliminar categorías que ya estan relacionadas a un producto";
            // 
            // grbBuscar
            // 
            this.grbBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grbBuscar.Controls.Add(this.label9);
            this.grbBuscar.Controls.Add(this.txtBId);
            this.grbBuscar.Controls.Add(this.label8);
            this.grbBuscar.Controls.Add(this.btnLimpiar);
            this.grbBuscar.Controls.Add(this.btnBuscar);
            this.grbBuscar.Controls.Add(this.txtBCategoria);
            this.grbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBuscar.Location = new System.Drawing.Point(22, 74);
            this.grbBuscar.Name = "grbBuscar";
            this.grbBuscar.Size = new System.Drawing.Size(213, 535);
            this.grbBuscar.TabIndex = 1;
            this.grbBuscar.TabStop = false;
            this.grbBuscar.Text = "»   Buscar una categoría:   «";
            this.grbBuscar.Paint += new System.Windows.Forms.PaintEventHandler(this.grb_Paint);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Categoría:";
            // 
            // txtBId
            // 
            this.txtBId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBId.Location = new System.Drawing.Point(6, 65);
            this.txtBId.MaxLength = 15;
            this.txtBId.Name = "txtBId";
            this.txtBId.Size = new System.Drawing.Size(100, 20);
            this.txtBId.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Id:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(122, 222);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(122, 183);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBCategoria
            // 
            this.txtBCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCategoria.Location = new System.Drawing.Point(6, 136);
            this.txtBCategoria.MaxLength = 15;
            this.txtBCategoria.Name = "txtBCategoria";
            this.txtBCategoria.Size = new System.Drawing.Size(201, 20);
            this.txtBCategoria.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(248, 74);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(724, 216);
            this.dgv.TabIndex = 3;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // grbDetalle
            // 
            this.grbDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDetalle.Controls.Add(this.btnCargar);
            this.grbDetalle.Controls.Add(this.btnOperacion);
            this.grbDetalle.Controls.Add(this.txtId);
            this.grbDetalle.Controls.Add(this.label10);
            this.grbDetalle.Controls.Add(this.picFoto);
            this.grbDetalle.Controls.Add(this.txtDescripcion);
            this.grbDetalle.Controls.Add(this.label7);
            this.grbDetalle.Controls.Add(this.label6);
            this.grbDetalle.Controls.Add(this.txtCategoria);
            this.grbDetalle.Controls.Add(this.label5);
            this.grbDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDetalle.Location = new System.Drawing.Point(248, 296);
            this.grbDetalle.Name = "grbDetalle";
            this.grbDetalle.Size = new System.Drawing.Size(724, 313);
            this.grbDetalle.TabIndex = 4;
            this.grbDetalle.TabStop = false;
            this.grbDetalle.Text = "»   Detalle de la categoría:   «";
            this.grbDetalle.Paint += new System.Windows.Forms.PaintEventHandler(this.grb_Paint);
            // 
            // btnOperacion
            // 
            this.btnOperacion.Location = new System.Drawing.Point(560, 281);
            this.btnOperacion.Name = "btnOperacion";
            this.btnOperacion.Size = new System.Drawing.Size(158, 23);
            this.btnOperacion.TabIndex = 7;
            this.btnOperacion.Text = "Registrar categoría";
            this.btnOperacion.UseVisualStyleBackColor = true;
            this.btnOperacion.Visible = false;
            this.btnOperacion.Click += new System.EventHandler(this.btnOperacion_Click);
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(181, 20);
            this.txtId.MaxLength = 15;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(153, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Id:";
            // 
            // picFoto
            // 
            this.picFoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picFoto.Location = new System.Drawing.Point(181, 101);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(363, 203);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 4;
            this.picFoto.TabStop = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(181, 72);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(537, 20);
            this.txtDescripcion.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(139, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Foto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Descripción:";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoria.Location = new System.Drawing.Point(181, 46);
            this.txtCategoria.MaxLength = 15;
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.ReadOnly = true;
            this.txtCategoria.Size = new System.Drawing.Size(201, 20);
            this.txtCategoria.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Categoría:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(560, 252);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(158, 23);
            this.btnCargar.TabIndex = 8;
            this.btnCargar.Text = "Cargar imagen ...";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Visible = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // FrmCategoriasCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.ControlBox = false;
            this.Controls.Add(this.grbDetalle);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.grbBuscar);
            this.Controls.Add(this.tabcOperacion);
            this.Name = "FrmCategoriasCrud";
            this.ShowIcon = false;
            this.Text = "Mantenimiento de categorías";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCategoriasCrud_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCategoriasCrud_FormClosed);
            this.Load += new System.EventHandler(this.FrmCategoriasCrud_Load);
            this.tabcOperacion.ResumeLayout(false);
            this.tbpListar.ResumeLayout(false);
            this.tbpListar.PerformLayout();
            this.tbpRegistrar.ResumeLayout(false);
            this.tbpRegistrar.PerformLayout();
            this.tbpModificar.ResumeLayout(false);
            this.tbpModificar.PerformLayout();
            this.tbpEliminar.ResumeLayout(false);
            this.tbpEliminar.PerformLayout();
            this.grbBuscar.ResumeLayout(false);
            this.grbBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.grbDetalle.ResumeLayout(false);
            this.grbDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabcOperacion;
        private System.Windows.Forms.TabPage tbpListar;
        private System.Windows.Forms.TabPage tbpRegistrar;
        private System.Windows.Forms.TabPage tbpModificar;
        private System.Windows.Forms.TabPage tbpEliminar;
        private System.Windows.Forms.GroupBox grbBuscar;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox grbDetalle;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnOperacion;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnCargar;
    }
}