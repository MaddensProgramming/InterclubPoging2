using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interclub
{
    public class Partij
    {
       

        public Partij(Partij partij)
        {
            Wit = partij.Wit.ShallowCopy();
            Zwart = partij.Zwart.ShallowCopy();
            ClubWit = partij.ClubWit;
            ClubZwart = partij.ClubZwart;
            Bord = partij.Bord;
            Resultaat = partij.Resultaat;
        }

        public Partij(int bord,Speler wit, Speler zwart, Ploeg clubWit, Ploeg clubZwart, int resultaat)
        {
            Wit = wit;
            Zwart = zwart;
            ClubWit = clubWit;
            ClubZwart = clubZwart;
            Resultaat = resultaat;
            Bord = bord;
        }

        public Speler Wit { get; set; }
        public Speler Zwart { get; set; }
        public Ploeg ClubWit { get; set; }
        public Ploeg ClubZwart { get; set; }
        public int Bord { get; set; }
        public int Resultaat { get; set; }

        public string ResultaatWeergeven()
        {
            switch (Resultaat)
            {
                case 1:
                    return "1-0";
                    
                case 2:
                    return "1/2-1/2";
                    
                case 3: return "0-1";

                default: return "0-0";
            }

        }

        public override string ToString()
        {
            return Wit.ToString() + " " + ResultaatWeergeven() + " " + Zwart.ToString();
        }

    }
}
