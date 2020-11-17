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
    public partial class Dossier_médical : Form
    {
        int mov;
        int movX;
        int movY;
        public Dossier_médical()
        {
            InitializeComponent();
        }

        private void Dossier_médical_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            ajouterdossiermedical r = new ajouterdossiermedical();
            r.Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            ajouterdossiermedical r = new ajouterdossiermedical();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing4);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing4(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Acceuilsecrétaire r = new Acceuilsecrétaire();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }


        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            fichepatient r = new fichepatient();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing1);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing1(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Facteur r = new Facteur();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing1);
            this.Hide();
            r.Show();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            RDV r = new RDV();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing2);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void dm_down(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void dm_move(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void dm_up(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void MenuTop_Paint(object sender, PaintEventArgs e)
        {

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

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {

        }
    }
}
