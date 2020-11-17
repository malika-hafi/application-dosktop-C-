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
    public partial class dossiermedicalmedecin : Form
    {
        int mov;
        int movX;
        int movY;
        public dossiermedicalmedecin()
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

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            ajouterdossiermedical r = new ajouterdossiermedical();
            r.Show();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            ordonnance r = new ordonnance();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing2);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            acceuilmedecin r = new acceuilmedecin();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void DMM_mousedown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void DMM_mousemove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void DMM_mouseup(object sender, MouseEventArgs e)
        {
            mov = 0;
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

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            acceuilmedecin r = new acceuilmedecin();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing1);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing1(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton7_Click_1(object sender, EventArgs e)
        {
            ajouterdossiermedical r = new ajouterdossiermedical();
            r.Show();
        }

        private void bunifuFlatButton4_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton8_Click_1(object sender, EventArgs e)
        {
            ordonnance_medecin r = new ordonnance_medecin();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing3);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing3(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
    }
    }

  
    
    

