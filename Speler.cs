using System;
using System.Collections.Generic;
using System.Text;

namespace Interclub
{
    public class Speler
    {
        public Speler(int stamnummer, int rating, string naam, int clubId, string clubName)
        {
            Id = stamnummer;
            Rating = rating;
            Name = naam;
            ClubId = clubId;
            ClubName = clubName;
            Games = new List<Partij>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int Tpr { get; set; }        
        public decimal Score { get; set; }
        public int NumberOfGames { get; set; }    
        public List<Partij> Games {get; set;}        
        public int ClubId { get; set; }
        public string ClubName { get; set; }


        public Speler ShallowCopy()
        {
            var result = (Speler)MemberwiseClone();
            result.Games = new List<Partij>();
            return result;                
        }        

        public override string ToString()
        {
            return Name;
        }

    }
}
