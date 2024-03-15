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
    public partial class Login : Form
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
        public Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] 
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Form1_Load(object sender, EventArgs e)
        {
            btnlogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnlogin.Width, btnlogin.Height, 20, 20));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 20, 20));
            txtuser.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            txtuser.AutoSize = false;
            txtuser.Size = new Size(270, 30);
            txtpass.AutoSize = false;
            txtpass.Size = new Size(270, 30);

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtuser.Text != "Nombre de Usuario") {
                if (txtpass.Text != "Contraseña") {
                    UserModel user = new UserModel();
                    var validLogin = user.LoginUser(txtuser.Text, txtpass.Text);
                    if (validLogin == true) {
                        Index mainMenu = new Index();
                        mainMenu.Show();
                        mainMenu.BringToFront();
                        mainMenu.FormClosed += Logout;
                        this.Hide();
                    }
                    else{
                        msgError("Lo sentimos, las credenciales que estás usando no son válidas.");
                        txtpass.Text = "Contraseña";
                        txtpass.UseSystemPasswordChar = false;
                        txtuser.Focus();
                    }
                }
                else {
                    msgError("Es necesario ingresar una dirección de correo y contraseña.");
                }
            }
            else {
                msgError("Es necesario ingresar una dirección de correo y contraseña.");
            }
            

            
        }

        private void msgError(string msg) {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }
        private void Logout(object sender, FormClosedEventArgs e) {
            txtpass.Text = "Contraseña";
            txtpass.UseSystemPasswordChar = false;
            txtuser.Text = "Nombre de Usuario";
            lblError.Visible = false;
            this.Show();
        }


        private void txtuser_Enter(object sender, EventArgs e)
        {
            if(txtuser.Text== "Nombre de Usuario" +
                "") {
                txtuser.Text = "";

            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Nombre de Usuario";

            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña")
            {
                txtpass.Text = "";
                txtpass.UseSystemPasswordChar = true;

            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Contraseña";
                txtpass.UseSystemPasswordChar = false;

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
