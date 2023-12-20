using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmCategoriasProductos : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        BindingSource bsCategorias = new BindingSource();
        BindingSource bsProductos = new BindingSource();

        public FrmCategoriasProductos()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void grb_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.Black, this);
        }

        private void FrmCategoriasProductos_Load(object sender, EventArgs e)
        {
            dgvCategorias.DataSource = bsCategorias;
            dgvProductos.DataSource = bsProductos;
            GetData();
            Utils.ConfDataGridView(dgvCategorias);
            Utils.ConfDataGridView(dgvProductos);
            Utils.ConfDgvProductos(dgvProductos);
            dgvCategorias.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCategorias.Columns["Categoría"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCategorias.Columns["Foto"].Width = 50;
            dgvCategorias.Columns["Foto"].DefaultCellStyle.Padding = new Padding(4, 4, 4, 4);
            ((DataGridViewImageColumn)dgvCategorias.Columns["Foto"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
            Utils.ActualizarBarraDeEstado($"Se encontraron {dgvCategorias.RowCount} registros en categorias y {dgvProductos.RowCount} registros de productos en la categoria {dgvCategorias.CurrentRow.Cells["Categoría"].Value}", this);
        }

        private void GetData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds.Locale = System.Globalization.CultureInfo.InvariantCulture;
                SqlDataAdapter dapCategorias = new SqlDataAdapter("Sp_Categorias_Listar", cn);
                dapCategorias.Fill(ds, "Categorias");
                SqlDataAdapter dapProductos = new SqlDataAdapter("Sp_Productos_All", cn);
                dapProductos.Fill(ds, "Productos");
                // en la siguiente instrucción se deben de proporcionar los nombres de los campos (alias) que devuelve el store procedure
                DataRelation dataRelation = new DataRelation("CategoriasProductos", ds.Tables["Categorias"].Columns["Id"], ds.Tables["Productos"].Columns["IdCategoria"]);
                ds.Relations.Add(dataRelation);
                bsCategorias.DataSource = ds;
                bsCategorias.DataMember = "Categorias";
                bsProductos.DataSource = bsCategorias;
                bsProductos.DataMember = "CategoriasProductos";
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

        private void FrmCategoriasProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Utils.ActualizarBarraDeEstado($"Se encontraron {dgvCategorias.RowCount} registros en categorias y {dgvProductos.RowCount} registros de productos en la categoria {dgvCategorias.CurrentRow.Cells["Categoría"].Value}", this);
        }
    }
}
