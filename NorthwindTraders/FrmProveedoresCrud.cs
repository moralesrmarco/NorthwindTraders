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
    public partial class FrmProveedoresCrud : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        bool EventoCargado = true; // esta variable es necesaria para controlar el manejador de eventos de la celda del dgv, ojo no quitar

        public FrmProveedoresCrud()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void grbPaint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.Black, this);
        }

        private void FrmProveedoresCrud_Load(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LlenarCboPais();
            LlenarDgv(null);
        }

        private void LlenarCboPais()
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Proveedores_Pais", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dap.Fill(tbl);
                cboBPais.DataSource = tbl;
                cboBPais.DisplayMember = "País";
                cboBPais.ValueMember = "Id";
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

        private void LlenarDgv(object sender)
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
            try
            {
                SqlCommand cmd;
                if (sender == null)
                {
                    cmd = new SqlCommand("Sp_Proveedores_Listar", cn);
                    cmd.Parameters.AddWithValue("top100", 0);
                }
                else
                {
                    cmd = new SqlCommand("Sp_Proveedores_Buscar", cn);
                    cmd.Parameters.AddWithValue("Id", txtBId.Text);
                    cmd.Parameters.AddWithValue("Compañia", txtBCompañia.Text);
                    cmd.Parameters.AddWithValue("Contacto", txtBContacto.Text);
                    cmd.Parameters.AddWithValue("Domicilio", txtBDomicilio.Text);
                    cmd.Parameters.AddWithValue("Ciudad", txtBCiudad.Text);
                    cmd.Parameters.AddWithValue("Region", txtBRegion.Text);
                    cmd.Parameters.AddWithValue("CodigoP", txtBCodigoP.Text);
                    cmd.Parameters.AddWithValue("Pais", cboBPais.SelectedValue);
                    cmd.Parameters.AddWithValue("Telefono", txtBTelefono.Text);
                    cmd.Parameters.AddWithValue("Fax", txtBFax.Text);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dap.Fill(tbl);
                dgv.DataSource = tbl;
                Utils.ConfDataGridView(dgv);
                ConfDgv(dgv);
                if (sender == null)
                    if (dgv.RowCount < 20)
                        Utils.ActualizarBarraDeEstado($"Se muestran los últimos {dgv.RowCount} proveedores registrados", this);
                    else
                        Utils.ActualizarBarraDeEstado($"Se muestran los últimos {dgv.RowCount} proveedores registrados", this);
                else
                    Utils.ActualizarBarraDeEstado($"Se encontraron {dgv.RowCount} registros", this);
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

        private void ConfDgv(DataGridView dgv)
        {
            dgv.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Título de contacto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Ciudad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Región"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Código postal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["País"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Teléfono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Fax"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void DeshabilitarControles()
        {
            txtId.ReadOnly = txtCompañia.ReadOnly = txtContacto.ReadOnly = txtTitulo.ReadOnly = true;
            txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCodigoP.ReadOnly = true;
            txtPais.ReadOnly = txtTelefono.ReadOnly = txtFax.ReadOnly = true;
        }
    }
}
