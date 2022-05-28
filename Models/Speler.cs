using System;
using System.Collections.Generic;
using System.Text;

namespace Interclub
{
    public class Speler
    {
        public Speler(int stamnummer, int rating, string firstName, string lastName, int clubId, string clubName)
        {
            Id = stamnummer;
            Rating = rating;
            FirstName = firstName;
            Name = lastName;
            ClubId = clubId;
            ClubName = clubName;
            Games = new List<Game>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public int Rating { get; set; }        
        public int Tpr { get; set; }        
        public decimal Score { get; set; }
        public int NumberOfGames { get; set; }    
        public List<Game> Games {get; set;}        
        public int ClubId { get; set; }
        public string ClubName { get; set; }


        public Speler ShallowCopy()
        {
            var result = (Speler)MemberwiseClone();
            result.Games = new List<Game>();
            return result;                
        }        

        public override string ToString()
        {
            return Name;
        }

    }
}
