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
    public partial class GlumacForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\nikolar\documents\visual studio 2013\Projects\Fonis_Decembar\Fonis_Decembar\Database.mdf;Integrated Security=True");
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public GlumacForm()
        {
            InitializeComponent();
        }

        private void napuniCombo()
        {
            con.Open();
            com.CommandText = "select * from pozoriste";
            com.Connection = con;
            dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ComboElement ce = new ComboElement();
                    ce.Id = dr[0].ToString();
                    ce.Naziv = dr[1].ToString();
                    cmbMaticno.Items.Add(ce);
                   // string pozoriste =dr[0].ToString() +" "+ dr[1].ToString();
                   // cmbMaticno.Items.Add(pozoriste);
                }
            }

            con.Close();
        }

        private void GlumacForm_Load(object sender, EventArgs e)
        {
            loadList();
            napuniCombo();
            btnIzmeni.Enabled = false;
            btnObrisi.Enabled = false;
            btnDodaj.Enabled = true;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (txtIme.Text != "" && txtPrezime.Text != "" && txtDatum.Text != "" & cmbMaticno.SelectedIndex != -1)
            {
                ComboElement ce = cmbMaticno.SelectedItem as ComboElement;
                con.Open();
                com.CommandText = "INSERT INTO glumac (ime, prezime, datum_rodjenja, maticno_pozoriste) values ('" + txtIme.Text + "','" + txtPrezime.Text + "','" + txtDatum.Text + "','"+ ce.Id +"')";
                com.Connection = con;
                com.ExecuteNonQuery();
                com.Clone();
                MessageBox.Show("Glumac je uspesno dodat!");
                con.Close();
                lstGlumac.Items.Clear();
                loadList();
                btnReset.PerformClick();
            }
            else
            {
                MessageBox.Show("Nisu uneti svi podaci!");
            }
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadList() 
        {
            con.Open();
            com.CommandText = "select * from glumac";
            com.Connection = con;
            dr = com.ExecuteReader();

            while (dr.Read())
            {
                Glumac g = new Glumac(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[0].ToString());
                lstGlumac.Items.Add(g);
            }

            con.Close();
        }

        private void lstGlumac_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDodaj.Enabled = false;
            btnObrisi.Enabled = true;
            btnIzmeni.Enabled = true;
            ListBox l = sender as ListBox;
            if (l.SelectedIndex != -1)
            {
                lstGlumac.SelectedIndex = l.SelectedIndex;
                Glumac g = lstGlumac.SelectedItem as Glumac;
                txtIme.Text = g.Ime;
                txtPrezime.Text = g.Prezime;
                string datumRodjnja = g.DatumRodjenja.Substring(0, 9);
                txtDatum.Text = datumRodjnja;
                con.Open();
                com.CommandText = "select * from glumac join pozoriste on glumac.maticno_pozoriste = pozoriste.id_pozorista where ime='"+g.Ime+"' and prezime='"+g.Prezime+"'";
                com.Connection = con;
                dr = com.ExecuteReader();
                dr.Read();
                string pozoriste = dr[6].ToString();
                int index = cmbMaticno.FindString(pozoriste);
                cmbMaticno.SelectedIndex = index;
               
                con.Close();

              /*  string ime = lstGlumac.SelectedItem.ToString();
                com.CommandText = "select * from pozoriste where naziv_pozorista='" + naziv + "'";
                com.Connection = con;
                dr = com.ExecuteReader();
                dr.Read();

                txtIme.Text = dr[1].ToString();
               txtAdresa.Text = dr[2].ToString();
                txtGodina.Text = dr[3].ToString();

                con.Close();



                // txtIme.Text = lstPozorista.SelectedItems.ToString();
               */ 

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDatum.Text = "";
            txtIme.Text = "";
            txtPrezime.Text = "";
            cmbMaticno.SelectedIndex = -1;
            lstGlumac.SelectedIndex = -1;
            btnDodaj.Enabled = true;
            btnIzmeni.Enabled = false;
            btnObrisi.Enabled = false;
            lstGlumac.Items.Clear();
            loadList();
            
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (txtIme.Text != "" && txtPrezime.Text != "" & txtDatum.Text != "" & cmbMaticno.SelectedIndex != -1 & lstGlumac.SelectedIndex != -1)
            {
                ComboElement ce = cmbMaticno.SelectedItem as ComboElement;
                Glumac g = lstGlumac.SelectedItem as Glumac;
                con.Open();
                com.CommandText = "update glumac set ime='" + txtIme.Text + "', prezime='" + txtPrezime.Text + "', datum_rodjenja='" + txtDatum.Text + "', maticno_pozoriste='"+ce.Id+"' where ime='" + g.Ime+ "' and prezime='"+g.Prezime+"'";
                com.Connection = con;
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Uspesno ste promenili glumca");
                btnReset.PerformClick();
            }
            else
            {
                MessageBox.Show("Morate selektovati sve parametre! ");
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (lstGlumac.SelectedIndex !=-1)
            {
                con.Open();
                Glumac g = lstGlumac.SelectedItem as Glumac;
                com.CommandText = "delete from pred2glum where id_glumac='" + g.Id+ "'";
                com.ExecuteNonQuery();
                com.CommandText = "delete from glumac where ime='" + g.Ime + "' and prezime='" + g.Prezime + "' and id_glumac='" + g.Id + "'";
                com.Connection = con;
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Uspesno obrisan glumac!");
                btnReset.PerformClick();

                
            }
            else
            {
                MessageBox.Show("Nije selektovan glumac!");
            }
        }

        


    }
}
