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

namespace Presentation
{
    public partial class Actividades : Form
    {
        public Actividades()
        {
            InitializeComponent();
        }
        private void AbrirCreactividad(object sender, FormClosedEventArgs e)
        {
            AbrirFormActIndex<Creactividad>();
        }
        private void AbrirIndexactividad(object sender, FormClosedEventArgs e)
        {
            AbrirFormActCrear<Indexactividades>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AbrirFormActCrear<Indexactividades>();

        }
        public void AbrirFormActCrear<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = contenedoract.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la coleccion el formulario
                                                                                   //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.FormClosed += AbrirCreactividad;
                formulario.TopLevel = false;
                contenedoract.Controls.Add(formulario);
                contenedoract.Tag = formulario;              
                formulario.Show();
                formulario.BringToFront();
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }
        private void AbrirFormActIndex<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = contenedoract.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la coleccion el formulario
                                                                                  //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.FormClosed += AbrirIndexactividad;
                formulario.TopLevel = false;
                contenedoract.Controls.Add(formulario);
                contenedoract.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }


    }

}
