using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmPedidosxClientes : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        string clienteId;
        //bool keyTab = false;

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
            //ConfDgvClientes();
            LlenarDgvPedidos();
            //ConfDgvPedidos();
        }

        private void LlenarDgvClientes()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos, obteniendo los clientes...", this);
                SqlCommand cmd = new SqlCommand("Sp_Clientes_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dgvClientes.DataSource = dt;
                ConfDgvClientes();
                clienteId = dgvClientes.CurrentRow.Cells["Id"].Value.ToString();
                Utils.ActualizarBarraDeEstado($"Se encontraron {dgvClientes.RowCount} registros de clientes", this);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error con la base de datos:\n" + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error:\n" + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Utils.ActualizarBarraDeEstado("Consultando la base de datos, obteniendo los pedidos...", this);
                dgvPedidos.DataSource = null;
                dgvPedidos.Refresh();
                SqlCommand cmd = new SqlCommand("Sp_PedidosxCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("ClienteId", dgvClientes.CurrentRow.Cells["Id"].Value.ToString());
                cmd.Parameters.AddWithValue("ClienteId", clienteId);
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dgvPedidos.DataSource = dt;
                ConfDgvPedidos();
                int rowsPedidos = dgvPedidos.RowCount;
                if (rowsPedidos == 1 && dgvPedidos.Rows[0].Cells["Id"].Value.ToString() == "")
                    rowsPedidos = 0;
                Utils.ActualizarBarraDeEstado($"Se encontraron {dgvClientes.RowCount} registros de clientes y {rowsPedidos} registros de pedidos del cliente", this);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error con la base de datos:\n" + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error:\n" + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clienteId = dgvClientes.CurrentRow.Cells["Id"].Value.ToString();
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

        //private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        //{
        //    //if (keyTab)
        //    //    return;
        //    // esto si me funciona cuando se cambia de selección con las teclas Up, Down, pageUp y pageDown
        //    // pero no funciona cuando se cambia de registro con las teclas tab y shifttab por lo que procedo a programar el evento keyDown
        //    LlenarDgvPedidos();
        //    //keyTab = false;
        //}

        private void dgvClientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Utils.ActualizarBarraDeEstado($"Se encontraron {dgvClientes.RowCount} registros de clientes y {dgvPedidos.RowCount} registros de pedidos del cliente", this);
        }

        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Tab || (e.KeyCode == Keys.Tab && e.Shift) || (e.KeyCode == Keys.Up && e.Control) || (e.KeyCode == Keys.Down && e.Control) || (e.KeyCode == Keys.Enter && e.Control)))
                return;
            int rowIndex = 0;
            if (e.KeyCode == Keys.Enter && e.Control)
                return;
            else if (e.KeyCode == Keys.Up && e.Control)
                rowIndex = 0;
            else if (e.KeyCode == Keys.Down && e.Control)
                rowIndex = dgvClientes.RowCount - 1;
            else if (e.KeyCode == Keys.Up)
            {
                rowIndex = dgvClientes.CurrentRow.Index - 1;
                if (rowIndex < 0)
                    return;
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                rowIndex = dgvClientes.CurrentRow.Index + 1;
                if (rowIndex >= dgvClientes.RowCount)
                    return;
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                rowIndex = dgvClientes.CurrentRow.Index;
                int visibleRowCount = dgvClientes.DisplayedRowCount(false);
                rowIndex = Math.Max(0, rowIndex - visibleRowCount);
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                rowIndex = dgvClientes.CurrentRow.Index;
                int visibleRowCount = dgvClientes.DisplayedRowCount(false);
                rowIndex = Math.Min(dgvClientes.RowCount - 1, rowIndex + visibleRowCount);
            }
            else if (e.KeyCode == Keys.Tab && e.Shift)
            {
                if (dgvClientes.CurrentCell.ColumnIndex == 0)
                    rowIndex = dgvClientes.CurrentRow.Index - 1;
                else
                    return;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                if (dgvClientes.CurrentCell.ColumnIndex == dgvClientes.Columns.Count - 1)
                    rowIndex = dgvClientes.CurrentRow.Index + 1;
                else
                    return;
            }
            //keyTab = true;
            DataGridViewRow row = dgvClientes.Rows[rowIndex];
            clienteId = row.Cells["Id"].Value.ToString();
            LlenarDgvPedidos();
            //keyTab = false;
        }

        //private void LlenarDgvPedidos2()
        //{
        //    try
        //    {
        //        Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
        //        SqlCommand cmd = new SqlCommand("Sp_PedidosxCliente", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("ClienteId", clienteId);
        //        SqlDataAdapter dap = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        dap.Fill(dt);
        //        dgvPedidos.DataSource = dt;
        //        Utils.ActualizarBarraDeEstado($"Se encontraron {dgvClientes.RowCount} registros de clientes y {dgvPedidos.RowCount} registros de pedidos del cliente", this);
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show("Ocurrio un error con la base de datos: " + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Utils.ActualizarBarraDeEstado("Activo", this);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ocurrio un error: " + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Utils.ActualizarBarraDeEstado("Activo", this);
        //    }
        //}
    }
}
