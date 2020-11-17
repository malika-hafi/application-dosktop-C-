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
    
    public partial class Login : Form
    {
        int mov;
        int movX;
        int movY;
        ADO d = new ADO();
        public Login()
        {
            InitializeComponent();
               
            




        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuMetroTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            inscreption f = new inscreption();
            f.Show();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void Minimiser_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void log_down(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;

        }

        private void log_up(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void log_move(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            d.CONNECTER();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bool tr = false;
            d.cmd.CommandText = "select password,nom,metier from utilisateur";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                if (bunifuMaterialTextbox1.Text.Equals(d.dr[1].ToString()) && bunifuMaterialTextbox2.Text.Equals(d.dr[0].ToString()))
                {
                    tr = true;
                    break;
                }
            }
            if (tr == true)
            {
                if (d.dr[2].Equals("secretaire"))
                {
                    this.Hide();
                    Acceuilsecrétaire f = new Acceuilsecrétaire();
                    f.Show();
                }
                if (d.dr[2].Equals("medcin"))
                {
                    this.Hide();
                    acceuilmedecin f = new acceuilmedecin();
                    f.Show();
                }


            }
            else
            {
                MessageBox.Show("les cordonnées d'utilisateur ou mode passe incorrect");
            }
            d.dr.Close();
            
        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }
    }

}
    


