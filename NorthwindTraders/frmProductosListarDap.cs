﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class frmProductosListarDap : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);

        string strProcedure = "";

        public frmProductosListarDap()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmProductosListarDap_Load(object sender, EventArgs e)
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                SqlCommand cmd = new SqlCommand("Select 0 As IdCategoria, '»--- Seleccione ---«' As Categoria Union All Select CategoryId As IdCategoria, CategoryName As Categoria From Categories", cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable tblCategoria = new DataTable();
                dap.Fill(tblCategoria);
                cboCategoria.DataSource = tblCategoria;
                cboCategoria.DisplayMember = "Categoria";
                cboCategoria.ValueMember = "IdCategoria";
                cmd = new SqlCommand("Select 0 As IdProveedor, '»--- Seleccione ---«' As Proveedor Union All Select SupplierId As IdProveedor, CompanyName As Proveedor From Suppliers", cn);
                dap = new SqlDataAdapter(cmd);
                DataTable tblProveedor = new DataTable();
                dap.Fill(tblProveedor);
                cboProveedor.DataSource = tblProveedor;
                cboProveedor.DisplayMember = "Proveedor";
                cboProveedor.ValueMember = "IdProveedor";
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
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            strProcedure = "SP_Productos_All";
            llenarDgvLista(sender);
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

        private void llenarDgvLista(object sender)
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                // el data adapter abre y cierra la conexión automaticamente al ejecutar el fill
                // se puede hacer de la siguiente manera
                /*
                SqlDataAdapter dap = new SqlDataAdapter("Usp_ListarProductos", Cn);
                dap.SelectCommand.CommandType = CommandType.StoredProcedure;
                */
                // tambien se puede hacer de la siguiente manera
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
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dap.Fill(tbl);
                dgvLista.DataSource = tbl;
                Utils.ConfDataGridView(dgvLista);
                Utils.ConfDgvProductos(dgvLista);
                //dgvLista.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgvLista.Columns["Precio"].DefaultCellStyle.Format = "c";
                //dgvLista.Columns["Unidades en inventario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgvLista.Columns["Unidades en pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgvLista.Columns["Punto de pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgvLista.Columns["IdCategoria"].Visible = false;
                //dgvLista.Columns["IdProveedor"].Visible = false;
                Utils.ActualizarBarraDeEstado($"Se encontraron: {tbl.Rows.Count} registros", this);
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

        private void frmProductosListarDap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }
    }
}
