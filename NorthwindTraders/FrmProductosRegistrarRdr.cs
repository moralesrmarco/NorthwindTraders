using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmProductosRegistrarRdr : Form
    {

        protected SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        protected string nameForm = "FrmProductosRegistrarRdr";

        public FrmProductosRegistrarRdr()
        {
            InitializeComponent();
        }

        private void FrmProductosRegistrarRdr_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                SqlCommand cmd = new SqlCommand("Select 0 As IdCategoria, '»--- Seleccione ---«' As Categoria Union All Select CategoryId As IdCategoria, CategoryName As Categoria From Categories Order By Categoria", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                DataTable tblBCategoria = new DataTable();
                tblBCategoria.TableName = "tblBCategoria";
                DataColumn dc;
                dc = new DataColumn("IdCategoria", Type.GetType("System.Int32"));
                tblBCategoria.Columns.Add(dc);
                dc = new DataColumn("Categoria", Type.GetType("System.String"));
                tblBCategoria.Columns.Add(dc);
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
                rdr.Close();
                cboBCategoria.DataSource = tblBCategoria;
                cboBCategoria.DisplayMember = "Categoria";
                cboBCategoria.ValueMember = "IdCategoria";
                cboCategoria.DataSource = tblCategoria;
                cboCategoria.DisplayMember = "Categoria";
                cboCategoria.ValueMember = "IdCategoria";
                cmd = null;
                cmd = new SqlCommand("Select 0 As IdProveedor, '»--- Seleccione ---«' As Proveedor Union All Select SupplierId As IdProveedor, CompanyName As Proveedor From Suppliers Order By Proveedor", cn);
                cmd.CommandType = CommandType.Text;
                rdr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                DataTable tblBProveedor = new DataTable();
                tblBProveedor.TableName = "tblBProveedor";
                dc = new DataColumn("IdProveedor", Type.GetType("System.Int32"));
                tblBProveedor.Columns.Add(dc);
                dc = new DataColumn("Proveedor", Type.GetType("System.String"));
                tblBProveedor.Columns.Add(dc);
                DataTable tblProveedor = tblBProveedor.Clone();
                tblProveedor.TableName = "tblProveedor";
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
                rdr.Close();
                cboBProveedor.DataSource = tblBProveedor;
                cboBProveedor.DisplayMember = "Proveedor";
                cboBProveedor.ValueMember = "IdProveedor";
                cboProveedor.DataSource = tblProveedor;
                cboProveedor.DisplayMember = "Proveedor";
                cboProveedor.ValueMember = "IdProveedor";
                if (nameForm != "FrmProductosRegistrarRdr")
                {
                    lblBusque.Visible = true;
                    DeshabilitarControles();
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
            LlenarDgv(null);
        }

        private void LlenarDgv(object sender)
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
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
                    Utils.ActualizarBarraDeEstado("No se encontraron registros con el criterio de buqueda proporcionado", this, true);
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

        private void groupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.Black, this);
        }

        protected void BorrarDatosProducto()
        {
            txtId.Text = "";
            txtProducto.Text = "";
            txtCantidadxU.Text = "";
            txtPrecio.Text = "";
            txtUInventario.Text = "";
            txtUPedido.Text = "";
            txtPPedido.Text = "";
            chkDescontinuado.Checked = false;
            cboCategoria.SelectedIndex = 0;
            cboProveedor.SelectedIndex = 0;
        }

        protected bool ValidarControles()
        {
            bool validacion = true;
            if (nameForm != "FrmProductosEliminarRdr")
            {
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
            }
            return validacion;
        }

        protected void BorrarMensajesError()
        {
            errorProvider1.SetError(cboCategoria, "");
            errorProvider1.SetError(cboProveedor, "");
            errorProvider1.SetError(txtProducto, "");
            errorProvider1.SetError(txtPrecio, "");
            errorProvider1.SetError(txtUInventario, "");
            errorProvider1.SetError(txtUPedido, "");
            errorProvider1.SetError(txtPPedido, "");
        }

        private void HabilitarControles()
        {
            txtProducto.Enabled = true;
            cboCategoria.Enabled = true;
            cboProveedor.Enabled = true;
            txtCantidadxU.Enabled = true;
            txtPrecio.Enabled = true;
            txtUInventario.Enabled = true;
            txtUPedido.Enabled = true;
            txtPPedido.Enabled = true;
            chkDescontinuado.Enabled = true;
        }

        protected void DeshabilitarControles()
        {

            if (nameForm != "FrmProductosRegistrarRdr")
            {
                txtProducto.Enabled = false;
                cboCategoria.Enabled = false;
                cboProveedor.Enabled = false;
                txtCantidadxU.Enabled = false;
                txtPrecio.Enabled = false;
                txtUInventario.Enabled = false;
                txtUPedido.Enabled = false;
                txtPPedido.Enabled = false;
                chkDescontinuado.Enabled = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (nameForm == "FrmProductosModificarRdr")
                btnModificar.Enabled = false;
            else if (nameForm == "FrmProductosEliminarRdr")
                btnEliminar.Enabled = false;
            BorrarMensajesError();
            DeshabilitarControles();
            BorrarDatosProducto();
            LlenarDgv(sender);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBProducto.Text = txtBId.Text = "";
            cboBProveedor.SelectedIndex = cboBCategoria.SelectedIndex = 0;
            DeshabilitarControles();
            BorrarMensajesError();
            BorrarDatosProducto();

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (nameForm != "FrmProductosRegistrarRdr")
            {
                BorrarMensajesError();
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
                if (nameForm == "FrmProductosModificarRdr")
                {
                    HabilitarControles();
                    btnModificar.Enabled = true;
                }
                else if (nameForm == "FrmProductosEliminarRdr")
                {
                    DeshabilitarControles();
                    btnEliminar.Enabled = true;
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int numRegs = 0;
            try
            {
                BorrarMensajesError();
                if (ValidarControles())
                {
                    btnRegistrar.Enabled = false;
                    DeshabilitarControles();
                    Utils.ActualizarBarraDeEstado("Actualizando base de datos...", this);
                    SqlCommand cmd = new SqlCommand("Sp_Productos_Insertar", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Categoria", cboCategoria.SelectedValue);
                    cmd.Parameters.AddWithValue("Proveedor", cboProveedor.SelectedValue);
                    cmd.Parameters.AddWithValue("Producto", txtProducto.Text);
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
                    txtId.Text = cmd.Parameters["Id"].Value.ToString();
                    if (numRegs > 0)
                        MessageBox.Show($"El producto con Id: {txtId.Text} y Nombre: {txtProducto.Text} se registró satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"El producto con Id: {txtId.Text} y Nombre: {txtProducto.Text} NO fue registrado en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (numRegs > 0)
            {
                txtBId.Text = txtId.Text;
                txtBProducto.Text = "";
                cboBCategoria.SelectedIndex = 0;
                cboBProveedor.SelectedIndex = 0;
                btnBuscar.PerformClick();
                BorrarDatosProducto();
                btnLimpiar.PerformClick();
                btnRegistrar.Enabled = true;
                HabilitarControles();
                numRegs = 0;
            }
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

        private void FrmProductosRegistrarRdr_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cboCategoria.SelectedIndex != 0 || cboProveedor.SelectedIndex != 0 || txtProducto.Text.Trim() != "" || txtCantidadxU.Text.Trim() != "" || txtPrecio.Text.Trim() != "" || txtUInventario.Text.Trim() != "" || txtUPedido.Text.Trim() != "" || txtPPedido.Text.Trim() != "")
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro de querer cerrar el formulario?, si responde Si se perderan los datos no guardados", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void FrmProductosRegistrarRdr_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void txtBId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender , e);
        }
    }
}
