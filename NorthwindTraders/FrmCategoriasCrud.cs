using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmCategoriasCrud : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        bool EventoCargado = true; // esta variable es necesaria para controlar el manejador de eventos de la celda del dgv, ojo no quitar
        OpenFileDialog openFileDialog;

        public FrmCategoriasCrud()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void grb_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.Black, this);
        }

        private void FrmCategoriasCrud_Load(object sender, EventArgs e)
        {
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
                    cmd = new SqlCommand("Sp_Categorias_Listar", cn);
                    cmd.Parameters.AddWithValue("top100", 0);
                }
                else
                {
                    cmd = new SqlCommand("Sp_Categorias_Buscar", cn);
                    cmd.Parameters.AddWithValue("Id", txtBId.Text);
                    cmd.Parameters.AddWithValue("Categoria", txtBCategoria.Text);
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
                dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv.Columns["Categoría"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv.Columns["Foto"].Width = 50;
                dgv.Columns["Foto"].DefaultCellStyle.Padding = new Padding(4, 4, 4, 4);
                ((DataGridViewImageColumn)dgv.Columns["Foto"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                if (sender == null)
                    Utils.ActualizarBarraDeEstado("Se muestran las últimas 20 categorías registradas", this);
                else
                    Utils.ActualizarBarraDeEstado($"Se encontraron {dgv.RowCount} registros", this);
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

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabcOperacion.SelectedTab != tbpRegistrar)
            {
                DataGridViewRow dgvr = dgv.CurrentRow;
                txtId.Text = dgvr.Cells["Id"].Value.ToString();
                txtCategoria.Text = dgvr.Cells["Categoría"].Value.ToString();
                txtDescripcion.Text = dgvr.Cells["Descripción"].Value.ToString();
                if (dgvr.Cells["Foto"].Value != DBNull.Value)
                {
                    byte[] foto = (byte[])dgvr.Cells["Foto"].Value;
                    MemoryStream ms;
                    if (int.Parse(txtId.Text) <= 8)
                    {
                        ms = new MemoryStream(foto, 78, foto.Length - 78);
                    }
                    else
                    {
                        ms = new MemoryStream(foto);
                    }

                    picFoto.Image = Image.FromStream(ms);
                }
                else
                    picFoto.Image = null;
                DeshabilitarControles();
                if (tabcOperacion.SelectedTab == tbpListar)
                {
                    btnCargar.Visible = false;
                    btnOperacion.Enabled = false;
                }
                else if (tabcOperacion.SelectedTab == tbpModificar)
                {
                    HabilitarControles();
                    btnOperacion.Enabled = true;
                    btnCargar.Visible = true;
                    btnCargar.Enabled = true;
                }
                else if (tabcOperacion.SelectedTab == tbpEliminar)
                {
                    btnOperacion.Enabled = true;
                    btnCargar.Visible = false;
                }
            } 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BorrarMensajesError();
            BorrarDatosCategoria();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
            LlenarDgv(sender);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            BorrarDatosBusqueda();
            BorrarDatosCategoria();
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab != tbpRegistrar)
                DeshabilitarControles();
        }

        private void BorrarDatosBusqueda()
        {
            txtBCategoria.Text = txtBId.Text = "";
        }

        private void BorrarDatosCategoria()
        {
            txtCategoria.Text = txtDescripcion.Text = txtId.Text = "";
            picFoto.Image = null;
        }

        private void DeshabilitarControles()
        {
            txtCategoria.ReadOnly = txtDescripcion.ReadOnly = true;
            picFoto.Enabled = false;
        }

        private void HabilitarControles()
        {
            txtCategoria.ReadOnly = txtDescripcion.ReadOnly = false;
            picFoto.Enabled = true;
        }

        private void BorrarMensajesError()
        {
            errorProvider1.SetError(txtCategoria, "");
            errorProvider1.SetError(txtDescripcion, "");
            errorProvider1.SetError(btnCargar, "");
        }

        private bool ValidarControles()
        {
            bool valida = true;
            if (txtCategoria.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtCategoria, "Ingrese la categoría");
            }
            if (txtDescripcion.Text == "")
            {
                valida = false;
                errorProvider1.SetError(txtDescripcion, "Ingrese la descripción");
            }
            if (picFoto.Image == null)
            {
                valida = false;
                errorProvider1.SetError(btnCargar, "Ingrese la imagen");
            }
            return valida;
        }

        private void tabcOperacion_Selected(object sender, TabControlEventArgs e)
        {
            BorrarDatosCategoria();
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab == tbpRegistrar)
            {
                if (EventoCargado)
                {
                    dgv.CellClick -= new DataGridViewCellEventHandler(dgv_CellClick);
                    EventoCargado = false;
                }
                BorrarDatosBusqueda();
                HabilitarControles();
                btnOperacion.Text = "Registrar categoría";
                btnOperacion.Visible = true;
                btnOperacion.Enabled = true;
                btnCargar.Visible = true;
                btnCargar.Enabled = true;
                LlenarDgv(null);
            }
            else
            {
                if (!EventoCargado)
                {
                    dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
                    EventoCargado = true;
                }
                DeshabilitarControles();
                if (tabcOperacion.SelectedTab == tbpListar)
                {
                    btnOperacion.Enabled = false;
                    btnOperacion.Visible = false;
                    btnCargar.Visible = false;
                    btnCargar.Enabled = false;
                } 
                else if (tabcOperacion.SelectedTab == tbpModificar)
                {
                    btnOperacion.Text = "Actualizar categoría";
                    btnOperacion.Enabled = false;
                    btnOperacion.Visible = true;
                    btnCargar.Visible = true;
                    btnCargar.Enabled = false;
                } 
                else if (tabcOperacion.SelectedTab == tbpEliminar)
                {
                    btnOperacion.Text = "Eliminar categoría";
                    btnOperacion.Enabled = false;
                    btnOperacion.Visible = true;
                    btnCargar.Visible = false;
                    btnCargar.Enabled = false;
                }
            }
        }

        private void btnOperacion_Click(object sender, EventArgs e)
        {
            int numRegs = 0;
            BorrarMensajesError();
            if (tabcOperacion.SelectedTab == tbpRegistrar)
            {
                if (ValidarControles())
                {
                    Utils.ActualizarBarraDeEstado("Actualizando la base de datos...", this);
                    DeshabilitarControles();
                    btnOperacion.Enabled = false;
                    btnCargar.Enabled = false;
                    byte[] fileFoto = null;
                    Stream stream = openFileDialog.OpenFile();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        fileFoto = ms.ToArray();
                    }
                    // La siguiente forma no me gusto por que es forzoso solo formato jpeg
                    //MemoryStream ms = new MemoryStream();
                    //picFoto.Image.Save(ms, ImageFormat.Jpeg);
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Sp_Categorias_Insertar", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Categoria", txtCategoria.Text);
                        cmd.Parameters.AddWithValue("Descripcion", txtDescripcion.Text);
                        //cmd.Parameters.AddWithValue("Foto", ms.GetBuffer());
                        cmd.Parameters.AddWithValue("Foto", fileFoto);
                        cmd.Parameters.AddWithValue("Id", 0);
                        cmd.Parameters["Id"].Direction = ParameterDirection.Output;
                        cn.Open();
                        numRegs = cmd.ExecuteNonQuery();
                        if (numRegs > 0)
                        {
                            txtId.Text = cmd.Parameters["Id"].Value.ToString();
                            MessageBox.Show($"La categoría con Id: {txtId.Text} y Nombre: {txtCategoria.Text} se registró satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"La categoría con Id:  {txtId.Text}  y Nombre:  {txtCategoria .Text} NO fue registrada en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    btnOperacion.Enabled = true;
                    btnCargar.Enabled = true;
                    if (numRegs > 0)
                    {
                        BorrarDatosBusqueda();
                        txtBId.Text = txtId.Text;
                        btnBuscar.PerformClick();
                        btnLimpiar.PerformClick();
                    }
                    Utils.ActualizarBarraDeEstado("Activo", this);
                }
            }
            else if (tabcOperacion.SelectedTab == tbpModificar)
            {
                if (ValidarControles())
                {
                    Utils.ActualizarBarraDeEstado("Actualizando la base de datos...", this);
                    DeshabilitarControles();
                    btnOperacion.Enabled = false;
                    btnCargar.Enabled = false;
                    byte[] fileFoto = null;
                    Stream stream = openFileDialog.OpenFile();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        fileFoto = ms.ToArray();
                    }
                    // La siguiente forma no me gusto por que es forzoso solo formato jpeg
                    //MemoryStream ms = new MemoryStream();
                    //picFoto.Image.Save(ms, ImageFormat.Jpeg);
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Sp_Categorias_Actualizar", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Id", txtId.Text);
                        cmd.Parameters.AddWithValue("Categoria", txtCategoria.Text);
                        cmd.Parameters.AddWithValue("Descripcion", txtDescripcion.Text);
                        cmd.Parameters.AddWithValue("Foto", fileFoto);
                        //cmd.Parameters.AddWithValue("Foto", ms.GetBuffer());
                        cn.Open();
                        numRegs = cmd.ExecuteNonQuery();
                        if (numRegs > 0)
                            MessageBox.Show($"La categoría con Id: {txtId.Text} y Nombre: {txtCategoria.Text} se actualizó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show($"La categoría con Id: {txtId.Text} y Nombre: {txtCategoria.Text} NO fue registrado en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    }
                }
            }
            else if (tabcOperacion.SelectedTab == tbpEliminar)
            {
                //no valido los controles porque los datos son directamente de la base de datos y en su debido momento ya fueron validados
                DialogResult respuesta = MessageBox.Show($"¿Esta seguro de eliminar la categoría con Id: {txtId.Text} y Nombre: {txtCategoria.Text}?", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    btnOperacion.Enabled = false;
                    Utils.ActualizarBarraDeEstado("Actualizando la base de datos...", this);
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Sp_Categorias_Eliminar", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Id", txtId.Text);
                        cn.Open();
                        numRegs = cmd.ExecuteNonQuery();
                        if (numRegs > 0)
                            MessageBox.Show($"La categoría con Id: {txtId.Text} y Nombre: {txtCategoria.Text} se eliminó satisfactoriamente", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show($"La categoría con Id: {txtId.Text} y Nombre: {txtCategoria.Text} NO se eliminó en la base de datos", "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    }
                }
                BorrarDatosCategoria();
                btnOperacion.Enabled = false;
            }
        }

        private void FrmCategoriasCrud_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void FrmCategoriasCrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tabcOperacion.SelectedTab != tbpListar)
            {
                if (txtId.Text.Trim() != "" || txtCategoria.Text.Trim() != "" || txtDescripcion.Text.Trim() != "" || picFoto.Image != null)
                {
                    DialogResult respuesta = MessageBox.Show("¿Esta seguro de querer cerrar el formulario?, si responde Si, se perderan los datos no guardados", "Northwind Traders", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.No)
                        e.Cancel = true;
                }
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Mostrar el cuadro de diálogo OpenFileDialog
            //La instrucción siguiente es para que nos muestre todos los tipos juntos
            openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.InitialDirectory = "c:\\Imágenes\\";
            //La instrucción siguiente es para que nos muestre varias filas en el openfiledialog que nos permita abrir por un tipo especifico
            openFileDialog.Filter = "Archivos jpg (*.jpg)|*.jpg|Archivos jpeg (*.jpeg)|*.jpeg|Archivos png (*.png)|*.png|Archivos bmp (*.bmp)|*.bmp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Cargar la imagen seleccionada en un objeto Image
                Image image = Image.FromFile(openFileDialog.FileName);

                // Mostrar la imagen en un control PictureBox
                picFoto.Image = image;
                errorProvider1.SetError(btnCargar, "");
            }
        }
    }
}
