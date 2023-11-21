using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTraders
{
    internal class Utils
    {

        public static void ActualizarBarraDeEstado(string mensaje, Form form)
        {
            MDIPrincipal mDIPrincipal = (MDIPrincipal)form.MdiParent;
            if (mensaje != "Activo")
                mDIPrincipal.ToolStripEstado.BackColor = SystemColors.ActiveCaption;
            else
                mDIPrincipal.ToolStripEstado.BackColor = SystemColors.Control;
            mDIPrincipal.ToolStripEstado.Text = mensaje;
            mDIPrincipal.Refresh();
        }

        public static void CerrarFormularios(string formDebeQuedarAbierto)
        {
            //Declaramos una lista de tipo Form
            List<Form> formularios = new List<Form>();
            //Recorremos Application.OpenForms el cual tiene la lista de formularios y metemos todos los forms en la lista que declaramos
            foreach (Form f in Application.OpenForms)
                formularios.Add(f);
            //recorremos la lista de formularios
            for(int i = 0; i < formularios.Count; i++)
            {
                //validamos que el nombre de los formularios sean distintos al unico formulario que queremos abierto, en este caso que se cierren todos los formularios que no sean FormLogin
                if (formularios[i].Name != formDebeQuedarAbierto)
                {
                    formularios[i].Close();
                }
            }
        }

        public static void ValidarDigitosSinPunto(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8);
        }

        public static void ValidarDigitosConPunto(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            // solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
            // Forzar que solo se capturen como maximo dos digito despues del punto decimal
            if (e.KeyChar != 8)
            {
                string numsDecimales = (sender as TextBox).Text + e.KeyChar;
                if ((sender as TextBox).Text.IndexOf('.') > -1)
                {
                    int posComienzo = (sender as TextBox).Text.IndexOf('.');
                    numsDecimales = numsDecimales.Substring(posComienzo, numsDecimales.Length - posComienzo);
                    if (numsDecimales.Length > 3)
                        e.Handled = true;
                }
            }
        }
    }
}
