namespace NorthwindTraders
{
    partial class FrmProductosEliminarDap
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(392, 208);
            this.btnActualizar.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.SetChildIndex(this.btnActualizar, 0);
            this.groupBox2.Controls.SetChildIndex(this.txtProducto, 0);
            this.groupBox2.Controls.SetChildIndex(this.txtCantidadxU, 0);
            this.groupBox2.Controls.SetChildIndex(this.txtPrecio, 0);
            this.groupBox2.Controls.SetChildIndex(this.txtUInventario, 0);
            this.groupBox2.Controls.SetChildIndex(this.txtUPedido, 0);
            this.groupBox2.Controls.SetChildIndex(this.txtPPedido, 0);
            this.groupBox2.Controls.SetChildIndex(this.cboCategoria, 0);
            this.groupBox2.Controls.SetChildIndex(this.cboProveedor, 0);
            this.groupBox2.Controls.SetChildIndex(this.chkDescontinuado, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnEliminar, 0);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(392, 256);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(168, 23);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar producto";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FrmProductosEliminarDap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(822, 549);
            this.Name = "FrmProductosEliminarDap";
            this.Load += new System.EventHandler(this.FrmProductosEliminarDap_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
    }
}
