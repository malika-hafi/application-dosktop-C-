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
    public partial class AcceuilPrincipale : Form
    {
        public AcceuilPrincipale()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            inscreption i = new inscreption();
            i.Show();
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
