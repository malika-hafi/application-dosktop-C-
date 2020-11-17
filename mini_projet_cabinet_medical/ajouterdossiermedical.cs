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
    public partial class ajouterdossiermedical : Form
    {
        int mov;
        int movX;
        int movY;
        public ajouterdossiermedical()
        {
            InitializeComponent();
        }

        private void exit3_Click(object sender, EventArgs e)
        {
            ajouterdossiermedical r = new ajouterdossiermedical();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing5);
            this.Hide();
        }
        private void f_FormClosing5(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }


        private void Minimiser_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dm_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;

        }

        private void dm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
            }

            private void dm_MouseUp(object sender, MouseEventArgs e)
        {
            

                mov = 0;
            }
    }
}
