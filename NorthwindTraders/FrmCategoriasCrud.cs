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
    public partial class FrmCategoriasCrud : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        bool EventoCargado = true; // esta variable es necesaria para controlar el manejador de eventos de la celda del dgv, ojo no quitar

        public FrmCategoriasCrud()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void grb_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.Black, this);
        }

        private void FrmCategoriasCrud_Load(object sender, EventArgs e)
        {
            LlenarDgv(null);
        }

        private void LlenarDgv(object sender)
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
            try
            {
                SqlCommand cmd;
                if (sender == null)
                {
                    cmd = new SqlCommand("Sp_Categorias_Listar", cn);
                    cmd.Parameters.AddWithValue("top100", 0);
                }
                else
                {
                    cmd = new SqlCommand("Sp_Categorias_Buscar", cn);
                    cmd.Parameters.AddWithValue("Id", txtBId.Text);
                    cmd.Parameters.AddWithValue("Categoria", txtBCategoria.Text);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dap.Fill(tbl);
                dgv.DataSource = tbl;
                dgv.EnableHeadersVisualStyles = false;
                dgv.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.GradientActiveCaption;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.GradientActiveCaption;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
                dgv.DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Regular);
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.AllowUserToOrderColumns = true;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgv.MultiSelect = false;
                dgv.ReadOnly = true;
                dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgv.Columns["Foto"].Visible = false;
                dgv.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv.Columns["Categoría"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (sender == null)
                    Utils.ActualizarBarraDeEstado("Se muestran las últimas 20 categorías registradas", this);
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

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabcOperacion.SelectedTab != tbpRegistrar)
            {
                DataGridViewRow dgvr = dgv.CurrentRow;
                txtId.Text = dgvr.Cells["Id"].Value.ToString();
                txtCategoria.Text = dgvr.Cells["Categoría"].Value.ToString();
                txtDescripcion.Text = dgvr.Cells["Descripción"].Value.ToString();
                DeshabilitarControles();
                if (tabcOperacion.SelectedTab == tbpListar)
                {
                    btnOperacion.Visible = false;
                    btnOperacion.Enabled = false;
                }
                else if (tabcOperacion.SelectedTab == tbpModificar)
                    HabilitarControles();
                else if (tabcOperacion.SelectedTab == tbpEliminar)
                {
                    btnOperacion.Visible = true;
                    btnOperacion.Enabled = true;
                }
            } 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BorrarMensajesError();
            BorrarDatosCategoria();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
            LlenarDgv(sender);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            BorrarDatosBusqueda();
            BorrarDatosCategoria();
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
        }

        private void BorrarDatosBusqueda()
        {
            txtBCategoria.Text = txtBId.Text = "";
        }

        private void BorrarDatosCategoria()
        {
            txtCategoria.Text = txtDescripcion.Text = txtId.Text = "";
            picFoto.Image = null;
        }

        private void DeshabilitarControles()
        {
            txtCategoria.ReadOnly = txtDescripcion.ReadOnly = true;
            picFoto.Enabled = false;
        }

        private void HabilitarControles()
        {
            txtCategoria.ReadOnly = txtDescripcion.ReadOnly = false;
            picFoto.Enabled = true;
        }

        private void BorrarMensajesError()
        {
            errorProvider1.SetError(txtCategoria, "");
            errorProvider1.SetError(txtDescripcion, "");
        }

        private bool ValidarControles()
        {
            bool valida = true;
            if (txtCategoria.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtCategoria, "Ingrese la categoría");
            }
            if (txtDescripcion.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtDescripcion, "Ingrese la descripción");
            }
            return valida;
        }
    }
}
