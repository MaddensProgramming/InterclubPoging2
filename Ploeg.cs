using System;
using System.Collections.Generic;
using System.Text;

namespace Interclub
{
    public class Ploeg
    {
        public Ploeg(int clubnummer, string naam, int nummer, int klasse, string reeks)
        {
            ClubId = clubnummer;
            ClubName = naam;
            TeamNumber = nummer;
            Class = klasse;
            Division = reeks;
        }

        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public int TeamNumber { get; set; }
        public int Class { get; set; }
        public string Division { get; set; }

        public Ploeg ShallowCopy()
        {
            return (Ploeg)MemberwiseClone();          
        }

        public override string ToString()
        {
            return ClubName + " "+  TeamNumber; 
        }

    }




}
