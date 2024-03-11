namespace NorthwindTraders
{
    partial class FrmPedidosxClienteDetalle
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
            this.GrbClientes = new System.Windows.Forms.GroupBox();
            this.GrbPedidos = new System.Windows.Forms.GroupBox();
            this.GrbDetalle = new System.Windows.Forms.GroupBox();
            this.DgvClientes = new System.Windows.Forms.DataGridView();
            this.DgvPedidos = new System.Windows.Forms.DataGridView();
            this.DgvDetalle = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.GrbClientes.SuspendLayout();
            this.GrbPedidos.SuspendLayout();
            this.GrbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainer1.Panel2.Controls.Add(this.GrbDetalle);
            this.splitContainer1.Size = new System.Drawing.Size(984, 621);
            this.splitContainer1.SplitterDistance = 310;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.GrbClientes);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.GrbPedidos);
            this.splitContainer2.Size = new System.Drawing.Size(984, 310);
            this.splitContainer2.SplitterDistance = 492;
            this.splitContainer2.TabIndex = 0;
            // 
            // GrbClientes
            // 
            this.GrbClientes.Controls.Add(this.DgvClientes);
            this.GrbClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbClientes.Location = new System.Drawing.Point(0, 0);
            this.GrbClientes.Name = "GrbClientes";
            this.GrbClientes.Size = new System.Drawing.Size(492, 310);
            this.GrbClientes.TabIndex = 0;
            this.GrbClientes.TabStop = false;
            this.GrbClientes.Text = "»   Clientes:   «";
            this.GrbClientes.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // GrbPedidos
            // 
            this.GrbPedidos.Controls.Add(this.DgvPedidos);
            this.GrbPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbPedidos.Location = new System.Drawing.Point(0, 0);
            this.GrbPedidos.Name = "GrbPedidos";
            this.GrbPedidos.Size = new System.Drawing.Size(488, 310);
            this.GrbPedidos.TabIndex = 0;
            this.GrbPedidos.TabStop = false;
            this.GrbPedidos.Text = "»   Pedidos:   «";
            this.GrbPedidos.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // GrbDetalle
            // 
            this.GrbDetalle.Controls.Add(this.DgvDetalle);
            this.GrbDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbDetalle.Location = new System.Drawing.Point(0, 0);
            this.GrbDetalle.Name = "GrbDetalle";
            this.GrbDetalle.Size = new System.Drawing.Size(984, 307);
            this.GrbDetalle.TabIndex = 0;
            this.GrbDetalle.TabStop = false;
            this.GrbDetalle.Text = "»   Detalle de pedido:   «";
            this.GrbDetalle.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // DgvClientes
            // 
            this.DgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvClientes.Location = new System.Drawing.Point(3, 18);
            this.DgvClientes.Name = "DgvClientes";
            this.DgvClientes.Size = new System.Drawing.Size(486, 289);
            this.DgvClientes.TabIndex = 0;
            // 
            // DgvPedidos
            // 
            this.DgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPedidos.Location = new System.Drawing.Point(3, 18);
            this.DgvPedidos.Name = "DgvPedidos";
            this.DgvPedidos.Size = new System.Drawing.Size(482, 289);
            this.DgvPedidos.TabIndex = 0;
            // 
            // DgvDetalle
            // 
            this.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDetalle.Location = new System.Drawing.Point(3, 18);
            this.DgvDetalle.Name = "DgvDetalle";
            this.DgvDetalle.Size = new System.Drawing.Size(978, 286);
            this.DgvDetalle.TabIndex = 0;
            // 
            // FrmPedidosxClienteDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmPedidosxClienteDetalle";
            this.Text = "Consulta de detalle de pedidos por cliente";
            this.Load += new System.EventHandler(this.FrmPedidosxClienteDetalle_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.GrbClientes.ResumeLayout(false);
            this.GrbPedidos.ResumeLayout(false);
            this.GrbDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox GrbClientes;
        private System.Windows.Forms.GroupBox GrbPedidos;
        private System.Windows.Forms.GroupBox GrbDetalle;
        private System.Windows.Forms.DataGridView DgvClientes;
        private System.Windows.Forms.DataGridView DgvPedidos;
        private System.Windows.Forms.DataGridView DgvDetalle;
    }
}