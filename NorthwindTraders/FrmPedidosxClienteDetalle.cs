using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindTraders
{ 
    public partial class FrmPedidosxClienteDetalle : Form
    {
        public FrmPedidosxClienteDetalle()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void GrbPaint(object sender, PaintEventArgs e)
        {
            Utils.GrbPaint(sender, e, this);
        }

        private void FrmPedidosxClienteDetalle_Load(object sender, EventArgs e)
        {
            Utils.ConfDataGridView(DgvClientes);
            Utils.ConfDataGridView(DgvPedidos);
            Utils.ConfDataGridView(DgvDetalle);
        }
    }
}
