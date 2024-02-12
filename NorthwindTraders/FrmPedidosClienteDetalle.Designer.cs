namespace NorthwindTraders
{
    partial class FrmPedidosClienteDetalle
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
            this.grbClientes = new System.Windows.Forms.GroupBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.grbPedidos = new System.Windows.Forms.GroupBox();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.grbDetallePedido = new System.Windows.Forms.GroupBox();
            this.dgvDetallePedido = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grbClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.grbPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.grbDetallePedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.grbDetallePedido);
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
            this.splitContainer2.Panel1.Controls.Add(this.grbClientes);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(10, 3, 5, 3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grbPedidos);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(5, 3, 10, 3);
            this.splitContainer2.Size = new System.Drawing.Size(984, 310);
            this.splitContainer2.SplitterDistance = 492;
            this.splitContainer2.TabIndex = 0;
            // 
            // grbClientes
            // 
            this.grbClientes.Controls.Add(this.dgvClientes);
            this.grbClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbClientes.Location = new System.Drawing.Point(10, 3);
            this.grbClientes.Name = "grbClientes";
            this.grbClientes.Size = new System.Drawing.Size(477, 304);
            this.grbClientes.TabIndex = 0;
            this.grbClientes.TabStop = false;
            this.grbClientes.Text = "»   Clientes:   «";
            this.grbClientes.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientes.Location = new System.Drawing.Point(3, 19);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(471, 282);
            this.dgvClientes.TabIndex = 0;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);
            // 
            // grbPedidos
            // 
            this.grbPedidos.Controls.Add(this.dgvPedidos);
            this.grbPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPedidos.Location = new System.Drawing.Point(5, 3);
            this.grbPedidos.Name = "grbPedidos";
            this.grbPedidos.Size = new System.Drawing.Size(473, 304);
            this.grbPedidos.TabIndex = 0;
            this.grbPedidos.TabStop = false;
            this.grbPedidos.Text = "»   Pedidos:   «";
            this.grbPedidos.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidos.Location = new System.Drawing.Point(3, 19);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.Size = new System.Drawing.Size(467, 282);
            this.dgvPedidos.TabIndex = 0;
            this.dgvPedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellClick);
            // 
            // grbDetallePedido
            // 
            this.grbDetallePedido.Controls.Add(this.dgvDetallePedido);
            this.grbDetallePedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDetallePedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDetallePedido.Location = new System.Drawing.Point(10, 3);
            this.grbDetallePedido.Name = "grbDetallePedido";
            this.grbDetallePedido.Size = new System.Drawing.Size(964, 301);
            this.grbDetallePedido.TabIndex = 0;
            this.grbDetallePedido.TabStop = false;
            this.grbDetallePedido.Text = "»   Detalle de pedido:   «";
            this.grbDetallePedido.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // dgvDetallePedido
            // 
            this.dgvDetallePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallePedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetallePedido.Location = new System.Drawing.Point(3, 19);
            this.dgvDetallePedido.Name = "dgvDetallePedido";
            this.dgvDetallePedido.Size = new System.Drawing.Size(958, 279);
            this.dgvDetallePedido.TabIndex = 0;
            // 
            // FrmPedidosClienteDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmPedidosClienteDetalle";
            this.Text = "Consulta de detalle de pedidos por cliente";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPedidosClienteDetalle_FormClosed);
            this.Load += new System.EventHandler(this.FrmPedidosClienteDetalle_Load);
            this.Shown += new System.EventHandler(this.FrmPedidosClienteDetalle_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grbClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.grbPedidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.grbDetallePedido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox grbClientes;
        private System.Windows.Forms.GroupBox grbPedidos;
        private System.Windows.Forms.GroupBox grbDetallePedido;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.DataGridView dgvDetallePedido;
    }
}