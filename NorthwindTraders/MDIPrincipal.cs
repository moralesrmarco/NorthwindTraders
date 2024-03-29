﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public partial class MDIPrincipal : Form
    {
        private int childFormNumber = 0;

        public ToolStripStatusLabel ToolStripEstado
        {
            get { return tsslEstado; }
            set { tsslEstado = value; }
        }

        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void tsmiListarProductosDap_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            frmProductosListarDap frmProductosListarDap = new frmProductosListarDap
            {
                MdiParent = this
            };
            frmProductosListarDap.Show();
        }

        private void tsmiListarProductosRdr_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            frmProductosListarRdr frmProductosListarRdr = new frmProductosListarRdr
            {
                MdiParent = this
            };
            frmProductosListarRdr.Show();
        }

        private void tsmiRegistrarProductos_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProductosRegistrarDap frmProductosRegistrarDap = new FrmProductosRegistrarDap
            {
                MdiParent = this
            };
            frmProductosRegistrarDap.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
        }

        private void tsmiEditarProductos_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProductosModificarDap frmProductosModificarDap = new FrmProductosModificarDap
            {
                MdiParent = this
            };
            frmProductosModificarDap.Show();
        }

        private void tsmiMantenimientoProductosCrud_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProductosCrudDap frmProductosCrudDap = new FrmProductosCrudDap
            {
                MdiParent = this
            };
            frmProductosCrudDap.Show();
        }

        private void tsmiEliminarProductos_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProductosEliminarDap frmProductosEliminarDap = new FrmProductosEliminarDap
            {
                MdiParent = this
            };
            frmProductosEliminarDap.Show();
        }

        private void tsmiRegistrarProductosRdr_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProductosRegistrarRdr frmProductosRegistrarRdr = new FrmProductosRegistrarRdr
            {
                MdiParent = this
            };
            frmProductosRegistrarRdr.Show();
        }

        private void tsmiModificarProductosRdr_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProductosModificarRdr frmProductosModificarRdr = new FrmProductosModificarRdr
            {
                MdiParent = this
            };
            frmProductosModificarRdr.Show();
        }

        private void tsmiEliminarProductosRdr_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProductosEliminarRdr frmProductosEliminarRdr = new FrmProductosEliminarRdr
            {
                MdiParent = this
            };
            frmProductosEliminarRdr.Show();
        }

        private void tsmiMantenimientoProductosCrudRdr_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProductosCrudRdr frmProductosCrudRdr = new FrmProductosCrudRdr
            {
                MdiParent = this
            };
            frmProductosCrudRdr.Show();
        }

        private void tsmiMantenimientoDeCategorías_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmCategoriasCrud frmCategoriasCrud = new FrmCategoriasCrud
            {
                MdiParent = this
            };
            frmCategoriasCrud.Show();
        }

        private void tsmiCategoriasProductos_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmCategoriasProductos frmCategoriasProductos = new FrmCategoriasProductos
            {
                MdiParent = this
            };
            frmCategoriasProductos.Show();
        }

        private void tsmiMantenimientoDeClientes_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmClientesCrud frmClientesCrud = new FrmClientesCrud
            {
                MdiParent = this
            };
            frmClientesCrud.Show();
        }

        private void tsmiMantenimientoDeEmpleados_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmEmpleadosCrud frmEmpleadosCrud = new FrmEmpleadosCrud
            {
                MdiParent = this
            };
            frmEmpleadosCrud.Show();
        }

        private void tsmiMantenimientoDeProveedores_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProveedoresCrud frmProveedoresCrud = new FrmProveedoresCrud
            {
                MdiParent = this
            };
            frmProveedoresCrud.Show();
        }

        private void tsmiMantenimientoDeProductos_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProductosCrud frmProductosCrud = new FrmProductosCrud
            {
                MdiParent = this
            };
            frmProductosCrud.Show();
        }

        private void tsmiMantenimientoDePedidos_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmPedidosCrud frmPedidosCrud = new FrmPedidosCrud
            {
                MdiParent = this
            };
            frmPedidosCrud.Show();
        }

        private void tsmiMantenimientoDeDetalleDePedidos_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmPedidosDetalleCrud frmPedidosDetalleCrud = new FrmPedidosDetalleCrud
            {
                MdiParent = this
            };
            frmPedidosDetalleCrud.Show();
        }

        private void tsmiConsultaDeProductosPorCategoría_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmCategoriasProductos frmCategoriasProductos = new FrmCategoriasProductos
            {
                MdiParent = this
            };
            frmCategoriasProductos.Show();
        }

        private void tsmiConsultaDeProductosPorProveedor_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProveedoresProductos frmProveedoresProductos = new FrmProveedoresProductos
            {
                MdiParent = this
            };
            frmProveedoresProductos.Show();
        }

        private void tsmiProveedoresProductos_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProveedoresProductos frmProveedoresProductos = new FrmProveedoresProductos
            {
                MdiParent = this
            };
            frmProveedoresProductos.Show();
        }

        private void tsmiConsultaAlfabeticaDeProductos_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProductosConsultaAlfabetica frmProductosConsultaAlfabetica = new FrmProductosConsultaAlfabetica
            {
                MdiParent = this
            };
            frmProductosConsultaAlfabetica.Show();
        }

        private void tsmiDirectorioDeClientesYProveedoresPorCiudad_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmClientesyProveedoresDirectorio frmClientesyProveedoresDirectorio = new FrmClientesyProveedoresDirectorio
            {
                MdiParent = this
            };
            frmClientesyProveedoresDirectorio.Show();
        }

        private void tsmiListadoDeProductosPorCategorias_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProductosPorCategoriasListado frmProductosPorCategoriasListado = new FrmProductosPorCategoriasListado
            {
                MdiParent = this
            };
            frmProductosPorCategoriasListado.Show();
        }

        private void tsmiProductosPorEncimaPrecioProm_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmProductosPorEncimaPrecioPromedio frmProductosPorEncimaPrecioPromedio = new FrmProductosPorEncimaPrecioPromedio
            {
                MdiParent = this
            };
            frmProductosPorEncimaPrecioPromedio.Show();
        }

        private void tsmiConsultaDePedidosPorCliente_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmPedidosCliente frmPedidosCliente = new FrmPedidosCliente
            {
                MdiParent = this
            };
            frmPedidosCliente.Show();
        }

        private void tsmiConsultaDeDetalleDePedidosPorCliente_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmPedidosClienteDetalle frmPedidosClienteDetalle = new FrmPedidosClienteDetalle
            {
                MdiParent = this
            };
            frmPedidosClienteDetalle.Show();
        }

        private void tsmiConsultaDePedidoPorVendedor_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmPedidosVendedor frmPedidosVendedor = new FrmPedidosVendedor
            {
                MdiParent = this
            };
            frmPedidosVendedor.Show();
        }

        private void tsmiConsultaDeDetalleDePedidosPorVendedor_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmPedidosVendedorDetalle frmPedidosVendedorDetalle = new FrmPedidosVendedorDetalle
            {
                MdiParent = this
            };
            frmPedidosVendedorDetalle.Show();
        }

        private void tsmiConsultaDetallePedidos_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmPedidosDetalleConsulta frmPedidosDetalleConsulta = new FrmPedidosDetalleConsulta
            {
                MdiParent = this
            };
            frmPedidosDetalleConsulta.Show();
        }

        private void tsmiConsultaDePedidosPorClientes_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmPedidosxClientes frmPedidosxClientes = new FrmPedidosxClientes
            {
                MdiParent = this
            };
            frmPedidosxClientes.Show();
        }

        private void tsmiConsultaDeDetalleDePedidosPorClientes_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmPedidosxClienteDetalle frmPedidosxClienteDetalle = new FrmPedidosxClienteDetalle
            {
                MdiParent = this
            };
            frmPedidosxClienteDetalle.Show();
        }

        private void tsmiConsultaDePedidosPorVendedor_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmPedidosxVendedor frmPedidosxVendedor = new FrmPedidosxVendedor
            {
                MdiParent = this
            };
            frmPedidosxVendedor.Show();
        }

        private void tsmiConsultaDeDetalleDePedidosPorVendedor2_Click(object sender, EventArgs e)
        {
            Utils.CerrarFormularios("MDIPrincipal");
            FrmPedidosxVendedorDetalle frmPedidosxVendedorDetalle = new FrmPedidosxVendedorDetalle
            {
                MdiParent = this
            };
            frmPedidosxVendedorDetalle.Show();
        }
    }
}
