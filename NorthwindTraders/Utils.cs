using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NorthwindTraders
{
    public class Utils
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

        public static void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor, Form form)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                g.Clear(form.BackColor);

                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }
    }
}
