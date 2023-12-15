using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmProductosCrudRdr : Form
    {

        private SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);

        bool EventoCargado = true; // esta variable es necesaria para controlar el manejador de eventos de la celda del dgv ojo no quitar

        public FrmProductosCrudRdr()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void groupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.Black, this);
        }

        private void FrmProductosCrudRdr_Load(object sender, EventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
            try
            {
                SqlCommand cmd = new SqlCommand("Select 0 As IdCategoria, '»--- Seleccione ---«' As Categoria Union All Select CategoryId As IdCategoria, CategoryName As Categoria From Categories", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (rdr.HasRows)
                {
                    DataTable tblBCategoria = new DataTable();
                    tblBCategoria.TableName = "tblBCategoria";
                    tblBCategoria.Columns.Add("IdCategoria", Type.GetType("System.Int32"));
                    tblBCategoria.Columns.Add("Categoria", Type.GetType("System.String"));
                    DataTable tblCategoria = tblBCategoria.Clone();
                    tblCategoria.TableName = "tblCategoria";
                    DataRow dr;
                    while (rdr.Read())
                    {
                        dr = tblBCategoria.NewRow();
                        dr["IdCategoria"] = rdr["IdCategoria"];
                        dr["Categoria"] = rdr["Categoria"];
                        tblBCategoria.Rows.Add(dr);
                        dr = tblCategoria.NewRow();
                        dr["IdCategoria"] = rdr["IdCategoria"];
                        dr["Categoria"] = rdr["Categoria"];
                        tblCategoria.Rows.Add(dr);
                    }
                    cboBCategoria.DataSource = tblBCategoria;
                    cboBCategoria.DisplayMember = "Categoria";
                    cboBCategoria.ValueMember = "IdCategoria";
                    cboCategoria.DataSource = tblCategoria;
                    cboCategoria.DisplayMember = "Categoria";
                    cboCategoria.ValueMember = "IdCategoria";
                }
                rdr.Close();
                cmd = new SqlCommand("Select 0 As IdProveedor, '»--- Seleccione ---«' As Proveedor Union All Select SupplierId As IdProveedor, CompanyName As Proveedor From Suppliers Order By Proveedor", cn);
                cmd.CommandType = CommandType.Text;
                rdr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (rdr.HasRows)
                {
                    DataTable tblBProveedor = new DataTable();
                    tblBProveedor.TableName = "tblBProveedor";
                    tblBProveedor.Columns.Add("IdProveedor", Type.GetType("System.Int32"));
                    tblBProveedor.Columns.Add("Proveedor", Type.GetType("System.String"));
                    DataTable tblProveedor = tblBProveedor.Clone();
                    tblProveedor.TableName = "tblProveedor";
                    DataRow dr;
                    while (rdr.Read())
                    {
                        dr = tblBProveedor.NewRow();
                        dr["IdProveedor"] = rdr["IdProveedor"];
                        dr["Proveedor"] = rdr["Proveedor"];
                        tblBProveedor.Rows.Add(dr);
                        dr = tblProveedor.NewRow();
                        dr["IdProveedor"] = rdr["IdProveedor"];
                        dr["Proveedor"] = rdr["Proveedor"];
                        tblProveedor.Rows.Add(dr);
                    }
                    cboBProveedor.DataSource = tblBProveedor;
                    cboBProveedor.DisplayMember = "Proveedor";
                    cboBProveedor.ValueMember = "IdProveedor";
                    cboProveedor.DataSource = tblProveedor;
                    cboProveedor.DisplayMember = "Proveedor";
                    cboProveedor.ValueMember = "IdProveedor";
                }
                rdr.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error con la base de datos: " + ex.Message + "\r\n" + ex.LineNumber + "\r\n" + ex.StackTrace, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message + "\r\n" + ex.StackTrace, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
            finally
            {
                cn.Close();
            }
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
                    cmd = new SqlCommand("Sp_Productos_All", cn);
                    cmd.Parameters.AddWithValue("top100", 0);
                }
                else
                {
                    cmd = new SqlCommand("Sp_Productos_Buscar", cn);
                    cmd.Parameters.AddWithValue("Id", txtBId.Text);
                    cmd.Parameters.AddWithValue("Producto", txtBProducto.Text);
                    cmd.Parameters.AddWithValue("Categoria", cboBCategoria.SelectedValue);
                    cmd.Parameters.AddWithValue("Proveedor", cboBProveedor.SelectedValue);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (rdr.HasRows)
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = rdr;
                    dgv.DataSource = bs;
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
                    dgv.Enabled = true;
                    dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv.Columns["Precio"].DefaultCellStyle.Format = "c";
                    dgv.Columns["Unidades en inventario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv.Columns["Unidades en pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv.Columns["Punto de pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv.Columns["Cantidad por unidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv.Columns["Precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv.Columns["Unidades en inventario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv.Columns["Unidades en pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv.Columns["Punto de pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv.Columns["Descontinuado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgv.Columns["Categoría"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    if (sender == null)
                        Utils.ActualizarBarraDeEstado("Se muestran los últimos 20 productos registrados", this);
                    else
                        Utils.ActualizarBarraDeEstado($"Se encontraron {dgv.Rows.Count} registros", this);
                }
                else
                {
                    dgv.DataSource = null;
                    Utils.ActualizarBarraDeEstado("No se encontraron registros con el criterio de busqueda proporcionado", this, true);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error con la base de datos: " + ex.Message + "\r\n" + ex.LineNumber + "\r\n" + ex.StackTrace, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message + "\r\n" + ex.StackTrace, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
            finally
            {
                cn.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BorrarMensajesError();
            BorrarDatosProducto();
            if (tabOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
            LlenarDgv(sender);
        }

        private void BorrarMensajesError()
        {
            errorProvider1.SetError(cboCategoria, "");
            errorProvider1.SetError(cboProveedor, "");
            errorProvider1.SetError(txtProducto, "");
            errorProvider1.SetError(txtPrecio, "");
            errorProvider1.SetError(txtUInventario, "");
            errorProvider1.SetError(txtUPedido, "");
            errorProvider1.SetError(txtPPedido, "");
        }

        private void BorrarDatosProducto()
        {
            txtId.Text = "";
            cboCategoria.SelectedIndex = 0;
            cboProveedor.SelectedIndex = 0;
            txtProducto.Text = "";
            txtCantidadxU.Text = "";
            txtPrecio.Text = "";
            txtUInventario.Text = "";
            txtUPedido.Text = "";
            txtPPedido.Text = "";
            chkDescontinuado.Checked = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            BorrarDatosBusqueda();
            BorrarDatosProducto();
            BorrarMensajesError();
            if (tabOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
        }
        
        private void BorrarDatosBusqueda()
        {
            txtBProducto.Text = txtBId.Text = "";
            cboBProveedor.SelectedIndex = cboBCategoria.SelectedIndex = 0;
        }

        private bool ValidarControles()
        {
            bool valida = true;
            if (cboCategoria.SelectedIndex == 0 || cboCategoria.SelectedIndex == -1)
            {
                valida = false;
                errorProvider1.SetError(cboCategoria, "Seleccione una categoría");
            }
            if (cboProveedor.SelectedIndex == 0 || cboProveedor.SelectedIndex == -1)
            {
                valida = false;
                errorProvider1.SetError(cboProveedor, "Seleccione un proveedor");
            }
            if (txtProducto.Text.Trim() == "")
            {
                valida = false;
                errorProvider1.SetError(txtProducto, "Ingrese producto");

            }
            if (txtPrecio.Text.Trim() == "")
            {
                valida = false;
                errorProvider1.SetError(txtPrecio, "Ingrese precio");
            }
            if (txtUInventario.Text.Trim() == "")
            {
                valida = false;
                errorProvider1.SetError(txtUInventario, "Ingrese unidades en inventario");
            }
            if (txtUPedido.Text.Trim() == "")
            {
                valida = false;
                errorProvider1.SetError(txtUPedido, "Ingrese unidades en pedido");
            }
            if (txtPPedido.Text.Trim() == "")
            {
                valida = false;
                errorProvider1.SetError(txtPPedido, "Ingrese punto de pedido");
            }
            return valida;
        }

        private void txtUInventario_Validating(object sender, CancelEventArgs e)
        {
            if (txtUInventario.Text.Trim() != "")
            {
                if (int.Parse(txtUInventario.Text) > 32767)
                {
                    errorProvider1.SetError(txtUInventario, "La cantidad no puede ser mayor a 32767");
                    e.Cancel = true;
                }
                else
                    errorProvider1.SetError(txtUInventario, "");
            }
        }

        private void txtUPedido_Validating(object sender, CancelEventArgs e)
        {
            if (txtUPedido.Text.Trim() != "")
            {
                if (int.Parse(txtUPedido.Text) > 32767)
                {
                    errorProvider1.SetError(txtUPedido, "La cantidad no puede ser mayor a 32767");
                    e.Cancel = true;
                }
                else
                    errorProvider1.SetError(txtUPedido, "");
            }
        }

        private void txtPPedido_Validating(object sender, CancelEventArgs e)
        {
            if (txtPPedido.Text.Trim() != "")
            {
                if (int.Parse(txtPPedido.Text) > 32767)
                {
                    errorProvider1.SetError(txtPPedido, "La cantidad no puede ser mayor a 32767");
                    e.Cancel = true;
                }
                else
                    errorProvider1.SetError(txtPPedido, "");
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosConPunto(sender, e);
        }

        private void ValidarDigitosSinPunto(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        private void DeshabilitarControles()
        {
            cboCategoria.Enabled = cboProveedor.Enabled = txtProducto.Enabled = txtCantidadxU.Enabled = txtPrecio.Enabled = txtUInventario.Enabled = txtUPedido.Enabled = txtPPedido.Enabled = chkDescontinuado.Enabled = btnAccion.Enabled = false;
        }

        private void HabilitarControles()
        {
            cboCategoria.Enabled = cboProveedor.Enabled = txtProducto.Enabled = txtCantidadxU.Enabled = txtPrecio.Enabled = txtUInventario.Enabled = txtUPedido.Enabled = txtPPedido.Enabled = chkDescontinuado.Enabled =  btnAccion.Enabled = true;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabOperacion.SelectedTab != tbpRegistrar)
            {
                DataGridViewRow dgvr = dgv.CurrentRow;
                txtId.Text = dgvr.Cells["Id"].Value.ToString();
                txtProducto.Text = dgvr.Cells["Producto"].Value.ToString();
                if (dgvr.Cells["Cantidad por unidad"].Value == DBNull.Value)
                    txtCantidadxU.Text = "";
                else
                    txtCantidadxU.Text = dgvr.Cells["Cantidad por unidad"].Value.ToString();
                txtPrecio.Text = dgvr.Cells["Precio"].Value.ToString();
                txtUInventario.Text = dgvr.Cells["Unidades en inventario"].Value.ToString();
                txtUPedido.Text = dgvr.Cells["Unidades en pedido"].Value.ToString();
                txtPPedido.Text = dgvr.Cells["Punto de pedido"].Value.ToString();
                chkDescontinuado.Checked = (bool)dgvr.Cells["Descontinuado"].Value;
                int indexCategoria = cboCategoria.FindStringExact(dgvr.Cells["Categoría"].Value.ToString());
                cboCategoria.SelectedIndex = indexCategoria;
                int indexProveedor = cboProveedor.FindStringExact(dgvr.Cells["Proveedor"].Value.ToString());
                cboProveedor.SelectedIndex = indexProveedor;
                if (tabOperacion.SelectedTab == tbpModificar)
                    HabilitarControles();
                else if (tabOperacion.SelectedTab == tbpEliminar)
                {
                    DeshabilitarControles();
                    btnAccion.Enabled = true;
                }
            }
        }

        private void tabOperacion_Selected(object sender, TabControlEventArgs e)
        {
            if (tabOperacion.SelectedTab == tbpRegistrar)
            {
                if (EventoCargado)
                {
                    dgv.CellClick -= new DataGridViewCellEventHandler(dgv_CellClick);
                    EventoCargado = false;
                }
                btnAccion.Text = "Registrar producto";
                LlenarDgv(null);
                HabilitarControles();
                BorrarDatosBusqueda();
            }
            else
            {
                if (!EventoCargado)
                {
                    dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
                    EventoCargado = true;
                }
                DeshabilitarControles();
                if (tabOperacion.SelectedTab == tbpModificar)
                    btnAccion.Text = "Actualizar producto";
                else
                    btnAccion.Text = "Eliminar producto";
            }
            BorrarDatosProducto();
            BorrarMensajesError();
        }

        private void FrmProductosCrudRdr_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cboCategoria.SelectedIndex != 0 || cboProveedor.SelectedIndex != 0 || txtProducto.Text.Trim() != "" || txtCantidadxU.Text.Trim() != "" || txtPrecio.Text.Trim() != "" || txtUInventario.Text.Trim() != "" || txtUPedido.Text.Trim() != "" || txtPPedido.Text.Trim() !="")
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro de querer cerrar el formulario?, si responde Si, se perderan los datos no guardados", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void FrmProductosCrudRdr_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            int numRegs = 0;
            if (tabOperacion.SelectedTab == tbpRegistrar)
            {
                BorrarMensajesError();
                if (ValidarControles())
                {
                    Utils.ActualizarBarraDeEstado("Actualizando base de datos...", this);
                    DeshabilitarControles();
                    try
                    {
                        Utils.ActualizarBarraDeEstado("Activo", this);
                        SqlCommand cmd = new SqlCommand("Sp_Productos_Insertar", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Categoria", cboCategoria.SelectedValue);
                        cmd.Parameters.AddWithValue("Proveedor", cboProveedor.SelectedValue);
                        cmd.Parameters.AddWithValue("Producto", txtProducto.Text);
                        if (txtCantidadxU.Text.Trim() == "")
                            cmd.Parameters.AddWithValue("Cantidad", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("Cantidad", txtCantidadxU.Text);
                        cmd.Parameters.AddWithValue("Precio", txtPrecio.Text);
                        cmd.Parameters.AddWithValue("UInventario", txtUInventario.Text);
                        cmd.Parameters.AddWithValue("UPedido", txtUPedido.Text);
                        cmd.Parameters.AddWithValue("PPedido", txtPPedido.Text);
                        cmd.Parameters.AddWithValue("Descontinuado", chkDescontinuado.Checked);
                        cmd.Parameters.AddWithValue("Id", 0);
                        cmd.Parameters["Id"].Direction = ParameterDirection.Output;
                        cn.Open();
                        numRegs = cmd.ExecuteNonQuery();
                        if (numRegs > 0)
                        {
                            txtId.Text = cmd.Parameters["Id"].Value.ToString();
                            MessageBox.Show($"El producto con Id: {txtId.Text} y Nombre: {txtProducto.Text} se registró satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"El producto con Id: {txtId.Text} y Nombre: {txtProducto.Text} NO fue registrado en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    HabilitarControles();
                    if (numRegs > 0)
                    {
                        BorrarDatosBusqueda();
                        txtBId.Text = txtId.Text;
                        btnBuscar.PerformClick();
                        btnLimpiar.PerformClick();
                        numRegs = 0;
                    }
                }
            }
            else if (tabOperacion.SelectedTab == tbpModificar)
            {
                BorrarMensajesError();
                if (ValidarControles())
                {
                    Utils.ActualizarBarraDeEstado("Actualizando base de datos...", this);
                    DeshabilitarControles();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Sp_Productos_Actualizar", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Id", txtId.Text);
                        cmd.Parameters.AddWithValue("Categoria", cboCategoria.SelectedValue);
                        cmd.Parameters.AddWithValue("Proveedor", cboProveedor.SelectedValue);
                        cmd.Parameters.AddWithValue("Producto", txtProducto.Text);
                        cmd.Parameters.AddWithValue("Cantidad", txtCantidadxU.Text);
                        cmd.Parameters.AddWithValue("Precio", txtPrecio.Text);
                        cmd.Parameters.AddWithValue("UInventario", txtUInventario.Text);
                        cmd.Parameters.AddWithValue("UPedido", txtUPedido.Text);
                        cmd.Parameters.AddWithValue("PPedido", txtPPedido.Text);
                        cmd.Parameters.AddWithValue("Descontinuado", chkDescontinuado.Checked);
                        cn.Open();
                        numRegs = cmd.ExecuteNonQuery();
                        if (numRegs > 0)
                            MessageBox.Show($"El producto con Id: {txtId.Text} y Nombre: {txtProducto.Text} se actualizó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show($"El producto con Id: {txtId.Text} y Nombre: {txtProducto.Text} NO fue registrado en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (numRegs > 0)
                    {
                        BorrarDatosBusqueda();
                        txtBId.Text = txtId.Text;
                        btnBuscar.PerformClick();
                        btnLimpiar.PerformClick();
                        numRegs = 0;
                    }
                }
            }
            else if(tabOperacion.SelectedTab == tbpEliminar)
            {
                BorrarMensajesError();
                //no valido los controles porque los datos son directamente de la base de datos y en su debido momento ya fueron validados
                DialogResult respuesta = MessageBox.Show($"¿Esta seguro de eliminar el producto con Id: {txtId.Text} y Nombre: {txtProducto.Text}?", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    Utils.ActualizarBarraDeEstado("Actualizando base de datos...", this);
                    DeshabilitarControles();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Sp_Productos_Eliminar", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Id", txtId.Text);
                        cn.Open();
                        numRegs = cmd.ExecuteNonQuery();
                        if (numRegs > 0)
                            MessageBox.Show($"El producto con Id: {txtId.Text} y Nombre: {txtProducto.Text} se eliminó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show($"El producto con Id: {txtId.Text} y Nombre: {txtProducto.Text} NO se eliminó en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (numRegs > 0)
                    {
                        BorrarDatosBusqueda();
                        txtBId.Text = txtId.Text;
                        btnBuscar.PerformClick();
                        btnLimpiar.PerformClick();
                        numRegs = 0;
                    }
                }
                BorrarDatosProducto();
                btnAccion.Enabled = false;
            }
        }
    }
}
