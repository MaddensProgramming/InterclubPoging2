﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Interclub
{
    class Spelers
    {
        public List<Speler> Lijst { get; set; }

        public Spelers() {
        Lijst=new List<Speler>();        
        }

        public void SpelerToevoegen(Speler speler) {
            Lijst.Add(speler);
        }

        public Speler ZoekSpeler(int stamnummer, string naam, int rating)
        {
            foreach (Speler item in Lijst)
                if (item.Stamnummer == stamnummer)
                {  return item; }

            Speler nieuweSpeler= new Speler(stamnummer,rating, naam);
            SpelerToevoegen(nieuweSpeler);
            return nieuweSpeler;            

        }
    }

}