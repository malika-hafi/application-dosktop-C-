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
    public partial class profilmedecin : Form
         
    {
        int mov;
        int movX;
        int movY;
        public profilmedecin()
        {
            InitializeComponent();
        }

        private void Minimiser_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void exit3_Click(object sender, EventArgs e)
        {
            profilmedecin r = new profilmedecin();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing5);
            this.Hide();
        }
        private void f_FormClosing5(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void pr_move(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void pr_down(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;

        }

        private void pr_upp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void profilmedecin_Load(object sender, EventArgs e)
        {

        }

        private void Restaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Restaurar.Visible = false;
            Maximizar.Visible = true;
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            Restaurar.Visible = true;
        }
    }
    }

