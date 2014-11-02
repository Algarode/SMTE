using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koffiescanner
{
    class Reactie
    {
        public string Naam { get; set; }
        public string Commentaar { get; set; }

        public Reactie(string naam, string commentaar)
        {
            this.Naam = naam;
            this.Commentaar = commentaar;
        }
    }
}
