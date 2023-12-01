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
    public partial class FrmProductosRegistrarRdr : Form
    {

        protected SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);

        public FrmProductosRegistrarRdr()
        {
            InitializeComponent();
        }

        protected void FrmProductosRegistrarRdr_Load(object sender, EventArgs e)
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
                LlenarDgv(null);
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
                    cmd.Parameters.AddWithValue("Producto", txtProducto.Text);
                    cmd.Parameters.AddWithValue("Categoria", cboBCategoria.SelectedValue);
                    cmd.Parameters.AddWithValue("Proveedor", cboBProveedor.SelectedValue);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleResult);
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

        private void groupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;
            Utils.DrawGroupBox(groupBox, e.Graphics, Color.Black, Color.Black, this);
        }
    }
}
