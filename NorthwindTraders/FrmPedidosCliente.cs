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
    public partial class FrmPedidosCliente : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        BindingSource bsClientes = new BindingSource();
        BindingSource bsPedidos = new BindingSource();

        public FrmPedidosCliente()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void GrbPaint(object sender, PaintEventArgs e)
        {
            Utils.GrbPaint(sender, e, this);
        }

        private void FrmPedidosCliente_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = bsClientes;
            dgvPedidos.DataSource = bsPedidos;
            GetData();
            Utils.ConfDataGridView(dgvClientes);
            Utils.ConfDataGridView(dgvPedidos);
            ConfDgvPedidos(dgvPedidos);
        }

        private void GetData()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                DataSet ds = new DataSet();
                SqlDataAdapter dapClientes = new SqlDataAdapter("Sp_Clientes_Listar", cn);
                dapClientes.Fill(ds, "Clientes");
                // primero intente con una vista y me marco error, tuve que poner el codigo sql en un procedimiento almacenado
                //SqlDataAdapter dapPedidos = new SqlDataAdapter("Vw_PedidosCliente", cn)
                SqlDataAdapter dapPedidos = new SqlDataAdapter("Sp_PedidosCliente", cn);
                dapPedidos.Fill(ds, "Pedidos");
                // en la siguiente instrucción se deben de proporcionar los nombres de los campos (alias) que devuelve el store procedure
                DataRelation dataRelation = new DataRelation("PedidosCliente", ds.Tables["Clientes"].Columns["Id"], ds.Tables["Pedidos"].Columns["Cliente Id"]);
                ds.Relations.Add(dataRelation);
                bsClientes.DataSource = ds;
                bsClientes.DataMember = "Clientes";
                bsPedidos.DataSource = bsClientes;
                bsPedidos.DataMember = "PedidosCliente";
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

        private void FrmPedidosCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            Utils.ActualizarBarraDeEstado($"Se encontraron {dgvClientes.RowCount} registros en clientes y {dgvPedidos.RowCount} registros de pedidos del cliente {dgvClientes.CurrentRow.Cells["Nombre de compañía"].Value}", this);
        }

        private void ConfDgvPedidos(DataGridView dgv)
        {
            dgv.Columns["Id"].DisplayIndex = 0;
            dgv.Columns["Cliente"].DisplayIndex = 1;
            dgv.Columns["Vendedor"].DisplayIndex = 2;
            dgv.Columns["Total del pedido"].DisplayIndex = 3;
            dgv.Columns["Fecha de pedido"].DisplayIndex = 4;
            dgv.Columns["Fecha requerido"].DisplayIndex = 5;
            dgv.Columns["Fecha de envío"].DisplayIndex = 6;
            dgv.Columns["Flete"].DisplayIndex = 7;
            dgv.Columns["Compañía transportista"].DisplayIndex = 8;
            dgv.Columns["Dirigido a"].DisplayIndex = 9;
            dgv.Columns["Domicilio"].DisplayIndex = 10;
            dgv.Columns["Ciudad"].DisplayIndex = 11;
            dgv.Columns["Región"].DisplayIndex = 12;
            dgv.Columns["Código postal"].DisplayIndex = 13;
            dgv.Columns["País"].DisplayIndex = 14;
            dgv.Columns["Cliente Id"].DisplayIndex = 15;
            dgv.Columns["Nombre de contacto"].DisplayIndex = 16;
            dgv.Columns["Vendedor Id"].DisplayIndex = 17;
            dgv.Columns["Compañía transportista Id"].DisplayIndex = 18;
            dgv.Columns["Cliente Id"].Visible = false;
            dgv.Columns["Nombre de contacto"].Visible = false;
            dgv.Columns["Vendedor Id"].Visible = false;
            dgv.Columns["Compañía transportista Id"].Visible = false;
            dgv.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Vendedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Total del pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgv.Columns["Fecha de pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgv.Columns["Fecha requerido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgv.Columns["Fecha de envío"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgv.Columns["Flete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Dirigido a"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgv.Columns["Domicilio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Ciudad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Región"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Código postal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["País"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Compañía transportista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgv.Columns["Total del pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Total del pedido"].DefaultCellStyle.Format = "c";
            dgv.Columns["Flete"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Flete"].DefaultCellStyle.Format = "c";
            dgv.Columns["Fecha de pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Fecha requerido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Fecha de envío"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Compañía transportista"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Vendedor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Fecha de pedido"].DefaultCellStyle.Format = "dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            dgv.Columns["Fecha requerido"].DefaultCellStyle.Format = "dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            dgv.Columns["Fecha de envío"].DefaultCellStyle.Format = "dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";

        }

        private void dgvClientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Utils.ActualizarBarraDeEstado($"Se encontraron {dgvClientes.RowCount} registros en clientes", this);
        }
    }
}
