using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmProductosModificarDap : Form
    {

        protected SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);

        protected bool habilitarConts = true; // esta propiedad es util para que al heredar el formulario al FrmProductosEliminarDap no se habiliten los controles del producto.

        public FrmProductosModificarDap()
        {
            InitializeComponent();
        }

        protected void FrmProductosModificarDap_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                SqlCommand cmd1 = new SqlCommand("Select 0 As IdCategoria, '»--- Seleccione ---«' As Categoria Union All Select CategoryId As IdCategoria, CategoryName As Categoria From Categories Order by Categoria", cn);
                cmd1.CommandType = CommandType.Text;
                SqlDataAdapter dap1 = new SqlDataAdapter(cmd1);
                DataTable tbl1 = new DataTable();
                dap1.Fill(tbl1);
                cboCategoria.DataSource = tbl1;
                cboCategoria.DisplayMember = "Categoria";
                cboCategoria.ValueMember = "IdCategoria";
                DataTable tblBCategoria = tbl1.Clone();
                DataRow dr;
                foreach (DataRow drFila in tbl1.Rows)
                {
                    dr = tblBCategoria.NewRow();
                    dr["IdCategoria"] = Convert.ToInt32(drFila["IdCategoria"]);
                    dr["Categoria"] = drFila["Categoria"];
                    tblBCategoria.Rows.Add(dr);
                }
                cboBCategoria.DataSource = tblBCategoria;
                cboBCategoria.DisplayMember = "Categoria";
                cboBCategoria.ValueMember = "IdCategoria";
                cmd1.CommandText = "Select 0 As IdProveedor, '»--- Seleccione ---«' As Proveedor Union All Select SupplierId As IdProveedor, CompanyName As Proveedor From Suppliers Order by Proveedor";
                dap1 = new SqlDataAdapter(cmd1);
                tbl1 = new DataTable();
                dap1.Fill(tbl1);
                cboProveedor.DataSource = tbl1;
                cboProveedor.DisplayMember = "Proveedor";
                cboProveedor.ValueMember = "IdProveedor";
                DataTable tblBProveedor = tbl1.Clone();
                foreach (DataRow drFila in tbl1.Rows)
                {
                    dr = tblBProveedor.NewRow();
                    dr["IdProveedor"] = drFila["IdProveedor"];
                    dr["Proveedor"] = drFila["Proveedor"];
                    tblBProveedor.Rows.Add(dr);
                }
                cboBProveedor.DataSource = tblBProveedor;
                cboBProveedor.DisplayMember = "Proveedor";
                cboBProveedor.ValueMember = "IdProveedor";
                LlenarDgv(null);
                DeshabilitarControles();
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
            BorrarMensajesError();
            BorrarDatosProducto();
            LlenarDgv(sender);
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBProducto.Text = txtBId.Text = "";
            cboBProveedor.SelectedIndex = cboBCategoria.SelectedIndex = 0;
            DeshabilitarControles();
            BorrarMensajesError();
            BorrarDatosProducto();
        }
        
        protected void LlenarDgv(object sender)
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
                    Utils.ActualizarBarraDeEstado($"Se encontraron: {dgv.Rows.Count} registros", this);
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

        protected void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
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
            if (habilitarConts)
                HabilitarControles();
            else
                DeshabilitarControles();
        }

        protected void HabilitarControles()
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
            btnActualizar.Enabled = true;
        }

        protected void DeshabilitarControles()
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
            btnActualizar.Enabled = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                BorrarMensajesError();
                if (ValidarControles())
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
                    cmd.Parameters.AddWithValue("Descontinuado", chkDescontinuado.Checked);
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

        protected void BorrarDatosProducto()
        {
            BorrarMensajesError();
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

        protected void txtUInventario_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        protected void txtUPedido_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        protected void txtPPedido_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        protected void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosConPunto(sender, e);
        }

        protected void txtUInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        protected void txtUPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        protected void txtPPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
        }

        private void groupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.Black, this);
        }
    }
}
