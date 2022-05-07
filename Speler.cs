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
            Partijen = new List<Partij>();
        }

        public int Stamnummer { get; set; }
        public int Rating { get; set; }
        public string Naam { get; set; }

        public decimal Punten { get; set; }

        public int AantalPartijen { get; set; }

        public int TPR { get; set; }

        public List<Partij> Partijen {get; set;}

        public Speler ShallowCopy()
        {
            var result = (Speler)MemberwiseClone();
            result.Partijen = new List<Partij>();
            return result;                
        }        

        public override string ToString()
        {
            return Naam;
        }

    }
}
