using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmPedidosxClienteDetalle : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        static string clienteId;
        static int pedidoId;

        public FrmPedidosxClienteDetalle()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void GrbPaint(object sender, PaintEventArgs e)
        {
            Utils.GrbPaint(sender, e, this);
        }

        private void FrmPedidosxClienteDetalle_Load(object sender, EventArgs e)
        {
            Utils.ConfDataGridView(DgvClientes);
            Utils.ConfDataGridView(DgvPedidos);
            Utils.ConfDataGridView(DgvDetalle);
            DgvClientes.SelectionChanged -= new EventHandler(DgvClientes_SelectionChanged);
            LlenarDgvClientes();
            DgvClientes.SelectionChanged += new EventHandler(DgvClientes_SelectionChanged);
            ConfDgvClientes();
            LlenarDgvPedidos();
            ConfDgvPedidos();
            LlenarDgvDetalle();
            ConfDgvDetalle();
        }

        private void LlenarDgvClientes()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                SqlCommand cmd = new SqlCommand("Select CustomerID As [Id], CompanyName As [Nombre de compañia], ContactName As [Nombre de Contacto], Address As Domicilio, City As Ciudad, Phone As Teléfono, Fax from Customers", cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                DgvClientes.DataSource = dt;
                Utils.ActualizarBarraDeEstado($"Se encontraron {DgvClientes.RowCount} registros de clientes", this);
                clienteId = DgvClientes.CurrentRow.Cells["Id"].Value.ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error con la base de datos: \n" + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: \n" + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
        }

        private void ConfDgvClientes()
        {
            DgvClientes.Columns["Id"].Visible = false;
            DgvClientes.Columns["Teléfono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvClientes.Columns["Fax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void LlenarDgvPedidos()
        {
            try
            {
                //clienteId = DgvClientes.CurrentRow.Cells["Id"].Value.ToString();
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                SqlCommand cmd = new SqlCommand($"SELECT Orders.OrderID AS Pedido, Orders.CustomerID AS Cliente, Orders.EmployeeID AS IdEmpleado, Customers.CompanyName AS [Nombre cliente], Employees.FirstName + N' ' + Employees.LastName AS Vendedor, Orders.OrderDate AS [Fecha de pedido], Orders.RequiredDate AS [Fecha requerido], Orders.ShippedDate AS [Fecha de envío], SUM(CONVERT(money, ([Order Details].UnitPrice * [Order Details].Quantity) * (1 - [Order Details].Discount))) AS Total FROM Orders LEFT OUTER JOIN Employees ON Orders.EmployeeID = Employees.EmployeeID LEFT OUTER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID LEFT OUTER JOIN Customers ON Orders.CustomerID = Customers.CustomerID WHERE Orders.CustomerID = '{clienteId}' GROUP BY Orders.OrderID, Orders.CustomerID, Orders.EmployeeID, Customers.CompanyName, Employees.FirstName + N' ' + Employees.LastName, Orders.OrderDate, Orders.RequiredDate, Orders.ShippedDate Order By orders.OrderID Desc", cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                DgvPedidos.DataSource = dt;
                Utils.ActualizarBarraDeEstado($"Se encontraron {DgvClientes.RowCount} registros de clientes, {DgvPedidos.RowCount} registros de pedidos del cliente {clienteId}", this);
                pedidoId = (int)DgvPedidos.CurrentRow.Cells["Pedido"].Value;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error con la base de datos: \n" + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: \n" + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
        }

        private void ConfDgvPedidos()
        {
            DgvPedidos.Columns["Pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvPedidos.Columns["Cliente"].Visible = false;
            DgvPedidos.Columns["IdEmpleado"].Visible = false;
            DgvPedidos.Columns["Nombre cliente"].Visible = false;
            DgvPedidos.Columns["Fecha de pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Fecha de pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvPedidos.Columns["Fecha de pedido"].DefaultCellStyle.Format = "dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            DgvPedidos.Columns["Fecha requerido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Fecha requerido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvPedidos.Columns["Fecha requerido"].DefaultCellStyle.Format = "dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            DgvPedidos.Columns["Fecha de envío"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Fecha de envío"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvPedidos.Columns["Fecha de envío"].DefaultCellStyle.Format = "dd\" de \"MMM\" de \"yyyy\n hh:mm:ss tt";
            DgvPedidos.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvPedidos.Columns["Total"].DefaultCellStyle.Format = "c";
        }

        private void LlenarDgvDetalle()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                SqlCommand cmd = new SqlCommand($"SELECT [Order Details].OrderID AS Pedido, Categories.CategoryName AS Categoría, Products.ProductName AS Producto, [Order Details].UnitPrice AS Precio, [Order Details].Quantity AS Cantidad, [Order Details].Discount AS Descuento, CONVERT(money, ([Order Details].UnitPrice * [Order Details].Quantity) * (1 - [Order Details].Discount)) AS Importe, Suppliers.CompanyName AS Proveedor, Suppliers.ContactName AS [Nombre de contacto], Suppliers.Country AS País, Suppliers.Phone AS Teléfono, Suppliers.Fax FROM Suppliers RIGHT OUTER JOIN Products ON Suppliers.SupplierID = Products.SupplierID LEFT OUTER JOIN Categories ON Products.CategoryID = Categories.CategoryID RIGHT OUTER JOIN [Order Details] ON Products.ProductID = [Order Details].ProductID WHERE [Order Details].OrderId = {pedidoId}", cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dt.Columns.Add(new DataColumn("Sub total", Type.GetType("System.Decimal")));
                dt.Columns.Add(new DataColumn("Total", Type.GetType("System.Decimal")));
                decimal subtotal = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    subtotal += Convert.ToDecimal(dr["Importe"]);
                    dr["Sub total"] = subtotal;
                }
                foreach (DataRow dr in dt.Rows)
                    dr["Total"] = subtotal;
                dt.Columns["Sub total"].SetOrdinal(7);
                dt.Columns["Total"].SetOrdinal(8);
                DgvDetalle.DataSource = dt;
                Utils.ActualizarBarraDeEstado($"Se encontraron {DgvClientes.RowCount} registros de clientes, {DgvPedidos.RowCount} registros de pedidos del cliente {clienteId} y {DgvDetalle.RowCount} registros del detalle del pedido N° {pedidoId}", this);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error con la base de datos: \n" + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: \n" + ex.Message, "Northwind Traders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.ActualizarBarraDeEstado("Activo", this);
            }
        }

        private void ConfDgvDetalle()
        {
            DgvDetalle.Columns["Pedido"].Visible = false;
            DgvDetalle.Columns["Precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["Precio"].DefaultCellStyle.Format = "c";
            DgvDetalle.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "n";
            DgvDetalle.Columns["Descuento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["Descuento"].DefaultCellStyle.Format = "n2";
            DgvDetalle.Columns["Importe"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["Importe"].DefaultCellStyle.Format = "c";
            DgvDetalle.Columns["Sub total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Sub total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["Sub total"].DefaultCellStyle.Format = "c";
            DgvDetalle.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["Total"].DefaultCellStyle.Format = "c";
            DgvDetalle.Columns["País"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["País"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["Teléfono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["Fax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void FrmPedidosxClienteDetalle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarDgvPedidos();
            LlenarDgvDetalle();
        }

        private void DgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            LlenarDgvPedidos();
            LlenarDgvDetalle();
        }
    }
}
