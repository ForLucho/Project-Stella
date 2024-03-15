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
using Common.Cache;
using Domain;
using System.Runtime.InteropServices;

namespace Presentation
{
    public partial class Inforo : Form
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
        public Inforo()
        {
            InitializeComponent();
        }

        string Month = "";
        string Year = "";
        string day = "";
        string id = "";
        string usuario = "";

        private void IndexForo_Load(object sender, EventArgs e)
        {
            Showforum();
            FormForo.Visible = true;
            FormForo.Location = new Point(0, 0);
            FormPublicacion.Visible = false;
            FormPublicacion.Location = new Point(824, 0);
            FormUsuario.Visible = false;
            FormUsuario.Location = new Point(824, 0);
            txtitulo.AutoSize = false;
            txtitulo.Size = new Size(703, 25);
            txtcontenido.AutoSize = false;
            txtcontenido.Size = new Size(550, 65);
            txtcomentario.AutoSize = false;
            txtcomentario.Size = new Size(580, 60);

            panelcrearpost.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelcrearpost.Width, panelcrearpost.Height, 20, 20));
            paneldetalle.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, paneldetalle.Width, paneldetalle.Height, 20, 20));
            panelcontenido.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelcontenido.Width, panelcontenido.Height, 20, 20));
            panelcomentarios.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelcomentarios.Width, panelcomentarios.Height, 20, 20));
            panelinicioforo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelinicioforo.Width, panelinicioforo.Height, 20, 20));
            panelpost.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelpost.Width, panelpost.Height, 20, 20));
            panel15.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel15.Width, panel15.Height, 20, 20));
            panel16.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel16.Width, panel16.Height, 15, 15));
            panel20.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel20.Width, panel20.Height, 15, 15));
            panel21.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel21.Width, panel21.Height, 20, 20));
            panel22.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel22.Width, panel22.Height, 15, 15));
            panel23.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel23.Width, panel23.Height, 20, 20));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            btnresponder.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnresponder.Width, btnresponder.Height, 20, 20));
            btneliminarespuesta.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btneliminarespuesta.Width, btneliminarespuesta.Height, 20, 20));
            btneliminar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btneliminar.Width, btneliminar.Height, 20, 20));
            btnpublicar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnpublicar.Width, btnpublicar.Height, 20, 20));
            txtcomentario.Size= new Size(580, 60);
            contenido.Size = new Size(727, 83);
        }
        private void Showforum()
        {
            ActiviModel objeto = new ActiviModel();
            dataGridView1.DataSource = objeto.MostrarForo();
        }

        private void btnpublicar_Click(object sender, EventArgs e)
        {
            if (txtitulo.Text != "Introduzca el título (obligatorio)" && txtcontenido.Text != "Por favor, introduzca el texto")
            {
                day = DateTime.Now.ToString("dd");
                Month = DateTime.Now.ToString("MM");
                Year = DateTime.Now.ToString("yyyy");
                id = UserLoginCache.ID_USUARIO;
                try
                {
                    objetoCN.InsertarPU(id, txtitulo.Text, day, Month, Year, txtcontenido.Text);
                    MessageBox.Show("Se inserto correctamente");
                    Month = "";
                    Year = "";
                    day = "";
                    Showforum();
                    txtitulo.Text = "Introduzca el título (obligatorio)";
                    txtcontenido.Text = "Por favor, introduzca el texto";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo insertar los datos por: " + ex);
                }
            }
            else
                MessageBox.Show("Es necesario rellenar todos los campos");

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection();
            string idcon = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            idcons.Text = idcon;
            FormForo.Visible = false;
            FormForo.Location = new Point(824, 0);
            FormPublicacion.Visible = true;
            FormPublicacion.Location = new Point(0, 0);
            FormUsuario.Visible = false;
            FormUsuario.Location = new Point(824, 0);
            ShowPublicacion();
            CargarPublicacion();
            Showresp();
            txtitulo.Text = "Introduzca el título (obligatorio)";
            txtcontenido.Text = "Por favor, introduzca el texto";
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idco = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string idus = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                if (UserLoginCache.TIPOUSUARIO == "Usuario")
                {
                    if (idus == UserLoginCache.ID_USUARIO)
                    {
                        ActiviModel objacti = new ActiviModel();
                        objacti.DeleteCOPU(idco);
                        objacti.DeletePU(idco);
                        MessageBox.Show("Se elimino la publicación " + idco + " correctamente");
                        Showforum();
                    }
                    else
                    {
                        MessageBox.Show("Solo puedes eliminar tus propios posts");
                    }

                }
                else
                {
                    ActiviModel objacti = new ActiviModel();
                    objacti.DeleteCOPU(idco);
                    objacti.DeletePU(idco);
                    MessageBox.Show("Se elimino la publicación " + idco + " correctamente");
                    Showforum();
                }                
            }
            else
                MessageBox.Show("Debe seleccionar una actividad");
        }
        private void CargarPublicacion()
        {
            int ndia = PubliCache.DIACONS;
            int nmes = PubliCache.MESCONS;
            int nanio = PubliCache.ANIOCONS;
            string dia = Convert.ToString(ndia);
            string mes = Convert.ToString(nmes);
            string anio = Convert.ToString(nanio);
            usuario = PubliCache.ID_USUARIO;
            idusuario.Text = PubliCache.ID_USUARIO;
            titulo.Text = PubliCache.TITULO;
            fecha.Text = dia + "/" + mes + "/" + anio;
            contenido.Text = PubliCache.CONTENIDO;
        }
        private void ShowPublicacion()
        {
            string idcon = idcons.Text;
            ActiviModel mostrar = new ActiviModel();
            mostrar.MostrarPub(idcon);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string com = txtcomentario.Text;
            if (txtcomentario.Text != "Publica tu comentario ahora"){
                try
                {
                    if (com != "")
                    {
                        string idcon = idcons.Text;
                        string idusuario = UserLoginCache.ID_USUARIO;
                        string day = DateTime.Now.ToString("dd");
                        string Month = DateTime.Now.ToString("MM");
                        string Year = DateTime.Now.ToString("yyyy");
                        ActiviModel mostrar = new ActiviModel();
                        mostrar.InsertarCO(idcon, idusuario, com, day, Month, Year);
                        MessageBox.Show("Se inserto correctamente");
                        Showresp();
                        txtcomentario.Text = "Publica tu comentario ahora";
                    }
                    else
                        MessageBox.Show("Ingrese un valor para el comentario");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo insertar los datos por: " + ex);
                }
            }
            else
                MessageBox.Show("Es necesario llenar la respuesta");

        }
        private void Showresp()
        {
            string idcon = idcons.Text;
            ActiviModel objeto = new ActiviModel();
            dataGridView2.DataSource = objeto.MostrarResp(idcon);
        }

        private void btneliminarespuesta_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                string idpub = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string idcom = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                string idus = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                if (UserLoginCache.TIPOUSUARIO == "Usuario")
                {
                    if (idus == UserLoginCache.ID_USUARIO)
                    {
                        ActiviModel objacti = new ActiviModel();
                        objacti.DeleteCO(idpub, idcom);
                        MessageBox.Show("Se elimino el comentario " + idcom + " correctamente");
                        Showresp();
                    }
                    else
                    {
                        MessageBox.Show("Solo puedes eliminar tus propios comentarios");
                    }

                }
                else
                {
                    ActiviModel objacti = new ActiviModel();
                    objacti.DeleteCO(idpub, idcom);
                    MessageBox.Show("Se elimino el comentario " + idcom + " correctamente");
                    Showresp();
                }    
            }
            else
                MessageBox.Show("Debe seleccionar una actividad");
        }

        //FormUsuario
        private void PerfilUsuario_Load()
        {
            UserModel user = new UserModel();
            user.CargarUsuario(lblusuario.Text);
            lblnombre.Text = UserCache.NOMBRE;
            lblapellido.Text = UserCache.APELLIDO;
            lblcorreo.Text = UserCache.CORREO;
            lblpais.Text = UserCache.PAIS;
            lbltiposuario.Text = UserCache.TIPOUSUARIO;
            lbldescripcion.Text = UserCache.DESCRIPCION;
            int leermes = (int)UserCache.MESINICIO;
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

            lblfecha.Text = UserCache.DIAINICIO + " de " + txtmes + " del " + UserCache.ANIOINICIO;
            ShowMedalla();
        }
        private void ShowMedalla()
        {
            int medoro = 0;
            int medpla = 0;
            int medbro = 0;
            string idusuario = UserCache.ID_USUARIO;
            UserModel objeto = new UserModel();
            dataGridView3.DataSource = objeto.ShowMedallas(idusuario);
            int rows = dataGridView3.Rows.Count;
            int secu = rows - 2;
            for (int rowi = 0; rowi <= secu;)
            {
                string medalla = dataGridView3.Rows[rowi].Cells[1].Value.ToString();
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

        private void btncerrar_Click(object sender, EventArgs e)
        {
            FormForo.Visible = false;
            FormForo.Location = new Point(824, 0);
            FormPublicacion.Visible = true;
            FormPublicacion.Location = new Point(0, 0);
            FormUsuario.Visible = false;
            FormUsuario.Location = new Point(824, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormForo.Visible = true;
            FormForo.Location = new Point(0, 0);
            FormPublicacion.Visible = false;
            FormPublicacion.Location = new Point(824, 0);
            Showforum();
            txtcomentario.Text = "Publica tu comentario ahora";
        }

        private void panelperfil_Click(object sender, EventArgs e)
        {
            lblusuario.Text = usuario;
            FormForo.Visible = false;
            FormForo.Location = new Point(824, 0);
            FormPublicacion.Visible = false;
            FormPublicacion.Location = new Point(824, 0);
            FormUsuario.Visible = true;
            FormUsuario.Location = new Point(0, 0);
            PerfilUsuario_Load();
        }

        private void fecha_Click(object sender, EventArgs e)
        {
            lblusuario.Text = usuario;
            FormForo.Visible = false;
            FormForo.Location = new Point(824, 0);
            FormPublicacion.Visible = false;
            FormPublicacion.Location = new Point(824, 0);
            FormUsuario.Visible = true;
            FormUsuario.Location = new Point(0, 0);
            PerfilUsuario_Load();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            lblusuario.Text = usuario;
            FormForo.Visible = false;
            FormForo.Location = new Point(824, 0);
            FormPublicacion.Visible = false;
            FormPublicacion.Location = new Point(824, 0);
            FormUsuario.Visible = true;
            FormUsuario.Location = new Point(0, 0);
            PerfilUsuario_Load();
        }

        private void idusuario_Click(object sender, EventArgs e)
        {
            lblusuario.Text = usuario;
            FormForo.Visible = false;
            FormForo.Location = new Point(824, 0);
            FormPublicacion.Visible = false;
            FormPublicacion.Location = new Point(824, 0);
            FormUsuario.Visible = true;
            FormUsuario.Location = new Point(0, 0);
            PerfilUsuario_Load();
        }
        private void btnresponder_MouseHover(object sender, EventArgs e)
        {
            btnresponder.BackColor = Color.FromArgb(101, 126, 248);
            btnresponder.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void btnresponder_MouseLeave(object sender, EventArgs e)
        {
            btnresponder.BackColor = Color.FromArgb(225, 231, 255);
            btnresponder.ForeColor = Color.FromArgb(101, 126, 248);
        }

        private void txtcomentario_Enter(object sender, EventArgs e)
        {
            if (txtcomentario.Text == "Publica tu comentario ahora" +
                "")
            {
                txtcomentario.Text = "";

            }
        }

        private void txtcomentario_Leave(object sender, EventArgs e)
        {
            if (txtcomentario.Text == "")
            {
                txtcomentario.Text = "Publica tu comentario ahora";

            }
        }

        private void btnpublicar_Enter(object sender, EventArgs e)
        {
            btnresponder.BackColor = Color.FromArgb(101, 126, 248);
            btnresponder.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void btnpublicar_Leave(object sender, EventArgs e)
        {
            btnresponder.BackColor = Color.FromArgb(225, 231, 255);
            btnresponder.ForeColor = Color.FromArgb(101, 126, 248);
        }

        private void txtitulo_Enter(object sender, EventArgs e)
        {
            if (txtitulo.Text == "Introduzca el título (obligatorio)" +
                "")
            {
                txtitulo.Text = "";

            }
        }

        private void txtitulo_Leave(object sender, EventArgs e)
        {
            if (txtitulo.Text == "")
            {
                txtitulo.Text = "Introduzca el título (obligatorio)";

            }
        }

        private void txtcontenido_Enter(object sender, EventArgs e)
        {
            if (txtcontenido.Text == "Por favor, introduzca el texto" +
                "")
            {
                txtcontenido.Text = "";

            }
        }

        private void txtcontenido_Leave(object sender, EventArgs e)
        {
            if (txtcontenido.Text == "")
            {
                txtcontenido.Text = "Por favor, introduzca el texto";

            }
        }

        private void contenido_Click(object sender, EventArgs e)
        {

        }
    }
}
