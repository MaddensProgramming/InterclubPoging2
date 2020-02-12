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

        public static Speler SpelerChecken(int stamnummer, int rating, string naam) {
            if (Spelers.IsGeregistreerd(stamnummer, out Speler speler)) return speler;
            else { Speler nieuw= new Speler(stamnummer, rating, naam); Spelers.SpelerToevoegen(nieuw); return nieuw; }       
        } 
        
    }
}
