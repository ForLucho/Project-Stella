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
    public partial class Indexactividades : Form
    {
        ActiviModel objetoCN = new ActiviModel();

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
        public Indexactividades()
        { 
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string usercheck = UserLoginCache.TIPOUSUARIO;
            if (usercheck == "Usuario")
            {
                btneliminar.Visible = false;
                btneliminar.Enabled = false;
                btncrear.Visible = false;
                btncrear.Enabled = false;
                dataGridView1.Size = new Size(285, 348);
                btnseleccionar.Location = new Point(18, 434);
            }
            btnseleccionar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnseleccionar.Width, btnseleccionar.Height, 20, 20));
            btneliminar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btneliminar.Width, btneliminar.Height, 20, 20));
            ShowActivities();
        }
        private void ShowActivities()
        {
            ActiviModel objeto = new ActiviModel();
            dataGridView1.DataSource = objeto.MostrarActi();
        }
        private void Updateactivities(object sender, FormClosedEventArgs e)
        {
            ShowActivities();
        }
        private void btncrear_Click(object sender, EventArgs e)
        {
            Creactividad Creactividad = new Creactividad();
            Creactividad.FormClosed += Updateactivities;
            this.Close();

        }

        private void btnseleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idac = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string nume = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                Actejercicios Actejercicios = new Actejercicios();
                Actejercicios.id.Text = idac;
                Actejercicios.Numexe.Text = nume;
                Actejercicios.Show();
            }
            else
                MessageBox.Show("Debe seleccionar una actividad");
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idac = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                ActiviModel objacti = new ActiviModel();
                UserModel objuser = new UserModel();
                objuser.DeleteME(idac);
                objacti.DeleteEJ(idac);
                objacti.DeleteAC(idac);
                MessageBox.Show("Se elimino la actividad "+idac+" correctamente");
                ShowActivities();
            }
            else
                MessageBox.Show("Debe seleccionar una actividad");
        }
    }
}
    