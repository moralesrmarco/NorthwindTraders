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
    public partial class FrmPedidosVendedor : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        BindingSource bsVendedores = new BindingSource();
        BindingSource bsPedidos = new BindingSource();

        public FrmPedidosVendedor()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void GrbPaint(object sender, PaintEventArgs e)
        {
            Utils.GrbPaint(sender, e, this);
        }

        private void FrmPedidosVendedor_Load(object sender, EventArgs e)
        {
            Utils.ConfDataGridView(dgvVendedores);
            Utils.ConfDataGridView(dgvPedidos);
            dgvVendedores.DataSource = bsVendedores;
            dgvPedidos.DataSource = bsPedidos;
            GetData();
            ConfDgvVendedores();
            ConfDgvPedidos();
        }

        private void GetData()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                DataSet ds = new DataSet();
                SqlDataAdapter dapVendedores = new SqlDataAdapter("Sp_Vendedores_Listar", cn);
                dapVendedores.Fill(ds, "Vendedores");
                SqlDataAdapter dapPedidos = new SqlDataAdapter("Sp_PedidosVendedor", cn);
                dapPedidos.Fill(ds, "Pedidos");
                // en la siguiente instrucción se deben de proporcionar los nombres de los campos (alias) que devuelve el store procedure
                DataRelation dataRelation = new DataRelation("PedidosVendedores", ds.Tables["Vendedores"].Columns["Id"], ds.Tables["Pedidos"].Columns["Vendedor Id"]);
                ds.Relations.Add(dataRelation);
                bsVendedores.DataSource = ds;
                bsVendedores.DataMember = "Vendedores";
                bsPedidos.DataSource = bsVendedores;
                bsPedidos.DataMember = "PedidosVendedores";
                Utils.ActualizarBarraDeEstado($"Se encontraron {dgvVendedores.RowCount} registros en vendedores y {dgvPedidos.RowCount} registros de pedidos del vendedor {dgvVendedores.CurrentRow.Cells["Nombres"].Value} {dgvVendedores.CurrentRow.Cells["Apellidos"].Value}", this);
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

        private void FrmPedidosVendedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void dgvVendedores_SelectionChanged(object sender, EventArgs e)
        {
            Utils.ActualizarBarraDeEstado($"Se encontraron {dgvVendedores.RowCount} registros en vendedores y {dgvPedidos.RowCount} registros de pedidos del vendedor {dgvVendedores.CurrentRow.Cells["Nombres"].Value} {dgvVendedores.CurrentRow.Cells["Apellidos"].Value}", this);
        }

        private void ConfDgvVendedores()
        {
            dgvVendedores.Columns["Reportaa"].Visible = false;
            dgvVendedores.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVendedores.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendedores.Columns["Título de cortesia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendedores.Columns["Fecha de nacimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVendedores.Columns["Fecha de contratación"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVendedores.Columns["Ciudad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendedores.Columns["Región"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendedores.Columns["Código postal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendedores.Columns["País"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendedores.Columns["Extensión"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendedores.Columns["Ciudad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVendedores.Columns["Región"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVendedores.Columns["Código postal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVendedores.Columns["País"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVendedores.Columns["Extensión"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVendedores.Columns["Reporta a"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVendedores.Columns["Fecha de contratación"].DefaultCellStyle.Format = "dd \"de\" MMM \"de\" yyyy";
            dgvVendedores.Columns["Fecha de nacimiento"].DefaultCellStyle.Format = "dd \"de\" MMM \"de\" yyyy";
            //dgvVendedores.Columns["Fecha de contratación"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dgvVendedores.Columns["Fecha de nacimiento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVendedores.Columns["Fecha de contratación"].Width = 55;
            dgvVendedores.Columns["Fecha de nacimiento"].Width = 55;
            dgvVendedores.Columns["Título de cortesia"].Width = 40;
        }

        private void ConfDgvPedidos()
        {
            dgvPedidos.Columns["Cliente Id"].Visible = false;
            dgvPedidos.Columns["Nombre de contacto"].Visible = false;
            dgvPedidos.Columns["Vendedor Id"].Visible = false;
            dgvPedidos.Columns["Compañía transportista Id"].Visible = false;
            dgvPedidos.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Total del pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Ciudad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Región"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Código postal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["País"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Flete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Total del pedido"].DefaultCellStyle.Format = "c";
            dgvPedidos.Columns["Flete"].DefaultCellStyle.Format = "c";
            dgvPedidos.Columns["Total del pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPedidos.Columns["Ciudad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPedidos.Columns["Región"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPedidos.Columns["Código postal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPedidos.Columns["País"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPedidos.Columns["Flete"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPedidos.Columns["Id"].DisplayIndex = 0;
            dgvPedidos.Columns["Vendedor"].DisplayIndex = 1;
            dgvPedidos.Columns["Cliente"].DisplayIndex = 2;
            dgvPedidos.Columns["Fecha de pedido"].DisplayIndex = 3;
            dgvPedidos.Columns["Fecha requerido"].DisplayIndex = 4;
            dgvPedidos.Columns["Fecha de envío"].DisplayIndex = 5;
            dgvPedidos.Columns["Total del pedido"].DisplayIndex = 7;
            dgvPedidos.Columns["Flete"].DisplayIndex = 8;
            dgvPedidos.Columns["Dirigido a"].DisplayIndex = 9;
            dgvPedidos.Columns["Domicilio"].DisplayIndex = 10;
            dgvPedidos.Columns["Ciudad"].DisplayIndex = 11;
            dgvPedidos.Columns["Región"].DisplayIndex = 12;
            dgvPedidos.Columns["Código postal"].DisplayIndex = 13;
            dgvPedidos.Columns["País"].DisplayIndex = 14;
            dgvPedidos.Columns["Compañía transportista"].DisplayIndex = 15;
            dgvPedidos.Columns["Cliente Id"].DisplayIndex = 16;
            dgvPedidos.Columns["Nombre de contacto"].DisplayIndex = 17;
            dgvPedidos.Columns["Vendedor Id"].DisplayIndex = 18;
            dgvPedidos.Columns["Fecha de pedido"].DefaultCellStyle.Format = "dd \"de\" MMM \"de\" yyyy\n hh:mm:ss tt";
            dgvPedidos.Columns["Fecha requerido"].DefaultCellStyle.Format = "dd \"de\" MMM \"de\" yyyy\n hh:mm:ss tt";
            dgvPedidos.Columns["Fecha de envío"].DefaultCellStyle.Format = "dd \"de\" MMM \"de\" yyyy\n hh:mm:ss tt";
            dgvPedidos.Columns["Fecha de pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPedidos.Columns["Fecha requerido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPedidos.Columns["Fecha de envío"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPedidos.Columns["Fecha de pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Fecha requerido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Fecha de envío"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
