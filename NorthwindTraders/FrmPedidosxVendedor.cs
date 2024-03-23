using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmPedidosxVendedor : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        static int employeeId;

        public FrmPedidosxVendedor()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void GrbPaint(object sender, PaintEventArgs e)
        {
            Utils.GrbPaint(sender, e, this);
        }

        private void FrmPedidosxVendedor_Load(object sender, EventArgs e)
        {
            Utils.ConfDataGridView(DgvVendedores);
            Utils.ConfDataGridView(DgvPedidos);
            LlenarDgvVendedores();
            LlenarDgvPedidos();
        }

        private void LlenarDgvVendedores()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos, obteniendo los vendedores...", this);
                SqlCommand cmd = new SqlCommand("Sp_Vendedores_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                DgvVendedores.DataSource = dt;
                employeeId = (int)DgvVendedores.CurrentRow.Cells["Id"].Value;
                ConfDgvVendedores();
                Utils.ActualizarBarraDeEstado($"Se encontraron {DgvVendedores.RowCount} registros de vendedores", this);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error con la base de datos: \n" + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: \n" + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
        }

        private void ConfDgvVendedores()
        {
            DgvVendedores.Columns["Reportaa"].Visible = false;
            DgvVendedores.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvVendedores.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvVendedores.Columns["Título de cortesia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvVendedores.Columns["Fecha de nacimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvVendedores.Columns["Fecha de contratación"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvVendedores.Columns["Ciudad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvVendedores.Columns["Región"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvVendedores.Columns["Código postal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvVendedores.Columns["País"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvVendedores.Columns["Extensión"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvVendedores.Columns["Ciudad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvVendedores.Columns["Región"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvVendedores.Columns["Código postal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvVendedores.Columns["País"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvVendedores.Columns["Extensión"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvVendedores.Columns["Reporta a"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvVendedores.Columns["Fecha de contratación"].DefaultCellStyle.Format = "dd \"de\" MMM \"de\" yyyy";
            DgvVendedores.Columns["Fecha de nacimiento"].DefaultCellStyle.Format = "dd \"de\" MMM \"de\" yyyy";
            //DgvVendedores.Columns["Fecha de contratación"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //DgvVendedores.Columns["Fecha de nacimiento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvVendedores.Columns["Fecha de contratación"].Width = 55;
            DgvVendedores.Columns["Fecha de nacimiento"].Width = 55;
            DgvVendedores.Columns["Título de cortesia"].Width = 40;
        }

        private void LlenarDgvPedidos()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos, obteniendo los pedidos...", this);
                DgvPedidos.DataSource = null;
                DgvPedidos.Refresh();
                SqlCommand cmd = new SqlCommand("Sp_PedidosxVendedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("VendedorId", employeeId);
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                DgvPedidos.DataSource = dt;
                ConfDgvPedidos();
                int rowsPedidos = DgvPedidos.RowCount;
                if (rowsPedidos == 1 && DgvPedidos.Rows[0].Cells["Id"].Value.ToString() == "")
                    rowsPedidos = 0;
                Utils.ActualizarBarraDeEstado($"Se encontraron {DgvVendedores.RowCount} registros en vendedores y {rowsPedidos} registros de pedidos del vendedor {DgvPedidos.Rows[0].Cells["Vendedor"].Value}", this);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error con la base de datos: \n" + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: \n" + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
        }

        private void ConfDgvPedidos()
        {
            DgvPedidos.Columns["Cliente Id"].Visible = false;
            DgvPedidos.Columns["Nombre de contacto"].Visible = false;
            DgvPedidos.Columns["Vendedor Id"].Visible = false;
            DgvPedidos.Columns["Compañía transportista Id"].Visible = false;
            DgvPedidos.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Total del pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Ciudad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Región"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Código postal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["País"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Flete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Total del pedido"].DefaultCellStyle.Format = "c";
            DgvPedidos.Columns["Flete"].DefaultCellStyle.Format = "c";
            DgvPedidos.Columns["Total del pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvPedidos.Columns["Ciudad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvPedidos.Columns["Región"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvPedidos.Columns["Código postal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvPedidos.Columns["País"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvPedidos.Columns["Flete"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvPedidos.Columns["Id"].DisplayIndex = 0;
            DgvPedidos.Columns["Vendedor"].DisplayIndex = 1;
            DgvPedidos.Columns["Cliente"].DisplayIndex = 2;
            DgvPedidos.Columns["Fecha de pedido"].DisplayIndex = 3;
            DgvPedidos.Columns["Fecha requerido"].DisplayIndex = 4;
            DgvPedidos.Columns["Fecha de envío"].DisplayIndex = 5;
            DgvPedidos.Columns["Total del pedido"].DisplayIndex = 7;
            DgvPedidos.Columns["Flete"].DisplayIndex = 8;
            DgvPedidos.Columns["Dirigido a"].DisplayIndex = 9;
            DgvPedidos.Columns["Domicilio"].DisplayIndex = 10;
            DgvPedidos.Columns["Ciudad"].DisplayIndex = 11;
            DgvPedidos.Columns["Región"].DisplayIndex = 12;
            DgvPedidos.Columns["Código postal"].DisplayIndex = 13;
            DgvPedidos.Columns["País"].DisplayIndex = 14;
            DgvPedidos.Columns["Compañía transportista"].DisplayIndex = 15;
            DgvPedidos.Columns["Cliente Id"].DisplayIndex = 16;
            DgvPedidos.Columns["Nombre de contacto"].DisplayIndex = 17;
            DgvPedidos.Columns["Vendedor Id"].DisplayIndex = 18;
            DgvPedidos.Columns["Fecha de pedido"].DefaultCellStyle.Format = "dd \"de\" MMM \"de\" yyyy\n hh:mm:ss tt";
            DgvPedidos.Columns["Fecha requerido"].DefaultCellStyle.Format = "dd \"de\" MMM \"de\" yyyy\n hh:mm:ss tt";
            DgvPedidos.Columns["Fecha de envío"].DefaultCellStyle.Format = "dd \"de\" MMM \"de\" yyyy\n hh:mm:ss tt";
            DgvPedidos.Columns["Fecha de pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvPedidos.Columns["Fecha requerido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvPedidos.Columns["Fecha de envío"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvPedidos.Columns["Fecha de pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Fecha requerido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Fecha de envío"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void DgvVendedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            employeeId = (int)DgvVendedores.CurrentRow.Cells["Id"].Value;
            LlenarDgvPedidos();
        }

        private void FrmPedidosxVendedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void DgvVendedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Tab || (e.KeyCode == Keys.Tab && e.Shift) || (e.KeyCode == Keys.Up && e.Control) || (e.KeyCode == Keys.Down && e.Control) || (e.KeyCode == Keys.Enter && e.Control)))
                return;
            int rowIndex = 0;
            if (e.KeyCode == Keys.Enter && e.Control)
                return;
            else if (e.KeyCode == Keys.Up && e.Control)
                rowIndex = 0;
            else if (e.KeyCode == Keys.Down && e.Control)
                rowIndex = DgvVendedores.RowCount - 1;
            else if (e.KeyCode == Keys.Up)
            {
                rowIndex = DgvVendedores.CurrentRow.Index - 1;
                if (rowIndex < 0)
                    return;
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                rowIndex = DgvVendedores.CurrentRow.Index + 1;
                if (rowIndex >= DgvVendedores.RowCount)
                    return;
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                rowIndex = DgvVendedores.CurrentRow.Index;
                int visibleRowCount = DgvVendedores.DisplayedRowCount(false);
                rowIndex = Math.Max(0, rowIndex - visibleRowCount);
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                rowIndex = DgvVendedores.CurrentRow.Index;
                int visibleRowCount = DgvVendedores.DisplayedRowCount(false);
                rowIndex = Math.Min(DgvVendedores.RowCount - 1, rowIndex + visibleRowCount);
            }
            else if (e.KeyCode == Keys.Tab && e.Shift)
            {
                if (DgvVendedores.CurrentCell.ColumnIndex == 0) // el columnindex del campo Id es 0
                    rowIndex = DgvVendedores.CurrentRow.Index - 1;
                else
                    return;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                if (DgvVendedores.CurrentCell.ColumnIndex == DgvVendedores.Columns.Count - 1)
                    rowIndex = DgvVendedores.CurrentRow.Index + 1;
                else
                    return;
            }
            DataGridViewRow row = DgvVendedores.Rows[rowIndex];
            employeeId = (int)row.Cells["Id"].Value;
            LlenarDgvPedidos();
        }
    }
}
