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
            LlenarDgvClientes();
            LlenarDgvPedidos();
            LlenarDgvDetalle();
        }

        private void LlenarDgvClientes()
        {
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos, obteniendo los clientes...", this);
                SqlCommand cmd = new SqlCommand("Select CustomerID As [Id], CompanyName As [Nombre de compañia], ContactName As [Nombre de Contacto], Address As Domicilio, City As Ciudad, Phone As Teléfono, Fax from Customers", cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                DgvClientes.DataSource = dt;
                ConfDgvClientes();
                clienteId = DgvClientes.Rows[0].Cells["Id"].Value.ToString();
                Utils.ActualizarBarraDeEstado($"Se encontraron {DgvClientes.RowCount} registros de clientes", this);
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
                Utils.ActualizarBarraDeEstado("Consultando la base de datos, obteniendo los pedidos...", this);
                DgvPedidos.DataSource = null;
                DgvPedidos.Refresh();
                SqlCommand cmd = new SqlCommand($"SELECT Orders.OrderID AS Pedido, Orders.CustomerID AS Cliente, Orders.EmployeeID AS IdEmpleado, Customers.CompanyName AS [Nombre cliente], Employees.FirstName + N' ' + Employees.LastName AS Vendedor, Orders.OrderDate AS [Fecha de pedido], Orders.RequiredDate AS [Fecha requerido], Orders.ShippedDate AS [Fecha de envío], SUM(CONVERT(money, ([Order Details].UnitPrice * [Order Details].Quantity) * (1 - [Order Details].Discount))) AS Total FROM Orders LEFT OUTER JOIN Employees ON Orders.EmployeeID = Employees.EmployeeID LEFT OUTER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID LEFT OUTER JOIN Customers ON Orders.CustomerID = Customers.CustomerID WHERE Orders.CustomerID = '{clienteId}' GROUP BY Orders.OrderID, Orders.CustomerID, Orders.EmployeeID, Customers.CompanyName, Employees.FirstName + N' ' + Employees.LastName, Orders.OrderDate, Orders.RequiredDate, Orders.ShippedDate Order By orders.OrderID Desc", cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                DgvPedidos.DataSource = dt;
                ConfDgvPedidos();
                if (DgvPedidos.RowCount > 0)
                {
                    pedidoId = (int)DgvPedidos.CurrentRow.Cells["Pedido"].Value;
                    Utils.ActualizarBarraDeEstado($"Se encontraron {DgvClientes.RowCount} registros de clientes, {DgvPedidos.RowCount} registros de pedidos del cliente {clienteId}", this);
                }
                else
                {
                    pedidoId = 0;
                    Utils.ActualizarBarraDeEstado($"Se encontraron {DgvClientes.RowCount} registros de clientes y 0 registros de pedidos del cliente {DgvClientes.CurrentRow.Cells["Id"].Value}", this);
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
                Utils.ActualizarBarraDeEstado("Consultando la base de datos, obteniendo el detalle del pedido...", this);
                DgvDetalle.DataSource = null;
                DgvDetalle.Refresh();
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
                ConfDgvDetalle();
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
            clienteId = DgvClientes.CurrentRow.Cells["Id"].Value.ToString();
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

        private void DgvClientes_KeyDown(object sender, KeyEventArgs e)
    {
            if (!(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Tab || (e.KeyCode == Keys.Tab && e.Shift) || (e.KeyCode == Keys.Up && e.Control) || (e.KeyCode == Keys.Down && e.Control) || (e.KeyCode == Keys.Enter && e.Control)))
                return;
            try
            {
                int rowInd = 0;
                if (e.KeyCode == Keys.Enter && e.Control)
                    return;
                else if (e.KeyCode == Keys.Up && e.Control)
                    rowInd = 0;
                else if (e.KeyCode == Keys.Down && e.Control)
                    rowInd = DgvClientes.RowCount - 1;
                else if (e.KeyCode == Keys.Up)
                {
                    rowInd = DgvClientes.CurrentRow.Index - 1;
                    if (rowInd < 0)
                        return;
                }
                else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    rowInd = DgvClientes.CurrentRow.Index + 1;
                    if (rowInd >= DgvClientes.RowCount)
                        return;
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    // Obtén el índice de la fila actualmente seleccionada o con el foco
                    rowInd = DgvClientes.CurrentRow.Index;
                    // Calcula el índice de la primera fila visible después de Page Up
                    int visibleRowCount = DgvClientes.DisplayedRowCount(false); // false para contar solo las filas completamente visibles
                    int targetRowIndex = Math.Max(0, rowInd - visibleRowCount);
                    // Ahora puedes usar 'targetRowIndex' para acceder a la fila deseada
                    rowInd = targetRowIndex;
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    // Obtén el índice de la fila actualmente seleccionada o con el foco
                    rowInd = DgvClientes.CurrentRow.Index;
                    // Calcula el índice de la última fila visible después de Page Down
                    int visibleRowCount = DgvClientes.DisplayedRowCount(false); // false para contar solo las filas completamente visibles
                    int targetRowIndex = Math.Min(DgvClientes.RowCount - 1, rowInd + visibleRowCount);
                    // Ahora puedes usar 'targetRowIndex' para acceder a la fila deseada
                    rowInd = targetRowIndex;
                }
                else if (e.KeyCode == Keys.Tab && e.Shift)
                {
                    if (DgvClientes.CurrentCell.ColumnIndex == 1) // el columnindex del campo nombre de compañía es 1, porque en el 0 esta el clienteid.
                        rowInd = DgvClientes.CurrentRow.Index - 1;
                    else
                        return;

                }
                else if (e.KeyCode == Keys.Tab)
                {
                    // Obtén el índice de la fila actualmente seleccionada o con el foco
                    rowInd = DgvClientes.CurrentRow.Index;
                    // Verifica si el foco está en la última celda de la fila actual
                    if (DgvClientes.CurrentCell.ColumnIndex == DgvClientes.Columns.Count - 1)
                        rowInd++;
                    else
                        // este es para que no haga nada si la fila no es la ultima
                        return;
                }
                DataGridViewRow row = DgvClientes.Rows[rowInd];
                clienteId = row.Cells["Id"].Value.ToString();
                DgvPedidos.DataSource = null;
                DgvPedidos.Refresh();
                DgvDetalle.DataSource = null;
                DgvDetalle.Refresh();
                LlenarDgvPedidos();
                //ConfDgvPedidos();
                pedidoId = (int)DgvPedidos.CurrentRow.Cells["Pedido"].Value;
                LlenarDgvDetalle();
                //ConfDgvDetalle();
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
            //ConfDgvDetalle();
        }

        private void DgvPedidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Tab || (e.KeyCode == Keys.Tab && e.Shift) || (e.KeyCode == Keys.Up && e.Control) || (e.KeyCode == Keys.Down && e.Control) || (e.KeyCode == Keys.Enter && e.Control)))
                return;
            try
            {
                int rowInd = 0;
                if (e.KeyCode == Keys.Enter && e.Control)
                    return;
                else if (e.KeyCode == Keys.Up && e.Control)
                    rowInd = 0;
                else if (e.KeyCode == Keys.Down && e.Control)
                    rowInd = DgvPedidos.RowCount - 1;
                else if (e.KeyCode == Keys.Up)
                {
                    rowInd = DgvPedidos.CurrentRow.Index - 1;
                    if (rowInd < 0)
                        return;
                }
                else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    rowInd = DgvPedidos.CurrentRow.Index + 1;
                    if (rowInd >= DgvPedidos.RowCount)
                        return;
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    rowInd = DgvPedidos.CurrentRow.Index;
                    int visibleRowCount = DgvPedidos.DisplayedRowCount(false);
                    int targetRowIndex = Math.Max(0, rowInd - visibleRowCount);
                    rowInd = targetRowIndex;
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    rowInd = DgvPedidos.CurrentRow.Index;
                    int visibleRowCount = DgvPedidos.DisplayedRowCount(false);
                    int targetRowIndex = Math.Min(DgvPedidos.RowCount - 1, rowInd + visibleRowCount);
                    rowInd = targetRowIndex;
                }
                else if (e.KeyCode == Keys.Tab && e.Shift)
                {
                    if (DgvPedidos.CurrentCell.ColumnIndex == 0) // el columnindex del campo pedido es 0;
                        rowInd = DgvPedidos.CurrentRow.Index - 1;
                    else
                        return;
                }
                else if (e.KeyCode == Keys.Tab)
                {
                    if (DgvPedidos.CurrentCell.ColumnIndex == DgvPedidos.Columns.Count - 1)
                        rowInd = DgvPedidos.CurrentRow.Index + 1;
                    else
                        return;
                }
                DataGridViewRow row = DgvPedidos.Rows[rowInd];
                pedidoId = (int)row.Cells["Pedido"].Value;
                DgvDetalle.DataSource = null;
                DgvDetalle.Refresh();
                LlenarDgvDetalle();
                //ConfDgvDetalle();
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
