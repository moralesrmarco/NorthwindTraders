using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class FrmPedidosClienteDetalle : Form
    {

        SqlConnection cn = new SqlConnection(NorthwindTraders.Properties.Settings.Default.NWCn);
        DataSet ds = new DataSet();

        public FrmPedidosClienteDetalle()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            splitContainer1.SplitterWidth = 3;
            splitContainer2.SplitterWidth = 3;
        }

        private void GrbPaint(object sender, PaintEventArgs e)
        {
            Utils.GrbPaint(sender, e, this);
        }

        private void FrmPedidosClienteDetalle_Load(object sender, EventArgs e)
        {
            Utils.ConfDataGridView(dgvClientes);
            Utils.ConfDataGridView(dgvPedidos);
            Utils.ConfDataGridView(dgvDetallePedido);
            Utils.ActualizarBarraDeEstado("Consultando la base de datos...", this);
            try
            {
                DataTable dtClientes = new DataTable("Clientes");
                DataTable dtPedidos = new DataTable("Pedidos");
                DataTable dtDetalle = new DataTable("Detalle");
                SqlDataAdapter dapClientes = new SqlDataAdapter("Select CustomerID As [Id], CompanyName As [Nombre de compañia], ContactName As [Nombre de Contacto], Address As Domicilio, City As Ciudad, Phone As Teléfono, Fax from Customers", cn);
                SqlDataAdapter dapPedidos = new SqlDataAdapter("SELECT Orders.OrderID AS Pedido, Orders.CustomerID AS Cliente, Orders.EmployeeID AS IdEmpleado, Customers.CompanyName AS [Nombre cliente], Employees.FirstName + N' ' + Employees.LastName AS Vendedor, Orders.OrderDate AS [Fecha de pedido], Orders.RequiredDate AS [Fecha requerido], Orders.ShippedDate AS [Fecha de envío], SUM(CONVERT(money, ([Order Details].UnitPrice * [Order Details].Quantity) * (1 - [Order Details].Discount))) AS Total FROM Orders LEFT OUTER JOIN Employees ON Orders.EmployeeID = Employees.EmployeeID LEFT OUTER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID LEFT OUTER JOIN Customers ON Orders.CustomerID = Customers.CustomerID GROUP BY Orders.OrderID, Orders.CustomerID, Orders.EmployeeID, Customers.CompanyName, Employees.FirstName + N' ' + Employees.LastName, Orders.OrderDate, Orders.RequiredDate, Orders.ShippedDate Order By orders.OrderID Desc", cn);
                SqlDataAdapter dapDetalle = new SqlDataAdapter("SELECT [Order Details].OrderID AS Pedido, Categories.CategoryName AS Categoría, Products.ProductName AS Producto, [Order Details].UnitPrice AS Precio, [Order Details].Quantity AS Cantidad, [Order Details].Discount AS Descuento, CONVERT(money, ([Order Details].UnitPrice * [Order Details].Quantity) * (1 - [Order Details].Discount)) AS Importe, Suppliers.CompanyName AS Proveedor, Suppliers.ContactName AS [Nombre de contacto], Suppliers.Country AS País, Suppliers.Phone AS Teléfono, Suppliers.Fax FROM Suppliers RIGHT OUTER JOIN Products ON Suppliers.SupplierID = Products.SupplierID LEFT OUTER JOIN Categories ON Products.CategoryID = Categories.CategoryID RIGHT OUTER JOIN [Order Details] ON Products.ProductID = [Order Details].ProductID", cn);
                dapClientes.Fill(dtClientes);
                ds.Tables.Add(dtClientes);
                dapPedidos.Fill(dtPedidos);
                ds.Tables.Add(dtPedidos);
                dapDetalle.Fill(dtDetalle);
                ds.Tables.Add(dtDetalle);
                //Creamos una relación entre las tablas Clientes y Pedidos a través del campo común
                DataColumn dcPadre = dtClientes.Columns["Id"];
                DataColumn dcHijo = dtPedidos.Columns["Cliente"];
                DataRelation relation = new DataRelation("ClientesPedidos", dcPadre, dcHijo, true);
                // Añadimos la relación al objeto dataset
                ds.Relations.Add(relation);
                // Creamos una relación entre las tablas Pedidos y Detalle a través del campo común
                DataColumn dcPadre1 = dtPedidos.Columns["Pedido"];
                DataColumn dcHijo1 = dtDetalle.Columns["Pedido"];
                DataRelation relation1 = new DataRelation("PedidosDetalle", dcPadre1, dcHijo1, true);
                // Añadimos la relación al objeto dataset
                ds.Relations.Add(relation1);
                //Llenamos el datagrid de clientes
                dgvClientes.DataSource = ds.Tables["Clientes"];
                dgvClientes.Columns["Id"].Visible = false;
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

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarPedidos();
            MostrarDetallePedidos();
        }

        private void MostrarPedidos()
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos, obteniendo los pedidos...", this);
            // Limpiar los valores del DataGridView
            dgvPedidos.DataSource = null;
            dgvPedidos.Refresh();
            dgvDetallePedido.DataSource = null;
            dgvDetallePedido.Refresh();
            // Obtener la fila de la tabla maestra: Clientes
            DataGridViewRow dgvr = dgvClientes.CurrentRow;
            //la siguiente instrucción funcionaba en el caso en que el id fuera un entero y continuo, no funcionaba en casos en que el id fuera discontinuo
            //DataRow drFilaPadre = ds.Tables["Clientes"].Rows[Convert.ToInt32(dgvrFila.Cells["Id cliente"].Value) - 1];
            // Esta en VB originalmente Dim drFilaPadre As DataRow = mDataSet.Tables("COMU").Rows(CInt(loFila.Cells("ID_COMU").Value) - 1)

            // El codigo original lo tuve que adaptar para que buscara un id tipo string
            DataRow[] drFilaPadre0 = ds.Tables["Clientes"].Select("Id = '" + dgvr.Cells["Id"].Value.ToString() + "'");
            // se obtine el valor de la fila[0] del arreglo
            DataRow drFilaPadre = drFilaPadre0[0];
            // Obtener las filas hijas de la tabla Pedidos, gracias a la relación ClientesPedidos
            DataRow[] drFilasHijas = drFilaPadre.GetChildRows("ClientesPedidos");
            DataTable dt = new DataTable();
            dt.TableName = "Pedidos";
            // Creamos una columna, y la añadimos al objeto DataTable
            DataColumn dc;
            dc = new DataColumn("Pedido", System.Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Cliente", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Vendedor", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Fecha de pedido", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Fecha requerido", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Fecha de envío", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dt.Columns.Add(new DataColumn("Total", typeof(decimal)));
            //Rellenar el datatable con valores de las filas hijas
            DataRow dr;
            foreach (DataRow drFila in drFilasHijas)
            {
                dr = dt.NewRow();
                // Añadimos los datos de la fila actual
                dr["Pedido"] = Convert.ToInt32(drFila["Pedido"]);
                dr["Cliente"] = (drFila["Cliente"] == DBNull.Value) ? "" : Convert.ToString(drFila["Cliente"]);
                dr["Vendedor"] = (drFila["Vendedor"] == DBNull.Value) ? "" : drFila["Vendedor"].ToString();
                dr["Fecha de pedido"] = (drFila["Fecha de pedido"] == DBNull.Value) ? "" : FormatoFecha(Convert.ToDateTime(drFila["Fecha de pedido"]));
                dr["Fecha requerido"] = (drFila["Fecha requerido"] == DBNull.Value) ? "" : FormatoFecha(Convert.ToDateTime(drFila["Fecha requerido"]));
                dr["Fecha de envío"] = (drFila["Fecha de envío"] == DBNull.Value) ? "" : FormatoFecha(Convert.ToDateTime(drFila["Fecha de envío"]));
                dr["Total"] = (drFila["Total"] == DBNull.Value) ? 0 : Convert.ToDecimal(drFila["Total"]);
                // Agregamos el registro a la colección Rows
                dt.Rows.Add(dr);
            }
            //Cargar los valores al datagridview
            dgvPedidos.DataSource = dt;
            ConfDgvPedidos();
            Utils.ActualizarBarraDeEstado($"Se encontraron {dgvClientes.RowCount} registros de cliente, {dgvPedidos.RowCount} registros de pedidos del cliente {dgvr.Cells[1].Value.ToString()}", this);
        }

        private string FormatoFecha(DateTime fecha)
        {
            string strFecha = string.Format("{0:dd}", fecha) + " de " + string.Format("{0:MMM}", fecha) + " de " + string.Format("{0:yyyy}", fecha) + "\n" + string.Format("{0:hh}", fecha) + ":" + string.Format("{0:mm}", fecha) + ":" + string.Format("{0:ss}", fecha) + " " + string.Format("{0:tt}", fecha);
            return strFecha;
        }

        private void ConfDgvPedidos()
        {
            dgvPedidos.Columns["Cliente"].Visible = false;
            // aqui no se aplica el formato de fecha por que devuelve la cadena 01/01/0001 si el valor de la fecha es nula por eso se cambio el 
            //dgvPedidos.Columns["Fecha de pedido"].DefaultCellStyle.Format = "ddd dd \"de\" MMM \"de\" yyyy\n hh:mm:ss tt";
            //dgvPedidos.Columns["Fecha requerido"].DefaultCellStyle.Format = "ddd dd \"de\" MMM \"de\" yyyy\n hh:mm:ss tt";
            //dgvPedidos.Columns["Fecha de envío"].DefaultCellStyle.Format = "ddd dd \"de\" MMM \"de\" yyyy\n hh:mm:ss tt";
            dgvPedidos.Columns["Fecha de pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPedidos.Columns["Fecha requerido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPedidos.Columns["Fecha de envío"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPedidos.Columns["Pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Fecha de pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Fecha requerido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Fecha de envío"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPedidos.Columns["Total"].DefaultCellStyle.Format = "c";
            dgvPedidos.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void FrmPedidosClienteDetalle_Shown(object sender, EventArgs e)
        {
            MostrarPedidos();
            MostrarDetallePedidos();
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarDetallePedidos();
        }

        private void MostrarDetallePedidos()
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos, obteniendo el detalle del pedido...", this);
            // Limpiar los valores del DataGridView
            dgvDetallePedido.DataSource = null;
            dgvDetallePedido.Refresh();
            // Obtener la fila de la tabla maestra Pedidos
            DataGridViewRow dgvr = dgvPedidos.CurrentRow;
            // Obtenemos la fila padre
            DataRow[] drFilaPadre0 = ds.Tables["Pedidos"].Select("Pedido = " + dgvr.Cells["Pedido"].Value.ToString());
            DataRow drFilaPadre = drFilaPadre0[0];
            //DataRow drFilaPadre = ds.Tables["Pedidos"].Rows[Convert.ToInt32(dgvrFila.Cells["Pedido"].Value)];
            // Obtener las filas hijas de la tabla DetallePedidos, gracias a la relación Pedidos_DetallePedidos
            DataRow[] drFilasHijas = drFilaPadre.GetChildRows("PedidosDetalle");
            DataTable dt = new DataTable();
            dt.TableName = "Detalle";
            // Creamos las columnas y la añadimos al objeto DataTable
            DataColumn dc;
            dc = new DataColumn("Pedido", Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Categoría", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Producto", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Precio", Type.GetType("System.Decimal"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Cantidad", Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Descuento", Type.GetType("System.Decimal"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Importe", Type.GetType("System.Decimal"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Sub total", Type.GetType("System.Decimal"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Total", Type.GetType("System.Decimal"));
            dt.Columns.Add(dc);
            // las siguientes columnas se ponen solo para rellenar mas el datagridview
            dc = new DataColumn("Proveedor", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Nombre de contacto", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("País", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Teléfono", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Fax", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            //Rellenar el datatable con valores de las filas hijas
            decimal subTotal = 0, total = 0;
            DataRow dr;
            foreach (DataRow drFila in drFilasHijas)
            {
                dr = dt.NewRow();
                // Añadimos los datos de la fila actual
                dr["Pedido"] = Convert.ToInt32(drFila["Pedido"]);
                dr["Categoría"] = drFila["Categoría"].ToString();
                dr["Producto"] = drFila["Producto"].ToString();
                dr["Precio"] = Convert.ToDecimal(drFila["Precio"]);
                dr["Cantidad"] = Convert.ToInt32(drFila["Cantidad"]);
                dr["Descuento"] = Convert.ToDecimal(drFila["Descuento"]);
                dr["Importe"] = Convert.ToDecimal(drFila["Importe"]);
                subTotal += Convert.ToDecimal(drFila["Importe"]);
                dr["Sub total"] = subTotal;
                dr["Proveedor"] = drFila["Proveedor"].ToString();
                dr["Nombre de contacto"] = drFila["Nombre de contacto"].ToString();
                dr["País"] = drFila["País"].ToString();
                dr["Teléfono"] = drFila["Teléfono"].ToString();
                dr["Fax"] = drFila["Fax"].ToString();
                dt.Rows.Add(dr);
            }
            total = subTotal;
            foreach (DataRow drFila in dt.Rows)
                drFila["Total"] = total;
            //txtTotal.Text = total.ToString("c");
            //Cargar los valores al datagridview
            dgvDetallePedido.DataSource = dt;
            ConfDgvDetalle();
            Utils.ActualizarBarraDeEstado($"Se encontraron {dgvClientes.RowCount} registros en Clientes, {dgvPedidos.RowCount} registros de pedidos del Cliente {dgvClientes.CurrentRow.Cells[1].Value} y {dgvDetallePedido.RowCount} registros del detalle del pedido N° {dgvPedidos.CurrentRow.Cells["Pedido"].Value}", this);
        }

        private void ConfDgvDetalle()
        {
            dgvDetallePedido.Columns ["Pedido"].Visible = false;
            dgvDetallePedido.Columns ["Precio"].DefaultCellStyle.Format = "c";
            dgvDetallePedido.Columns ["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetallePedido.Columns ["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetallePedido.Columns ["Descuento"].DefaultCellStyle.Format = "n2";
            dgvDetallePedido.Columns ["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetallePedido.Columns ["Importe"].DefaultCellStyle.Format = "c";
            dgvDetallePedido.Columns ["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetallePedido.Columns ["Sub total"].DefaultCellStyle.Format = "c";
            dgvDetallePedido.Columns ["Sub total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetallePedido.Columns ["Total"].DefaultCellStyle.Format = "c";
            dgvDetallePedido.Columns ["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void FrmPedidosClienteDetalle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

    }
}
