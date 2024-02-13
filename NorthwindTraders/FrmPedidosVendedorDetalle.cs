using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmPedidosVendedorDetalle : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        DataSet ds = new DataSet();

        public FrmPedidosVendedorDetalle()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void GrbPaint(object sender, PaintEventArgs e)
        {
            Utils.GrbPaint(sender, e, this);
        }

        private void FrmPedidosVendedorDetalle_Load(object sender, EventArgs e)
        {
            Utils.ConfDataGridView(dgvVendedores);
            Utils.ConfDataGridView(dgvPedidos);
            Utils.ConfDataGridView(dgvDetalle);
            try
            {
                Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
                DataTable dtVendedores = new DataTable("Vendedores");
                DataTable dtPedidos = new DataTable("Pedidos");
                DataTable dtDetalle = new DataTable("Detalle");
                SqlDataAdapter dapVendedores = new SqlDataAdapter("SELECT EmployeeID AS Id, FirstName AS Nombres, LastName AS Apellidos, Title AS Título, HireDate AS [Fecha de contratación], HomePhone AS Teléfono, Extension AS Extensión FROM Employees", cn);
                dapVendedores.Fill(dtVendedores);
                ds.Tables.Add(dtVendedores);
                SqlDataAdapter dapPedidos = new SqlDataAdapter("SELECT Orders.OrderID AS Pedido, Orders.EmployeeId AS [IdEmpleado], Customers.CompanyName AS Cliente, Orders.OrderDate AS [Fecha de pedido], Orders.RequiredDate AS [Fecha requerido], Orders.ShippedDate AS [Fecha de envío], SUM(CONVERT(money, ([Order Details].UnitPrice * [Order Details].Quantity) * (1 - [Order Details].Discount))) AS Importe FROM Orders LEFT OUTER JOIN Customers ON Orders.CustomerID = Customers.CustomerID LEFT OUTER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID GROUP BY Orders.OrderID, Orders.EmployeeId, Customers.CompanyName, Orders.OrderDate, Orders.RequiredDate, Orders.ShippedDate", cn);
                dapPedidos.Fill(dtPedidos);
                ds.Tables.Add(dtPedidos);
                SqlDataAdapter dapDetalle = new SqlDataAdapter("SELECT [Order Details].OrderID AS Pedido, Categories.CategoryName AS Categoría, Products.ProductName AS Producto, [Order Details].UnitPrice AS Precio, [Order Details].Quantity AS Cantidad, [Order Details].Discount AS Descuento, CONVERT(money, ([Order Details].UnitPrice * [Order Details].Quantity) * (1 - [Order Details].Discount)) AS Importe, Suppliers.CompanyName AS Proveedor, Suppliers.ContactName AS [Nombre de contacto], Suppliers.Country AS País, Suppliers.Phone AS Teléfono, Suppliers.Fax FROM Suppliers RIGHT OUTER JOIN Products ON Suppliers.SupplierID = Products.SupplierID LEFT OUTER JOIN Categories ON Products.CategoryID = Categories.CategoryID RIGHT OUTER JOIN [Order Details] ON Products.ProductID = [Order Details].ProductID", cn);
                dapDetalle.Fill(dtDetalle);
                ds.Tables.Add(dtDetalle);
                //Creamos una relación entre las tablas Vendedores y Pedidos a través del campo común
                DataColumn dcPadre = dtVendedores.Columns["Id"];
                DataColumn dcHijo = dtPedidos.Columns["IdEmpleado"];
                DataRelation relation = new DataRelation("VendedoresPedidos", dcPadre, dcHijo, true);
                // Añadimos la relación al objeto dataset
                ds.Relations.Add(relation);
                // Creamos una relación entre las tablas Pedidos y Detalle a través del campo común
                DataColumn dcPadre1 = dtPedidos.Columns["Pedido"];
                DataColumn dcHijo1 = dtDetalle.Columns["Pedido"];
                DataRelation relation1 = new DataRelation("PedidosDetalle", dcPadre1, dcHijo1, true);
                // Añadimos la relación al objeto dataset
                ds.Relations.Add(relation1);
                // Llenamos el datagrid de vendedores
                dgvVendedores.DataSource = ds.Tables["Vendedores"];
                ConfDgvVendedores();
                Utils.ActualizarBarraDeEstado("Activo", this);
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
        private void ConfDgvVendedores()
        {
            dgvVendedores.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dgvVendedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarPedidos();
        }

        private void MostrarPedidos()
        {

        }
    }
}
