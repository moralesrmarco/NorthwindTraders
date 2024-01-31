using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmPedidosDetalleCrud : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        int IdDetalle = 1;

        public FrmPedidosDetalleCrud()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void grbPaint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.Black, this);
        }

        private void FrmPedidosDetalleCrud_Load(object sender, EventArgs e)
        {
            label12.Text = "Fecha\ninicial:";
            label13.Text = "Fecha\nfinal:";
            label14.Text = "Fecha\ninicial:";
            label15.Text = "Fecha\nfinal:";
            label16.Text = "Fecha\ninicial:";
            label17.Text = "Fecha\nfinal:";
            DeshabilitarControles();
            LlenarCboCategoria();
            LlenarDgvPedidos(null);
            Utils.ConfDataGridView(dgvPedidos);
            Utils.ConfDataGridView(dgvDetalle);
            ConfDgvPedidos(dgvPedidos);
            ConfDgvDetalle(dgvDetalle);
            txtPrecio.Text = "$0.00";
            txtDescuento.Text = "0.00";
            txtTotal.Text = "$0.00";
            txtCantidad.Text = "0";
        }

        private void DeshabilitarControles()
        {
            cboCategoria.Enabled = cboProducto.Enabled = false;
            txtCantidad.ReadOnly = txtDescuento.ReadOnly = true;
            btnAgregar.Enabled = false;
        }

        private void HabilitarControles()
        {
            cboCategoria.Enabled = cboProducto.Enabled = true;
            txtCantidad.ReadOnly = txtDescuento.ReadOnly = false;
            btnAgregar.Enabled = true;
        }

        private void LlenarDgvPedidos(object sender)
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
            try
            {
                SqlCommand cmd;
                if (sender == null)
                {
                    cmd = new SqlCommand("Sp_Pedidos_Listar20", cn);
                }
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

        private void ConfDgvDetalle(DataGridView dgv)
        {
            dgvDetalle.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["Modificar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvDetalle.Columns["Eliminar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvDetalle.Columns["Precio"].DefaultCellStyle.Format = "c";
            dgvDetalle.Columns["Descuento"].DefaultCellStyle.Format = "n2";
            dgvDetalle.Columns["Importe"].DefaultCellStyle.Format = "c";
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BorrarDatosPedido();
            BorrarMensajesError();
            DeshabilitarControles();
            LlenarDgvPedidos(sender);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            BorrarDatosPedido();
            BorrarMensajesError();
            BorrarDatosBuqueda();
            DeshabilitarControles();
        }

        private void BorrarDatosPedido()
        {
            txtId.Text = txtCliente.Text = "";
            cboCategoria.SelectedIndex = 0;
            cboProducto.DataSource = null;
            txtPrecio.Text = "$0.00";
            txtCantidad.Text = "0";
            txtDescuento.Text = "0.00";
            txtTotal.Text = "$0.00";
            dgvDetalle.Rows.Clear();
        }

        private void BorrarMensajesError()
        {
            errorProvider1.SetError(cboCategoria, "");
            errorProvider1.SetError(cboProducto, "");
            errorProvider1.SetError(txtCantidad, "");
            errorProvider1.SetError(txtDescuento, "");
        }

        private bool ValidarControles()
        {
            bool valida = true;
            if (cboCategoria.SelectedIndex <= 0)
            {
                valida = false;
                errorProvider1.SetError(cboCategoria, "Ingrese la categoría");
            }
            if (cboProducto.SelectedIndex <= 0)
            {
                valida = false;
                errorProvider1.SetError(cboProducto, "Ingrese el producto");
            }
            if (txtCantidad.Text == "" || txtCantidad.Text == "0")
            {
                valida = false;
                errorProvider1.SetError(txtCantidad, "Ingrese la cantidad");
            }
            if (txtDescuento.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtDescuento, "Ingrese el descuento");
            }
            if (decimal.Parse(txtDescuento.Text) > 1 || decimal.Parse(txtDescuento.Text) < 0)
            {
                valida = false;
                errorProvider1.SetError(txtDescuento, "El descuento no puede ser mayor que 1 o menor que 0");                
            }
            //string total = txtTotal.Text;
            //total = total.Replace("$", "");
            //if (txtTotal.Text == "" || decimal.Parse(total) == 0)
            //{
            //    valida = false;
            //    errorProvider1.SetError(btnAgregar, "Ingrese el detalle del pedido");
            //}
            //if (cboProducto.SelectedIndex > 0)
            //{
            //    valida = false;
            //    errorProvider1.SetError(cboProducto, "Ha seleccionado un producto y no lo ha agregado al pedido");
            //}
            return valida;
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

        private void txtBIdInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        private void txtBIdFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        private void FrmPedidosDetalleCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cboCategoria.SelectedIndex > 0 || cboProducto.SelectedIndex > 0 )
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro de querer cerrar el formulario?, se perderan los datos no guardados", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void FrmPedidosDetalleCrud_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrecio.Text = "$0.00";
            if (cboCategoria.SelectedIndex > 0)
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
                DataRow drow = tbl.NewRow();
                drow["Id"] = 0;
                drow["Producto"] = "«--- Seleccione ---»";
                tbl.Rows.Add(drow);
                cboProducto.DataSource = tbl;
                cboProducto.DisplayMember = "Producto";
                cboProducto.ValueMember = "Id";
            }
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BorrarDatosPedido();
            DataGridViewRow dgvr = dgvPedidos.CurrentRow;
            txtId.Text = dgvr.Cells["Id"].Value.ToString();
            txtCliente.Text = dgvr.Cells["Cliente"].Value.ToString();
            LlenarDatosDetallePedido();
            HabilitarControles();
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
                    pedidoDetalle.ProductId = (int)rdr["Id producto"];
                    pedidoDetalle.ProductName = rdr["Producto"].ToString();
                    pedidoDetalle.UnitPrice = (decimal)rdr["Precio"];
                    pedidoDetalle.Quantity = (short)rdr["Cantidad"];
                    pedidoDetalle.Discount = decimal.Parse(rdr["Descuento"].ToString());
                    dgvDetalle.Rows.Add(new object[] { IdDetalle, pedidoDetalle.ProductName, pedidoDetalle.UnitPrice, pedidoDetalle.Quantity, pedidoDetalle.Discount, (pedidoDetalle.UnitPrice * pedidoDetalle.Quantity) * (1 - pedidoDetalle.Discount), "  Modificar  ", "  Eliminar  ", pedidoDetalle.ProductId });
                    ++IdDetalle;
                }
                rdr.Close();
                CalcularTotal();
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
            Utils.ActualizarBarraDeEstado($"Se muestran {dgvPedidos.RowCount} registros de pedidos y {dgvDetalle.RowCount} registros del detalle del pedido con Id: {txtId.Text}", this);
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow dgvr in dgvDetalle.Rows)
            {
                decimal importe = (decimal)dgvr.Cells["Importe"].Value;
                total += importe;
            }
            txtTotal.Text = string.Format("{0:c}", total);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int numRegs = 0;
            BorrarMensajesError();
            if (ValidarControles())
            {
                try
                {
                    Utils.ActualizarBarraDeEstado("Actualizando la base de datos...", this);
                    DeshabilitarControles();
                    PedidoDetalle pedidoDetalle = new PedidoDetalle();
                    pedidoDetalle.ProductId = (int)cboProducto.SelectedValue;
                    txtPrecio.Text = txtPrecio.Text.Replace("$", "");
                    pedidoDetalle.UnitPrice = decimal.Parse(txtPrecio.Text);
                    pedidoDetalle.Quantity = short.Parse(txtCantidad.Text);
                    pedidoDetalle.Discount = decimal.Parse(txtDescuento.Text);
                    pedidoDetalle.ProductName = cboProducto.Text;
                    PedidoDetalleDb pedidoDetalleDb = new PedidoDetalleDb();
                    pedidoDetalleDb.PedidoId = int.Parse(txtId.Text);
                    numRegs = pedidoDetalleDb.Add(pedidoDetalle);
                    if (numRegs > 0)
                        MessageBox.Show($"El producto: {pedidoDetalle.ProductName} del Pedido: {pedidoDetalleDb.PedidoId}, se registró satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"El producto: {pedidoDetalle.ProductName} del Pedido: {pedidoDetalleDb.PedidoId}, NO se registró en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    MessageBox.Show($"Error, ya existe un registro del producto {cboProducto.Text} en la base de datos, modifique la cantidad del producto de ese registro", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BorrarDatosAgregarProducto();
                    HabilitarControles();
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
                    BorrarDatosDetallePedido();
                    LlenarDatosDetallePedido();
                    HabilitarControles();
                    Utils.ActualizarBarraDeEstado($"Se muestran {dgvPedidos.RowCount} registros de pedidos y {dgvDetalle.RowCount} registros del detalle; del pedido con Id: {txtId.Text}", this);

                }
            }
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand($"Select UnitPrice from Products Where ProductId = {cboProducto.SelectedValue}", cn);
                    cmd.CommandType = CommandType.Text;
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
                if (txtCantidad.Text == "0") txtCantidad.Text = "1";
            }
        }

        private void BorrarDatosDetallePedido()
        {
            cboCategoria.SelectedIndex = 0;
            cboProducto.DataSource = null;
            txtPrecio.Text = "$0.00";
            txtCantidad.Text = "0";
            txtDescuento.Text = "0.00";
            txtTotal.Text = "$0.00";
            dgvDetalle.Rows.Clear();
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgvDetalle.Columns["Eliminar"].Index)
            {
                DataGridViewRow dgvr = dgvDetalle.CurrentRow;
                string productName = dgvr.Cells["Producto"].Value.ToString();
                int productId = (int)dgvr.Cells["ProductoId"].Value;
                int orderId = int.Parse(txtId.Text);
                EliminarProducto(productName, productId, orderId);
            }
            if (e.ColumnIndex == dgvDetalle.Columns["Modificar"].Index)
            {
                DataGridViewRow dgvr = dgvDetalle.CurrentRow;
                FrmPedidosDetalleModificar frmPedidosDetalleModificar = new FrmPedidosDetalleModificar();
                frmPedidosDetalleModificar.PedidoId = int.Parse(txtId.Text);
                frmPedidosDetalleModificar.ProductoId = int.Parse(dgvr.Cells["ProductoId"].Value.ToString());
                frmPedidosDetalleModificar.Producto = dgvr.Cells["Producto"].Value.ToString();
                frmPedidosDetalleModificar.Precio = decimal.Parse(dgvr.Cells["Precio"].Value.ToString());
                frmPedidosDetalleModificar.Cantidad = short.Parse(dgvr.Cells["Cantidad"].Value.ToString());
                frmPedidosDetalleModificar.Descuento = decimal.Parse(dgvr.Cells["Descuento"].Value.ToString());
                frmPedidosDetalleModificar.Importe = decimal.Parse(dgvr.Cells["Importe"].Value.ToString());
                DialogResult dialogResult = frmPedidosDetalleModificar.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    BorrarDatosDetallePedido();
                    LlenarDatosDetallePedido();
                }
            }
        }

        private void EliminarProducto(String productName, int productId, int orderId)
        {
            int numRegs = 0;
            BorrarMensajesError();
            BorrarDatosAgregarProducto();
            try
            {
                DialogResult respuesta = MessageBox.Show($"¿Esta seguro de eliminar el producto : {productName} del pedido: {orderId}?", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    Utils.ActualizarBarraDeEstado("Actualizando la base de datos...", this);
                    DeshabilitarControles();
                    PedidoDetalle pedidoDetalle = new PedidoDetalle();
                    pedidoDetalle.ProductId = productId;
                    PedidoDetalleDb pedidoDetalleDb = new PedidoDetalleDb();
                    pedidoDetalleDb.PedidoId = orderId;
                    numRegs = pedidoDetalleDb.Delete(pedidoDetalle);
                    if (numRegs > 0)
                        MessageBox.Show($"El producto: {productName} del Pedido: {pedidoDetalleDb.PedidoId}, se eliminó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"El producto: {productName} del Pedido: {pedidoDetalleDb.PedidoId}, NO se eliminó en la base de datos, es posible que el registro se haya eliminado previamente por otro usuario de la red", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (numRegs > 0)
            {
                BorrarDatosDetallePedido();
                LlenarDatosDetallePedido();
                HabilitarControles();
                Utils.ActualizarBarraDeEstado($"Se muestran {dgvPedidos.RowCount} registros de pedidos y {dgvDetalle.RowCount} registros del detalle; del pedido con Id: {txtId.Text}", this);
            }
        }

        private void BorrarDatosAgregarProducto()
        {
            cboCategoria.SelectedIndex = 0;
            cboProducto.DataSource = null;
            txtPrecio.Text = "$0.00";
            txtCantidad.Text = "0";
            txtDescuento.Text = "0.00";
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

        private class PedidoDetalleDb
        {
            public int PedidoId { get; set; }

            public byte Add(PedidoDetalle pedidoDetalle)
            {
                // las excepciones generadas en este segmento de código son capturadas en un nivel superior, por eso no uso bloque try
                byte numRegs = 0;
                using (SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_PedidosDetalle_Insertar", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("OrderId", PedidoId);
                    cmd.Parameters.AddWithValue("ProductId", pedidoDetalle.ProductId);
                    cmd.Parameters.AddWithValue("UnitPrice", pedidoDetalle.UnitPrice);
                    cmd.Parameters.AddWithValue("Quantity", pedidoDetalle.Quantity);
                    cmd.Parameters.AddWithValue("Discount", pedidoDetalle.Discount);
                    cn.Open();
                    numRegs = (byte)cmd.ExecuteNonQuery();
                    cn.Close();
                }
                return numRegs;
            }

            public byte Delete(PedidoDetalle pedidoDetalle)
            {
                byte numRegs = 0;
                using (SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_PedidosDetalle_Eliminar", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("OrderId", PedidoId);
                    cmd.Parameters.AddWithValue("ProductId", pedidoDetalle.ProductId);
                    cn.Open();
                    numRegs = (byte)cmd.ExecuteNonQuery();
                    cn.Close();
                }
                return numRegs;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosConPunto(sender, e);
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
