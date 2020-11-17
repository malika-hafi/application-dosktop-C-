using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace mini_projet_cabinet_medical
{
    class ADO
    {
        // declaration des objets sql
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();
        // declaration de fonction de connection
        public void CONNECTER()
        {
            if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {

                con.ConnectionString = "Data Source=DESKTOP-VP0TP4E\\SQLEXPRESS;Initial Catalog=cabinet medical;Integrated Security=True";
                con.Open();
            }
        }
        // declaration de fonction deconnection
        public void DECONNECTER()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}

