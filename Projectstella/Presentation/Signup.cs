using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace Presentation
{
    public partial class Signup : Form
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
        public Signup()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Signup_Load(object sender, EventArgs e)
        {
            btncontinuar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btncontinuar.Width, btncontinuar.Height, 20, 20));
            panelpais.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelpais.Width, panelpais.Height, 20, 20));
            panelnombre.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelnombre.Width, panelnombre.Height, 20, 20));
            panelapellido.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelapellido.Width, panelapellido.Height, 20, 20));
            panelusername.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelusername.Width, panelusername.Height, 20, 20));
            panelcorreo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelcorreo.Width, panelcorreo.Height, 20, 20));
            panelcontrasenia.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelcontrasenia.Width, panelcontrasenia.Height, 20, 20));

            txtpais.AutoSize = false;
            txtpais.Size = new Size(270, 30);
            txtnombre.AutoSize = false;
            txtnombre.Size = new Size(120, 30);
            txtapellido.AutoSize = false;
            txtapellido.Size = new Size(120, 30);
            txtusername.AutoSize = false;
            txtusername.Size = new Size(270, 30);
            txtcorreo.AutoSize = false;
            txtcorreo.Size = new Size(270, 30);
            txtcontrasenia.AutoSize = false;
            txtcontrasenia.Size = new Size(270, 30);
        }


        private void btniniciarsecion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btncontinuar_Click(object sender, EventArgs e)
        {
            string usuario = txtusername.Text;
            string pais = txtpais.Text;
            string correo = txtcorreo.Text;
            string nombre = txtnombre.Text;
            string apellido = txtapellido.Text;
            string contrasenia = txtcontrasenia.Text;
            string day = DateTime.Now.ToString("dd");
            string Month = DateTime.Now.ToString("MM");
            string Year = DateTime.Now.ToString("yyyy");
            string descripcion = "Soy una firma preestablecida";
            string tipo = "Usuario";
            UserModel mostrar = new UserModel();
            try
            {
                if (pais != "País" && nombre != "Nombre" && apellido != "Apellido" && usuario != "Nombre de Usuario" && correo != "Correo electrónico" && correo != "Contraseña")
                {    
                    mostrar.InsertUS(usuario, pais, correo, nombre, apellido, contrasenia, day, Month, Year, descripcion, tipo);
                }
                else
                {
                    MessageBox.Show("Es necesario completar todos los campos");
                }
                MessageBox.Show("Se inserto correctamente");
                Login login = new Login();
                login.Show();
                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("no se pudo insertar los datos por: " + ex);
            }
        }

        private void txtpais_Enter(object sender, EventArgs e)
        {
            if (txtpais.Text == "País" +
                "")
            {
                txtpais.Text = "";

            }
        }

        private void txtpais_Leave(object sender, EventArgs e)
        {
            if (txtpais.Text == "")
            {
                txtpais.Text = "País";

            }
        }

        private void txtnombre_Enter(object sender, EventArgs e)
        {
            if (txtnombre.Text == "Nombre" +
                "")
            {
                txtnombre.Text = "";

            }
        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                txtnombre.Text = "Nombre";

            }
        }

        private void txtapellido_Enter(object sender, EventArgs e)
        {
            if (txtapellido.Text == "Apellido" +
                "")
            {
                txtapellido.Text = "";

            }
        }

        private void txtapellido_Leave(object sender, EventArgs e)
        {
            if (txtapellido.Text == "")
            {
                txtapellido.Text = "Apellido";

            }
        }

        private void txtusername_Enter(object sender, EventArgs e)
        {
            if (txtusername.Text == "Nombre de Usuario" +
                "")
            {
                txtusername.Text = "";

            }
        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            if (txtusername.Text == "")
            {
                txtusername.Text = "Nombre de Usuario";

            }
        }

        private void txtcorreo_Enter(object sender, EventArgs e)
        {
            if (txtcorreo.Text == "Correo electrónico" +
                "")
            {
                txtcorreo.Text = "";

            }
        }

        private void txtcorreo_Leave(object sender, EventArgs e)
        {
            if (txtcorreo.Text == "")
            {
                txtcorreo.Text = "Correo electrónico";

            }
        }

        private void txtcontrasenia_Enter(object sender, EventArgs e)
        {
            if (txtcontrasenia.Text == "Contraseña")
            {
                txtcontrasenia.Text = "";
                txtcontrasenia.UseSystemPasswordChar = true;

            }
        }

        private void txtcontrasenia_Leave(object sender, EventArgs e)
        {
            if (txtcontrasenia.Text == "")
            {
                txtcontrasenia.Text = "Contraseña";
                txtcontrasenia.UseSystemPasswordChar = false;

            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btncerrar_MouseHover(object sender, EventArgs e)
        {
            btncerrar.BackColor = Color.FromArgb(213, 81, 45);
        }

        private void btncerrar_MouseLeave(object sender, EventArgs e)
        {
            btncerrar.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnminimizar_MouseHover(object sender, EventArgs e)
        {
            btnminimizar.BackColor = Color.FromArgb(53, 53, 53);
        }

        private void btnminimizar_MouseLeave(object sender, EventArgs e)
        {
            btnminimizar.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

    }
}
