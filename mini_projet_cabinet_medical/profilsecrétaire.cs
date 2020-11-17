using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace mini_projet_cabinet_medical
{
    public partial class profilsecrétaire : Form
    {
        int mov;
        int movX;
        int movY;
        ADO d = new ADO();
        // declaration de fonction nombre
        public int nombre()
        {
            int cpt;
            d.cmd.CommandText = "SELECT Count(nom) from profileSecritaire where nom='" + bunifuMaterialTextbox1.Text + "'";
            d.cmd.Connection = d.con;
            cpt = (int)d.cmd.ExecuteScalar();
            return cpt;



        }
        // declaration de la methode ajouter
        public bool AJOUTER()
        {
            if (nombre() == 0)
            {
                d.cmd.CommandText = " insert into profileSecritaire values('" + bunifuMaterialTextbox1.Text + "','" + bunifuMaterialTextbox4.Text + "','" + bunifuMaterialTextbox6.Text + "','" + bunifuMaterialTextbox2.Text + "','" + bunifuMaterialTextbox9.Text + "','" + bunifuMaterialTextbox7.Text +  "','" + bunifuMaterialTextbox3.Text + "','" + bunifuMaterialTextbox5.Text + "','" + bunifuMaterialTextbox8.Text + "','" + bunifuMaterialTextbox10.Text + "','" + bunifuMaterialTextbox13.Text + "','" + bunifuMaterialTextbox12.Text + "')";
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }
        public profilsecrétaire()
        {
            InitializeComponent();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void exit3_Click(object sender, EventArgs e)
        {
            profilsecrétaire r = new profilsecrétaire();
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

        private void pr_down(object sender, MouseEventArgs e)
        {

            mov = 1;
            movX = e.X;
            movY = e.Y;

        }

        private void pr_move(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void pr_up(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void profilsecrétaire_Load(object sender, EventArgs e)
        {
            d.CONNECTER();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "" || bunifuMaterialTextbox2.Text == "" || bunifuMaterialTextbox3.Text == "" || bunifuMaterialTextbox4.Text == "" || bunifuMaterialTextbox5.Text == "" || bunifuMaterialTextbox6.Text == "" || bunifuMaterialTextbox7.Text == "" || bunifuMaterialTextbox8.Text == "" || bunifuMaterialTextbox9.Text == "" || bunifuMaterialTextbox10.Text == "" || bunifuMaterialTextbox12.Text == "" || bunifuMaterialTextbox13.Text == "")
            {
                MessageBox.Show("merci de remplir les cases vides");
                return;
            }
            if (AJOUTER() == true)
            {

                MessageBox.Show("ajoute avec succes");
            }
            else
            {
                MessageBox.Show("medicament existe deja");
            }

        }

        private void bunifuMaterialTextbox7_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            String source = @"Data Source=DESKTOP-VP0TP4E\\SQLEXPRESS;Initial Catalog=cabinet medical;Integrated Security=True";
            SqlConnection con = new SqlConnection(source);
            con.Open();
            MessageBox.Show("connection");
            String sqlselectQuery = "select * from profileSecritaire where role='" + bunifuMaterialTextbox2.Text.ToString() ;
            SqlCommand cmd = new SqlCommand(sqlselectQuery, con);
            SqlDataReader rd = cmd.ExecuteReader();
            con.Close();



        }
    }
}
