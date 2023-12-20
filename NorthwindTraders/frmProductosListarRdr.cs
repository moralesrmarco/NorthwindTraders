using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class frmProductosListarRdr : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);

        string strProcedure = "";

        public frmProductosListarRdr()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmProductosListarRdr_Load(object sender, EventArgs e)
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                SqlCommand cmd = new SqlCommand("Select 0 As IdCategoria, '»--- Seleccione ---«' As Categoria Union All Select CategoryId As IdCategoria, CategoryName As Categoria From Categories", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                BindingSource bs = new BindingSource();
                bs.DataSource = dr;
                cboCategoria.DataSource = bs;
                cboCategoria.DisplayMember = "Categoria";
                cboCategoria.ValueMember = "IdCategoria";
                dr.Close();
                SqlCommand cmd1 = new SqlCommand("Select 0 As IdProveedor, '»--- Seleccione ---«' As Proveedor Union All Select SupplierId As IdProveedor, CompanyName As Proveedor From Suppliers", cn);
                cmd1.CommandType = CommandType.Text;
                SqlDataReader dr1 = cmd1.ExecuteReader(CommandBehavior.SingleResult);
                BindingSource bs1 = new BindingSource();
                bs1.DataSource = dr1;
                cboProveedor.DataSource = bs1;
                cboProveedor.DisplayMember = "Proveedor";
                cboProveedor.ValueMember = "IdProveedor";
                dr1.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error con la base de datos: " + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            strProcedure = "SP_Productos_All";
            llenarDgvLista(sender);
        }

        private void llenarDgvLista(object sender)
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                SqlCommand cmd = new SqlCommand(strProcedure, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //MessageBox.Show(((Button)sender).Tag.ToString());
                if (((Button)sender).Tag.ToString() == "Buscar")
                {
                    cmd.Parameters.AddWithValue("Id", txtId.Text);
                    cmd.Parameters.AddWithValue("Producto", txtNombre.Text);
                    cmd.Parameters.AddWithValue("Categoria", cboCategoria.SelectedValue);
                    cmd.Parameters.AddWithValue("Proveedor", cboProveedor.SelectedValue);
                }
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (dr.HasRows)
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dr;
                    dgvLista.DataSource = bs;
                    Utils.ConfDataGridView(dgvLista);
                    Utils.ConfDgvProductos(dgvLista);
                    Utils.ActualizarBarraDeEstado($"Se encontraron: {dgvLista.RowCount} registros", this);
                }
                else
                {
                    dgvLista.DataSource = null;
                    Utils.ActualizarBarraDeEstado("No se encontraron registros con el criterio de buqueda proporcionado", this, true);
                }
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
            cboCategoria.SelectedIndex = 0;
            cboProveedor.SelectedIndex = 0;
            dgvLista.DataSource = null;
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            strProcedure = "SP_Productos_Buscar";
            llenarDgvLista(sender);
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        private void frmProductosListarRdr_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }
    }
}
