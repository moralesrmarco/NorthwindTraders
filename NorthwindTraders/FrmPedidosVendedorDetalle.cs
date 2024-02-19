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
                SqlDataAdapter dapPedidos = new SqlDataAdapter("SELECT Orders.OrderID AS Pedido, Orders.EmployeeId AS [IdEmpleado], Customers.CompanyName AS Cliente, Orders.OrderDate AS [Fecha de pedido], Orders.RequiredDate AS [Fecha requerido], Orders.ShippedDate AS [Fecha de envío], SUM(CONVERT(money, ([Order Details].UnitPrice * [Order Details].Quantity) * (1 - [Order Details].Discount))) AS Total FROM Orders LEFT OUTER JOIN Customers ON Orders.CustomerID = Customers.CustomerID LEFT OUTER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID GROUP BY Orders.OrderID, Orders.EmployeeId, Customers.CompanyName, Orders.OrderDate, Orders.RequiredDate, Orders.ShippedDate ORDER BY Orders.OrderID DESC", cn);
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
            dgvVendedores.Columns["Fecha de contratación"].DefaultCellStyle.Format = "dd \"de\" MMM \"de\" yyyy";
            dgvVendedores.Columns["Fecha de contratación"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendedores.Columns["Fecha de contratación"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVendedores.Columns["Extensión"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendedores.Columns["Extensión"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVendedores.Columns["Teléfono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void dgvVendedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarPedidos();
            MostrarDetallePedidos();
        }

        private void MostrarPedidos()
        {
            Utils.ActualizarBarraDeEstado("Consultando la base de datos, obteniendo los pedidos...", this);
            dgvPedidos.DataSource = null;
            dgvPedidos.Refresh();
            dgvDetalle.DataSource = null;
            dgvDetalle.Refresh();
            // Obtener la fila de la tabla maestra: Vendedores
            DataGridViewRow dgvr = dgvVendedores.CurrentRow;
            //la siguiente instrucción funcionaba en el caso en que el id fuera un entero y continuo, no funcionaba en casos en que el id fuera discontinuo
            //DataRow drFilaPadre = ds.Tables["Clientes"].Rows[Convert.ToInt32(dgvrFila.Cells["Id cliente"].Value) - 1];
            // Esta en VB originalmente Dim drFilaPadre As DataRow = mDataSet.Tables("COMU").Rows(CInt(loFila.Cells("ID_COMU").Value) - 1)

            // El codigo original lo tuve que adaptar para que buscara un id tipo int
            DataRow[] drFilaPadre0 = ds.Tables["Vendedores"].Select("Id = " + dgvr.Cells["Id"].Value.ToString());
            // se obtine el valor de la fila[0] del arreglo
            DataRow drFilaPadre = drFilaPadre0[0];
            // Obtener las filas hijas de la tabla Pedidos, gracias a la relación VendedoresPedidos
            DataRow[] drFilasHijas = drFilaPadre.GetChildRows("VendedoresPedidos");
            DataTable dt = new DataTable();
            dt.TableName = "Pedidos";
            // Creamos una columna, y la añadimos al objeto DataTable
            DataColumn dc;
            dc = new DataColumn("Pedido", Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Cliente", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Vendedor", Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            //dc = new DataColumn("Fecha de pedido", Type.GetType("System.DateTime"));
            dc = new DataColumn("Fecha de pedido", typeof(String));
            dt.Columns.Add(dc);
            dc = new DataColumn("Fecha requerido", typeof(System.String));
            dt.Columns.Add(dc);
            dc = new DataColumn("Fecha de envío", typeof(String));
            dt.Columns.Add(dc);
            dc = new DataColumn("Total", Type.GetType("System.Decimal"));
            dt.Columns.Add(dc);
            //Rellenar el datatable con valores de las filas hijas
            DataRow dr;
            foreach (DataRow drFila in drFilasHijas)
            {
                dr = dt.NewRow();
                // Añadimos los datos de la fila actual
                dr["Pedido"] = Convert.ToInt32(drFila["Pedido"]);
                dr["Cliente"] = (drFila["Cliente"] == DBNull.Value) ? "" : Convert.ToString(drFila["Cliente"]);
                dr["Vendedor"] = (drFila["IdEmpleado"] == DBNull.Value) ? "" : drFila["IdEmpleado"].ToString();
                dr["Fecha de pedido"] = (drFila["Fecha de pedido"] == DBNull.Value) ? "" : FormatoFecha(Convert.ToDateTime(drFila["Fecha de pedido"]));
                dr["Fecha requerido"] = (drFila["Fecha requerido"] == DBNull.Value) ? "" : FormatoFecha(Convert.ToDateTime(drFila["Fecha requerido"]));
                dr["Fecha de envío"] = (drFila["Fecha de envío"] == DBNull.Value) ? "" : FormatoFecha(Convert.ToDateTime(drFila["Fecha de envío"]));
                //dr["Fecha de envío"] = (drFila["Fecha de envío"] == DBNull.Value) ? "" : Convert.ToString(drFila["Fecha de envío"]);
                dr["Total"] = (drFila["Total"] == DBNull.Value) ? 0 : Convert.ToDecimal(drFila["Total"]);
                dt.Rows.Add(dr);
            }
            //Cargar los valores al datagridview
            dgvPedidos.DataSource = dt;
            ConfDgvPedidos();
            Utils.ActualizarBarraDeEstado($"Se encontraron {dgvVendedores.RowCount} registros en vendedores, {dgvPedidos.RowCount} registros de pedidos del vendedor {dgvVendedores.CurrentRow.Cells["Nombres"].Value} {dgvVendedores.CurrentRow.Cells["Apellidos"].Value}", this);
        }

        private string FormatoFecha(DateTime fecha)
        {
            string strFecha = string.Format("{0:dd}", fecha)+" de "+string.Format("{0:MMM}", fecha)+" de "+string.Format("{0:yyyy}", fecha)+"\n"+string.Format("{0:hh}", fecha)+":"+string.Format("{0:mm}", fecha)+":"+string.Format("{0:ss}", fecha)+" "+string.Format("{0:tt}", fecha);
            return strFecha;
        }

        private void ConfDgvPedidos()
        {
            dgvPedidos.Columns["Vendedor"].Visible = false;
            // aqui no se aplica el formato de fecha por que devuelve la cadena 01/01/0001 si el valor de la fecha es nula por eso se cambio el flujo del programa para que muestre una cadena vacia si el valor de la fecha es nulo
            //dgvPedidos.Columns["Fecha de pedido"].DefaultCellStyle.Format = "dd \"de\" MMM \"de\" yyyy\n hh:mm:ss tt";
            //dgvPedidos.Columns["Fecha requerido"].DefaultCellStyle.Format = "dd \"de\" MMM \"de\" yyyy\n hh:mm:ss tt";
            //dgvPedidos.Columns["Fecha de envío"].DefaultCellStyle.Format = "dd \"de\" MMM \"de\" yyyy\n hh:mm:ss tt";
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

        private void FrmPedidosVendedorDetalle_Shown(object sender, EventArgs e)
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
            dgvDetalle.DataSource = null;
            dgvDetalle.Refresh();
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
            dc = new DataColumn("Pedido", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("Categoría", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("Producto", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("Precio", typeof(decimal));
            dt.Columns.Add(dc);
            dc = new DataColumn("Cantidad", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("Descuento", typeof(decimal));
            dt.Columns.Add(dc);
            dc = new DataColumn("Importe", typeof(decimal));
            dt.Columns.Add(dc);
            dc = new DataColumn("Sub total", typeof(decimal));
            dt.Columns.Add(dc);
            dc = new DataColumn("Total", typeof(decimal));
            dt.Columns.Add(dc);
            dc = new DataColumn("Proveedor", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("Nombre de contacto", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("País", typeof(string));
            dt.Columns.Add(dc);
            dt.Columns.Add(new DataColumn("Teléfono", typeof(string)));
            dt.Columns.Add(new DataColumn("Fax", typeof(string)));
            //Rellenar el datatable con valores de las filas hijas
            decimal subTotal = 0, total = 0;
            DataRow dr;
            foreach (DataRow drFila in drFilasHijas)
            {
                dr = dt.NewRow();
                //añadimos los datos de la fila actual
                dr["Pedido"] = drFila["Pedido"];
                dr["Categoría"] = drFila["Categoría"];
                dr["Producto"] = drFila["Producto"];
                dr["Precio"] = drFila["Precio"];
                dr["Cantidad"] = drFila["Cantidad"];
                dr["Descuento"] = drFila["Descuento"];
                dr["Importe"] = drFila["Importe"];
                subTotal += Convert.ToDecimal(drFila["Importe"]);
                dr["Sub total"] = subTotal;
                dr["Proveedor"] = drFila["Proveedor"];
                dr["Nombre de contacto"] = drFila["Nombre de contacto"];
                dr["País"] = drFila["País"];
                dr["Teléfono"] = drFila["Teléfono"];
                dr["Fax"] = drFila["Fax"];
                dt.Rows.Add(dr);
            }
            total = subTotal;
            foreach (DataRow drFila in dt.Rows)
                drFila["Total"] = total;
            // cargar los valores al datagridview
            dgvDetalle.DataSource = dt;
            ConfDgvDetalle();
            Utils.ActualizarBarraDeEstado($"Se encontraron {dgvVendedores.RowCount} registros en vendedores, {dgvPedidos.RowCount} registros de pedidos del vendedor {dgvVendedores.CurrentRow.Cells["Nombres"].Value} {dgvVendedores.CurrentRow.Cells["Apellidos"].Value} y {dgvDetalle.RowCount} registros del detalle del pedido N° {dgvPedidos.CurrentRow.Cells["Pedido"].Value}", this);
        }

        private void ConfDgvDetalle()
        {
            dgvDetalle.Columns["Pedido"].Visible = false;
            dgvDetalle.Columns["Precio"].DefaultCellStyle.Format = "c";
            dgvDetalle.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Descuento"].DefaultCellStyle.Format = "n2";
            dgvDetalle.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Importe"].DefaultCellStyle.Format = "c";
            dgvDetalle.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["Sub total"].DefaultCellStyle.Format = "c";
            dgvDetalle.Columns["Sub total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["Total"].DefaultCellStyle.Format = "c";
            dgvDetalle.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void FrmPedidosVendedorDetalle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.ActualizarBarraDeEstado("Activo", this);
        }

    }
}
