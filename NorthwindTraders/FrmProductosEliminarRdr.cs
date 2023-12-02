using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmProductosEliminarRdr : NorthwindTraders.FrmProductosRegistrarRdr
    {
        public FrmProductosEliminarRdr()
        {
            InitializeComponent();
            nameForm = "FrmProductosEliminarRdr";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            int numRegs = 0;
            DialogResult respuesta = MessageBox.Show($"¿Esta seguro de eliminar el producto con Id: {txtId.Text} y Nombre: {txtProducto.Text}?", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    Utils.ActualizarBarraDeEstado("Actualizando base de datos...", this);
                    SqlCommand cmd = new SqlCommand("Sp_Productos_Eliminar", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Id", txtId.Text);
                    cn.Open();
                    numRegs = cmd.ExecuteNonQuery();
                    if (numRegs > 0)
                    {
                        MessageBox.Show($"El producto con Id: {txtId.Text} y Nombre: {txtProducto.Text} se eliminó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                }

            }
            Utils.ActualizarBarraDeEstado("Activo", this);
            if (numRegs > 0)
            {
                txtBId.Text = txtId.Text;
                txtBProducto.Text = "";
                cboBCategoria.SelectedIndex = cboBProveedor.SelectedIndex = 0;
                btnBuscar.PerformClick();
                btnLimpiar.PerformClick();
                numRegs = 0;
            }
            BorrarDatosProducto();
        }
    }
}
