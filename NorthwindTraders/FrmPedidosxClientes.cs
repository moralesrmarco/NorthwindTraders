using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmPedidosxClientes : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);

        public FrmPedidosxClientes()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void GrbPaint(object sender, PaintEventArgs e)
        {
            Utils.GrbPaint(sender, e, this);
        }

        private void FrmPedidosxClientes_Load(object sender, EventArgs e)
        {
            Utils.ConfDataGridView(dgvClientes);
            Utils.ConfDataGridView(dgvPedidos);
            LlenarDgvClientes();
            ConfDgvClientes();
            LlenarDgvPedidos();
            ConfDgvPedidos();
        }

        private void LlenarDgvClientes()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                SqlCommand cmd = new SqlCommand("Sp_Clientes_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dgvClientes.DataSource = dt;
                Utils.ActualizarBarraDeEstado($"Se encontraron {dgvClientes.RowCount} registros de clientes", this);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error con la base de datos: " + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
        }

        private void FrmPedidosxClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void ConfDgvClientes()
        {
            dgvClientes.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClientes.Columns["Ciudad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns["Ciudad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClientes.Columns["Región"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns["Región"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClientes.Columns["Código postal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns["Código postal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClientes.Columns["País"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns["País"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClientes.Columns["Teléfono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClientes.Columns["Fax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void LlenarDgvPedidos()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                SqlCommand cmd = new SqlCommand("Sp_PedidosxCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ClienteId", dgvClientes.CurrentRow.Cells["Id"].Value.ToString());
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dgvPedidos.DataSource = dt;
                Utils.ActualizarBarraDeEstado($"Se encontraron {dgvClientes.RowCount} registros de clientes y {dgvPedidos.RowCount} registros de pedidos del cliente", this);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error con la base de datos: " + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarDgvPedidos();
        }

        private void ConfDgvPedidos()
        {
            dgvPedidos.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPedidos.Columns["Cliente Id"].Visible = false;
            dgvPedidos.Columns["Nombre de contacto"].Visible = false;
            dgvPedidos.Columns["Vendedor Id"].Visible = false;
            dgvPedidos.Columns["Total del pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvPedidos.Columns["Total del pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPedidos.Columns["Total del pedido"].DefaultCellStyle.Format = "c";
            dgvPedidos.Columns["Fecha de pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Fecha de pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPedidos.Columns["Fecha de pedido"].DefaultCellStyle.Format = "dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            dgvPedidos.Columns["Fecha requerido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Fecha requerido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPedidos.Columns["Fecha requerido"].DefaultCellStyle.Format = "dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            dgvPedidos.Columns["Fecha de envío"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Fecha de envío"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPedidos.Columns["Fecha de envío"].DefaultCellStyle.Format = "dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            dgvPedidos.Columns["Compañía transportista Id"].Visible = false;
            dgvPedidos.Columns["Compañía transportista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvPedidos.Columns["Compañía transportista"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPedidos.Columns["Flete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Flete"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPedidos.Columns["Flete"].DefaultCellStyle.Format = "c";
            dgvPedidos.Columns["Ciudad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Ciudad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPedidos.Columns["Región"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Región"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPedidos.Columns["Código postal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Código postal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPedidos.Columns["País"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["País"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            LlenarDgvPedidos();
        }

        private void dgvClientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Utils.ActualizarBarraDeEstado($"Se encontraron {dgvClientes.RowCount} registros de clientes y {dgvPedidos.RowCount} registros de pedidos del cliente", this);
        }
    }
}
