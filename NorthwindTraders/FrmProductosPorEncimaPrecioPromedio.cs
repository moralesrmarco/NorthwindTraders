using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmProductosPorEncimaPrecioPromedio : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        decimal precioPromedio = 0;

        public FrmProductosPorEncimaPrecioPromedio()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void GrbPaint(object sender, PaintEventArgs e)
        {
            Utils.GrbPaint(sender, e, this);
        }

        private void FrmProductosPorEncimaPrecioPromedio_Load(object sender, EventArgs e)
        {
            CalcularPrecioPromedio();
            Utils.ConfDataGridView(dgvListado);
            LlenarDgvListado();
            ConfDgvListado();
        }

        private void CalcularPrecioPromedio()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                SqlCommand cmd = new SqlCommand("SELECT AVG(UnitPrice) AS [Precio promedio] FROM Products", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (rdr.Read())
                {
                    precioPromedio = Convert.ToDecimal(rdr["Precio promedio"]);
                }
                string strPrecioPromedio = precioPromedio.ToString("c");
                grbListado.Text = "»   Listado de productos con el precio por encima del precio promedio " + strPrecioPromedio + " :   «";
                Utils.ActualizarBarraDeEstado("Activo", this);
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
            finally
            {
                cn.Close();
            }
        }

        private void LlenarDgvListado()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                SqlCommand cmd = new SqlCommand("Select * from Vw_ProductosPorEncimaDelPrecioPromedio", cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dap.Fill(tbl);
                dgvListado.DataSource = tbl;
                Utils.ActualizarBarraDeEstado($"Se encontraron {dgvListado.RowCount} registros", this);
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

        private void ConfDgvListado()
        {
            dgvListado.Columns["Fila"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvListado.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListado.Columns["Precio"].DefaultCellStyle.Format = "c";
            dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void FrmProductosPorEncimaPrecioPromedio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }
    }
}
