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
    public partial class ajouterpatient : Form
    {
        int mov;
        int movX;
        int movY;
        fichepatient f = new fichepatient();
        ADO d = new ADO();
        // declaration de fonction nombre
        public int nombre()
        {
            int cpt;
            d.cmd.CommandText = "SELECT Count(nom) from ajouterPatient where nom='" + nom.Text + "'";
            d.cmd.Connection = d.con;
            cpt = (int)d.cmd.ExecuteScalar();
            return cpt;



        }
        // declaration de la methode ajouter
        public bool AJOUTER()
        {
            if (nombre() == 0)
            {
                d.cmd.CommandText = " insert into ajouterPatient values('" + nom.Text + "','" + prenom.Text + "','" + sexe.Text + "','" + adresse.Text + "','" + dateNaissance.Text + "','" + numero.Text +  "')";
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
                d.cmd.CommandText = "delete from ajouterPatient where nom ='" + nom.Text + "'";
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
                d.cmd.CommandText = "update ajouterPatient set prenom ='" + prenom.Text + "',sexe='" + sexe.Text + "',adresse='" + adresse.Text + "',dateNaissance ='" + dateNaissance.Text + "',numero ='" + numero.Text  + "' where nom ='" + nom.Text + "'";
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }

        public ajouterpatient()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            d.CONNECTER();
        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
           ajouterpatient r = new ajouterpatient();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing5);
            this.Hide();
        }
        private void f_FormClosing5(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void Minimiser3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void Minimiser_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ap_mousemove(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;

        }

        private void ap_mouseup(object sender, MouseEventArgs e)
        {

        }

        private void ap_mousedown(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void Ap_mousedown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void Ap_mousemove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void Ap_mouseup(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }
      //  public string conString = "Data Source=DESKTOP-VP0TP4E\\SQLEXPRESS;Initial Catalog=cabinet medical;Integrated Security=True";
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            /*connection
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                
                string q = "insert into ajoutePasient(nom,prenom,sexe,adresse,dateNaissance,numero)values('"+nom.Text.ToString()+"','"+prenom.Text.ToString()+"','"+sexe.Text.ToString()+"','"+adresse.Text.ToString()+"','"+dateNaissance.Text.ToString()+"','"+numero.Text.ToString()+"')";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("connection Succefuly!!!");
          
                
            }
            //insert 
            SqlConnection con2 = new SqlConnection(@"Data Source=DESKTOP-VP0TP4E\SQLEXPRESS;Initial Catalog=cabinet medical;Integrated Security=True");
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("insert into ajoutePasient(nom, prenom, sexe, adresse, dateNaissance, numero)values(@nom, @prenom, @sexe, @adresse, @dateNaissance, @numero)", con2);

            cmd2.Parameters.AddWithValue("@nom", nom.Text);
            cmd2.Parameters.AddWithValue("@prenom", prenom.Text);
            cmd2.Parameters.AddWithValue("@sexe", sexe.Text);
            cmd2.Parameters.AddWithValue("@adresse", adresse.Text);
            cmd2.Parameters.AddWithValue("@dateNaissance", dateNaissance.Text);
            cmd2.Parameters.AddWithValue("@numero", numero.Text);

            int i=cmd2.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("data Succefuly insert!!!");
            }*/

            
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

            if (nom.Text == "" || prenom.Text == "" || sexe.Text == "" || adresse.Text == "" || dateNaissance.Text == "" || numero.Text == "" )
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
            if (nom.Text == "")
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

        private void bunifuThinButton23_Click_1(object sender, EventArgs e)
        {
            if (nom.Text == "" || prenom.Text == "" || sexe.Text == "" || adresse.Text == "" || dateNaissance.Text == "" || numero.Text == "")
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
