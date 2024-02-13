namespace NorthwindTraders
{
    partial class FrmPedidosVendedorDetalle
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grbVendedores = new System.Windows.Forms.GroupBox();
            this.grbPedidos = new System.Windows.Forms.GroupBox();
            this.grbDetalle = new System.Windows.Forms.GroupBox();
            this.dgvVendedores = new System.Windows.Forms.DataGridView();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grbVendedores.SuspendLayout();
            this.grbPedidos.SuspendLayout();
            this.grbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grbDetalle);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.splitContainer1.Size = new System.Drawing.Size(984, 621);
            this.splitContainer1.SplitterDistance = 310;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grbVendedores);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(10, 3, 4, 3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grbPedidos);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(4, 3, 10, 3);
            this.splitContainer2.Size = new System.Drawing.Size(984, 310);
            this.splitContainer2.SplitterDistance = 492;
            this.splitContainer2.TabIndex = 0;
            // 
            // grbVendedores
            // 
            this.grbVendedores.Controls.Add(this.dgvVendedores);
            this.grbVendedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbVendedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbVendedores.Location = new System.Drawing.Point(10, 3);
            this.grbVendedores.Name = "grbVendedores";
            this.grbVendedores.Size = new System.Drawing.Size(478, 304);
            this.grbVendedores.TabIndex = 0;
            this.grbVendedores.TabStop = false;
            this.grbVendedores.Text = "»   Vendedores:   «";
            this.grbVendedores.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // grbPedidos
            // 
            this.grbPedidos.Controls.Add(this.dgvPedidos);
            this.grbPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPedidos.Location = new System.Drawing.Point(4, 3);
            this.grbPedidos.Name = "grbPedidos";
            this.grbPedidos.Size = new System.Drawing.Size(474, 304);
            this.grbPedidos.TabIndex = 0;
            this.grbPedidos.TabStop = false;
            this.grbPedidos.Text = "»   Pedidos:   «";
            this.grbPedidos.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // grbDetalle
            // 
            this.grbDetalle.Controls.Add(this.dgvDetalle);
            this.grbDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDetalle.Location = new System.Drawing.Point(10, 3);
            this.grbDetalle.Name = "grbDetalle";
            this.grbDetalle.Size = new System.Drawing.Size(964, 301);
            this.grbDetalle.TabIndex = 0;
            this.grbDetalle.TabStop = false;
            this.grbDetalle.Text = "»   Detalle de pedido:   «";
            this.grbDetalle.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // dgvVendedores
            // 
            this.dgvVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendedores.Location = new System.Drawing.Point(3, 18);
            this.dgvVendedores.Name = "dgvVendedores";
            this.dgvVendedores.Size = new System.Drawing.Size(472, 283);
            this.dgvVendedores.TabIndex = 0;
            this.dgvVendedores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendedores_CellClick);
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidos.Location = new System.Drawing.Point(3, 18);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.Size = new System.Drawing.Size(468, 283);
            this.dgvPedidos.TabIndex = 0;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(3, 18);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(958, 280);
            this.dgvDetalle.TabIndex = 0;
            // 
            // FrmPedidosVendedorDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmPedidosVendedorDetalle";
            this.Text = "Consulta de detalle de pedido por vendedor";
            this.Load += new System.EventHandler(this.FrmPedidosVendedorDetalle_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grbVendedores.ResumeLayout(false);
            this.grbPedidos.ResumeLayout(false);
            this.grbDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox grbVendedores;
        private System.Windows.Forms.GroupBox grbPedidos;
        private System.Windows.Forms.GroupBox grbDetalle;
        private System.Windows.Forms.DataGridView dgvVendedores;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.DataGridView dgvDetalle;
    }
}