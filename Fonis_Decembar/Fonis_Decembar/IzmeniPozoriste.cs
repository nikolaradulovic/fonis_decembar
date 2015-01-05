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
    public partial class IzmeniPozoriste : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\nikolar\documents\visual studio 2013\Projects\Fonis_Decembar\Fonis_Decembar\Database.mdf;Integrated Security=True");
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        
        public IzmeniPozoriste()
        {
            InitializeComponent();
        }
        private void IzmeniPozoriste_Load(object sender, EventArgs e)
        {
            loadList();
            btnIzmeni.Enabled = false;
            btnObrisi.Enabled = false;
        }
      
        private void loadList() 
        {
            

            con.Open();
            com.CommandText = "select * from pozoriste";
            com.Connection = con;
            dr = com.ExecuteReader();

            while (dr.Read())
            {
                lstPozorista.Items.Add(dr[1].ToString());
            }

            con.Close();
        }

     
        private void lstPozorista_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            ListBox l = sender as ListBox;

            if (l.SelectedIndex != -1)
            {
                btnObrisi.Enabled = true;
                btnIzmeni.Enabled = true;
                btnDodaj.Enabled = false;
                lstPozorista.SelectedIndex = l.SelectedIndex;
                con.Open();
                
                string naziv = lstPozorista.SelectedItem.ToString();
                com.CommandText = "select * from pozoriste where naziv_pozorista='" + naziv + "'";
                com.Connection = con;
                dr = com.ExecuteReader();
                dr.Read();
              
                txtIme.Text = dr[1].ToString();
                txtAdresa.Text = dr[2].ToString();
                txtGodina.Text = dr[3].ToString();

                con.Close();

                
                
               // txtIme.Text = lstPozorista.SelectedItems.ToString();

            }
            
        }

      

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (lstPozorista.SelectedIndex != -1) 
            {
                con.Open();
                com.CommandText = "delete from pozoriste where naziv_pozorista='"+txtIme.Text+"' and adresa='"+txtAdresa.Text+"' and godina_osnivanja='"+txtGodina.Text+"'";
                com.Connection = con;
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Uspesno obrisano pozoriste!");
                btnReset.PerformClick();
            }
            else 
            {
                MessageBox.Show("Nije selektovano pozoriste!");
            }
                
 
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (txtIme.Text != "" && txtGodina.Text != "" & txtAdresa.Text != "" && lstPozorista.SelectedIndex != -1)
            {
                con.Open();
                com.CommandText = "update pozoriste set naziv_pozorista='" + txtIme.Text + "', adresa='" + txtAdresa.Text + "', godina_osnivanja='" + txtGodina.Text + "' where naziv_pozorista='" + lstPozorista.SelectedItem.ToString() + "'";
                com.Connection = con;
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Uspesno promenjeno pozoriste");
                btnReset.PerformClick();
            }
            else
            {
                MessageBox.Show("Morate selektovati pozoriste! ");
            }

        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lstPozorista.Items.Clear();
            btnDodaj.Enabled = true;
            btnIzmeni.Enabled = false;
            btnObrisi.Enabled = false;
            txtAdresa.Text = "";
            txtGodina.Text = "";
            txtIme.Text = "";
            lstPozorista.SelectedIndex = -1;
            loadList();

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (txtIme.Text != "" && txtAdresa.Text != "" && txtGodina.Text != "")
            {
                con.Open();
                com.CommandText = "INSERT INTO pozoriste (naziv_pozorista, adresa, godina_osnivanja) values ('" + txtIme.Text + "','" + txtAdresa.Text + "','" + txtGodina.Text + "')";
                com.Connection = con;
                com.ExecuteNonQuery();
                com.Clone();
                con.Close();
                MessageBox.Show("Pozoriste je uspesno dodato!");
                btnReset.PerformClick();

            }
        }

      

       
    }
}
