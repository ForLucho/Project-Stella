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
using Common.Cache;
using Domain;

namespace Presentation
{
    public partial class Editusuario : Form
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
        public Editusuario()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtdescripcion.AutoSize = false;
            txtdescripcion.Size = new Size(684, 86);
            txtnombre.AutoSize = false;
            txtnombre.Size = new Size(631, 30);
            txtapellido.AutoSize = false;
            txtapellido.Size = new Size(631, 30);
            txtcorreo.AutoSize = false;
            txtcorreo.Size = new Size(631, 30);
            btnguardar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnguardar.Width, btnguardar.Height, 20, 20));
            btncancelar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btncancelar.Width, btncancelar.Height, 20, 20));
            LoadUserData();        
        }
        private void LoadUserData()
        {
            txtnombre.Text = UserLoginCache.NOMBRE;
            txtapellido.Text = UserLoginCache.APELLIDO;
            txtcorreo.Text = UserLoginCache.CORREO;
            lblusuario.Text = UserLoginCache.ID_USUARIO;
            lblpais.Text = UserLoginCache.PAIS;
            lbltiposuario.Text = UserLoginCache.TIPOUSUARIO;
            txtdescripcion.Text = UserLoginCache.DESCRIPCION;
            txtcontrasenia.Text = UserLoginCache.CONTRASENIA;
            int leermes = (int)UserLoginCache.MESINICIO;
            string txtmes = "";
            if (leermes == 1)
            {
                txtmes = "enero";
            }
            if (leermes == 2)
            {
                txtmes = "febrero";
            }
            if (leermes == 3)
            {
                txtmes = "marzo";
            }
            if (leermes == 4)
            {
                txtmes = "abril";
            }
            if (leermes == 5)
            {
                txtmes = "mayo";
            }
            if (leermes == 6)
            {
                txtmes = "junio";
            }
            if (leermes == 7)
            {
                txtmes = "julio";
            }
            if (leermes == 8)
            {
                txtmes = "agosto";
            }
            if (leermes == 9)
            {
                txtmes = "setiembre";
            }
            if (leermes == 10)
            {
                txtmes = "octubre";
            }
            if (leermes == 11)
            {
                txtmes = "noviembre";
            }
            if (leermes == 12)
            {
                txtmes = "diciembre";
            }

            lblfecha.Text = UserLoginCache.DIAINICIO + " de " + txtmes + " del " + UserLoginCache.ANIOINICIO;
        }
        private void reset(){
            LoadUserData();
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            reset();
            this.Close();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            var userModel = new UserModel(
                idusuario:UserLoginCache.ID_USUARIO,
                contrasenia:txtcontrasenia.Text,
                descripcion:txtdescripcion.Text,
                nombre:txtnombre.Text,
                apellido:txtapellido.Text,
                correo:txtcorreo.Text);
            var result = userModel.editUserProfile();
            Usuario userform = new Usuario();
            MessageBox.Show(result);
            reset(); 
            this.Close();
        }
    }
}
