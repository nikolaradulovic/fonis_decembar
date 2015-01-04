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

namespace Fonis_Decembar
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\nikolar\documents\visual studio 2013\Projects\Fonis_Decembar\Fonis_Decembar\Database.mdf;Integrated Security=True");
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
       
       /* private void svaPozoristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn column;
            DataRow row;
           
      
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Naziv";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Adresa";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Godina Osnivanja";
            
            dt.Columns.Add(column);

            con.Open();
            com.CommandText = "select * from pozoriste";
            com.Connection = con;
            dr = com.ExecuteReader();

            if (dr.HasRows) 
            {
                while (dr.Read())
                {
                    row = dt.NewRow();
                    row["Naziv"] = dr[1].ToString();
                    row["Adresa"] = dr[2].ToString();
                    row["Godina Osnivanja"] = dr[3].ToString();
                    dt.Rows.Add(row);
                }
            }


            con.Close();

            gridMain.DataSource = dt;
        }
        */
        private void zatvoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void izmeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IzmeniPozoriste izmeni = new IzmeniPozoriste();
            izmeni.Show();

            
        }

        private void sviGlumciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlumacForm gf = new GlumacForm();
            gf.Show();
        }

        private void opcijeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PredstaveForm2 pf = new PredstaveForm2();
            pf.Show();
        }

       

       

        
    }
}
