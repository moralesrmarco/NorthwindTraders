﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmClientesCrud : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        bool EventoCargado = true; // esta variable es necesaria para controlar el manejador de eventos de la celda del dgv, ojo no quitar

        public FrmClientesCrud()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void grbPaint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.Black, this);
        }

        private void FrmClientesCrud_Load(object sender, EventArgs e)
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
                if (sender == null)
                    if (dgv.RowCount < 20)
                        Utils.ActualizarBarraDeEstado($"Se muestran los primeros {dgv.RowCount} clientes registrados", this);
                    else
                        Utils.ActualizarBarraDeEstado($"Se muestran los primeros {dgv.RowCount} clientes registrados", this);
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

        private void DeshabilitarControles()
        {
            txtId.ReadOnly = txtCompañia.ReadOnly = txtContacto.ReadOnly = txtTitulo.ReadOnly = true;
            txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCodigoP.ReadOnly = true;
            txtPais.ReadOnly = txtTelefono.ReadOnly = txtFax.ReadOnly = true;
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
            txtBId.Text = txtBCompañia.Text = txtBContacto.Text = txtBDomicilio.Text = txtBCiudad.Text = "";
            txtBRegion.Text = txtBCodigoP.Text = txtBTelefono.Text = txtBFax.Text = "";
            cboBPais.SelectedIndex = 0;
        }

        private void BorrarDatosCliente()
        {
            txtId.Text = txtCompañia.Text = txtContacto.Text = txtDomicilio.Text = txtCiudad.Text = "";
            txtRegion.Text = txtCodigoP.Text = txtTelefono.Text = txtFax.Text = txtPais.Text = txtTitulo.Text = "";
        }

        private void BorrarMensajesError()
        {
            errorProvider1.SetError(txtId, "");
            errorProvider1.SetError(txtCompañia, "");
            errorProvider1.SetError(txtContacto, "");
            errorProvider1.SetError(txtTitulo, "");
            errorProvider1.SetError(txtDomicilio, "");
            errorProvider1.SetError(txtCiudad, "");
            errorProvider1.SetError(txtPais, "");
            errorProvider1.SetError(txtTelefono, "");
        }

        private void HabilitarControles()
        {
            txtId.ReadOnly = txtCompañia.ReadOnly = txtContacto.ReadOnly = txtTitulo.ReadOnly = false;
            txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCodigoP.ReadOnly = false;
            txtPais.ReadOnly = txtTelefono.ReadOnly = txtFax.ReadOnly = false;
        }

        private bool ValidarControles()
        {
            bool valida = true;
            if (txtId.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtId, "Ingrese el Id del cliente");
            }
            if (txtCompañia.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtCompañia, "Ingrese el nombre de la compañia");
            }
            if (txtContacto.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtContacto, "Ingrese el nombre del contacto");
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

        private void FrmClientesCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tabcOperacion.SelectedTab != tbpListar)
                if (txtId.Text != "" || txtCompañia.Text != "" || txtContacto.Text != "" || txtTitulo.Text != "" || txtDomicilio.Text != "" || txtCiudad.Text != "" || txtRegion.Text != "" || txtCodigoP.Text != "" || txtPais.Text != "" || txtTelefono.Text != "" || txtFax.Text != "")
                {
                    DialogResult respuesta = MessageBox.Show("¿Esta seguro de querer cerrar el formulario?, si responde Si, se perderan los datos no guardados", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.No)
                        e.Cancel = true;
                }
        }

        private void FrmClientesCrud_FormClosed(object sender, FormClosedEventArgs e)
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
                txtCompañia.Text = dgvr.Cells["Nombre de compañía"].Value.ToString();
                txtContacto.Text = dgvr.Cells["Nombre de contacto"].Value.ToString();
                txtTitulo.Text = dgvr.Cells["Título de contacto"].Value.ToString();
                txtDomicilio.Text = dgvr.Cells["Domicilio"].Value.ToString();
                txtCiudad.Text = dgvr.Cells["Ciudad"].Value.ToString();
                txtRegion.Text = dgvr.Cells["Región"].Value.ToString();
                txtCodigoP.Text = dgvr.Cells["Código postal"].Value.ToString();
                txtPais.Text = dgvr.Cells["País"].Value.ToString();
                txtTelefono.Text = dgvr.Cells["Teléfono"].Value.ToString();
                txtFax.Text = dgvr.Cells["Fax"].Value.ToString();
                if (tabcOperacion.SelectedTab == tbpModificar)
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
                        cmd.Parameters.AddWithValue("Compañia", txtCompañia.Text);
                        cmd.Parameters.AddWithValue("Contacto", txtContacto.Text);
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
                        if (txtFax.Text.Trim() == "")
                            cmd.Parameters.AddWithValue("Fax", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("Fax", txtFax.Text);
                        cn.Open();
                        numRegs = cmd.ExecuteNonQuery();
                        if (numRegs > 0)
                            MessageBox.Show($"El cliente con Id: {txtId.Text} y nombre de compañia: {txtCompañia.Text} se registró satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show($"El cliente con Id:  {txtId.Text}  y nombre de compañia:  {txtCompañia.Text} NO fue registrado en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        btnLimpiar.PerformClick();
                        LlenarDgv(null);
                    }
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
                        cmd.Parameters.AddWithValue("Compañia", txtCompañia.Text);
                        cmd.Parameters.AddWithValue("Contacto", txtContacto.Text);
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
                        if (txtFax.Text.Trim() == "")
                            cmd.Parameters.AddWithValue("Fax", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("Fax", txtFax.Text);
                        cn.Open();
                        numRegs = cmd.ExecuteNonQuery();
                        if (numRegs > 0)
                            MessageBox.Show($"El cliente con Id: {txtId.Text} y nombre de compañia: {txtCompañia.Text} se modificó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show($"El cliente con Id: {txtId.Text} y nombre de compañía: {txtCompañia.Text} NO fue modificado en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (txtId.Text == "")
                {
                    MessageBox.Show("Seleccione el cliente a eliminar", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult respuesta = MessageBox.Show($"¿Esta seguro de eliminar el cliente con Id: {txtId.Text} y nombre de compañia: {txtCompañia.Text}?", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
                            MessageBox.Show($"El cliente con Id: {txtId.Text} y nombre de compañía: {txtCompañia.Text} se eliminó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show($"El cliente con Id: {txtId.Text} y nombre de compañía: {txtCompañia.Text} NO se eliminó en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
