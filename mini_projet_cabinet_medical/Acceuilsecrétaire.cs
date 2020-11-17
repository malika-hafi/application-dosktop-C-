using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mini_projet_cabinet_medical
{
    public partial class Acceuilsecrétaire : Form
    {
        int mov;
        int movX;
        int movY;
        public Acceuilsecrétaire()
        {
            InitializeComponent();
        }

        private void menusidebar_Click(object sender, EventArgs e)
        {
            if (bunifuGradientPanel1.Width == 200)
            {
                bunifuGradientPanel1.Visible = false;
                bunifuGradientPanel1.Width = 43;
               
                LineaSidebar.Width = 0;
                LineaSidebar1.Width = 0;
                animationsidebar.Show(bunifuGradientPanel1);
            }
            else
            {
                bunifuGradientPanel1.Visible = false;
                bunifuGradientPanel1.Width = 200;
               
                LineaSidebar1.Width = 190;
                LineaSidebar.Width = 190;
                animationsidebarback.Show(bunifuGradientPanel1);
            }
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            Restaurar.Visible = true;
        }

        private void Restaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Restaurar.Visible = false;
            Maximizar.Visible = true;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
             profilsecrétaire r= new profilsecrétaire();
            r.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
           

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            fichepatient r = new fichepatient();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
    

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Dossier_médical r = new Dossier_médical();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing2);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            RDV r = new RDV();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing1);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing1(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void Minimiser_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            ordonnance r = new ordonnance();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing3);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing3(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void MenuTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void wrapper_Paint(object sender, PaintEventArgs e)
        {
            patients.Series["patients"].Points.AddXY("lunndi",  20);
            patients.Series["patients"].Points.AddXY("mardi", 16);
            patients.Series["patients"].Points.AddXY("mercredi", 21);
            patients.Series["patients"].Points.AddXY("jeudi", 45);
            patients.Series["patients"].Points.AddXY("vendredi", 45);
            patients.Series["patients"].Points.AddXY("samedi", 45);
            patients.Series["patients"].Points.AddXY("dimanche", 45);

            ordonances.Series["ordonances"].Points.AddXY("ABC", 300);
            ordonances.Series["ordonances"].Points.AddXY("EFC", 100);
            ordonances.Series["ordonances"].Points.AddXY("ARB", 150);
            ordonances.Series["ordonances"].Points.AddXY("ADR", 400);
        }

        private void mouse(object sender, MouseEventArgs e)
        {

        }

        private void MenuTop_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;

        }

        private void MenuTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);



            }
        }

        private void MenuTop_MouseUp(object sender, MouseEventArgs e)
        {
                mov = 0;
            }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            profilsecrétaire r = new profilsecrétaire();
            r.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
         }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AcceuilPrincipale p = new AcceuilPrincipale();
            p.Show();
        }
    }
}
    
