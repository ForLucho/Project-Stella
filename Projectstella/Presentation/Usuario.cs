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
    public partial class Usuario : Form
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
        public Usuario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUserData(); 
            btncancelar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btncancelar.Width, btncancelar.Height, 20, 20));
            btnguardar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnguardar.Width, btnguardar.Height, 20, 20));
            txtnombre.AutoSize = false;
            txtnombre.Size = new Size(440, 30);
            txtapellido.AutoSize = false;
            txtapellido.Size = new Size(440, 30);
            txtcorreo.AutoSize = false;
            txtcorreo.Size = new Size(440, 30);
            lbldescripcion.AutoSize = false;
            lbldescripcion.Size = new Size(415, 86);
            ShowMedalla();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void ShowMedalla()
        {
            int medoro = 0;
            int medpla = 0;
            int medbro = 0;
            string idusuario = UserLoginCache.ID_USUARIO;
            UserModel objeto = new UserModel();
            dataGridView1.DataSource = objeto.ShowMedallas(idusuario);
            int rows = dataGridView1.Rows.Count;
            int secu = rows - 2;
            for (int rowi = 0; rowi <= secu;)
            {
                string medalla = dataGridView1.Rows[rowi].Cells[1].Value.ToString();
                if (medalla == "Oro")
                {
                    medoro++;
                }
                else
                    if (medalla == "Plata")
                {
                    medpla++;
                }
                else
                    medbro++;
                rowi++;
            }
            string strimedoro = Convert.ToString(medoro);
            string strimedpla = Convert.ToString(medpla);
            string strimedbro = Convert.ToString(medbro);
            lblgold.Text = strimedoro;
            lblsilver.Text = strimedpla;
            lblbronze.Text = strimedbro;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void LoadUserData(){

            lblnombre.Text = UserLoginCache.NOMBRE;
            lblapellido.Text = UserLoginCache.APELLIDO;
            lblcorreo.Text = UserLoginCache.CORREO;
            lblusuario.Text = UserLoginCache.ID_USUARIO;
            lblpais.Text = UserLoginCache.PAIS;
            lbltiposuario.Text = UserLoginCache.TIPOUSUARIO;
            lbldescripcion.Text = UserLoginCache.DESCRIPCION;

            txtnombre.Text = UserLoginCache.NOMBRE;
            txtapellido.Text = UserLoginCache.APELLIDO;
            txtcorreo.Text = UserLoginCache.CORREO;
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

        private void linkeditar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel2.Visible = false;
            panel8.Visible = false;
            label1.Visible = false;
            lblpais.ForeColor = Color.LightSlateGray;
            lblfecha.ForeColor = Color.LightSlateGray;
            btnguardar.Enabled = true;
            btnguardar.Visible = true;
            btncancelar.Enabled = true;
            btncancelar.Visible = true;
            txtdescripcion.Enabled = true;
            txtdescripcion.Visible = true;
            txtnombre.Enabled = true;
            txtnombre.Visible = true;
            txtapellido.Enabled = true;
            txtapellido.Visible = true;
            txtcorreo.Enabled = true;
            txtcorreo.Visible = true;
            lbldescripcion.Visible = false;
            lblnombre.Visible = false;
            lblapellido.Visible = false;
            lblcorreo.Visible = false;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel8.Visible = true;
            label1.Visible = true;
            lblpais.ForeColor = Color.White;
            lblfecha.ForeColor = Color.White;
            btnguardar.Enabled = false;
            btnguardar.Visible = false;
            btncancelar.Enabled = false;
            btncancelar.Visible = false;
            txtdescripcion.Enabled = false;
            txtdescripcion.Visible = false;
            txtnombre.Enabled = false;
            txtnombre.Visible = false;
            txtapellido.Enabled = false;
            txtapellido.Visible = false;
            txtcorreo.Enabled = false;
            txtcorreo.Visible = false;
            lbldescripcion.Visible = true;
            lblnombre.Visible = true;
            lblapellido.Visible = true;
            lblcorreo.Visible = true;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            var userModel = new UserModel(
                idusuario: UserLoginCache.ID_USUARIO,
                contrasenia: txtcontrasenia.Text,
                descripcion: txtdescripcion.Text,
                nombre: txtnombre.Text,
                apellido: txtapellido.Text,
                correo: txtcorreo.Text);
            var result = userModel.editUserProfile();
            Usuario userform = new Usuario();
            MessageBox.Show(result);
            LoadUserData();

            panel2.Visible = true;
            panel8.Visible = true;
            label1.Visible = true;
            lblpais.ForeColor = Color.White;
            lblfecha.ForeColor = Color.White;
            btnguardar.Enabled = false;
            btnguardar.Visible = false;
            btncancelar.Enabled = false;
            btncancelar.Visible = false;
            txtdescripcion.Enabled = false;
            txtdescripcion.Visible = false;
            txtnombre.Enabled = false;
            txtnombre.Visible = false;
            txtapellido.Enabled = false;
            txtapellido.Visible = false;
            txtcorreo.Enabled = false;
            txtcorreo.Visible = false;
            lbldescripcion.Visible = true;
            lblnombre.Visible = true;
            lblapellido.Visible = true;
            lblcorreo.Visible = true;
        }

        private void Usuario_Enter(object sender, EventArgs e)
        {
            ShowMedalla();
        }
    }
}

