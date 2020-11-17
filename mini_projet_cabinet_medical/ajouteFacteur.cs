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
    public partial class ajouteFacteur : Form
    {
        ADO d = new ADO();
        // declaration de fonction nombre
        public int nombre()
        {
            int cpt;
            d.cmd.CommandText = "SELECT Count(id_patient) from facteurPatient where id_patient='" + id.Text + "'";
            d.cmd.Connection = d.con;
            cpt = (int)d.cmd.ExecuteScalar();
            return cpt;



        }
        // declaration de la methode ajouter
        public bool AJOUTER()
        {
            if (nombre() == 0)
            {
                d.cmd.CommandText = " insert into facteurPatient values('" + id.Text + "','" + nom.Text + "','" + prenom.Text + "','" + adresse.Text + "','" + numero.Text + "','" + prix.Text + "')";
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }// declaration de la methode Supprimer
        public bool suprimer()
        {
            if (nombre() != 0)
            {
                d.cmd.CommandText = "delete from facteurPatient where id_patient ='" + id.Text + "'";
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }
        // declaration de la methode MODIFIER
        public bool MODIFIER()
        {
            if (nombre() != 0)
            {
                d.cmd.CommandText = "update facteurPatient set nom ='" + nom.Text + "',prenom='" + prenom.Text + "',adresse='" + adresse.Text + "',telephone ='" + numero.Text + "',prix_consultation ='" + prix.Text + "' where id_patient ='" + id.Text + "'";
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }
        public ajouteFacteur()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void ajouteFacteur_Load(object sender, EventArgs e)
        {
            d.CONNECTER();
        }

        private void exit3_Click(object sender, EventArgs e)
        {
            ajouterpatient r = new ajouterpatient();
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
        public void VIDER(Control f)
        {
            foreach (Control ct in f.Controls)
            {
                if (ct.GetType() == typeof(TextBox))
                {
                    ct.Text = "";
                }
                if (ct.Controls.Count != 0)
                {
                    VIDER(ct);
                }
            }
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (id.Text == "" || nom.Text == "" || prenom.Text == "" || adresse.Text == "" || numero.Text == "" || prix.Text == "")
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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (id.Text == "")
            {
                MessageBox.Show("merci de remplir les cases vides");
                return;
            }
            if (suprimer() == true)
            {

                MessageBox.Show("suprission avec succes");
            }
            else
            {
                MessageBox.Show("medicament n'existe pas");
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (id.Text == "" || nom.Text == "" || prix.Text == "" || prenom.Text == "" || numero.Text == "" || adresse.Text == "")
            {
                MessageBox.Show("merci de remplir les cases vides");
                return;
            }
            if (MODIFIER() == true)
            {

                MessageBox.Show("modification  avec succes");
            }
            else
            {
                MessageBox.Show("medicament n'existe pas");
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("voulez vous vider la form?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                VIDER(this);
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("voulez vous quitter?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                d.DECONNECTER();
                this.Close();
            }
        }
    }
}
