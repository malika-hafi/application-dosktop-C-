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
    public partial class acceuilmedecin : Form
    {
        int mov;
        int movX;
        int movY;
        public acceuilmedecin()
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

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimiser_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            dossiermedicalmedecin r = new dossiermedicalmedecin();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            ordonnance_medecin r = new ordonnance_medecin();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing2);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void am_mousedown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void am_mousemove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void am_mouseup(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           profilmedecin r = new profilmedecin();
            r.Show();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void wrapper_Paint(object sender, PaintEventArgs e)
        {
            patients.Series["patients"].Points.AddXY("lunndi", 20);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AcceuilPrincipale p = new AcceuilPrincipale();
            p.Show();
        }
    }
}
