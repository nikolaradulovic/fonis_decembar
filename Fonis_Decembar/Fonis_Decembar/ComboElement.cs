using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonis_Decembar
{
    public class ComboElement
    {
        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public override string ToString()
        {
            
            return naziv;
        }

    }
}
