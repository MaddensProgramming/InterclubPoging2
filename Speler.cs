using System;
using System.Collections.Generic;
using System.Text;

namespace Interclub
{
    public class Speler
    {
        public Speler(int stamnummer, int rating, string naam)
        {
            Id = stamnummer;
            Rating = rating;
            Naam = naam;
            Games = new List<Partij>();
        }

        public int Id { get; set; }
        public int Rating { get; set; }
        public string Naam { get; set; }
        public decimal Score { get; set; }
        public int NumberOfGames { get; set; }
        public int TPR { get; set; }
        public List<Partij> Games {get; set;}

        public Speler ShallowCopy()
        {
            var result = (Speler)MemberwiseClone();
            result.Games = new List<Partij>();
            return result;                
        }        

        public override string ToString()
        {
            return Naam;
        }

    }
}
