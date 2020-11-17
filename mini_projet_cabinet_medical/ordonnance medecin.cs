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
    public partial class ordonnance_medecin : Form
    {
        int mov;
        int movX;
        int movY;
        ADO d = new ADO();
        public ordonnance_medecin()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Ajouterordonnence r = new Ajouterordonnence();
            r.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            acceuilmedecin r = new acceuilmedecin();
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
            dossiermedicalmedecin r = new dossiermedicalmedecin();
            r.FormClosing += new FormClosingEventHandler(f_FormClosing);
            this.Hide();
            r.Show();
        }
        private void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();       }

        private void Minimiser_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        private void om_mousedown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void om_mousemove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void om_mouseup(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = bunifuCustomDataGrid1.CurrentCell.RowIndex;
            bunifuCustomDataGrid1.Rows.RemoveAt(rowIndex);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Nom_Medicament")
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-VP0TP4E\\SQLEXPRESS;Initial Catalog=cabinet medical;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT id_Medicament,Nom_Medicament,Quantité,Pasologie,Dosage,Remarque FROM ajouteORD where Nom_Medicament like '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                bunifuCustomDataGrid1.DataSource = dt;
            }
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            ordonnance_medecin r = new ordonnance_medecin();

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
        private void button3_Click(object sender, EventArgs e)
        {
            exportgridtopdf(bunifuCustomDataGrid1, "ordonnances");
        }
    }
    }
    