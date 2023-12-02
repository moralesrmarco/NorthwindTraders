using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmProductosModificarRdr : NorthwindTraders.FrmProductosRegistrarRdr
    {
        public FrmProductosModificarRdr()
        {
            InitializeComponent();
            nameForm = "FrmProductosModificarRdr";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int numRegs = 0;
            BorrarMensajesError();
            if (ValidarControles())
            {
                DeshabilitarControles();
                btnModificar.Enabled = false;
                Utils.ActualizarBarraDeEstado("Actualizando base de datos...", this);
                try
                {
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
                    numRegs = cmd.ExecuteNonQuery();
                    if (numRegs > 0)
                        MessageBox.Show($"El producto con Id: {txtId.Text} y Nombre: {txtProducto.Text} se actualizó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"El producto con Id: {txtId.Text} y Nombre: {txtProducto.Text} NO se actualizó en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtBId.Text = txtId.Text;
                    txtBProducto.Text = "";
                    cboBCategoria.SelectedIndex = 0;
                    cboBProveedor.SelectedIndex = 0;
                    btnBuscar.PerformClick();
                    btnLimpiar.PerformClick();
                    BorrarDatosProducto();
                    numRegs = 0;
                }
            }
        }
    }
}
