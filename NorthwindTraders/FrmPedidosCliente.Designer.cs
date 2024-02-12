namespace NorthwindTraders
{
    partial class FrmPedidosCliente
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
            this.grbClientes = new System.Windows.Forms.GroupBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.grbPedidos = new System.Windows.Forms.GroupBox();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.grbPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.grbClientes);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grbPedidos);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.splitContainer1.Size = new System.Drawing.Size(984, 621);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 0;
            // 
            // grbClientes
            // 
            this.grbClientes.Controls.Add(this.dgvClientes);
            this.grbClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbClientes.Location = new System.Drawing.Point(10, 3);
            this.grbClientes.Name = "grbClientes";
            this.grbClientes.Size = new System.Drawing.Size(964, 322);
            this.grbClientes.TabIndex = 0;
            this.grbClientes.TabStop = false;
            this.grbClientes.Text = "»   Clientes:   «";
            this.grbClientes.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientes.Location = new System.Drawing.Point(3, 18);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(958, 301);
            this.dgvClientes.TabIndex = 0;
            this.dgvClientes.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvClientes_DataBindingComplete);
            this.dgvClientes.SelectionChanged += new System.EventHandler(this.dgvClientes_SelectionChanged);
            // 
            // grbPedidos
            // 
            this.grbPedidos.Controls.Add(this.dgvPedidos);
            this.grbPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPedidos.Location = new System.Drawing.Point(10, 3);
            this.grbPedidos.Name = "grbPedidos";
            this.grbPedidos.Size = new System.Drawing.Size(964, 283);
            this.grbPedidos.TabIndex = 0;
            this.grbPedidos.TabStop = false;
            this.grbPedidos.Text = "»   Pedidos:   «";
            this.grbPedidos.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidos.Location = new System.Drawing.Point(3, 18);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.Size = new System.Drawing.Size(958, 262);
            this.dgvPedidos.TabIndex = 0;
            // 
            // FrmPedidosCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmPedidosCliente";
            this.Text = "Consulta de pedidos por cliente";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPedidosCliente_FormClosed);
            this.Load += new System.EventHandler(this.FrmPedidosCliente_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.grbPedidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grbClientes;
        private System.Windows.Forms.GroupBox grbPedidos;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DataGridView dgvPedidos;
    }
}