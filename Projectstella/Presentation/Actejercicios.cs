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
    public partial class Actejercicios : Form
    {
        string correct = "";
        string numejetxt = "";
        int numactu = 1;
        int rowi = -1;
        int numeje = 0;
        int corans = 0;
        int incans = 0;

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

        public Actejercicios()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            corans = 0;
            incans = 0;
            panelexercise1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelexercise1.Width, panelexercise1.Height, 20, 20));
            panelexercise2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelexercise2.Width, panelexercise2.Height, 20, 20));
            panelexercise3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelexercise3.Width, panelexercise3.Height, 20, 20));
            panelexercise4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelexercise4.Width, panelexercise4.Height, 20, 20));
            panelexercise5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelexercise5.Width, panelexercise5.Height, 20, 20));
            panelexercise6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelexercise6.Width, panelexercise6.Height, 20, 20));
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 15, 15));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 20, 20));
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 15, 15));
            panel5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel5.Width, panel5.Height, 20, 20));
            panel6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel6.Width, panel6.Height, 15, 15));
            panel7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel7.Width, panel7.Height, 20, 20));
            panel8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel8.Width, panel8.Height, 15, 15));
            

            numejetxt = Numexe.Text;
            numeje = Convert.ToInt32(numejetxt);
            ShowTableAct();
            ShowEjercicios();
            CargarEjercicios();     
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panelexercise1.ClientRectangle, Color.DarkBlue, ButtonBorderStyle.Solid);
        }
        private void ShowTableAct()
        {
            string ideje = id.Text;
            ActiviModel objeto = new ActiviModel();
            dataGridView1.DataSource = objeto.MostrarTablaEjer(ideje);
        }
        private void ShowEjercicios()
        {
            if (numactu <= numeje)
            {
            string idac = id.Text;
            rowi++;
            string ideje = dataGridView1.Rows[rowi].Cells[0].Value.ToString();
            ActiviModel mostrar = new ActiviModel();
            mostrar.MostrarEje(idac,ideje);
            }
        }
        private void CargarEjercicios()
        {
            Ejeactual.Text = Convert.ToString(numactu);       
            if (numactu <= numeje) {
            panel1.BackColor = Color.FromArgb(223, 216, 206);
            panel2.BackColor = Color.FromArgb(238, 229, 220);
            panel3.BackColor = Color.FromArgb(223, 216, 206);
            panel4.BackColor = Color.FromArgb(238, 229, 220);
            panel5.BackColor = Color.FromArgb(223, 216, 206);
            panel6.BackColor = Color.FromArgb(238, 229, 220);
            panel7.BackColor = Color.FromArgb(223, 216, 206);
            panel8.BackColor = Color.FromArgb(238, 229, 220);
            correct = ActiviEjerCache.OPTIONTRUE;
            lblenunciado.Text = ActiviEjerCache.ENUNCIADO;
            Random random = new Random();
            int numt = random.Next(1, 5);
            if (numt == 1)
            {
                lbloption1.Text = ActiviEjerCache.OPTIONTRUE;
                option1.Text = ActiviEjerCache.OPTIONTRUE;
                }
            else
                 if (numt == 2)
                 {
                    lbloption2.Text = ActiviEjerCache.OPTIONTRUE;
                    option2.Text = ActiviEjerCache.OPTIONTRUE;
                }
                 else
                     if (numt == 3)
                     {
                        lbloption3.Text = ActiviEjerCache.OPTIONTRUE;
                        option3.Text = ActiviEjerCache.OPTIONTRUE;
                     }
                      else
                          {
                              lbloption4.Text = ActiviEjerCache.OPTIONTRUE;
                              option4.Text = ActiviEjerCache.OPTIONTRUE;
                          }

            int control = 1;
            int numf1 = 0;
            for (int i = 0; i < control;)
            {
            numf1 = random.Next(1, 5);
            if (numf1 != numt)
            {
                if (numf1 == 1)
                {
                    lbloption1.Text = ActiviEjerCache.OPTIONFALSE1;
                    option1.Text = ActiviEjerCache.OPTIONFALSE1;
                    control = 0;
                }
                else
                    if (numf1== 2)
                {
                    lbloption2.Text = ActiviEjerCache.OPTIONFALSE1;
                    option2.Text = ActiviEjerCache.OPTIONFALSE1;
                    control = 0;
                }
                else
                    if (numf1 == 3)
                {
                    lbloption3.Text = ActiviEjerCache.OPTIONFALSE1;
                    option3.Text = ActiviEjerCache.OPTIONFALSE1;
                    control = 0;
                }
                else
                {
                    lbloption4.Text = ActiviEjerCache.OPTIONFALSE1;
                    option4.Text = ActiviEjerCache.OPTIONFALSE1;
                    control = 0;
                }
            }
            }

            control = 1;
            int numf2 = 0;
            for (int i = 0; i < control;)
            {
            numf2 = random.Next(1, 5);
                if (numf2 != numt && numf2 != numf1)
            {
                if (numf2 == 1)
                {
                    lbloption1.Text = ActiviEjerCache.OPTIONFALSE2;
                    option1.Text = ActiviEjerCache.OPTIONFALSE2;
                    control = 0;
                }
                else
                    if (numf2 == 2)
                {
                    lbloption2.Text = ActiviEjerCache.OPTIONFALSE2;
                    option2.Text = ActiviEjerCache.OPTIONFALSE2;
                    control = 0;
                }
                else
                    if (numf2 == 3)
                {
                    lbloption3.Text = ActiviEjerCache.OPTIONFALSE2;
                    option3.Text = ActiviEjerCache.OPTIONFALSE2;
                    control = 0;
                }
                else
                {
                    lbloption4.Text = ActiviEjerCache.OPTIONFALSE2;
                    option4.Text = ActiviEjerCache.OPTIONFALSE2;
                    control = 0;
                }
            }
            }

            control = 1;
            int numf3 = 0;
            for (int i = 0; i < control;)
            {
            numf3 = random.Next(1, 5);
                if (numf3 != numt && numf3 != numf1 && numf3 != numf2)
            {
                if (numf3 == 1)
                {
                    lbloption1.Text = ActiviEjerCache.OPTIONFALSE3;
                    option1.Text = ActiviEjerCache.OPTIONFALSE3;
                    control = 0;
                }
                else
                    if (numf3 == 2)
                {
                    lbloption2.Text = ActiviEjerCache.OPTIONFALSE3;
                    option2.Text = ActiviEjerCache.OPTIONFALSE3;
                    control = 0;
                }
                else
                    if (numf3 == 3)
                {
                    lbloption3.Text = ActiviEjerCache.OPTIONFALSE3;
                    option3.Text = ActiviEjerCache.OPTIONFALSE3;
                    control = 0;
                }
                else
                {
                    lbloption4.Text = ActiviEjerCache.OPTIONFALSE3;
                    option4.Text = ActiviEjerCache.OPTIONFALSE3;
                    control = 0;
                }
            }
            }
            numactu++;
            }
            else
            {
                if (corans == numeje)
                {
                    string medposs = "Oro";
                    string idusuario= UserLoginCache.ID_USUARIO;
                    string idactividad = id.Text;
                    MessageBox.Show("Medalla de Oro");
                    UserModel mostrar = new UserModel();
                    mostrar.InsertME(medposs, idusuario, idactividad);
                }
                else
                    if(incans <= corans)
                    {
                        string medposs = "Plata";
                        string idusuario= UserLoginCache.ID_USUARIO;
                        string idactividad = id.Text;
                        MessageBox.Show("Medalla de Plata");
                        UserModel mostrar = new UserModel();
                        mostrar.InsertME(medposs, idusuario, idactividad);
                    }
                    else
                        if (corans < incans)
                        {
                            string medposs = "Bronce";
                            string idusuario= UserLoginCache.ID_USUARIO;
                            string idactividad = id.Text;
                            MessageBox.Show("Medalla de Bronce");
                            UserModel mostrar = new UserModel();
                            mostrar.InsertME(medposs, idusuario, idactividad);
                        }
            this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            lbloption1.Enabled = true;
            lbloption2.Enabled = true;
            lbloption3.Enabled = true;
            lbloption4.Enabled = true;
            lbloption1.Visible = true;
            lbloption2.Visible = true;
            lbloption3.Visible = true;
            lbloption4.Visible = true;
            option1.Visible = false;
            option2.Visible = false;
            option3.Visible = false;
            option4.Visible = false;
            picstella.Visible = true;
            pictcorrect.Visible = false;
            picincorrect.Visible = false;
            ShowEjercicios();
            CargarEjercicios();
            
        }

        private void lbloption1_Click_1(object sender, EventArgs e)
        {
            if (lbloption1.Text == correct)
            {
                panel1.BackColor = Color.FromArgb(161, 168, 135);
                panel2.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                pictcorrect.Visible = true;
                corans++; 
            }
            else
                if (lbloption2.Text == correct)
            {
                panel1.BackColor = Color.FromArgb(223, 165, 135);
                panel2.BackColor = Color.FromArgb(237, 217, 206);
                panel3.BackColor = Color.FromArgb(161, 168, 135);
                panel4.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                picincorrect.Visible = true;
                incans++;
            }
            else
                if (lbloption3.Text == correct)
            {
                panel1.BackColor = Color.FromArgb(223, 165, 135);
                panel2.BackColor = Color.FromArgb(237, 217, 206);
                panel5.BackColor = Color.FromArgb(161, 168, 135);
                panel6.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                picincorrect.Visible = true;
                incans++;
            }
            else
                if (lbloption4.Text == correct)
            {
                panel1.BackColor = Color.FromArgb(223, 165, 135);
                panel2.BackColor = Color.FromArgb(237, 217, 206);
                panel7.BackColor = Color.FromArgb(161, 168, 135);
                panel8.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                picincorrect.Visible = true;
                incans++;
            }
        }

        private void lbloption2_Click_1(object sender, EventArgs e)
        {
            if (lbloption2.Text == correct)
            {
                panel3.BackColor = Color.FromArgb(161, 168, 135);
                panel4.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                pictcorrect.Visible = true;
                corans++;
            }
            else
                if (lbloption1.Text == correct)
            {
                panel3.BackColor = Color.FromArgb(223, 165, 135);
                panel4.BackColor = Color.FromArgb(237, 217, 206);
                panel1.BackColor = Color.FromArgb(161, 168, 135);
                panel2.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                picincorrect.Visible = true;
                incans++;
            }
            else
                if (lbloption3.Text == correct)
            {
                panel3.BackColor = Color.FromArgb(223, 165, 135);
                panel4.BackColor = Color.FromArgb(237, 217, 206);
                panel5.BackColor = Color.FromArgb(161, 168, 135);
                panel6.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                picincorrect.Visible = true;
                incans++;
            }
            else
                if (lbloption4.Text == correct)
            {
                panel3.BackColor = Color.FromArgb(223, 165, 135);
                panel4.BackColor = Color.FromArgb(237, 217, 206);
                panel7.BackColor = Color.FromArgb(161, 168, 135);
                panel8.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                picincorrect.Visible = true;
                incans++;
            }
        }

        private void lbloption3_Click_1(object sender, EventArgs e)
        {
            if (lbloption3.Text == correct)
            {
                panel5.BackColor = Color.FromArgb(161, 168, 135);
                panel6.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                pictcorrect.Visible = true;
                corans++;
            }
            else
                if (lbloption1.Text == correct)
            {
                panel5.BackColor = Color.FromArgb(223, 165, 135);
                panel6.BackColor = Color.FromArgb(237, 217, 206);
                panel1.BackColor = Color.FromArgb(161, 168, 135);
                panel2.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                picincorrect.Visible = true;
                incans++;
            }
            else
                if (lbloption2.Text == correct)
            {
                panel5.BackColor = Color.FromArgb(223, 165, 135);
                panel6.BackColor = Color.FromArgb(237, 217, 206);
                panel3.BackColor = Color.FromArgb(161, 168, 135);
                panel4.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                picincorrect.Visible = true;
                incans++;
            }
            else
                if (lbloption4.Text == correct)
            {
                panel5.BackColor = Color.FromArgb(223, 165, 135);
                panel6.BackColor = Color.FromArgb(237, 217, 206);
                panel7.BackColor = Color.FromArgb(161, 168, 135);
                panel8.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                picincorrect.Visible = true;
                incans++;
            }
        }

        private void lbloption4_Click_1(object sender, EventArgs e)
        {
            if (lbloption4.Text == correct)
            {
                panel7.BackColor = Color.FromArgb(161, 168, 135);
                panel8.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                pictcorrect.Visible = true;
                corans++;               
            }
            else
                if (lbloption1.Text == correct)
            {
                panel7.BackColor = Color.FromArgb(223, 165, 135);
                panel8.BackColor = Color.FromArgb(237, 217, 206);
                panel1.BackColor = Color.FromArgb(161, 168, 135);
                panel2.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                picincorrect.Visible = true;
                incans++;
            }
            else
                if (lbloption3.Text == correct)
            {
                panel7.BackColor = Color.FromArgb(223, 165, 135);
                panel8.BackColor = Color.FromArgb(237, 217, 206);
                panel5.BackColor = Color.FromArgb(161, 168, 135);
                panel6.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                picincorrect.Visible = true;
                incans++;
            }
            else
                if (lbloption2.Text == correct)
            {
                panel7.BackColor = Color.FromArgb(223, 165, 135);
                panel8.BackColor = Color.FromArgb(237, 217, 206);
                panel3.BackColor = Color.FromArgb(161, 168, 135);
                panel4.BackColor = Color.FromArgb(209, 217, 191);
                lbloption1.Enabled = false;
                lbloption2.Enabled = false;
                lbloption3.Enabled = false;
                lbloption4.Enabled = false;
                lbloption1.Visible = false;
                lbloption2.Visible = false;
                lbloption3.Visible = false;
                lbloption4.Visible = false;
                option1.Visible = true;
                option2.Visible = true;
                option3.Visible = true;
                option4.Visible = true;
                picstella.Visible = false;
                picincorrect.Visible = true;
                incans++;
            }
        }

        private void panelexercise1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelexercise3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelexercise4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
