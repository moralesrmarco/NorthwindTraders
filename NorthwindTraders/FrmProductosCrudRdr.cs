using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmProductosCrudRdr : Form
    {

        private SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);

        public FrmProductosCrudRdr()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void txtBId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.ValidarDigitosSinPunto(sender, e);
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
    }
}
