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

    public partial class PredstaveForm2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\nikolar\documents\visual studio 2013\Projects\Fonis_Decembar\Fonis_Decembar\Database.mdf;Integrated Security=True");
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
    
        public PredstaveForm2()
        {
            InitializeComponent();
        }

        private void PredstaveForm2_Load(object sender, EventArgs e)
        {
            loadList();
            loadPredstave();
            napuniCombo();
            btnIzmeni.Enabled = false;
            btnObrisi.Enabled = false;
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
                lstIzbor.Items.Add(g);
           
            }

            con.Close();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstIzbor.SelectedItem != null)
            {
                Glumac gl = lstIzbor.SelectedItem as Glumac;
                List<Glumac> izabrani = new List<Glumac>();
                foreach(var glumac in lstIzabrani.Items)
                {
                    Glumac g = glumac as Glumac;
                    izabrani.Add(g);
                }
                if (!izabrani.Contains(gl))
                {
                    lstIzabrani.Items.Add(lstIzbor.SelectedItem);
                    lstIzbor.Items.Remove(lstIzbor.SelectedItem);
                }
                else 
                {
                   
                    lstIzbor.Items.Remove(lstIzbor.SelectedItem);
                }
            }
            else
            {

                MessageBox.Show("Niste selektovali glumca");
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            
            if (lstIzabrani.SelectedItem != null)
            {
                Glumac gl = lstIzabrani.SelectedItem as Glumac;
                List<Glumac> svi = new List<Glumac>();
                foreach(var glumac in lstIzbor.Items)
                {
                    Glumac g = glumac as Glumac;
                    svi.Add(g);
                }
                if (!svi.Contains(gl))
                {
                    lstIzbor.Items.Add(lstIzabrani.SelectedItem);
                    lstIzabrani.Items.Remove(lstIzabrani.SelectedItem);
                }
                else 
                {
                   
                    lstIzabrani.Items.Remove(lstIzabrani.SelectedItem);
                }
                
            }
            else
            {
                MessageBox.Show("Niste selektovali glumca");
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
          
            if (txtIme.Text != "" & cmbPozoriste.SelectedIndex != -1 & lstIzabrani.Items.Count != 0)
            {
                ComboElement ce = cmbPozoriste.SelectedItem as ComboElement;
                con.Open();
                com.CommandText = "INSERT INTO predstava (ime_predstave, pozoriste) values ('" + txtIme.Text + "','" + ce.Id + "');SELECT SCOPE_IDENTITY();";
                com.Connection = con;
                string id = com.ExecuteScalar().ToString();
                foreach(var item in lstIzabrani.Items)
                {
                    Glumac g = item as Glumac;
                    string id_glumac = g.Id;
                    com.CommandText = "INSERT INTO pred2glum (id_predstava,id_glumac) values ('"+id+"','"+id_glumac+"')";
                    com.ExecuteNonQuery();
                }
                
                con.Close();
       
             
                MessageBox.Show("Predstava je uspesno uneta");
                btnPocetak.PerformClick();
            }
            else
            {
                MessageBox.Show("Morate uneti sve podatke");
            }
        }

        private void napuniCombo()
        {
            cmbPozoriste.Items.Clear();
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
                    cmbPozoriste.Items.Add(ce);
          
                }
            }

            con.Close();
        }

        public void loadPredstave() 
        {
            lstPredstave.Items.Clear();
            con.Open();
            com.CommandText = "select * from predstava  INNER JOIN pozoriste ON predstava.pozoriste = pozoriste.id_pozorista";
            com.Connection = con;
            dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
               
                    Predstava p = new Predstava();
                    p.Id = dr[0].ToString();
                    p.Ime = dr[1].ToString();
                    p.Pozoriste = dr[4].ToString();
                    lstPredstave.Items.Add(p);
                    
          
  
                }
            }

            con.Close();
        }

        public void ucitajGlumce(string id) 
        {
            
            con.Open();
            com.CommandText = "select * from pred2glum INNER JOIN glumac on pred2glum.id_glumac=glumac.id_glumac  where id_predstava='"+id+"'";
            com.Connection = con;
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    Glumac g = new Glumac(dr[3].ToString(), dr[4].ToString(),dr[5].ToString(),dr[2].ToString());
                    lstIzabrani.Items.Add(g);

                }
            }
            con.Close();
        }

        private void lstPredstave_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstIzabrani.Items.Clear();
            lstIzbor.Items.Clear();
            loadList();
           
            btnDodaj.Enabled = false;
            btnIzmeni.Enabled = true;
            btnObrisi.Enabled = true;
            ListBox l = sender as ListBox;
            if (l.SelectedIndex != -1) 
            {

                lstPredstave.SelectedIndex = l.SelectedIndex;
                Predstava p = lstPredstave.SelectedItem as Predstava;
                txtIme.Text = p.Ime;
                int index = cmbPozoriste.FindString(p.Pozoriste);
                cmbPozoriste.SelectedIndex = index;
                ucitajGlumce(p.Id);
            }

        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (lstPredstave.SelectedIndex != -1)
            {
                con.Open();
                Predstava p = lstPredstave.SelectedItem as Predstava;
                com.CommandText = "delete from pred2glum where id_predstava='" + p.Id + "'";
                com.ExecuteNonQuery();
                com.CommandText = "delete from predstava where ime_predstave='" + p.Ime + "' and  id_predstava='" + p.Id + "'";
                com.Connection = con;
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Uspesno obrisana predstava!");
                btnPocetak.PerformClick();


            }
            else
            {
                MessageBox.Show("Nije selektovana predstava!");
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (txtIme.Text != "" && cmbPozoriste.SelectedIndex != -1 && lstPredstave.SelectedIndex != -1 && lstIzabrani.Items.Count != 0)
            {
                ComboElement ce = cmbPozoriste.SelectedItem as ComboElement;
                Predstava p = lstPredstave.SelectedItem as Predstava;
                con.Open();
                com.CommandText = "update predstava set ime_predstave='" + txtIme.Text + "', pozoriste='"+ce.Id+"' where id_predstava='"+p.Id+"'";
                com.Connection = con;
                com.ExecuteNonQuery();
                
                com.CommandText  ="delete from pred2glum where id_predstava='"+p.Id+"'";
                com.ExecuteNonQuery();
                foreach (var item in lstIzabrani.Items)
                {
                    Glumac g = item as Glumac;
                    string id_glumac = g.Id;
                    com.CommandText = "INSERT INTO pred2glum (id_predstava,id_glumac) values ('" + p.Id + "','" + id_glumac + "')";
                    com.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Uspesno ste izmenili predstavu");
                btnPocetak.PerformClick();
            }
            else
            {
                MessageBox.Show("Morate selektovati sve parametre! ");
            }
        }

        private void btnPocetak_Click(object sender, EventArgs e)
        {
            txtIme.Text = "";
            cmbPozoriste.SelectedIndex = -1 ;
            lstIzabrani.Items.Clear();
            lstIzbor.Items.Clear();
            lstPredstave.SelectedIndex = -1;
            lstIzbor.SelectedIndex = -1;
            btnDodaj.Enabled = true;
            btnIzmeni.Enabled = false;
            btnObrisi.Enabled = false;
            lstPredstave.Items.Clear();
            loadPredstave();
            loadList();
            napuniCombo();
            
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

    

     
    }
}
