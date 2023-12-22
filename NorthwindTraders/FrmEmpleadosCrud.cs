using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmEmpleadosCrud : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        bool EventoCargado = true; // esta variable es necesaria para controlar el manejador de eventos de la celda del dgv, ojo no quitar

        public FrmEmpleadosCrud()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void grbPaint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.Black, this);
        }

        private void FrmEmpleadosCrud_Load(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("Sp_Clientes_Pais", cn);
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
                    cmd = new SqlCommand("Sp_Clientes_Listar", cn);
                    cmd.Parameters.AddWithValue("top100", 0);
                }
                else
                {
                    cmd = new SqlCommand("Sp_Clientes_Buscar", cn);
                    cmd.Parameters.AddWithValue("Id", txtBId.Text);
                    cmd.Parameters.AddWithValue("Compañia", txtBNombre.Text);
                    cmd.Parameters.AddWithValue("Contacto", txtBApellido.Text);
                    cmd.Parameters.AddWithValue("Domicilio", txtBDomicilio.Text);
                    cmd.Parameters.AddWithValue("Ciudad", txtBCiudad.Text);
                    cmd.Parameters.AddWithValue("Region", txtBRegion.Text);
                    cmd.Parameters.AddWithValue("CodigoP", txtBCodigoP.Text);
                    cmd.Parameters.AddWithValue("Pais", cboBPais.SelectedValue);
                    cmd.Parameters.AddWithValue("Telefono", txtBTelefono.Text);
                    cmd.Parameters.AddWithValue("Fax", txtBTitulo.Text);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dap.Fill(tbl);
                dgv.DataSource = tbl;
                Utils.ConfDataGridView(dgv);
                if (sender == null)
                    Utils.ActualizarBarraDeEstado("Se muestran los primeros 20 clientes registrados", this);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BorrarMensajesError();
            BorrarDatosCliente();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
            LlenarDgv(sender);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            BorrarMensajesError();
            BorrarDatosBusqueda();
            BorrarDatosCliente();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
        }

        private void BorrarDatosBusqueda()
        {
            txtBId.Text = txtBNombre.Text = txtBApellido.Text = txtBDomicilio.Text = txtBCiudad.Text = "";
            txtBRegion.Text = txtBCodigoP.Text = txtBTelefono.Text = txtBTitulo.Text = "";
            cboBPais.SelectedIndex = 0;
        }

        private void BorrarDatosCliente()
        {
            txtId.Text = txtNombre.Text = txtApellido.Text = txtDomicilio.Text = txtCiudad.Text = "";
            txtRegion.Text = txtCodigoP.Text = txtTelefono.Text = txtTitCortesia.Text = txtPais.Text = txtTitulo.Text = "";
        }

        private void BorrarMensajesError()
        {
            errorProvider1.SetError(txtId, "");
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtApellido, "");
            errorProvider1.SetError(txtTitulo, "");
            errorProvider1.SetError(txtDomicilio, "");
            errorProvider1.SetError(txtCiudad, "");
            errorProvider1.SetError(txtPais, "");
            errorProvider1.SetError(txtTelefono, "");
        }

        private void DeshabilitarControles()
        {
            txtId.ReadOnly = txtNombre.ReadOnly = txtApellido.ReadOnly = txtTitulo.ReadOnly =  true;
            txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCodigoP.ReadOnly = true;
            txtPais.ReadOnly = txtTelefono.ReadOnly = txtTitCortesia.ReadOnly = true;
        }

        private void HabilitarControles()
        {
            txtId.ReadOnly = txtNombre.ReadOnly = txtApellido.ReadOnly = txtTitulo.ReadOnly = false;
            txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCodigoP.ReadOnly = false;
            txtPais.ReadOnly = txtTelefono.ReadOnly = txtTitCortesia.ReadOnly = false;
        }

        private bool ValidarControles()
        {
            bool valida = true;
            if (txtId.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtId, "Ingrese el Id del cliente");
            }
            if (txtNombre.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtNombre, "Ingrese el nombre de la compañia");
            }
            if (txtApellido.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtApellido, "Ingrese el nombre del contacto");
            }
            if (txtTitulo.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtTitulo, "Ingrese el título del contacto");
            }
            if (txtDomicilio.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtDomicilio, "Ingrese el domicilio");
            }
            if (txtCiudad.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtCiudad, "Ingrese la ciudad");
            }
            if (txtPais.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtPais, "Ingrese el país");
            }
            if (txtTelefono.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtTelefono, "Ingrese el teléfono");
            }
            return valida;
        }

        private void FrmEmpleadosCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tabcOperacion.SelectedTab != tbpListar)
                if (txtId.Text != "" || txtNombre.Text != "" || txtApellido.Text != "" || txtTitulo.Text != "" || txtDomicilio.Text != "" || txtCiudad.Text != "" || txtRegion.Text != "" || txtCodigoP.Text != "" || txtPais.Text != "" || txtTelefono.Text != "" || txtTitCortesia.Text != "")
                {
                    DialogResult respuesta = MessageBox.Show("¿Esta seguro de querer cerrar el formulario?, si responde Si, se perderan los datos no guardados", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.No)
                        e.Cancel = true;
                }
        }

        private void FrmEmpleadosCrud_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void tabcOperacion_Selected(object sender, TabControlEventArgs e)
        {
            BorrarDatosCliente();
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab == tbpRegistrar)
            {
                if (EventoCargado)
                {
                    dgv.CellClick -= new DataGridViewCellEventHandler(dgv_CellClick);
                    EventoCargado = false;
                }
                BorrarDatosBusqueda();
                HabilitarControles();
                txtId.Enabled = true;
                btnOperacion.Text = "Registrar cliente";
                btnOperacion.Visible = true;
                btnOperacion.Enabled = true;
                LlenarDgv(null);
            }
            else
            {
                if (!EventoCargado)
                {
                    dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
                    EventoCargado = true;
                }
                DeshabilitarControles();
                btnOperacion.Enabled = false;
                if (tabcOperacion.SelectedTab == tbpListar)
                {
                    btnOperacion.Visible = false;
                }
                else if (tabcOperacion.SelectedTab == tbpModificar)
                {
                    btnOperacion.Text = "Modificar cliente";
                    btnOperacion.Visible = true;
                }
                else if(tabcOperacion.SelectedTab == tbpEliminar)
                {
                    btnOperacion.Text = "Eliminar cliente";
                    btnOperacion.Visible = true;
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabcOperacion.SelectedTab != tbpRegistrar)
            {
                DeshabilitarControles();
                DataGridViewRow dgvr = dgv.CurrentRow;
                txtId.Text = dgvr.Cells["Id"].Value.ToString();
                txtNombre.Text = dgvr.Cells["Nombre de compañía"].Value.ToString();
                txtApellido.Text = dgvr.Cells["Nombre de contacto"].Value.ToString();
                txtTitulo.Text = dgvr.Cells["Título de contacto"].Value.ToString();
                txtDomicilio.Text = dgvr.Cells["Domicilio"].Value.ToString();
                txtCiudad.Text = dgvr.Cells["Ciudad"].Value.ToString();
                txtRegion.Text = dgvr.Cells["Región"].Value.ToString();
                txtCodigoP.Text = dgvr.Cells["Código postal"].Value.ToString();
                txtPais.Text = dgvr.Cells["País"].Value.ToString();
                txtTelefono.Text = dgvr.Cells["Teléfono"].Value.ToString();
                txtTitCortesia.Text = dgvr.Cells["Fax"].Value.ToString();
                if (tabcOperacion.SelectedTab == tbpListar)
                {
                    btnOperacion.Visible = false;
                    btnOperacion.Enabled = false;
                }
                else if (tabcOperacion.SelectedTab == tbpModificar)
                {
                    HabilitarControles();
                    txtId.Enabled = false;
                    btnOperacion.Visible = true;
                    btnOperacion.Enabled = true;
                }
                else if (tabcOperacion.SelectedTab == tbpEliminar)
                {
                    btnOperacion.Enabled = true;
                    btnOperacion.Visible = true;
                }
            }
        }

        private void btnOperacion_Click(object sender, EventArgs e)
        {
            int numRegs = 0;
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab == tbpRegistrar)
            {
                if (ValidarControles())
                {
                    Utils.ActualizarBarraDeEstado("Actualizando la base de datos...", this);
                    DeshabilitarControles();
                    btnOperacion.Enabled = false;
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Sp_Clientes_Insertar", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Id", txtId.Text);
                        cmd.Parameters.AddWithValue("Compañia", txtNombre.Text);
                        cmd.Parameters.AddWithValue("Contacto", txtApellido.Text);
                        cmd.Parameters.AddWithValue("Titulo", txtTitulo.Text);
                        cmd.Parameters.AddWithValue("Domicilio", txtDomicilio.Text);
                        cmd.Parameters.AddWithValue("Ciudad", txtCiudad.Text);
                        if (txtRegion.Text.Trim() == "")
                            cmd.Parameters.AddWithValue("Region", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("Region", txtRegion.Text);
                        if (txtCodigoP.Text.Trim() == "")
                            cmd.Parameters.AddWithValue("CodigoP", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("CodigoP", txtCodigoP.Text);
                        cmd.Parameters.AddWithValue("Pais", txtPais.Text);
                        cmd.Parameters.AddWithValue("Telefono", txtTelefono.Text);
                        if (txtTitCortesia.Text.Trim() == "")
                            cmd.Parameters.AddWithValue("Fax", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("Fax", txtTitCortesia.Text);
                        cn.Open();
                        numRegs = cmd.ExecuteNonQuery();
                        if (numRegs > 0)
                            MessageBox.Show($"El cliente con Id: {txtId.Text} y nombre de compañia: {txtNombre.Text} se registró satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show($"El cliente con Id:  {txtId.Text}  y nombre de compañia:  {txtNombre.Text} NO fue registrado en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    LlenarCboPais();
                    HabilitarControles();
                    btnOperacion.Enabled = true;
                    if (numRegs > 0)
                    {
                        BorrarDatosBusqueda();
                        txtBId.Text = txtId.Text;
                        btnBuscar.PerformClick();
                        btnLimpiar.PerformClick();
                    }
                    Utils.ActualizarBarraDeEstado("Activo", this);
                }
            }
            else if (tabcOperacion.SelectedTab == tbpModificar)
            {
                if (ValidarControles())
                {
                    Utils.ActualizarBarraDeEstado("Actualizando la base de datos...", this);
                    DeshabilitarControles();
                    btnOperacion.Enabled = false;
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Sp_Clientes_Actualizar", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Id", txtId.Text);
                        cmd.Parameters.AddWithValue("Compañia", txtNombre.Text);
                        cmd.Parameters.AddWithValue("Contacto", txtApellido.Text);
                        cmd.Parameters.AddWithValue("Titulo", txtTitulo.Text);
                        cmd.Parameters.AddWithValue("Domicilio", txtDomicilio.Text);
                        cmd.Parameters.AddWithValue("Ciudad", txtCiudad.Text);
                        if (txtRegion.Text.Trim() == "")
                            cmd.Parameters.AddWithValue("Region", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("Region", txtRegion.Text);
                        if (txtCodigoP.Text.Trim() == "")
                            cmd.Parameters.AddWithValue("CodigoP", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("CodigoP", txtCodigoP.Text);
                        cmd.Parameters.AddWithValue("Pais", txtPais.Text);
                        cmd.Parameters.AddWithValue("Telefono", txtTelefono.Text);
                        if (txtTitCortesia.Text.Trim() == "")
                            cmd.Parameters.AddWithValue("Fax", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("Fax", txtTitCortesia.Text);
                        cn.Open();
                        numRegs = cmd.ExecuteNonQuery();
                        if (numRegs > 0)
                            MessageBox.Show($"El cliente con Id: {txtId.Text} y nombre de compañia: {txtNombre.Text} se modificó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show($"El cliente con Id: {txtId.Text} y nombre de compañía: {txtNombre.Text} NO fue modificado en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    LlenarCboPais();
                    if (numRegs > 0)
                    {
                        BorrarDatosBusqueda();
                        txtBId.Text = txtId.Text;
                        btnBuscar.PerformClick();
                        btnLimpiar.PerformClick();
                    }
                }
            }
            else if (tabcOperacion.SelectedTab == tbpEliminar)
            {
                if (txtId.Text.Trim() == "")
                {
                    MessageBox.Show("Seleccione el cliente a eliminar", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult respuesta = MessageBox.Show($"¿Esta seguro de eliminar el cliente con Id: {txtId.Text} y nombre de compañia: {txtNombre.Text}?", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    btnOperacion.Enabled = false;
                    Utils.ActualizarBarraDeEstado("Actualizando la base de datos...", this);
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Sp_Clientes_Eliminar", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Id", txtId.Text);
                        cn.Open();
                        numRegs = cmd.ExecuteNonQuery();
                        if (numRegs>0)
                            MessageBox.Show($"El cliente con Id: {txtId.Text} y nombre de compañía: {txtNombre.Text} se eliminó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show($"El cliente con Id: {txtId.Text} y nombre de compañía: {txtNombre.Text} NO se eliminó en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    LlenarCboPais();
                    if (numRegs > 0)
                    {
                        BorrarDatosBusqueda();
                        txtBId.Text = txtId.Text;
                        btnBuscar.PerformClick();
                        btnLimpiar.PerformClick();
                    }
                }
            }
        }
    }
}
