using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmProveedoresProductos : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        BindingSource bsProveedores = new BindingSource();
        BindingSource bsProductos = new BindingSource();

        public FrmProveedoresProductos()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void grb_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.Black, this);
        }

        private void FrmProveedoresProductos_Load(object sender, EventArgs e)
        {
            dgvProveedores.DataSource = bsProveedores;
            dgvProductos.DataSource = bsProductos;
            GetData();
            Utils.ConfDataGridView(dgvProveedores);
            Utils.ConfDataGridView(dgvProductos);
            Utils.ConfDgvProductos(dgvProductos);
        }

        private void GetData()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                DataSet ds = new DataSet();
                ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                SqlDataAdapter dapProveedores = new SqlDataAdapter("Sp_Proveedores_Listar", cn);
                dapProveedores.Fill(ds, "Proveedores");
                SqlDataAdapter dapProductos = new SqlDataAdapter("Sp_Productos_All", cn);
                dapProductos.Fill(ds, "Productos");
                // en la siguiente instrucción se deben de proporcionar los nombres de los campos (alias) que devuelve el store procedure
                DataRelation dataRelation = new DataRelation("ProveedoresProductos", ds.Tables["Proveedores"].Columns["Id"], ds.Tables["Productos"].Columns["IdProveedor"]);
                ds.Relations.Add(dataRelation);
                bsProveedores.DataSource = ds;
                bsProveedores.DataMember = "Proveedores";
                bsProductos.DataSource = bsProveedores;
                bsProductos.DataMember = "ProveedoresProductos";
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

        private void FrmProveedoresProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            Utils.ActualizarBarraDeEstado($"Se encontraron {dgvProveedores.RowCount} registros en proveedores y {dgvProductos.RowCount} registros de productos; del proveedor {dgvProveedores.CurrentRow.Cells["Nombre de compañía"].Value}", this);
        }

        private void dgvProveedores_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Utils.ActualizarBarraDeEstado($"Se encontraron {dgvProveedores.RowCount} registros en proveedores", this);
        }
    }
}
