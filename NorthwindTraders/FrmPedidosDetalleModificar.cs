using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmPedidosDetalleModificar : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);

        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public short Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal Importe { get; set; }

        public FrmPedidosDetalleModificar()
        {
            InitializeComponent();
        }

        private void FrmPedidosDetalleModificar_Load(object sender, EventArgs e)
        {
            txtProducto.Text = Producto;
            txtPrecio.Text = Precio.ToString("c");
            txtCantidad.Text = Cantidad.ToString("n0");
            txtDescuento.Text = Descuento.ToString("n2");
            txtImporte.Text = Importe.ToString("c");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            BorrarMensajesError();
            if (ValidarControles())
                CalcularImporte();
        }

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            BorrarMensajesError();
            if (ValidarControles())
                CalcularImporte();
        }

        private void CalcularImporte()
        {
            Precio = decimal.Parse(txtPrecio.Text.Replace("$", ""));
            Cantidad = short.Parse(txtCantidad.Text.Replace(",", ""));
            Descuento = decimal.Parse(txtDescuento.Text);
            Importe = (Precio * Cantidad) * (1 - Descuento);
            txtImporte.Text = Importe.ToString("c");
        }

        private bool ValidarControles()
        {
            bool valida = true;
            if (txtCantidad.Text == "" || short.Parse(txtCantidad.Text.Replace(",", "")) == 0)
            {
                valida = false;
                errorProvider1.SetError(txtCantidad, "Ingrese la cantidad");
            }
            if(txtDescuento.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtDescuento, "Ingrese el descuento");

            }
            else
            {
                if (decimal.Parse(txtDescuento.Text) > 1 || decimal.Parse(txtDescuento.Text) < 0)
                {
                    valida = false;
                    errorProvider1.SetError(txtDescuento, "El descuento no puede ser mayor que 1 o menor que 0");
                }
            }
            return valida;
        }

        private void BorrarMensajesError()
        {
            errorProvider1.SetError(txtCantidad, "");
            errorProvider1.SetError(txtDescuento, "");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            byte numRegs = 0;
            BorrarMensajesError();
            if (ValidarControles())
            {
                try
                {
                    btnModificar.Enabled = false;
                    Utils.ActualizarBarraDeEstado("Actualizando la base de datos...", this);
                    SqlCommand cmd = new SqlCommand("Sp_PedidosDetalle_Actualizar", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("OrderId", PedidoId);
                    cmd.Parameters.AddWithValue("ProductId", ProductoId);
                    cmd.Parameters.AddWithValue("Quantity", txtCantidad.Text.Replace(",", ""));
                    cmd.Parameters.AddWithValue("Discount", txtDescuento.Text);
                    cn.Open();
                    numRegs = (byte)cmd.ExecuteNonQuery();
                    if (numRegs == 0)
                        MessageBox.Show("No se pudo realizar la modificación, es posible que el registro se haya eliminado previamente por otro usuario de la red", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
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
