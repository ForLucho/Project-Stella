using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Domain;
using Common.Cache;
using System.Runtime.InteropServices;

namespace Presentation
{

    public partial class Creactividad : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeft, // x-coordinate of upper-left corner
                int nTop, // y-coordinate of upper-left corner
                int nRight, // x-coordinate of lower-right corner
                int nBottom, // y-coordinate of lower-right corner
                int nWidthEllipse, // height of ellipse
                int nHeightEllipse // width of ellipse
             );
        ActiviModel objetoCN = new ActiviModel();
        
        public Creactividad()
        {
            InitializeComponent();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtnumenunciado_TextChanged(object sender, EventArgs e)
        {

        }
        private void Creactividad_Load(object sender, EventArgs e)
        {
            btncontinuar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btncontinuar.Width, btncontinuar.Height, 20, 20));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 20, 20));
            panel5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel5.Width, panel5.Height, 20, 20));
            panelexercise1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelexercise1.Width, panelexercise1.Height, 20, 20));
            panelexercise2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelexercise2.Width, panelexercise2.Height, 20, 20));
            panelexercise3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelexercise3.Width, panelexercise3.Height, 20, 20));
            panelexercise4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelexercise4.Width, panelexercise4.Height, 20, 20));
            panelexercise5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelexercise5.Width, panelexercise5.Height, 20, 20));
            panelexercise6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelexercise6.Width, panelexercise6.Height, 20, 20));

        }

        private void btncontinuar_Click(object sender, EventArgs e)
        {
            string usuario = UserLoginCache.ID_USUARIO;
            if (txtitulo.Text != "Titulo" && txtnumenunciado.Text != "Numero de enunciados" && txtdescripcion.Text != "Descripcion") {
                string numenunciado = txtnumenunciado.Text;
                int intnumenunciado = int.Parse(numenunciado.ToString());
                if (intnumenunciado <= 20)
                {
                    try
                    {
                        objetoCN.InsertarAC(txtitulo.Text, txtdescripcion.Text, txtnumenunciado.Text, usuario);
                        for (int i = 1; i <= intnumenunciado; i++)
                        {
                            Creaejercicios Form1 = new Creaejercicios();
                            Form1.ShowDialog();
                        }   
                        MessageBox.Show("Se inserto correctamente");
                        this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("no se pudo insertar los datos por: " + ex);
            }
                }
                else
                {
                    msgError("La cantidad maxima de ejercicios es de 20");
                }
            }
            else
            {
                msgError("Es necesario completar todos los campos");
            }
        }
        private void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }
        private void txtitulo_Enter(object sender, EventArgs e)
        {
            if (txtitulo.Text == "Titulo" +
                "")
            {
                txtitulo.Text = "";

            }
        }

        private void txtitulo_Leave(object sender, EventArgs e)
        {
            if (txtitulo.Text == "")
            {
                txtitulo.Text = "Titulo";

            }
        }

        private void txtnumenunciado_Enter(object sender, EventArgs e)
        {
            if (txtnumenunciado.Text == "Numero de enunciados" +
                "")
            {
                txtnumenunciado.Text = "";

            }
        }

        private void txtnumenunciado_Leave(object sender, EventArgs e)
        {
            if (txtnumenunciado.Text == "")
            {
                txtnumenunciado.Text = "Numero de enunciados";

            }
        }

        private void txtdescripcion_Enter(object sender, EventArgs e)
        {
            if (txtdescripcion.Text == "Descripcion" +
                "")
            {
                txtdescripcion.Text = "";

            }
        }

        private void txtdescripcion_Leave(object sender, EventArgs e)
        {
            if (txtdescripcion.Text == "")
            {
                txtdescripcion.Text = "Descripcion";

            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
