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

namespace Presentation
{
    public partial class Creaejercicios : Form
    {
        ActiviModel objetoCN = new ActiviModel();
        public Creaejercicios()
        {
            InitializeComponent();
        }
        int rows = 0;
        int curr = 0;
        string idactividad = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            txtenunciado.AutoSize = false;
            txtenunciado.Size = new Size(474, 70);
            ActiviModel objeto = new ActiviModel();
            dataGridView1.DataSource = objeto.MostrarActi();
            rows = dataGridView1.Rows.Count;
            curr = rows - 2;
            idactividad= dataGridView1.Rows[curr].Cells[0].Value.ToString();
        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            if(txtenunciado.Text != "Enunciado" && txtrue.Text != "Opción Corresta" && txtfalse1.Text != "Opción Falsa" && txtfalse2.Text != "Opción Falsa" && txtfalse3.Text != "Opción Falsa")
            {
            try
            {
                objetoCN.InsertarEJ(idactividad, txtenunciado.Text, txtrue.Text, txtfalse1.Text, txtfalse2.Text, txtfalse3.Text);
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
                MessageBox.Show("Complete todos los campos");
            }
        }

        private void txtenunciado_Enter(object sender, EventArgs e)
        {
            if (txtenunciado.Text == "Enunciado" +
                "")
            {
                txtenunciado.Text = "";

            }
        }

        private void txtenunciado_Leave(object sender, EventArgs e)
        {
            if (txtenunciado.Text == "")
            {
                txtenunciado.Text = "Enunciado";

            }
        }

        private void txtrue_Enter(object sender, EventArgs e)
        {
            if (txtrue.Text == "Opción Corresta" +
                "")
            {
                txtrue.Text = "";

            }
        }

        private void txtrue_Leave(object sender, EventArgs e)
        {
            if (txtrue.Text == "")
            {
                txtrue.Text = "Opción Corresta";

            }
        }

        private void txtfalse1_Enter(object sender, EventArgs e)
        {
            if (txtfalse1.Text == "Opción Falsa" +
                "")
            {
                txtfalse1.Text = "";

            }
        }

        private void txtfalse1_Leave(object sender, EventArgs e)
        {
            if (txtfalse1.Text == "")
            {
                txtfalse1.Text = "Opción Falsa";

            }
        }

        private void txtfalse2_Enter(object sender, EventArgs e)
        {
            if (txtfalse2.Text == "Opción Falsa" +
                "")
            {
                txtfalse2.Text = "";

            }
        }

        private void txtfalse2_Leave(object sender, EventArgs e)
        {
            if (txtfalse2.Text == "")
            {
                txtfalse2.Text = "Opción Falsa";

            }
        }

        private void txtfalse3_Enter(object sender, EventArgs e)
        {
            if (txtfalse3.Text == "Opción Falsa" +
                "")
            {
                txtfalse3.Text = "";

            }
        }

        private void txtfalse3_Leave(object sender, EventArgs e)
        {
            if (txtfalse3.Text == "")
            {
                txtfalse3.Text = "Opción Falsa";

            }
        }
    }
}
