using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmProductosRegistrarDap : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);

        public FrmProductosRegistrarDap()
        {
            InitializeComponent();
        }

        private void FrmProductosRegistrarDap_Load(object sender, EventArgs e)
        {
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
                cmd.CommandText = "Select 0 As IdProveedor, '»--- Seleccione ---«' As Proveedor Union All Select SupplierId As IdProveedor, CompanyName As Proveedor From Suppliers";
                dap = new SqlDataAdapter(cmd);
                DataTable tblProveedor = new DataTable();
                dap.Fill(tblProveedor);
                cboProveedor.DataSource = tblProveedor;
                cboProveedor.DisplayMember = "Proveedor";
                cboProveedor.ValueMember = "IdProveedor";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error con la base de datos: " + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
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
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ocurrio un error con la base de datos: " + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error: " + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.Close();
                    Utils.ActualizarBarraDeEstado("Activo", this);
                }
            }
        }

        private bool ValidarControles()
        {
            bool validacion = true;
            if (cboCategoria.SelectedIndex == 0)
            {
                validacion = false;
                errorProvider1.SetError(cboCategoria, "Seleccione una categoría");
            }
            if (cboProveedor.SelectedIndex == 0)
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
    }
}

/*
USE[Northwind]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_PRODUCTOS_INSERTAR]

    @Categoria INT,
    @Proveedor INT,
    @Producto NVARCHAR(40),
	@Cantidad NVARCHAR(20),
	@Precio MONEY,
    @UInventario SMALLINT,
    @UPedido SMALLINT,
    @PPedido SMALLINT,
    @Descontinuado BIT,
    @Id INT OUTPUT
as
	INSERT INTO Products
	(ProductName, SupplierId, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
	VALUES(@Producto, @Proveedor, @Categoria, @Cantidad, @Precio, @UInventario, @UPedido, @PPedido, @Descontinuado)


    SET @Id = @@IDENTITY

*/