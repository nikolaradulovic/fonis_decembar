using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonis_Decembar
{
    public class Glumac
    {
        string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        string prezime;

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }
        string datumRodjenja;

        public string DatumRodjenja
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value; }
        }
        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public override string ToString()
        {
            return ime + " " + prezime;

        }

        public override bool Equals(object obj)
        {
            if (ime == ((Glumac)obj).ime && prezime == ((Glumac)obj).prezime)
                return true;
            else
                return false;
             
        }
        public Glumac(string ime, string prezime, string datumRodjenja, string id)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.id = id;
        }

    }
}
