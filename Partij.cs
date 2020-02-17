using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interclub
{
    public class Partij
    {
        public Partij(Speler wit, Speler zwart, Ploeg clubWit, Ploeg clubZwart, int resultaat)
        {
            Wit = wit;
            Zwart = zwart;
            ClubWit = clubWit;
            ClubZwart = clubZwart;
            Resultaat = resultaat;
        }

        public Speler Wit { get; set; }
        public Speler Zwart { get; set; }
        public Ploeg ClubWit { get; set; }
        public Ploeg ClubZwart { get; set; }
        public int Resultaat { get; set; }

        public override string ToString()
        {
            return Wit.ToString() + " " + Resultaat + " " + Zwart.ToString();
        }
       
    }
}
