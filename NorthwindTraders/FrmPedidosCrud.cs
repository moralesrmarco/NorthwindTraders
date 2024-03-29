﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmPedidosCrud : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        bool eventoCargardo = true; // esta variable es necesaria para controlar el manejador de eventos de la celda del dgv, ojo no quitar
        int IdDetalle = 1;

        public FrmPedidosCrud()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void FrmPedidosCrud_Load(object sender, EventArgs e)
        {
            dtpHoraPedido.ValueChanged -= new EventHandler(dtpHoraPedido_ValueChanged);
            dtpHoraPedido.Value = DateTime.Now;
            dtpHoraRequerido.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtpHoraEnvio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtpHoraRequerido.Checked = false;
            dtpHoraEnvio.Checked = false;
            dtpHoraRequerido.Enabled = false;
            dtpHoraEnvio.Enabled = false;
            dtpHoraPedido.ValueChanged += new EventHandler(dtpHoraPedido_ValueChanged);
            label12.Text = "Fecha\ninicial:";
            label13.Text = "Fecha\nfinal:";
            label14.Text = "Fecha\ninicial:";
            label15.Text = "Fecha\nfinal:";
            label16.Text = "Fecha\ninicial:";
            label17.Text = "Fecha\nfinal:";
            DeshabilitarControles();
            LlenarCboCliente();
            LlenarCboEmpleado();
            LlenarCboTransportista();
            LlenarCboCategoria();
            LlenarDgvPedidos(null);
            Utils.ConfDataGridView(dgvDetalle);
            Utils.ConfDataGridView(dgvPedidos);
            ConfDgvPedidos(dgvPedidos);
            ConfDgvDetalle(dgvDetalle);
            dgvDetalle.Columns["Eliminar"].Visible = false;
            txtPrecio.Text = "$0.00";
            txtDescuento.Text = "0.00";
            txtFlete.Text = "$0.00";
        }

        private void grbPaint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.Black, this);
        }

        private void grbPaint2(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.LightSlateGray, this);
        }

        private void LlenarDgvPedidos(object sender)
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
            try
            {
                SqlCommand cmd;
                if (sender == null)
                    cmd = new SqlCommand("Sp_Pedidos_Listar20", cn);
                else
                {
                    cmd = new SqlCommand("Sp_Pedidos_Buscar", cn);
                    cmd.Parameters.AddWithValue("IdInicial", txtBIdInicial.Text);
                    cmd.Parameters.AddWithValue("IdFinal", txtBIdFinal.Text);
                    cmd.Parameters.AddWithValue("Cliente", txtBCliente.Text);
                    if (dtpBFPedidoIni.Checked && dtpBFPedidoFin.Checked)
                    {
                        cmd.Parameters.AddWithValue("FPedido", true); // este parametro es requerido para que funcione el store procedure con la misma logica que he venido usando en las demas busquedas
                        dtpBFPedidoIni.Value = Convert.ToDateTime(dtpBFPedidoIni.Value.ToShortDateString() + " 00:00:00.000");
                        cmd.Parameters.AddWithValue("FPedidoIni", dtpBFPedidoIni.Value);
                        dtpBFPedidoFin.Value = Convert.ToDateTime(dtpBFPedidoFin.Value.ToShortDateString() + " 23:59:59.998"); // se usa .998 porque lo redondea a .997 por la presición de los campos tipo datetime de sql server, el cual es el maximo valor de milesimas de segundo que puede guardarse en la db. Si se usa .999 lo redondea al segundo 0.000 del siquiente dia e incluye los datos del siguiente día que es un comportamiento que no se quiere por que solo se deben mostrar los datos de la fecha indicada. Ya se comprobo el comportamiento en la base de datos.
                        cmd.Parameters.AddWithValue("FPedidoFin", dtpBFPedidoFin.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("FPedido", false);
                        //cmd.Parameters.AddWithValue("FPedido", "");
                        cmd.Parameters.AddWithValue("FPedidoIni", DBNull.Value);
                        cmd.Parameters.AddWithValue("FPedidoFin", DBNull.Value);
                    }
                    if (chkBFPedidoNull.Checked)
                        cmd.Parameters.AddWithValue("FPedidoNull", true);
                    else
                        cmd.Parameters.AddWithValue("FPedidoNull", false);
                    if (dtpBFRequeridoIni.Checked && dtpBFRequeridoFin.Checked)
                    {
                        cmd.Parameters.AddWithValue("FRequerido", true);
                        //cmd.Parameters.AddWithValue("FRequerido", "1");
                        dtpBFRequeridoIni.Value = Convert.ToDateTime(dtpBFRequeridoIni.Value.ToShortDateString() + " 00:00:00.000");
                        cmd.Parameters.AddWithValue("FRequeridoIni", dtpBFRequeridoIni.Value);
                        dtpBFRequeridoFin.Value = Convert.ToDateTime(dtpBFRequeridoFin.Value.ToShortDateString() + " 23:59:59.998");
                        cmd.Parameters.AddWithValue("FRequeridoFin", dtpBFRequeridoFin.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("FRequerido", false);
                        //cmd.Parameters.AddWithValue("FRequerido", "");
                        cmd.Parameters.AddWithValue("FRequeridoIni", DBNull.Value);
                        cmd.Parameters.AddWithValue("FRequeridoFin", DBNull.Value);
                    }
                    if (chkBFRequeridoNull.Checked)
                        cmd.Parameters.AddWithValue("FRequeridoNull", true);
                    else
                        cmd.Parameters.AddWithValue("FRequeridoNull", false);
                    if (dtpBFEnvioIni.Checked && dtpBFEnvioFin.Checked)
                    {
                        cmd.Parameters.AddWithValue("FEnvio", true);
                        //cmd.Parameters.AddWithValue("FEnvio", "1");
                        dtpBFEnvioIni.Value = Convert.ToDateTime(dtpBFEnvioIni.Value.ToShortDateString() + " 00:00:00.000");
                        cmd.Parameters.AddWithValue("FEnvioIni", dtpBFEnvioIni.Value);
                        dtpBFEnvioFin.Value = Convert.ToDateTime(dtpBFEnvioFin.Value.ToShortDateString() + " 23:59:59.998");
                        cmd.Parameters.AddWithValue("FEnvioFin", dtpBFEnvioFin.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("FEnvio", false);
                        //cmd.Parameters.AddWithValue("FEnvio", "");
                        cmd.Parameters.AddWithValue("FEnvioIni", DBNull.Value);
                        cmd.Parameters.AddWithValue("FEnvioFin", DBNull.Value);
                    }
                    if (chkBFEnvioNull.Checked)
                        cmd.Parameters.AddWithValue("FEnvioNull", true);
                    else
                        cmd.Parameters.AddWithValue("FEnvioNull", false);
                    cmd.Parameters.AddWithValue("Empleado", txtBEmpleado.Text);
                    cmd.Parameters.AddWithValue("CompañiaT", txtBCompañiaT.Text);
                    cmd.Parameters.AddWithValue("Dirigidoa", txtBDirigidoa.Text);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dap.Fill(tbl);
                dgvPedidos.DataSource = tbl;
                //Utils.ConfDataGridView(dgvPedidos);
                //ConfDgvPedidos(dgvPedidos);
                if (sender == null)
                    Utils.ActualizarBarraDeEstado($"Se muestran los últimos {dgvPedidos.RowCount} pedidos registrados", this);
                else
                    Utils.ActualizarBarraDeEstado($"Se encontraron {dgvPedidos.RowCount} registros", this);
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

        private void ConfDgvPedidos(DataGridView dgv)
        {
            dgv.Columns["Fecha de pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Fecha requerido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Fecha de envío"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Compañía transportista"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Vendedor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Fecha de pedido"].DefaultCellStyle.Format = "ddd dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            dgv.Columns["Fecha requerido"].DefaultCellStyle.Format = "ddd dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            dgv.Columns["Fecha de envío"].DefaultCellStyle.Format = "ddd dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BorrarDatosPedido();
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
            LlenarDgvPedidos(sender);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            BorrarDatosPedido();
            BorrarMensajesError();
            BorrarDatosBuqueda();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
        }

        private void BorrarDatosBuqueda()
        {
            txtBIdInicial.Text = txtBIdFinal.Text = txtBCliente.Text = txtBEmpleado.Text = txtBCompañiaT.Text = txtBDirigidoa.Text = "";
            dtpBFPedidoIni.Checked = dtpBFPedidoFin.Checked = dtpBFRequeridoIni.Checked = dtpBFRequeridoFin.Checked = dtpBFEnvioIni.Checked = dtpBFEnvioFin.Checked = false;
            chkBFPedidoNull.Checked = chkBFRequeridoNull.Checked = chkBFEnvioNull.Checked = false;
        }

        private void txtBIdInicial_TextChanged(object sender, EventArgs e)
        {
            txtBIdFinal.Text = txtBIdInicial.Text;
        }

        private void dtpBFPedidoIni_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBFPedidoIni.Checked)
            {
                dtpBFPedidoFin.Checked = true;
                chkBFPedidoNull.Checked = false;
            }
            else
                dtpBFPedidoFin.Checked = false;
            dtpBFPedidoFin.Value = dtpBFPedidoIni.Value;
        }

        private void dtpBFPedidoFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBFPedidoFin.Checked)
            {
                dtpBFPedidoIni.Checked = true;
                chkBFPedidoNull.Checked = false;
            }
            else
                dtpBFPedidoIni.Checked = false;
        }

        private void dtpBFRequeridoIni_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBFRequeridoIni.Checked)
            {
                dtpBFRequeridoFin.Checked = true;
                chkBFRequeridoNull.Checked = false;
            }
            else
                dtpBFRequeridoFin.Checked = false;
            dtpBFRequeridoFin.Value = dtpBFRequeridoIni.Value;
        }

        private void dtpBFRequeridoFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBFRequeridoFin.Checked)
            {
                dtpBFRequeridoIni.Checked = true;
                chkBFRequeridoNull.Checked = false;
            }
            else
                dtpBFRequeridoIni.Checked = false;
        }

        private void dtpBFEnvioIni_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBFEnvioIni.Checked)
            {
                dtpBFEnvioFin.Checked = true;
                chkBFEnvioNull.Checked = false;
            }
            else
                dtpBFEnvioFin.Checked = false;
            dtpBFEnvioFin.Value = dtpBFEnvioIni.Value;
        }

        private void dtpBFEnvioFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBFEnvioFin.Checked)
            {
                dtpBFEnvioIni.Checked = true;
                chkBFEnvioNull.Checked = false;
            }
            else
                dtpBFEnvioIni.Checked = false;
        }

        private void chkBFPedidoNull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBFPedidoNull.Checked)
            {
                dtpBFPedidoIni.Checked = false;
                dtpBFPedidoFin.Checked = false;
            }
        }

        private void chkBFRequeridoNull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBFRequeridoNull.Checked)
            {
                dtpBFRequeridoIni.Checked = false;
                dtpBFRequeridoFin.Checked = false;
            }
        }

        private void chkBFEnvioNull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBFEnvioNull.Checked)
            {
                dtpBFEnvioIni.Checked = false;
                dtpBFEnvioFin.Checked = false;
            }
        }

        private void DeshabilitarControles()
        {
            cboCliente.Enabled = cboEmpleado.Enabled = cboTransportista.Enabled = cboCategoria.Enabled = cboProducto.Enabled = false;
            dtpPedido.Enabled = dtpHoraPedido.Enabled = dtpRequerido.Enabled = dtpHoraRequerido.Enabled = dtpEnvio.Enabled = dtpHoraEnvio.Enabled = false;
            txtDirigidoa.ReadOnly = txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCP.ReadOnly = txtPais.ReadOnly = txtFlete.ReadOnly = true;
            txtCantidad.ReadOnly = txtDescuento.ReadOnly = true;
            btnAgregar.Enabled = btnGenerar.Enabled = false;
            //dgvDetalle.Enabled = false;
        }

        private void LlenarCboCliente()
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Clientes_Seleccionar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dap.Fill(tbl);
                cboCliente.DataSource = tbl;
                cboCliente.DisplayMember = "Cliente";
                cboCliente.ValueMember = "Id";
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

        private void LlenarCboEmpleado()
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Empleados_Seleccionar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dap.Fill(tbl);
                cboEmpleado.DataSource = tbl;
                cboEmpleado.DisplayMember = "Empleado";
                cboEmpleado.ValueMember = "Id";
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

        private void LlenarCboTransportista()
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Transportistas_Seleccionar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dap.Fill(tbl);
                cboTransportista.DataSource = tbl;
                cboTransportista.DisplayMember = "Transportista";
                cboTransportista.ValueMember = "Id";
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

        private void LlenarCboCategoria()
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Categorias_Seleccionar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dap.Fill(tbl);
                cboCategoria.DataSource = tbl;
                cboCategoria.DisplayMember = "Categoria";
                cboCategoria.ValueMember = "Id";
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

        private void BorrarDatosPedido()
        {
            txtId.Text = "";
            cboCliente.SelectedIndex = cboEmpleado.SelectedIndex = cboTransportista.SelectedIndex = cboCategoria.SelectedIndex = 0;
            cboProducto.DataSource = null;
            dtpPedido.Value = dtpRequerido.Value = dtpEnvio.Value = DateTime.Now;
            dtpHoraPedido.Value = dtpHoraRequerido.Value = dtpHoraEnvio.Value = DateTime.Now;
            dtpRequerido.Checked = dtpEnvio.Checked = dtpHoraRequerido.Checked = dtpHoraEnvio.Checked = false;
            txtDirigidoa.Text = txtDomicilio.Text = txtCiudad.Text = txtRegion.Text = txtCP.Text = txtPais.Text = "";
            txtFlete.Text = txtPrecio.Text = "$0.00";
            txtCantidad.Text = "0";
            txtDescuento.Text = "0.00";
            txtTotal.Text = "$0.00";
            dgvDetalle.Rows.Clear();
        }

        private void BorrarMensajesError()
        {
            errorProvider1.SetError(cboProducto, "");
            errorProvider1.SetError(txtCantidad, "");
            errorProvider1.SetError(txtDescuento, "");
            errorProvider1.SetError(cboCliente, "");
            errorProvider1.SetError(cboEmpleado, "");
            errorProvider1.SetError(dtpPedido, "");
            errorProvider1.SetError(dtpHoraPedido, "");
            errorProvider1.SetError(cboTransportista, "");
            errorProvider1.SetError(btnAgregar, "");
        }

        private void HabilitarControles()
        {
            cboCliente.Enabled = cboEmpleado.Enabled = cboTransportista.Enabled = cboCategoria.Enabled = cboProducto.Enabled = true;
            dtpPedido.Enabled = dtpHoraPedido.Enabled = dtpRequerido.Enabled = dtpHoraRequerido.Enabled = dtpEnvio.Enabled = dtpHoraEnvio.Enabled = true;
            txtDirigidoa.ReadOnly = txtDomicilio.ReadOnly = txtCiudad.ReadOnly = txtRegion.ReadOnly = txtCP.ReadOnly = txtPais.ReadOnly = txtFlete.ReadOnly = false;
            txtCantidad.ReadOnly = txtDescuento.ReadOnly = false;
            btnAgregar.Enabled = btnGenerar.Enabled = true;
            //dgvDetalle.Enabled = true;
        }

        private bool ValidarControles()
        {
            bool valida = true;
            if (cboCliente.SelectedIndex == 0)
            {
                valida = false;
                errorProvider1.SetError(cboCliente, "Ingrese el cliente");
            }
            if (cboEmpleado.SelectedIndex == 0)
            {
                valida = false;
                errorProvider1.SetError(cboEmpleado, "Ingrese el empleado");
            }
            if (dtpPedido.Checked == false)
            {
                valida = false;
                errorProvider1.SetError(dtpPedido, "Ingrese la fecha de pedido");
            }
            if (dtpHoraPedido.Checked == false)
            {
                valida = false;
                errorProvider1.SetError(dtpHoraPedido, "Ingrese la hora de pedido");
            }
            if (cboTransportista.SelectedIndex == 0)
            {
                valida = false;
                errorProvider1.SetError(cboTransportista, "Ingrese la compañía transportista");
            }
            string total = txtTotal.Text;
            total = total.Replace("$", "");
            if (txtTotal.Text == "" || decimal.Parse(total) == 0)
            {
                valida = false;
                errorProvider1.SetError(btnAgregar, "Ingrese el detalle del pedido");
            }
            if (cboProducto.SelectedIndex > 0)
            {
                valida = false;
                errorProvider1.SetError(cboProducto, "Ha seleccionado un producto y no lo ha agregado al pedido");
            }
            return valida;
        }

        private void FrmPedidosCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tabcOperacion.SelectedTab != tbpConsultar)
            {
                if (cboCliente.SelectedIndex > 0 || cboEmpleado.SelectedIndex > 0 || cboTransportista.SelectedIndex > 0 || cboCategoria.SelectedIndex > 0 || cboProducto.SelectedIndex > 0)
                {
                    DialogResult respuesta = MessageBox.Show("¿Esta seguro de querer cerrar el formulario?, se perderan los datos no guardados", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void FrmPedidosCrud_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrecio.Text = "$0.00";
            if (cboCategoria.SelectedIndex != 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_Productos_Seleccionar", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Categoria", cboCategoria.SelectedValue);
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    dap.Fill(tbl);
                    cboProducto.DataSource = tbl;
                    cboProducto.DisplayMember = "Producto";
                    cboProducto.ValueMember = "Id";
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
            else
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add("Id", typeof(int));
                tbl.Columns.Add("Producto", typeof(string));
                DataRow dr = tbl.NewRow();
                dr["Id"] = 0;
                dr["Producto"] = "«--- Seleccione ---»";
                tbl.Rows.Add(dr);
                cboProducto.DataSource = tbl;
                cboProducto.DisplayMember = "Producto";
                cboProducto.ValueMember = "Id";
            }
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex > 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand($"Select Top 1 ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry from Orders  Where CustomerId = '{cboCliente.SelectedValue}' order by OrderId Desc", cn);
                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (rdr.Read())
                    {
                        txtDirigidoa.Text = (rdr["ShipName"] == DBNull.Value) ? "" : rdr.GetString(rdr.GetOrdinal("ShipName"));
                        txtDomicilio.Text = (rdr["ShipAddress"] == DBNull.Value) ? "" : rdr.GetString(rdr.GetOrdinal("ShipAddress"));
                        txtCiudad.Text = (rdr["ShipCity"] == DBNull.Value) ? "" : rdr.GetString(rdr.GetOrdinal("ShipCity"));
                        txtRegion.Text = (rdr["ShipRegion"] == DBNull.Value) ? "" : rdr.GetString(rdr.GetOrdinal("ShipRegion"));
                        txtCP.Text = (rdr["ShipPostalCode"] == DBNull.Value) ? "" :
                            rdr.GetString(rdr.GetOrdinal("ShipPostalCode"));
                        txtPais.Text = (rdr["ShipCountry"] == DBNull.Value) ? "" :
                            rdr.GetString(rdr.GetOrdinal("ShipCountry"));
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
            else
            {
                txtDirigidoa.Text = txtDomicilio.Text = txtCiudad.Text = txtRegion.Text = txtCP.Text = txtPais.Text = "";
            }
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand($"Select UnitPrice from Products Where ProductId = {cboProducto.SelectedValue}", cn);
                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (rdr.Read())
                        txtPrecio.Text = rdr["UnitPrice"] == DBNull.Value ? "0.00" : rdr.GetDecimal(rdr.GetOrdinal("UnitPrice")).ToString("c");
                    else
                        txtPrecio.Text = "0.00";
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
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
            {
                decimal importe = decimal.Parse(dgvr.Cells["Importe"].Value.ToString());
                total += importe;
            }
            txtTotal.Text = string.Format("{0:c}", total);
        }

        private void txtDescuento_Enter(object sender, EventArgs e)
        {
            txtDescuento.Text = "";
        }

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            if (txtDescuento.Text.Trim() == "")
                txtDescuento.Text = "0.00";
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Trim() == "" || int.Parse(txtCantidad.Text) == 0) txtCantidad.Text = "1";
        }

        private void txtFlete_Enter(object sender, EventArgs e)
        {
            if (txtFlete.Text.Contains("$")) txtFlete.Text = txtFlete.Text.Replace("$", "");
            if (decimal.Parse(txtFlete.Text) == 0) txtFlete.Text = "";
        }

        private void txtFlete_Leave(object sender, EventArgs e)
        {
            if (txtFlete.Text.Trim() == "") txtFlete.Text = "0.00";
            decimal flete = decimal.Parse(txtFlete.Text.Trim());
            txtFlete.Text = flete.ToString("c");
        }

        private void dtpPedido_ValueChanged(object sender, EventArgs e)
        {
            dtpHoraPedido.ValueChanged -= new EventHandler(dtpHoraPedido_ValueChanged);
            if (dtpPedido.Checked)
            {
                dtpHoraPedido.Checked = true;
                dtpHoraPedido.Value = Convert.ToDateTime(dtpPedido.Value.ToShortDateString() + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "." +  DateTime.Now.Millisecond);
                dtpHoraPedido.Enabled = true;
            }
            else
            {
                dtpHoraPedido.Checked = false;
                dtpHoraPedido.Value = Convert.ToDateTime(dtpPedido.Value.ToShortDateString() + " 00:00:00.000");
                dtpHoraPedido.Enabled = false;
            }
            dtpHoraPedido.ValueChanged += new EventHandler(dtpHoraPedido_ValueChanged);
        }

        private void dtpHoraPedido_ValueChanged(object sender, EventArgs e)
        {
            dtpHoraPedido.ValueChanged -= new EventHandler(dtpHoraPedido_ValueChanged);
            if (!dtpHoraPedido.Checked) dtpHoraPedido.Value = Convert.ToDateTime(dtpPedido.Value.ToShortDateString() + " 00:00:00.000");
            dtpHoraPedido.ValueChanged += new EventHandler(dtpHoraPedido_ValueChanged);
        }

        private void dtpRequerido_ValueChanged(object sender, EventArgs e)
        {
            if (dtpRequerido.Checked)
            {
                dtpHoraRequerido.Checked = true;
                dtpHoraRequerido.Value = Convert.ToDateTime(dtpRequerido.Value.ToShortDateString() + " 12:00:00.000");
                dtpHoraRequerido.Enabled = true;
            }
            else
            {
                dtpHoraRequerido.Checked = false;
                dtpHoraRequerido.Value = Convert.ToDateTime(dtpRequerido.Value.ToShortDateString() + " 00:00:00.000");
                dtpHoraRequerido.Enabled = false;
            }
        }

        private void dtpHoraRequerido_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpHoraRequerido.Checked) dtpHoraRequerido.Value = Convert.ToDateTime(dtpRequerido.Value.ToShortDateString() + " 00:00:00.000");
        }

        private void dtpEnvio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnvio.Checked)
            {
                dtpHoraEnvio.Checked = true;
                dtpHoraEnvio.Value = Convert.ToDateTime(dtpEnvio.Value.ToShortDateString() + " 12:00:00.000");
                dtpHoraEnvio.Enabled = true;
            }
            else
            {
                dtpHoraEnvio.Checked = false;
                dtpHoraEnvio.Value = Convert.ToDateTime(dtpEnvio.Value.ToShortDateString() + " 00:00:00.000");
                dtpHoraEnvio.Enabled = false;
            }
        }

        private void dtpHoraEnvio_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpHoraEnvio.Checked) dtpHoraEnvio.Value = Convert.ToDateTime(dtpEnvio.Value.ToShortDateString() + " 00:00:00.000");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BorrarMensajesError();
            if (cboProducto.SelectedIndex <= 0)
            {
                errorProvider1.SetError(cboProducto, "Ingrese el producto");
                return;
            }
            else
                errorProvider1.SetError(cboProducto, "");
            if (txtCantidad.Text.Trim() == "" || int.Parse(txtCantidad.Text) == 0)
            {
                errorProvider1.SetError(txtCantidad, "Ingrese la cantidad");
                return;
            }
            else
                errorProvider1.SetError(txtCantidad, "");
            if (decimal.Parse(txtDescuento.Text) > 1 || decimal.Parse(txtDescuento.Text) < 0)
            {
                errorProvider1.SetError(txtDescuento, "El descuento no puede ser mayor que 1 o menor que 0");
                return;
            }
            else
                errorProvider1.SetError(txtDescuento, "");
            txtPrecio.Text = txtPrecio.Text.Replace("$", "");
            dgvDetalle.Rows.Add(new object[] { IdDetalle, cboProducto.Text, txtPrecio.Text, txtCantidad.Text, txtDescuento.Text, ((decimal.Parse(txtPrecio.Text) * decimal.Parse(txtCantidad.Text)) * (1 - decimal.Parse(txtDescuento.Text))).ToString(), "Eliminar", cboProducto.SelectedValue });
            CalcularTotal();
            ++IdDetalle;
            cboCategoria.SelectedIndex = cboProducto.SelectedIndex = 0;
            txtPrecio.Text = "$0.00";
            txtCantidad.Text = "0";
            txtDescuento.Text = "0.00";
            cboCategoria.Focus();
        }

        private void ConfDgvDetalle(DataGridView dgv)
        {
            dgvDetalle.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void dgvDetalle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null) e.Value = decimal.Parse(e.Value.ToString()).ToString("c");
            if (e.ColumnIndex == 3 && e.Value != null) e.Value = decimal.Parse(e.Value.ToString()).ToString("n0");
            if (e.ColumnIndex == 4 && e.Value != null) e.Value = decimal.Parse(e.Value.ToString()).ToString("n2");
            if (e.ColumnIndex == 5 && e.Value != null) e.Value = decimal.Parse(e.Value.ToString()).ToString("c");
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvDetalle.Columns["Eliminar"].Index) return;
            dgvDetalle.Rows.RemoveAt(e.RowIndex);
            CalcularTotal();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int numRegs = 0;
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab == tbpRegistrar)
            {
                try
                {
                    if (ValidarControles())
                    {
                        Utils.ActualizarBarraDeEstado("Actualizando la base de datos...", this);
                        DeshabilitarControles();
                        btnGenerar.Enabled = false;
                        List<PedidoDetalle> lstDetalle = new List<PedidoDetalle>();
                        // llenado de elementos hijos
                        foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
                        {
                            PedidoDetalle detalle = new PedidoDetalle();
                            detalle.ProductId = int.Parse(dgvr.Cells["ProductoId"].Value.ToString());
                            detalle.UnitPrice = decimal.Parse(dgvr.Cells["Precio"].Value.ToString());
                            detalle.Quantity = short.Parse(dgvr.Cells["Cantidad"].Value.ToString());
                            detalle.Discount = decimal.Parse(dgvr.Cells["Descuento"].Value.ToString());
                            lstDetalle.Add(detalle);
                        }
                        Pedido pedido = new Pedido();
                        pedido.CustomerId = cboCliente.SelectedValue.ToString();
                        pedido.EmployeeId = (int)cboEmpleado.SelectedValue;
                        if (!dtpPedido.Checked) pedido.OrderDate = null;
                        else if (dtpHoraPedido.Checked) pedido.OrderDate = Convert.ToDateTime(dtpPedido.Value.ToShortDateString() + " " + dtpHoraPedido.Value.ToLongTimeString());
                        else pedido.OrderDate = Convert.ToDateTime(dtpPedido.Value.ToShortDateString() + " 00:00:00.000");
                        if (!dtpRequerido.Checked) pedido.RequiredDate = null;
                        else if (dtpHoraRequerido.Checked) pedido.RequiredDate = Convert.ToDateTime(dtpRequerido.Value.ToShortDateString() + " " + dtpHoraRequerido.Value.ToLongTimeString());
                        else pedido.RequiredDate = Convert.ToDateTime(dtpRequerido.Value.ToShortDateString() + " 00:00:00.000");
                        if (!dtpEnvio.Checked) pedido.ShippedDate = null;
                        else if (dtpHoraEnvio.Checked) pedido.ShippedDate = Convert.ToDateTime(dtpEnvio.Value.ToShortDateString() + " " + dtpHoraEnvio.Value.ToLongTimeString());
                        else pedido.ShippedDate = Convert.ToDateTime(dtpEnvio.Value.ToShortDateString() + " 00:00:00.000");
                        pedido.ShipVia = (int)cboTransportista.SelectedValue;
                        pedido.ShipName = txtDirigidoa.Text;
                        pedido.ShipAddress = txtDomicilio.Text;
                        pedido.ShipCity = txtCiudad.Text;
                        pedido.ShipRegion = txtRegion.Text;
                        pedido.ShipPostalCode = txtCP.Text;
                        pedido.ShipCountry = txtPais.Text;
                        if (txtFlete.Text.Contains("$")) txtFlete.Text = txtFlete.Text.Replace("$", "");
                        pedido.Freight = decimal.Parse(txtFlete.Text);
                        PedidosDB pedidosDB = new PedidosDB();
                        numRegs = pedidosDB.Add(pedido, lstDetalle, txtId, cboCliente.Text);
                    }
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    MessageBox.Show($"Error, existe un producto duplicado en el pedido, elimine el producto duplicado y modifique la cantidad del producto", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                HabilitarControles();
                btnGenerar.Enabled = true;
                if (numRegs > 0)
                {
                    IdDetalle = 1;
                    BorrarDatosPedido();
                    BorrarDatosBuqueda();
                    LlenarDgvPedidos(null);
                }
            } 
            else if (tabcOperacion.SelectedTab == tbpModificar)
            {
                if (ValidarControles())
                {
                    Utils.ActualizarBarraDeEstado("Actualizando la base de datos...", this);
                    DeshabilitarControles();
                    btnGenerar.Enabled = false;
                    try
                    {
                        Pedido pedido = new Pedido();
                        pedido.OrderId = int.Parse(txtId.Text);
                        pedido.CustomerId = cboCliente.SelectedValue.ToString();
                        pedido.EmployeeId = (int)cboEmpleado.SelectedValue;
                        if (!dtpPedido.Checked) pedido.OrderDate = null;
                        else if (dtpHoraPedido.Checked) pedido.OrderDate = Convert.ToDateTime(dtpPedido.Value.ToShortDateString() + " " + dtpHoraPedido.Value.ToLongTimeString());
                        else pedido.OrderDate = Convert.ToDateTime(dtpPedido.Value.ToShortDateString() + " 00:00:00.000");
                        if (!dtpRequerido.Checked) pedido.RequiredDate = null;
                        else if (dtpHoraRequerido.Checked) pedido.RequiredDate = Convert.ToDateTime(dtpRequerido.Value.ToShortDateString() + " " + dtpHoraRequerido.Value.ToLongTimeString());
                        else pedido.RequiredDate = Convert.ToDateTime(dtpRequerido.Value.ToShortDateString() + " 00:00:00.000");
                        if (!dtpEnvio.Checked) pedido.ShippedDate = null;
                        else if (dtpHoraEnvio.Checked) pedido.ShippedDate = Convert.ToDateTime(dtpEnvio.Value.ToShortDateString() + " " + dtpHoraEnvio.Value.ToLongTimeString());
                        else pedido.ShippedDate = Convert.ToDateTime(dtpEnvio.Value.ToShortDateString() + " 00:00:00.000");
                        pedido.ShipVia = (int)cboTransportista.SelectedValue;
                        pedido.ShipName = txtDirigidoa.Text;
                        pedido.ShipAddress = txtDomicilio.Text;
                        pedido.ShipCity = txtCiudad.Text;
                        pedido.ShipRegion = txtRegion.Text;
                        pedido.ShipPostalCode = txtCP.Text;
                        pedido.ShipCountry = txtPais.Text;
                        if (txtFlete.Text.Contains("$")) txtFlete.Text = txtFlete.Text.Replace("$", "");
                        pedido.Freight = decimal.Parse(txtFlete.Text);
                        PedidosDB pedidosDB = new PedidosDB();
                        numRegs = pedidosDB.Update(pedido, cboCliente.Text);
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
                    if (numRegs > 0)
                    {
                        BorrarDatosBuqueda();
                        txtBIdInicial.Text = txtId.Text;
                        btnBuscar.PerformClick();
                        btnLimpiar.PerformClick();
                    }
                }
            }
            else if (tabcOperacion.SelectedTab == tbpEliminar)
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("Seleccione el pedido a eliminar", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult respuesta = MessageBox.Show($"¿Esta seguro de eliminar el pedido con Id: {txtId.Text} del Cliente: {cboCliente.Text}?", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    Utils.ActualizarBarraDeEstado("Actualizando la base de datos...", this);
                    btnGenerar.Enabled = false;
                    try
                    {
                        Pedido pedido = new Pedido();
                        pedido.OrderId = int.Parse(txtId.Text);
                        PedidosDB pedidosDB = new PedidosDB();
                        numRegs = pedidosDB.Delete(pedido, cboCliente.Text);
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
                    if (numRegs > 0)
                    {
                        BorrarDatosBuqueda();
                        txtBIdInicial.Text = txtId.Text;
                        btnBuscar.PerformClick();
                        btnLimpiar.PerformClick();
                    }
                }
                else
                {
                    BorrarDatosPedido();
                    btnGenerar.Enabled = false;
                }
            }
        }

        private void txtFlete_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosConPunto(sender, e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosConPunto(sender, e);
        }

        // se anidan las clases para evitar interfieran con otro código similar del sistema, solo son accesibles desde su tipo contenedor
        private class PedidoDetalle
        {
            public int ProductId { get; set; }
            public decimal UnitPrice { get; set; }
            public short Quantity { get; set; }
            public decimal Discount { get; set; }
            public string ProductName { get; set; }
        }

        private class Pedido
        {
            public int OrderId { get; set; }
            public string CustomerId { get; set; }
            public int EmployeeId { get; set; }
            public DateTime? OrderDate { get; set; }
            public DateTime? RequiredDate { get; set; }
            public DateTime? ShippedDate { get; set; }
            public int ShipVia { get; set; }
            public decimal Freight { get; set; }
            public string ShipName { get; set; }
            public string ShipAddress { get; set; }
            public string ShipCity { get; set; }
            public string ShipRegion { get; set; }
            public string ShipPostalCode { get; set; }
            public string ShipCountry { get; set; }
        }

        private class PedidosDB
        {
            public int PedidoId { get; set; }

            public byte Add(Pedido pedido, List<PedidoDetalle> lst, TextBox textBox, string cliente)
            {
                // las excepciones generadas en este segmento de código son capturadas en un nivel superior, por eso no uso bloque try
                byte numRegs = 0;
                using (SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn))
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Id");
                    dt.Columns.Add("ProductId");
                    dt.Columns.Add("UnitPrice");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("Discount");
                    int i = 1;
                    foreach (var item in lst)
                    {
                        dt.Rows.Add(i, item.ProductId, item.UnitPrice, item.Quantity, item.Discount);
                        i++;
                    }
                    SqlCommand cmd = new SqlCommand("Sp_Pedidos_Insertar", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("OrderId", 0);
                    cmd.Parameters["OrderId"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("CustomerId", pedido.CustomerId);
                    cmd.Parameters.AddWithValue("EmployeeId", pedido.EmployeeId);
                    if (pedido.OrderDate == null) cmd.Parameters.AddWithValue("OrderDate", DBNull.Value);
                    else cmd.Parameters.AddWithValue("OrderDate", pedido.OrderDate);
                    if (pedido.RequiredDate == null) cmd.Parameters.AddWithValue("RequiredDate", DBNull.Value);
                    else cmd.Parameters.AddWithValue("RequiredDate", pedido.RequiredDate);
                    if (pedido.ShippedDate == null) cmd.Parameters.AddWithValue("ShippedDate", DBNull.Value);
                    else cmd.Parameters.AddWithValue("ShippedDate", pedido.ShippedDate);
                    cmd.Parameters.AddWithValue("ShipVia", pedido.ShipVia);
                    cmd.Parameters.AddWithValue("Freight", pedido.Freight);
                    if (pedido.ShipName.Trim() == "") cmd.Parameters.AddWithValue("ShipName", DBNull.Value);
                    else cmd.Parameters.AddWithValue("ShipName", pedido.ShipName);
                    if (pedido.ShipAddress.Trim() == "") cmd.Parameters.AddWithValue("ShipAddress", DBNull.Value);
                    else cmd.Parameters.AddWithValue("ShipAddress", pedido.ShipAddress);
                    if (pedido.ShipCity.Trim() == "") cmd.Parameters.AddWithValue("ShipCity", DBNull.Value);
                    else cmd.Parameters.AddWithValue("ShipCity", pedido.ShipCity);
                    if (pedido.ShipRegion.Trim() == "") cmd.Parameters.AddWithValue("ShipRegion", DBNull.Value);
                    else cmd.Parameters.AddWithValue("ShipRegion", pedido.ShipRegion);
                    if (pedido.ShipPostalCode.Trim() == "") cmd.Parameters.AddWithValue("ShipPostalCode", DBNull.Value);
                    else cmd.Parameters.AddWithValue("ShipPostalCode", pedido.ShipPostalCode);
                    if (pedido.ShipCountry.Trim() == "") cmd.Parameters.AddWithValue("ShipCountry", DBNull.Value);
                    else cmd.Parameters.AddWithValue("ShipCountry", pedido.ShipCountry);
                    var sqlParameter = new SqlParameter("lstOrderDetails", SqlDbType.Structured);
                    sqlParameter.TypeName = "dbo.OrderDetails";
                    sqlParameter.Value = dt;
                    cmd.Parameters.Add(sqlParameter);
                    cn.Open();
                    numRegs = (byte)cmd.ExecuteNonQuery();
                    PedidoId = (int)cmd.Parameters["OrderId"].Value;
                    textBox.Text = PedidoId.ToString();
                    cn.Close();
                    if (numRegs > 0) MessageBox.Show($"El pedido con Id: {PedidoId} del Cliente: {cliente}, se registró satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return numRegs;
            }

            public byte Update(Pedido pedido, string cliente)
            {
                // las excepciones generadas en este segmento de código son capturadas en un nivel superior, por eso no uso bloque try
                byte numRegs = 0;
                using (SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_Pedidos_Actualizar", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("OrderId", pedido.OrderId);
                    cmd.Parameters.AddWithValue("CustomerId", pedido.CustomerId);
                    cmd.Parameters.AddWithValue("EmployeeId", pedido.EmployeeId);
                    if (pedido.OrderDate == null) cmd.Parameters.AddWithValue("OrderDate", DBNull.Value);
                    else cmd.Parameters.AddWithValue("OrderDate", pedido.OrderDate);
                    if (pedido.RequiredDate == null) cmd.Parameters.AddWithValue("RequiredDate", DBNull.Value);
                    else cmd.Parameters.AddWithValue("RequiredDate", pedido.RequiredDate);
                    if (pedido.ShippedDate == null) cmd.Parameters.AddWithValue("ShippedDate", DBNull.Value);
                    else cmd.Parameters.AddWithValue("ShippedDate", pedido.ShippedDate);
                    cmd.Parameters.AddWithValue("ShipVia", pedido.ShipVia);
                    cmd.Parameters.AddWithValue("Freight", pedido.Freight);
                    if (pedido.ShipName.Trim() == "") cmd.Parameters.AddWithValue("ShipName", DBNull.Value);
                    else cmd.Parameters.AddWithValue("ShipName", pedido.ShipName);
                    if (pedido.ShipAddress.Trim() == "") cmd.Parameters.AddWithValue("ShipAddress", DBNull.Value);
                    else cmd.Parameters.AddWithValue("ShipAddress", pedido.ShipAddress);
                    if (pedido.ShipCity.Trim() == "") cmd.Parameters.AddWithValue("ShipCity", DBNull.Value);
                    else cmd.Parameters.AddWithValue("ShipCity", pedido.ShipCity);
                    if (pedido.ShipRegion.Trim() == "") cmd.Parameters.AddWithValue("ShipRegion", DBNull.Value);
                    else cmd.Parameters.AddWithValue("ShipRegion", pedido.ShipRegion);
                    if (pedido.ShipPostalCode.Trim() == "") cmd.Parameters.AddWithValue("ShipPostalCode", DBNull.Value);
                    else cmd.Parameters.AddWithValue("ShipPostalCode", pedido.ShipPostalCode);
                    if (pedido.ShipCountry.Trim() == "") cmd.Parameters.AddWithValue("ShipCountry", DBNull.Value);
                    else cmd.Parameters.AddWithValue("ShipCountry", pedido.ShipCountry);
                    cn.Open();
                    numRegs = (byte)cmd.ExecuteNonQuery();
                    cn.Close();
                    if (numRegs > 0) MessageBox.Show($"El pedido con Id: {pedido.OrderId} del Cliente: {cliente}, se actualizó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No se pudo realizar la modificación, es posible que el registro se haya eliminado previamente por otro usuario de la red", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return numRegs;
            }

            public byte Delete(Pedido pedido, string cliente)
            {
                byte numRegs = 0;
                using (SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_Pedidos_Eliminar", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("OrderId", pedido.OrderId);
                    cn.Open();
                    numRegs = (byte)cmd.ExecuteNonQuery();
                    cn.Close();
                    if (numRegs > 0) MessageBox.Show($"El pedido con Id: {pedido.OrderId} del Cliente: {cliente}, se eliminó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No se pudo realizar la eliminación, es posible que el registro haya sido eliminado previamente por otro usuario de la red", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return numRegs;
            }
        }

        private void tabcOperacion_Selected(object sender, TabControlEventArgs e)
        {
            IdDetalle = 1;
            BorrarDatosPedido();
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab == tbpRegistrar)
            {
                if (eventoCargardo)
                {
                    dgvPedidos.CellClick -= new DataGridViewCellEventHandler(dgvPedidos_CellClick);
                    eventoCargardo = false;
                }
                BorrarDatosBuqueda();
                HabilitarControles();
                btnGenerar.Text = "Generar pedido";
                btnGenerar.Visible = true;
                btnGenerar.Enabled = true;
                btnAgregar.Visible = true;
                btnAgregar.Enabled = true;
                dgvDetalle.Columns["Eliminar"].Visible = true;
                grbProducto.Enabled = true;
            }
            else
            {
                if (!eventoCargardo)
                {
                    dgvPedidos.CellClick += new DataGridViewCellEventHandler(dgvPedidos_CellClick);
                    eventoCargardo = true;
                }
                DeshabilitarControles();
                btnGenerar.Enabled = false;
                dgvDetalle.Columns["Eliminar"].Visible = false;
                grbProducto.Enabled = false;
                if (tabcOperacion.SelectedTab == tbpConsultar)
                {
                    btnGenerar.Visible = false;
                    btnAgregar.Visible = false;
                } 
                else if (tabcOperacion.SelectedTab == tbpModificar)
                {
                    btnGenerar.Text = "Modificar pedido";
                    btnGenerar.Visible = true;
                    btnAgregar.Visible = false;
                }
                else if (tabcOperacion.SelectedTab == tbpEliminar)
                {
                    btnGenerar.Text = "Eliminar pedido";
                    btnGenerar.Visible = true;
                    btnAgregar.Visible = false;
                }
            }
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabcOperacion.SelectedTab != tbpRegistrar)
            {
                BorrarDatosPedido();
                DataGridViewRow dgvr = dgvPedidos.CurrentRow;
                txtId.Text = dgvr.Cells["Id"].Value.ToString();
                LlenarDatosPedido();
                LlenarDatosDetallePedido();
                DeshabilitarControles();
                if (tabcOperacion.SelectedTab == tbpModificar)
                {
                    HabilitarControles();
                    btnGenerar.Enabled = true;
                }
                else if (tabcOperacion.SelectedTab == tbpEliminar)
                    btnGenerar.Enabled = true;
            }
        }

        private void LlenarDatosPedido()
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Pedidos_Listar1", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PedidoId", txtId.Text);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (rdr.Read())
                {
                    cboCliente.SelectedIndexChanged -= new EventHandler(cboCliente_SelectedIndexChanged);
                    cboCliente.SelectedValue = rdr["CustomerId"] == DBNull.Value ? 0 : rdr["CustomerId"];
                    cboCliente.SelectedIndexChanged += new EventHandler(cboCliente_SelectedIndexChanged);
                    cboEmpleado.SelectedValue = rdr["EmployeeId"] == DBNull.Value ? 0 : rdr["EmployeeId"];
                    cboTransportista.SelectedValue = rdr["ShipVia"] == DBNull.Value ? 0 : rdr["ShipVia"];
                    txtDirigidoa.Text = rdr["ShipName"] == DBNull.Value ? "" : rdr["ShipName"].ToString();
                    txtDomicilio.Text = rdr["ShipAddress"] == DBNull.Value ? "" : rdr["ShipAddress"].ToString();
                    txtCiudad.Text = rdr["ShipCity"] == DBNull.Value ? "" : rdr["ShipCity"].ToString();
                    txtRegion.Text = rdr["ShipRegion"] == DBNull.Value ? "" : rdr["ShipRegion"].ToString();
                    txtCP.Text = rdr["ShipPostalCode"] == DBNull.Value ? "" : rdr["ShipPostalCode"].ToString();
                    txtPais.Text = rdr["ShipCountry"] == DBNull.Value ? "" : rdr["ShipCountry"].ToString();
                    txtFlete.Text = rdr["Freight"] == DBNull.Value ? "" : rdr["Freight"].ToString();
                    decimal flete;
                    if (decimal.TryParse(txtFlete.Text, out flete))
                        txtFlete.Text = flete.ToString("c");
                    DateTime fecha;
                    if (DateTime.TryParse(rdr["OrderDate"].ToString(), out fecha))
                    {
                        dtpPedido.Value = fecha;
                        dtpHoraPedido.Value = fecha;
                    }
                    else
                    {
                        dtpPedido.Value = dtpPedido.MinDate;
                        dtpPedido.Checked = false;
                        dtpHoraPedido.Value = dtpPedido.MinDate;
                        dtpHoraPedido.Checked = false;
                    }
                    if (DateTime.TryParse(rdr["RequiredDate"].ToString(), out fecha))
                    {
                        dtpRequerido.Value = fecha;
                        dtpHoraRequerido.Value = fecha;
                    }
                    else
                    {
                        dtpRequerido.Value = dtpRequerido.MinDate;
                        dtpRequerido.Checked = false;
                        dtpHoraRequerido.Value = dtpHoraRequerido.MinDate;
                        dtpHoraRequerido.Checked = false;
                    }
                    if (DateTime.TryParse(rdr["ShippedDate"].ToString(), out fecha))
                    {
                        dtpEnvio.Value = fecha;
                        dtpHoraEnvio.Value = fecha;
                    }
                    else
                    {
                        dtpEnvio.Value = dtpEnvio.MinDate;
                        dtpEnvio.Checked = false;
                        dtpEnvio.Value = dtpHoraEnvio.MinDate;
                        dtpHoraEnvio.Checked = false;
                    }
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
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void LlenarDatosDetallePedido()
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_DetallePedidos_Productos_Listar1", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PedidoId", txtId.Text);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                IdDetalle = 1;
                PedidoDetalle pedidoDetalle;
                while (rdr.Read())
                {
                    pedidoDetalle = new PedidoDetalle();
                    pedidoDetalle.ProductId = (int)rdr["Id Producto"];
                    pedidoDetalle.ProductName = rdr["Producto"].ToString();
                    pedidoDetalle.UnitPrice = (decimal)rdr["Precio"];
                    pedidoDetalle.Quantity = (short)rdr["Cantidad"];
                    pedidoDetalle.Discount = decimal.Parse(rdr["Descuento"].ToString());
                    dgvDetalle.Rows.Add(new object[] { IdDetalle, pedidoDetalle.ProductName, pedidoDetalle.UnitPrice, pedidoDetalle.Quantity, pedidoDetalle.Discount, (pedidoDetalle.UnitPrice * pedidoDetalle.Quantity) * (1 - pedidoDetalle.Discount), "Eliminar", pedidoDetalle.ProductId });
                    ++IdDetalle;
                }
                rdr.Close();
                CalcularTotal();
                //IdDetalle = 1;
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
            Utils.ActualizarBarraDeEstado($"Se muestran {dgvPedidos.RowCount} registros", this);
        }

        private void txtBIdInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        private void txtBIdFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        private void txtCantidad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtCantidad.Text.Trim() != "")
            {
                if (int.Parse(txtCantidad.Text.Replace(",", "")) > 32767)
                {
                    errorProvider1.SetError(txtCantidad, "La cantidad no puede ser mayor a 32767");
                    e.Cancel = true;
                }
                else
                    errorProvider1.SetError(txtCantidad, "");
            }
        }
    }
}
