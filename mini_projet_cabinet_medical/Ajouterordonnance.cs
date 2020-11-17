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
    public partial class Ajouterordonnence : Form
    {
        int mov;
        int movX;
        int movY;
        ADO d = new ADO();
        // declaration de fonction nombre
        public int nombre()
        {
            int cpt;
            d.cmd.CommandText = "SELECT Count(id_Medicament) from ajouteORD where id_Medicament='" + id.Text + "'";
            d.cmd.Connection = d.con;
            cpt = (int)d.cmd.ExecuteScalar();
            return cpt;



        }
        // declaration de la methode ajouter
        public bool AJOUTER()
        {
            if (nombre() == 0)
            {
                d.cmd.CommandText = " insert into ajouteORD values('" + id.Text + "','"+  txtNomMedic.Text + "','" + txtQuantité.Text + "','" + txtPasologie.Text + "','" + txtDosage.Text + "','" + txtRemarque.Text + "')";
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
                d.cmd.CommandText = "delete from ajouteORD where id_Medicament ='" + id.Text + "'";
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
                d.cmd.CommandText = "update ajouteORD set Nom_Medicament='" + txtNomMedic.Text + "',Quantité ='" + txtQuantité.Text + "',Pasologie ='" + txtPasologie.Text + "',Dosage ='" + txtDosage.Text + "',Remarque ='" + txtRemarque.Text + "' where id_Medicament ='" + id.Text + "'";
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }


        public Ajouterordonnence()
        {
            InitializeComponent();
        }

        private void exit3_Click(object sender, EventArgs e)
        {
            Ajouterordonnence r=new Ajouterordonnence();
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

        private void AO_Mouse_Down(object sender, MouseEventArgs e)
        {

            mov = 1;
            movX = e.X;
            movY = e.Y;

        }

        private void AO_Mouse_Up(object sender, MouseEventArgs e)
        {

        }

        private void AO_Mouse_Move(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void Ajouterordonnence_Load(object sender, EventArgs e)
        {
            d.CONNECTER();
        }

        private void ao_Mouse_Down(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void ao_Mouse_Move(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void ao_Mouse_Up(object sender, MouseEventArgs e)
        {
            mov = 0;
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

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (id.Text == ""  || txtNomMedic.Text == "" || txtQuantité.Text == "" || txtPasologie.Text == "" || txtDosage.Text == "" || txtRemarque.Text == "")
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

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("voulez vous quitter?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                d.DECONNECTER();
                this.Close();
            }

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("voulez vous vider la form?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                VIDER(this);
            }

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (id.Text == ""|| txtNomMedic.Text == "" || txtQuantité.Text == "" || txtPasologie.Text == "" || txtDosage.Text == "" || txtRemarque.Text == "")
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

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void ajouterordnc_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
    

