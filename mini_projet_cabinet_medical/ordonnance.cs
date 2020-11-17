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
    public partial class ordonnance : Form
    {
        int mov;
        int movX;
        int movY;
        ADO d = new ADO();
        public ordonnance()
        {
            InitializeComponent();
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            Restaurar.Visible = true;
        }

        private void Restaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Restaurar.Visible = false;
            Maximizar.Visible = true;
        }

        private void Minimiser_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menusidebar_Click(object sender, EventArgs e)
        {
            if (bunifuGradientPanel1.Width == 200)
            {
                bunifuGradientPanel1.Visible = false;
                bunifuGradientPanel1.Width = 43;

                LineaSidebar.Width = 0;
                LineaSidebar1.Width = 0;
                animationsidebar.Show(bunifuGradientPanel1);
            }
            else
            {
                bunifuGradientPanel1.Visible = false;
                bunifuGradientPanel1.Width = 200;

                LineaSidebar1.Width = 190;
                LineaSidebar.Width = 190;
                animationsidebarback.Show(bunifuGradientPanel1);
            }
        }

        private void MenuTop_Paint(object sender, PaintEventArgs e)
        {

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

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            fichepatient r = new fichepatient();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing1);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing1(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Dossier_médical r = new Dossier_médical();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing2);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

            RDV r = new RDV();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing3);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing3(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Ajouterordonnence r = new Ajouterordonnence();
            r.Show();
        }

        private void or_down(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void or_move(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void or_up(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        public string conString = @"Data Source=DESKTOP-VP0TP4E\SQLEXPRESS;Initial Catalog=cabinet medical;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {

                con.Open();

                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM ajouteORD ", con);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                bunifuCustomDataGrid1.DataSource = dt;
                con.Close();

            }

        }

        private void wrapper_Paint(object sender, PaintEventArgs e)
        {
            d.CONNECTER();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = bunifuCustomDataGrid1.CurrentCell.RowIndex;
            bunifuCustomDataGrid1.Rows.RemoveAt(rowIndex);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           /* Boolean zak = false;
            for (int i = 0; i < this.bunifuCustomDataGrid1.Rows.Count - 1 ; i++)
            {
                if (this.bunifuCustomDataGrid1.Rows[i].Cells[0].Value.ToString() == this.bunifuTextbox1.text)
                {
                    bunifuCustomDataGrid1.Rows[i].Selected = true;
                    zak = true;
                }
            }
            if (zak == false) MessageBox.Show("le nom n'esxiste pas!!!");*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Facteur r = new Facteur();

            this.Hide();
            r.Show();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Nom_Medicament")
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-VP0TP4E\\SQLEXPRESS;Initial Catalog=cabinet medical;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT id_Medicament,Nom_Medicament,Quantité,Pasologie,Dosage,Remarque FROM ajouteORD where Nom_Medicament like '"+ textBox1.Text+"%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                bunifuCustomDataGrid1.DataSource = dt;
            }
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {

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

        private void ordonnance_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            exportgridtopdf(bunifuCustomDataGrid1, "ordonnances");
        }
    }

}
    

