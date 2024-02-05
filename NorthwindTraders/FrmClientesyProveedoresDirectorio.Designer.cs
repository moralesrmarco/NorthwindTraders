namespace NorthwindTraders
{
    partial class FrmClientesyProveedoresDirectorio
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
            this.grbClientesProveedores = new System.Windows.Forms.GroupBox();
            this.dgvClientesProveedores = new System.Windows.Forms.DataGridView();
            this.grbClientesProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // grbClientesProveedores
            // 
            this.grbClientesProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbClientesProveedores.Controls.Add(this.dgvClientesProveedores);
            this.grbClientesProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbClientesProveedores.Location = new System.Drawing.Point(16, 16);
            this.grbClientesProveedores.Name = "grbClientesProveedores";
            this.grbClientesProveedores.Size = new System.Drawing.Size(952, 592);
            this.grbClientesProveedores.TabIndex = 0;
            this.grbClientesProveedores.TabStop = false;
            this.grbClientesProveedores.Text = "»   Clientes y proveedores:   «";
            this.grbClientesProveedores.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // dgvClientesProveedores
            // 
            this.dgvClientesProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientesProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientesProveedores.Location = new System.Drawing.Point(3, 18);
            this.dgvClientesProveedores.Name = "dgvClientesProveedores";
            this.dgvClientesProveedores.Size = new System.Drawing.Size(946, 571);
            this.dgvClientesProveedores.TabIndex = 0;
            // 
            // FrmClientesyProveedoresDirectorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.ControlBox = false;
            this.Controls.Add(this.grbClientesProveedores);
            this.Name = "FrmClientesyProveedoresDirectorio";
            this.Text = "Directorio de clientes y proveedores por ciudad";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmClientesyProveedoresDirectorio_FormClosed);
            this.Load += new System.EventHandler(this.FrmClientesyProveedoresDirectorio_Load);
            this.grbClientesProveedores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbClientesProveedores;
        private System.Windows.Forms.DataGridView dgvClientesProveedores;
    }
}