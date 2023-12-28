using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmProductosCrud : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        bool EventoCargado = true; // esta variable es necesaria para controlar el manejador de eventos de la celda del dgv ojo no quitar

        public FrmProductosCrud()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void grbPaint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.Black, this);
        }

        private void FrmProductosCrud_Load(object sender, EventArgs e)
        {
            
            if (EventoCargado)
            {
                dgv.CellClick -= new DataGridViewCellEventHandler(dgvLista_CellClick);
                EventoCargado = false;
            }
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
                DataTable tblBCategoria = tblCategoria.Clone();
                DataRow dr;
                foreach (DataRow dataRow in tblCategoria.Rows)
                {
                    dr = tblBCategoria.NewRow();
                    dr["IdCategoria"] = Convert.ToInt32(dataRow["IdCategoria"]);
                    dr["Categoria"] = dataRow["Categoria"].ToString();
                    tblBCategoria.Rows.Add(dr);
                }
                cboBCategoria.DataSource = tblBCategoria;
                cboBCategoria.DisplayMember = "Categoria";
                cboBCategoria.ValueMember = "IdCategoria";
                cmd = new SqlCommand("Select 0 As IdProveedor, '»--- Seleccione ---«' As Proveedor Union All Select SupplierId As IdProveedor, CompanyName As Proveedor From Suppliers", cn);
                dap = new SqlDataAdapter(cmd);
                DataTable tblProveedor = new DataTable();
                dap.Fill(tblProveedor);
                cboProveedor.DataSource = tblProveedor;
                cboProveedor.DisplayMember = "Proveedor";
                cboProveedor.ValueMember = "IdProveedor";
                DataTable tblBProveedor = tblProveedor.Clone();
                DataRow dr1;
                foreach (DataRow dataRow1 in tblProveedor.Rows)
                {
                    dr1 = tblBProveedor.NewRow();
                    dr1["IdProveedor"] = Convert.ToInt32(dataRow1["IdProveedor"]);
                    dr1["Proveedor"] = dataRow1["Proveedor"].ToString();
                    tblBProveedor.Rows.Add(dr1);
                }
                cboBProveedor.DataSource = tblBProveedor;
                cboBProveedor.DisplayMember = "Proveedor";
                cboBProveedor.ValueMember = "IdProveedor";
                LlenarDgvLista(null);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBId.Text = "";
            txtBNombre.Text = "";
            cboBCategoria.SelectedIndex = 0;
            cboBProveedor.SelectedIndex = 0;

            BorrarMensajesError();
            BorrarDatosProducto();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BorrarMensajesError();
            BorrarDatosProducto();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
            LlenarDgvLista(sender);
        }

        private void LlenarDgvLista(object sender)
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                SqlCommand cmd;
                if (sender == null)
                {
                    cmd = new SqlCommand("SP_Productos_All", cn);
                }
                else
                {
                    cmd = new SqlCommand("Sp_Productos_Buscar", cn);
                    cmd.Parameters.AddWithValue("Id", txtBId.Text);
                    cmd.Parameters.AddWithValue("Producto", txtBNombre.Text);
                    cmd.Parameters.AddWithValue("Categoria", cboBCategoria.SelectedValue);
                    cmd.Parameters.AddWithValue("Proveedor", cboBProveedor.SelectedValue);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dap;
                dap = new SqlDataAdapter(cmd);
                DataTable tblProductos = new DataTable();
                dap.Fill(tblProductos);
                dgv.DataSource = tblProductos;
                Utils.ConfDataGridView(dgv);
                Utils.ConfDgvProductos(dgv);
                if (sender == null)
                    Utils.ActualizarBarraDeEstado("Se muestran los últimos 20 productos registrados", this);
                else
                    Utils.ActualizarBarraDeEstado($"Se encontraron: {tblProductos.Rows.Count} registros", this);
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

        private void btnAccion_Click(object sender, EventArgs e)
        {
            if (tabcOperacion.SelectedTab == tbpRegistrar)
            {
                BorrarMensajesError();
                if (ValidarControles())
                {
                    try
                    {
                        Utils.ActualizarBarraDeEstado("Actualizando base de datos...", this);
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
                        cmd.Parameters.AddWithValue("Descontinuado", chkbDescontinuado.Checked);
                        cmd.Parameters.AddWithValue("Id", 0);
                        cmd.Parameters["Id"].Direction = ParameterDirection.Output;
                        cn.Open();
                        int numRegs = cmd.ExecuteNonQuery();
                        if (numRegs > 0)
                        {
                            txtId.Text = cmd.Parameters["Id"].Value.ToString();
                            MessageBox.Show($"El producto con Id: {txtId.Text} y Nombre: {txtProducto.Text} se registró satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BorrarDatosProducto();
                            LlenarDgvLista(null);
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
            }
            else if(tabcOperacion.SelectedTab == tbpModificar)
            {
                BorrarMensajesError();
                if (ValidarControles())
                {
                    try
                    {
                        DeshabilitarControles();
                        Utils.ActualizarBarraDeEstado("Actualizando base de datos...", this);
                        SqlCommand cmd = new SqlCommand("Sp_Productos_Actualizar", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Id", txtId.Text);
                        cmd.Parameters.AddWithValue("Producto", txtProducto.Text);
                        cmd.Parameters.AddWithValue("Proveedor", cboProveedor.SelectedValue);
                        cmd.Parameters.AddWithValue("Categoria", cboCategoria.SelectedValue);
                        cmd.Parameters.AddWithValue("Cantidad", txtCantidadxU.Text);
                        cmd.Parameters.AddWithValue("Precio", txtPrecio.Text);
                        cmd.Parameters.AddWithValue("UInventario", txtUInventario.Text);
                        cmd.Parameters.AddWithValue("UPedido", txtUPedido.Text);
                        cmd.Parameters.AddWithValue("PPedido", txtPPedido.Text);
                        cmd.Parameters.AddWithValue("Descontinuado", chkbDescontinuado.Checked);
                        cn.Open();
                        int numRegs = cmd.ExecuteNonQuery();
                        if (numRegs > 0)
                        {
                            MessageBox.Show($"El producto con Id: {txtId.Text} y Nombre: {txtProducto.Text} se actualizó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtBId.Text = txtId.Text;
                            btnBuscar.PerformClick();
                            BorrarDatosProducto();
                            btnLimpiar.PerformClick();
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
            }
            else if (tabcOperacion.SelectedTab == tbpEliminar)
            {
                try
                {
                    DialogResult respuesta = MessageBox.Show($"¿Esta seguro de eliminar el producto con Id: {txtId.Text} y Nombre: {txtProducto.Text}?", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.Yes)
                    {
                        Utils.ActualizarBarraDeEstado("Actualizando base de datos...", this);
                        SqlCommand cmd = new SqlCommand("Sp_Productos_Eliminar", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Id", txtId.Text);
                        cn.Open();
                        int numRegs = cmd.ExecuteNonQuery();
                        if (numRegs > 0)
                        {
                            MessageBox.Show($"El producto con Id: {txtId.Text} y Nombre: {txtProducto.Text} se eliminó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtBId.Text = txtId.Text;
                            btnBuscar.PerformClick();
                            btnLimpiar.PerformClick();
                            DeshabilitarControles();
                        }
                    }
                    BorrarDatosProducto();
                    btnOperacion.Enabled = false;
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

        private bool ValidarControles()
        {
            bool validacion = true;
            if (cboCategoria.SelectedIndex == 0 || cboCategoria.SelectedIndex == -1)
            {
                validacion = false;
                errorProvider1.SetError(cboCategoria, "Seleccione una categoría");
            }
            if (cboProveedor.SelectedIndex == 0 || cboProveedor.SelectedIndex == -1)
            {
                validacion = false;
                errorProvider1.SetError(cboProveedor, "Seleccione un proveedor");
            }
            if (txtProducto.Text.Trim() == "")
            {
                validacion = false;
                errorProvider1.SetError(txtProducto, "Ingrese producto");
            }
            if (txtPrecio.Text.Trim() == "")
            {
                validacion = false;
                errorProvider1.SetError(txtPrecio, "Ingrese precio");
            }
            if (txtUInventario.Text.Trim() == "")
            {
                validacion = false;
                errorProvider1.SetError(txtUInventario, "Ingrese unidades en inventario");
            }
            if (txtUPedido.Text.Trim() == "")
            {
                validacion = false;
                errorProvider1.SetError(txtUPedido, "Ingrese unidades en pedido");
            }
            if (txtPPedido.Text.Trim() == "")
            {
                validacion = false;
                errorProvider1.SetError(txtPPedido, "Ingrese punto de pedido");
            }
            return validacion;
        }

        private void txtUInventario_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void txtUPedido_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void txtPPedido_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void txtUInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        private void txtUPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        private void txtPPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        private void BorrarDatosProducto()
        {
            BorrarMensajesError();
            txtId.Text = "";
            txtProducto.Text = "";
            txtCantidadxU.Text = "";
            txtPrecio.Text = "";
            txtUInventario.Text = "";
            txtUPedido.Text = "";
            txtPPedido.Text = "";
            chkbDescontinuado.Checked = false;
            cboCategoria.SelectedIndex = 0;
            cboProveedor.SelectedIndex = 0;
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvrFila = dgv.CurrentRow;
            txtId.Text = Convert.ToInt32(dgvrFila.Cells["Id"].Value).ToString();
            txtProducto.Text = dgvrFila.Cells["Producto"].Value.ToString();
            if (dgvrFila.Cells["Cantidad por unidad"].Value == DBNull.Value)
                txtCantidadxU.Text = "";
            else
                txtCantidadxU.Text = dgvrFila.Cells["Cantidad por unidad"].Value.ToString();
            txtPrecio.Text = dgvrFila.Cells["Precio"].Value.ToString();
            txtUInventario.Text = dgvrFila.Cells["Unidades en inventario"].Value.ToString();
            txtUPedido.Text = dgvrFila.Cells["Unidades en pedido"].Value.ToString();
            txtPPedido.Text = dgvrFila.Cells["Punto de pedido"].Value.ToString();
            chkbDescontinuado.Checked = (bool)dgvrFila.Cells["Descontinuado"].Value;
            int indexCategoria = cboCategoria.FindStringExact(dgvrFila.Cells["Categoría"].Value.ToString());
            cboCategoria.SelectedIndex = indexCategoria;
            int indexProveedor = cboProveedor.FindStringExact(dgvrFila.Cells["Proveedor"].Value.ToString());
            cboProveedor.SelectedIndex = indexProveedor;
            if (tabcOperacion.SelectedTab == tbpModificar)
                HabilitarControles();
            else if (tabcOperacion.SelectedTab == tbpEliminar)
            {
                DeshabilitarControles();
                btnOperacion.Enabled = true;
            }
        }

        private void tabOperacion_Selected(object sender, TabControlEventArgs e)
        {
            if (tabcOperacion.SelectedTab == tbpRegistrar)
            {
                if (EventoCargado)
                {
                    dgv.CellClick -= new DataGridViewCellEventHandler(dgvLista_CellClick);
                    EventoCargado = false;
                }
                btnOperacion.Text = "Registrar producto";
                BorrarDatosProducto();
                LlenarDgvLista(null);
                HabilitarControles();
            }
            else if (tabcOperacion.SelectedTab == tbpModificar)
            {
                if (!EventoCargado)
                {
                    dgv.CellClick += new DataGridViewCellEventHandler(dgvLista_CellClick);
                    EventoCargado = true;
                }
                btnOperacion.Text = "Actualizar producto";
                BorrarDatosProducto();
                DeshabilitarControles(); 
            }
            else if (tabcOperacion.SelectedTab == tbpEliminar)
            {
                if (!EventoCargado)
                {
                    dgv.CellClick += new DataGridViewCellEventHandler(dgvLista_CellClick);
                    EventoCargado = true;
                }
                btnOperacion.Text = "Eliminar producto";
                BorrarDatosProducto();
                DeshabilitarControles();
            }
        }

        private void HabilitarControles()
        {
            txtProducto.Enabled = true;
            txtCantidadxU.Enabled = true;
            txtPrecio.Enabled = true;
            txtUInventario.Enabled = true;
            txtUPedido.Enabled = true;
            txtPPedido.Enabled = true;
            chkbDescontinuado.Enabled = true;
            cboCategoria.Enabled = true;
            cboProveedor.Enabled = true;
            btnOperacion.Enabled = true;
        }

        private void DeshabilitarControles()
        {
            txtProducto.Enabled = false;
            txtCantidadxU.Enabled = false;
            txtPrecio.Enabled = false;
            txtUInventario.Enabled = false;
            txtUPedido.Enabled = false;
            txtPPedido.Enabled = false;
            chkbDescontinuado.Enabled = false;
            cboCategoria.Enabled = false;
            cboProveedor.Enabled = false;
            btnOperacion.Enabled = false;
        }

        private void FrmProductosCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cboCategoria.SelectedIndex != 0 || cboProveedor.SelectedIndex != 0 || txtProducto.Text.Trim() != "" || txtCantidadxU.Text.Trim() != "" || txtPrecio.Text.Trim() != "" || txtUInventario.Text.Trim() != "" || txtUPedido.Text.Trim() != "" || txtPPedido.Text.Trim() != "")
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro de querer cerrar el formulario?, si responde Si, se perderan los datos no guardados", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void FrmProductosCrud_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void txtBId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

    }
}
