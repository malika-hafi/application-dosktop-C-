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
    public partial class inscreption : Form
    {
        ADO d = new ADO();
        String metier;
        // declaration de fonction nombre
        public int nombre()
        {
            int cpt;
            d.cmd.CommandText = "SELECT Count(nom) from utilisateur where nom='" + bunifuMetroTextbox2.Text + "'";
            d.cmd.Connection = d.con;
            cpt = (int)d.cmd.ExecuteScalar();
            return cpt;


        }
        // declaration de la methode ajouter
        public bool AJOUTER()
        {
            if (nombre() == 0)
            {
                d.cmd.CommandText = " insert into utilisateur(nom,prenom,email,password,metier) values('" + bunifuMetroTextbox2.Text + "','" + bunifuMetroTextbox1.Text + "','" + bunifuMetroTextbox3.Text + "','" + bunifuMetroTextbox4.Text + "','" + metier + "')";
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }

        public inscreption()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void inscreption_Load(object sender, EventArgs e)
        {
            d.CONNECTER();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox2.Text == "" || bunifuMetroTextbox1.Text == "" || bunifuMetroTextbox3.Text == "" || bunifuMetroTextbox4.Text == "")
            {
                MessageBox.Show("merci de remplir les cases vides");
                return;
            }
            if (AJOUTER() == true)
            {

                MessageBox.Show("inscription  avec succes");
            }
            else
            {
                MessageBox.Show("utilisateur existe deja");
            }

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f = new Login();
            f.Show();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            metier = "secretaire";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            metier = "medcin";
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimiser_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
