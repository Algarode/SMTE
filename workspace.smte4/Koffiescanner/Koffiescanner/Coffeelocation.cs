using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koffiescanner
{
    class Coffeelocation
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNr { get; set; }
        public string Score { get; set; }

        public Coffeelocation(string name, int rank, string address, string city, string phoneNr, string score)
        {
            this.Name = name;
            this.Rank = rank;
            this.Address = address;
            this.City = city;
            this.PhoneNr = phoneNr;
            this.Score = score;
        }
    }
}