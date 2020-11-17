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
    public partial class Facteur : Form
    {
        public Facteur()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void Minimiser_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void menusidebar_Click(object sender, EventArgs e)
        {

        }

        private void MenuTop_Paint(object sender, PaintEventArgs e)
        {

        }
        public string conString = @"Data Source=DESKTOP-VP0TP4E\SQLEXPRESS;Initial Catalog=cabinet medical;Integrated Security=True";
        private void update_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {

                con.Open();

                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM facteurPatient ", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                Datafacteurs.DataSource = dt;
                con.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rowIndex = Datafacteurs.CurrentCell.RowIndex;
            Datafacteurs.Rows.RemoveAt(rowIndex);
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
           ajouteFacteur r = new ajouteFacteur();
            r.Show();
        }
        public void exportgridtopdf( DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfTable = new PdfPTable(dgw.Columns.Count);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            // add header 
            foreach(DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            // add datagrid
            foreach(DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell  cell in row.Cells)
                {
                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }
            var savefiledialogue = new SaveFileDialog();
            savefiledialogue.FileName = filename;
            savefiledialogue.DefaultExt = ".pdf";
            if (savefiledialogue.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialogue.FileName,FileMode.Create))
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
            exportgridtopdf(Datafacteurs, "facteur");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "nom")
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-VP0TP4E\\SQLEXPRESS;Initial Catalog=cabinet medical;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT id_patient,nom,prenom,adresse,telephone,prix_consultation FROM facteurPatient where nom like '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Datafacteurs.DataSource = dt;
            }
            if (comboBox1.Text == "prenom")
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-VP0TP4E\\SQLEXPRESS;Initial Catalog=cabinet medical;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT id_patient,nom,prenom,adresse,telephone,prix_consultation FROM facteurPatient where prenom like '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Datafacteurs.DataSource = dt;
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            fichepatient r = new fichepatient();
        
            this.Hide();
            r.Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Dossier_médical r = new Dossier_médical();
           
            this.Hide();
            r.Show();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            
        }

        private void Datafacteurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            RDV r = new RDV();

            this.Hide();
            r.Show();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            ordonnance r = new ordonnance();

            this.Hide();
            r.Show();
        }
    }
}
