using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Foro : Form
    {
        public Foro()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AbrirFormForo<Inforo>();
        }  
        public void AbrirFormForo<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = contenedorforo.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la coleccion el formulario
                                                                                  //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                contenedorforo.Controls.Add(formulario);
                contenedorforo.Tag = formulario;
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
