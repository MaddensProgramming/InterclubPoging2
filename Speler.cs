using System;
using System.Collections.Generic;
using System.Text;

namespace Interclub
{
    public class Speler
    {
        public Speler(int stamnummer, int rating, string naam)
        {
            Stamnummer = stamnummer;
            Rating = rating;
            Naam = naam;
        }

        public int Stamnummer{ get; set; }
        public int Rating { get; set; }
        public string Naam { get; set; }

        public override string ToString()
        {
            return Naam;
        }

    }
}
