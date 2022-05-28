using System;
using System.Collections.Generic;
using System.Text;

namespace Interclub
{
    public class Team
    {
        public Team(int clubnummer, string naam, int nummer, int klasse, string reeks)
        {
            ClubId = clubnummer;
            ClubName = naam;
            Id = nummer;
            Class = klasse;
            Division = reeks;
            Rounds = new List<Round>();
        }

        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public int Id { get; set; }
        public int Class { get; set; }
        public string Division { get; set; }
        public List<Round> Rounds { get; set; }

        public Team ShallowCopy()
        {
            var team = (Team)MemberwiseClone();
            team.Rounds = new List<Round>();
            return team;
            
        }

        public override string ToString()
        {
            return ClubName + " "+  Id; 
        }

    }




}
