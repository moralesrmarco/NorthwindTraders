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
    public partial class FrmClientesyProveedoresDirectorio : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);

        public FrmClientesyProveedoresDirectorio()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void GrbPaint(object sender, PaintEventArgs e)
        {
            Utils.GrbPaint(sender, e, this);
        }

        private void FrmClientesyProveedoresDirectorio_Load(object sender, EventArgs e)
        {
            Utils.ConfDataGridView(dgvClientesProveedores);
            LlenarDgvClientesProveedores();
            ConfDgvClientesProveedores();
        }

        private void LlenarDgvClientesProveedores()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                SqlCommand cmd = new SqlCommand("Select * from Vw_ClientesProveedores_DirectorioPorCiudad", cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dap.Fill(tbl);
                dgvClientesProveedores.DataSource = tbl;
                Utils.ActualizarBarraDeEstado($"Se encontraron {dgvClientesProveedores.RowCount} registros", this);
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

        private void ConfDgvClientesProveedores()
        {
            dgvClientesProveedores.Columns["Ciudad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientesProveedores.Columns["País"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientesProveedores.Columns["Relación"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientesProveedores.Columns["Teléfono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientesProveedores.Columns["Región"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientesProveedores.Columns["Código postal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientesProveedores.Columns["Fax"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientesProveedores.Columns["País"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClientesProveedores.Columns["Relación"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClientesProveedores.Columns["Teléfono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClientesProveedores.Columns["Región"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClientesProveedores.Columns["Código postal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClientesProveedores.Columns["Fax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
