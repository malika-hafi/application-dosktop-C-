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
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace mini_projet_cabinet_medical
{
    public partial class fichepatient : Form
    {
        int mov;
        int movX;
        int movY;
       
        public fichepatient()
        {
            InitializeComponent();
        }
        private void Form2_Shown(Object sender,EventArgs e)
        {
            ficheP.Rows.Add(
                new object[] {
                    "BENABDELKRIM",
                    "Amina",
                    "feminin",
                    "25-08-1999",
                    "miftah el khir Safi",
                    "0618527817"
                }
                );
          
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (bunifuGradientPanel1.Width == 200)
            {
                bunifuGradientPanel1.Visible = false;
                bunifuGradientPanel1.Width = 43;
                sidebarWrapper.Width = 90;
               LineaSidebar.Width = 0;
                LineaSidebar1.Width = 0;
                animationsidebar.Show(bunifuGradientPanel1);
            }
            else
            {
                bunifuGradientPanel1.Visible = false;
                bunifuGradientPanel1.Width = 200;
                sidebarWrapper.Width =221 ;
                LineaSidebar1.Width = 190;
                LineaSidebar.Width = 190;
                animationsidebarback.Show(bunifuGradientPanel1);
            }
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

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
            Maximizar.Visible= false;
            Restaurar.Visible = true;
        }

        private void Restaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Restaurar.Visible =false;
            Maximizar.Visible = true;


        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            ajouterpatient r = new ajouterpatient();
            r.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Acceuilsecrétaire r = new Acceuilsecrétaire();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Dossier_médical r = new Dossier_médical();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing5);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing5(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            RDV r = new RDV();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing2);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            ordonnance r = new ordonnance();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing3);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing3(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void fp_down(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void fp_move(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void fp_up(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        
        public string conString = @"Data Source=DESKTOP-VP0TP4E\SQLEXPRESS;Initial Catalog=cabinet medical;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            //actualiser la table de l application

            using (SqlConnection con = new SqlConnection(conString)){

             con.Open();

             SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM ajouterPatient ", con);
             DataTable dt = new DataTable();
             SDA.Fill(dt);
             ficheP.DataSource = dt;
             con.Close();

             }
           


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int rowIndex = ficheP.CurrentCell.RowIndex;
            ficheP.Rows.RemoveAt(rowIndex);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "nom")
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-VP0TP4E\\SQLEXPRESS;Initial Catalog=cabinet medical;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT nom,prenom,sexe,adresse,dateNaissance,numero FROM ajouterPatient where nom like '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ficheP.DataSource = dt;
            }
            if (comboBox1.Text == "prenom")
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-VP0TP4E\\SQLEXPRESS;Initial Catalog=cabinet medical;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT nom,prenom,sexe,adresse,dateNaissance,numero FROM ajouterPatient where prenom like '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ficheP.DataSource = dt;
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Facteur r = new Facteur();
            
            this.Hide();
            r.Show();
        }
        public void exportgridtopdf(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfTable = new PdfPTable(dgw.Columns.Count);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            // add header 
            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            // add datagrid
            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }
            var savefiledialogue = new SaveFileDialog();
            savefiledialogue.FileName = filename;
            savefiledialogue.DefaultExt = ".pdf";
            if (savefiledialogue.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialogue.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdfTable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            exportgridtopdf(ficheP, "patients");
        }
    }
}
