using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmPedidosxVendedorDetalle : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        static int vendedorId;
        static int pedidoId;

        public FrmPedidosxVendedorDetalle()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void GrbPaint(object sender, PaintEventArgs e)
        {
            Utils.GrbPaint(sender, e, this);
        }

        private void FrmPedidosxVendedorDetalle_Load(object sender, EventArgs e)
        {
            Utils.ConfDataGridView(DgvVendedores);
            Utils.ConfDataGridView(DgvPedidos);
            Utils.ConfDataGridView(DgvDetalle);
            LlenarDgvVendedores();
            LlenarDgvPedidos();
            LlenarDgvDetalle();
        }

        private void LlenarDgvVendedores()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos, obteniendo los vendedores...", this);
                SqlCommand cmd = new SqlCommand("SELECT EmployeeID AS Id, FirstName AS Nombres, LastName AS Apellidos, Title AS Título, HireDate AS [Fecha de contratación], HomePhone AS Teléfono, Extension AS Extensión FROM Employees", cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                DgvVendedores.DataSource = dt;
                ConfDgvVendedores();
                vendedorId = (int)DgvVendedores.CurrentRow.Cells["Id"].Value;
                Utils.ActualizarBarraDeEstado($"Se encontraron {DgvVendedores.RowCount} registros de vendedores", this);
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

        private void ConfDgvVendedores()
        {
            DgvVendedores.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvVendedores.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvVendedores.Columns["Título"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvVendedores.Columns["Fecha de contratación"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvVendedores.Columns["Fecha de contratación"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvVendedores.Columns["Fecha de contratación"].DefaultCellStyle.Format = "dd\" de \"MMM\" de \"yyyy";
            DgvVendedores.Columns["Teléfono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvVendedores.Columns["Extensión"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void LlenarDgvPedidos()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos, obteniendo los pedidos...", this);
                DgvPedidos.DataSource = null;
                DgvPedidos.Refresh();
                //SqlCommand cmd = new SqlCommand($"SELECT Orders.OrderID AS Pedido, Orders.EmployeeId AS [IdEmpleado],  Customers.CompanyName AS Cliente, Orders.OrderDate AS [Fecha de pedido], Orders.RequiredDate AS [Fecha requerido], Orders.ShippedDate AS [Fecha de envío], SUM(CONVERT(money, ([Order Details].UnitPrice * [Order Details].Quantity) * (1 - [Order Details].Discount))) AS Total FROM Orders LEFT OUTER JOIN Customers ON Orders.CustomerID = Customers.CustomerID LEFT OUTER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID WHERE Orders.EmployeeId = {vendedorId} GROUP BY Orders.OrderID, Orders.EmployeeId, Customers.CompanyName, Orders.OrderDate, Orders.RequiredDate, Orders.ShippedDate ORDER BY Orders.OrderID DESC", cn);
                SqlCommand cmd = new SqlCommand($"SELECT Orders.OrderID AS Pedido, Orders.EmployeeID AS IdEmpleado, \r\nEmployees.LastName + N', ' + Employees.FirstName AS Vendedor, Customers.CompanyName AS Cliente, \r\nOrders.OrderDate AS [Fecha de pedido], Orders.RequiredDate AS [Fecha requerido], Orders.ShippedDate AS [Fecha de envío], \r\nSUM(CONVERT(money, ([Order Details].UnitPrice * [Order Details].Quantity) * (1 - [Order Details].Discount))) AS Total\r\nFROM Orders LEFT OUTER JOIN\r\nEmployees ON Orders.EmployeeID = Employees.EmployeeID LEFT OUTER JOIN\r\nCustomers ON Orders.CustomerID = Customers.CustomerID LEFT OUTER JOIN\r\n[Order Details] ON Orders.OrderID = [Order Details].OrderID\r\n WHERE Orders.EmployeeId = {vendedorId} GROUP BY Orders.OrderID, Orders.EmployeeID, Customers.CompanyName, Orders.OrderDate, Orders.RequiredDate, Orders.ShippedDate, Employees.LastName + N', ' + Employees.FirstName\r\nORDER BY Pedido DESC", cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                DgvPedidos.DataSource = dt;
                ConfDgvPedidos();
                if (DgvPedidos.RowCount > 0)
                {
                    pedidoId = (int)DgvPedidos.CurrentRow.Cells["Pedido"].Value;
                    Utils.ActualizarBarraDeEstado($"Se encontraron {DgvVendedores.RowCount} registros de vendedores, {DgvPedidos.RowCount} registros de pedidos del vendedor {DgvPedidos.Rows[0].Cells["Vendedor"].Value}", this);
                }
                else
                {
                    pedidoId = 0;
                    Utils.ActualizarBarraDeEstado($"Se encontraron {DgvVendedores.RowCount} registros de vendedores, 0 registros de pedidos del vendedor", this);
                }
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
            DgvPedidos.Columns["IdEmpleado"].Visible = false;
            DgvPedidos.Columns["Vendedor"].Visible = false;
            DgvPedidos.Columns["Fecha de pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Fecha de pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvPedidos.Columns["Fecha de pedido"].DefaultCellStyle.Format = "dd\" de \"MMM\" de \"yyyy\nhh:mm:ss tt";
            DgvPedidos.Columns["Fecha requerido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Fecha requerido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvPedidos.Columns["Fecha requerido"].DefaultCellStyle.Format = "dd\" de \"MMM\" de \"yyyy\nhh:mm:ss tt";
            DgvPedidos.Columns["Fecha de envío"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Fecha de envío"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvPedidos.Columns["Fecha de envío"].DefaultCellStyle.Format = "dd\" de \"MMM\" de \"yyyy\nhh:mm:ss tt";
            DgvPedidos.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvPedidos.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvPedidos.Columns["Total"].DefaultCellStyle.Format = "c";
        }

        private void LlenarDgvDetalle()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos, obteniendo el detalle del pedido...", this);
                DgvDetalle.DataSource = null;
                DgvDetalle.Refresh();
                SqlCommand cmd = new SqlCommand($"SELECT [Order Details].OrderID AS Pedido, Categories.CategoryName AS Categoría, Products.ProductName AS Producto, [Order Details].UnitPrice AS Precio, [Order Details].Quantity AS Cantidad, [Order Details].Discount AS Descuento, CONVERT(money, ([Order Details].UnitPrice * [Order Details].Quantity) * (1 - [Order Details].Discount)) AS Importe, Suppliers.CompanyName AS Proveedor, Suppliers.ContactName AS [Nombre de contacto], Suppliers.Country AS País, Suppliers.Phone AS Teléfono, Suppliers.Fax FROM Suppliers RIGHT OUTER JOIN Products ON Suppliers.SupplierID = Products.SupplierID LEFT OUTER JOIN Categories ON Products.CategoryID = Categories.CategoryID RIGHT OUTER JOIN [Order Details] ON Products.ProductID = [Order Details].ProductID WHERE [Order Details].OrderID = {pedidoId}", cn);
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
                ConfDgvDetalle();
                Utils.ActualizarBarraDeEstado($"Se encontraron {DgvVendedores.RowCount} registros de vendedores, {DgvPedidos.RowCount} registros de pedidos del vendedor {DgvPedidos.Rows[0].Cells["Vendedor"].Value} y {DgvDetalle.RowCount} registros del detalle del pedido N° {pedidoId}", this);
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
            DgvDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "n0";
            DgvDetalle.Columns["Descuento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["Descuento"].DefaultCellStyle.Format = "n2";
            DgvDetalle.Columns["Importe"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvDetalle.Columns["Importe"].DefaultCellStyle.Format = "c";
            DgvDetalle.Columns["Sub total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Sub total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvDetalle.Columns["Sub total"].DefaultCellStyle.Format = "c";
            DgvDetalle.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvDetalle.Columns["Total"].DefaultCellStyle.Format = "c";
            DgvDetalle.Columns["País"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DgvDetalle.Columns["País"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["Teléfono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvDetalle.Columns["Fax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void FrmPedidosxVendedorDetalle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

        private void DgvVendedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vendedorId = (int)DgvVendedores.CurrentRow.Cells["Id"].Value;
            DgvPedidos.DataSource = null;
            DgvPedidos.Refresh();
            DgvDetalle.DataSource = null;
            DgvDetalle.Refresh();
            LlenarDgvPedidos();
            if (pedidoId != 0)
            {
                pedidoId = (int)DgvPedidos.CurrentRow.Cells["Pedido"].Value;
                LlenarDgvDetalle();
            }
        }

        private void DgvVendedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Tab || (e.KeyCode == Keys.Tab && e.Shift) || (e.KeyCode == Keys.Up && e.Control) || (e.KeyCode == Keys.Down && e.Control) || (e.KeyCode == Keys.Enter && e.Control)))
                return;
            try
            {
                int rowIndex = 0;
                if (e.KeyCode == Keys.Enter && e.Control)
                    return;
                else if (e.KeyCode == Keys.Up && e.Control)
                    rowIndex = 0;
                else if (e.KeyCode == Keys.Down && e.Control)
                    rowIndex = DgvVendedores.RowCount - 1;
                else if (e.KeyCode == Keys.Up)
                {
                    rowIndex = DgvVendedores.CurrentRow.Index - 1;
                    if (rowIndex < 0)
                        return;
                }
                else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    rowIndex = DgvVendedores.CurrentRow.Index + 1;
                    if (rowIndex >= DgvVendedores.RowCount)
                        return;
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    rowIndex = DgvVendedores.CurrentRow.Index;
                    int visibleRowCount = DgvVendedores.DisplayedRowCount(false);
                    rowIndex = Math.Max(0, rowIndex - visibleRowCount);
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    rowIndex = DgvVendedores.CurrentRow.Index;
                    int visibleRowCount = DgvVendedores.DisplayedRowCount(false);
                    rowIndex = Math.Min(DgvVendedores.RowCount - 1, rowIndex + visibleRowCount);
                }
                else if (e.KeyCode == Keys.Tab && e.Shift)
                {
                    if (DgvVendedores.CurrentCell.ColumnIndex == 0)
                        rowIndex = DgvVendedores.CurrentRow.Index - 1;
                    else
                        return;
                }
                else if (e.KeyCode == Keys.Tab)
                {
                    if (DgvVendedores.CurrentCell.ColumnIndex == DgvVendedores.Columns.Count - 1)
                        rowIndex = DgvVendedores.CurrentRow.Index + 1;
                    else
                        return;
                }
                DataGridViewRow dgvr = DgvVendedores.Rows[rowIndex];
                vendedorId = (int)dgvr.Cells["Id"].Value;
                DgvPedidos.DataSource = null;
                DgvPedidos.Refresh();
                DgvDetalle.DataSource = null;
                DgvDetalle.Refresh();
                LlenarDgvPedidos();
                pedidoId = (int)DgvPedidos.CurrentRow.Cells["Pedido"].Value;
                LlenarDgvDetalle();
            }
            catch
            {
                pedidoId = 0;
                DgvPedidos.DataSource = null;
                DgvDetalle.DataSource = null;
            }
        }

        private void DgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvDetalle.DataSource = null;
            DgvDetalle.Refresh();
            pedidoId = (int)DgvPedidos.CurrentRow.Cells["Pedido"].Value;
            LlenarDgvDetalle();
        }

        private void DgvPedidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Tab || (e.KeyCode == Keys.Tab && e.Shift) || (e.KeyCode == Keys.Up && e.Control) || (e.KeyCode == Keys.Down && e.Control) || (e.KeyCode == Keys.Enter && e.Control)))
                return;
            try
            {
                int rowIndex = 0;
                if (e.KeyCode == Keys.Enter && e.Control)
                    return;
                else if (e.KeyCode == Keys.Up && e.Control)
                    rowIndex = 0;
                else if (e.KeyCode == Keys.Down && e.Control)
                    rowIndex = DgvPedidos.RowCount - 1;
                else if (e.KeyCode == Keys.Up)
                {
                    rowIndex = DgvPedidos.CurrentRow.Index - 1;
                    if (rowIndex < 0)
                        return;
                }
                else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    rowIndex = DgvPedidos.CurrentRow.Index + 1;
                    if (rowIndex >= DgvPedidos.RowCount)
                        return;
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    rowIndex = DgvPedidos.CurrentRow.Index;
                    int visibleRowCount = DgvPedidos.DisplayedRowCount(false);
                    rowIndex = Math.Max(0, rowIndex - visibleRowCount);
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    rowIndex = DgvPedidos.CurrentRow.Index;
                    int visibleRowCount = DgvPedidos.DisplayedRowCount(false);
                    rowIndex = Math.Min(DgvPedidos.RowCount - 1, rowIndex + visibleRowCount);
                }
                else if (e.KeyCode == Keys.Tab && e.Shift)
                {
                    if (DgvPedidos.CurrentCell.ColumnIndex == 0)
                        rowIndex = DgvPedidos.CurrentRow.Index - 1;
                    else
                        return;
                }
                else if (e.KeyCode == Keys.Tab)
                {
                    if (DgvPedidos.CurrentCell.ColumnIndex == DgvPedidos.Columns.Count - 1)
                        rowIndex = DgvPedidos.CurrentRow.Index + 1;
                    else
                        return;
                }
                DataGridViewRow dgvr = DgvPedidos.Rows[rowIndex];
                pedidoId = (int)dgvr.Cells["Pedido"].Value;
                DgvDetalle.DataSource = null;
                DgvDetalle.Refresh();
                LlenarDgvDetalle();
            }
            catch
            {
                pedidoId = 0;
                DgvDetalle.DataSource = null;
                DgvDetalle.Refresh();
            }
        }
    }
}
