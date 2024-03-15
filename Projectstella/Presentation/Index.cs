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

namespace Presentation
{
    public partial class Index : Form
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
        public Index()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Form1_Load(object sender, EventArgs e)
        {
            AbrirFormulario<Inicio>();
            btnmore.Visible = true;
            btnmore.Location = new Point(195, 490);
            btnmore.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnmore.Width, btnmore.Height, 20, 20));

        }
        

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inicio>();
            btnmore.Visible = true;
            btnmore.Location= new Point(195, 490);
        }

        private void btnactividad_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Actividades>();
            btnmore.Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Foro>();
            btnmore.Visible = false;
        }

        private void btnperfil_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Usuario>();
            btnmore.Visible = false;
        }
        //private void linkperfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    AbrirFormHija(new Editusuario());
        //}
        //private void AbrirFormHija(object formhija) {
        //    if (this.contenedor.Controls.Count > 0)
        //        this.contenedor.Controls.RemoveAt(0);
        //    Form fh = formhija as Form;
        //    fh.TopLevel = false;
        //    fh.Dock = DockStyle.Fill;
        //    this.contenedor.Controls.Add(fh);
        //    this.contenedor.Tag = fh;
        //    fh.Show();
        //}
        public void AbrirFormulario<MiForm>()where MiForm : Form, new(){
            Form formulario;
            formulario = contenedor.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la coleccion el formulario
            //si el formulario/instancia no existe
            if (formulario == null){
                formulario = new MiForm();
                formulario.TopLevel = false;
                contenedor.Controls.Add(formulario);
                contenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();

            }
            //si el formulario/instancia existe
            else {
                formulario.BringToFront();
                formulario.Focus();
            }
        }
        private void btnmore_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Actividades>();
            btnmore.Visible = false;
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
    }
}

