using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmProductosEliminarDap : NorthwindTraders.FrmProductosModificarDap
    {

        //SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);

        public FrmProductosEliminarDap()
        {
            InitializeComponent();
        }

        private void FrmProductosEliminarDap_Load(object sender, EventArgs e)
        {
            habilitarConts = false; // es necesario para que se deshabiliten los controles heredados
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione un producto", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            DialogResult respuesta = MessageBox.Show($"¿Esta seguro de eliminar el producto con Id: {txtId.Text} y Nombre: {txtProducto.Text}?", "Northwind Traiders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                try
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
                    BorrarDatosProducto();
                }
            }
            else
                BorrarDatosProducto();
        }
    }
}
