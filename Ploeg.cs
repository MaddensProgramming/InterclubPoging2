using System;
using System.Collections.Generic;
using System.Text;

namespace Interclub
{
    public class Ploeg
    {
        public Ploeg(int clubnummer, string naam, int nummer, int klasse, string reeks)
        {
            Clubnummer = clubnummer;
            Naam = naam;
            Nummer = nummer;
            Klasse = klasse;
            Reeks = reeks;
        }

        public int Clubnummer { get; set; }

        public string Naam { get; set; }

        public int Nummer { get; set; }
        public int Klasse { get; set; }
        public string Reeks { get; set; }


        public override string ToString()
        {
            return Naam + " "+  Nummer; 
        }

    }




}
