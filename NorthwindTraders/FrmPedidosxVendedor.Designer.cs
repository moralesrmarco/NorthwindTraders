namespace NorthwindTraders
{
    partial class FrmPedidosxVendedor
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
            this.GrbVendedores = new System.Windows.Forms.GroupBox();
            this.DgvVendedores = new System.Windows.Forms.DataGridView();
            this.GrbPedidos = new System.Windows.Forms.GroupBox();
            this.DgvPedidos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.GrbVendedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVendedores)).BeginInit();
            this.GrbPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(10, 5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GrbVendedores);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GrbPedidos);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.splitContainer1.Size = new System.Drawing.Size(964, 611);
            this.splitContainer1.SplitterDistance = 304;
            this.splitContainer1.TabIndex = 0;
            // 
            // GrbVendedores
            // 
            this.GrbVendedores.Controls.Add(this.DgvVendedores);
            this.GrbVendedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbVendedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbVendedores.Location = new System.Drawing.Point(0, 3);
            this.GrbVendedores.Name = "GrbVendedores";
            this.GrbVendedores.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.GrbVendedores.Size = new System.Drawing.Size(964, 298);
            this.GrbVendedores.TabIndex = 0;
            this.GrbVendedores.TabStop = false;
            this.GrbVendedores.Text = "»   Vendedores:   «";
            this.GrbVendedores.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // DgvVendedores
            // 
            this.DgvVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVendedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvVendedores.Location = new System.Drawing.Point(10, 20);
            this.DgvVendedores.Name = "DgvVendedores";
            this.DgvVendedores.Size = new System.Drawing.Size(944, 268);
            this.DgvVendedores.TabIndex = 0;
            this.DgvVendedores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvVendedores_CellClick);
            this.DgvVendedores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvVendedores_KeyDown);
            // 
            // GrbPedidos
            // 
            this.GrbPedidos.Controls.Add(this.DgvPedidos);
            this.GrbPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbPedidos.Location = new System.Drawing.Point(0, 3);
            this.GrbPedidos.Name = "GrbPedidos";
            this.GrbPedidos.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.GrbPedidos.Size = new System.Drawing.Size(964, 297);
            this.GrbPedidos.TabIndex = 0;
            this.GrbPedidos.TabStop = false;
            this.GrbPedidos.Text = "»   Pedidos:   «";
            this.GrbPedidos.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // DgvPedidos
            // 
            this.DgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPedidos.Location = new System.Drawing.Point(10, 20);
            this.DgvPedidos.Name = "DgvPedidos";
            this.DgvPedidos.Size = new System.Drawing.Size(944, 267);
            this.DgvPedidos.TabIndex = 0;
            // 
            // FrmPedidosxVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmPedidosxVendedor";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Text = "Consulta de pedidos por vendedor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPedidosxVendedor_FormClosed);
            this.Load += new System.EventHandler(this.FrmPedidosxVendedor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.GrbVendedores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvVendedores)).EndInit();
            this.GrbPedidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox GrbVendedores;
        private System.Windows.Forms.GroupBox GrbPedidos;
        private System.Windows.Forms.DataGridView DgvVendedores;
        private System.Windows.Forms.DataGridView DgvPedidos;
    }
}