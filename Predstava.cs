using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonis_Decembar
{
    public class Predstava
    {
        string ime;
        string id;
        string pozoriste;
     

        public string Pozoriste
        {
            get { return pozoriste; }
            set { pozoriste = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public override string ToString()
        {
            return ime;
        }

    }
}
