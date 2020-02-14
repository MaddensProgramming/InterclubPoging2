﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interclub
{
    public class Ploegen
    {
        public Ploegen()
        {
            Lijst = new List<Ploeg>();
        }

        public List<Ploeg> Lijst { get; set; }



        public void PrintAllePloegen() {

            var alfabetisch = from ploeg in Lijst
                              orderby ploeg.Naam,ploeg.Nummer
                              select ploeg;
            foreach (Ploeg ploeg in alfabetisch)
                Console.WriteLine(ploeg);
        
        }

        public Ploeg AddPloeg(int clubnummer, string clubnaam, int ploegnummer, int klasse, string reeks) {

            var zoekopdracht = from ploeg in Lijst
                                       where (clubnummer == ploeg.Clubnummer) && (ploegnummer == ploeg.Nummer)
                                       select ploeg;

            if (zoekopdracht.Count() == 0)
            {

                Ploeg terug = new Ploeg(clubnummer, clubnaam, ploegnummer, klasse, reeks);
                Lijst.Add(terug);
                return terug;


            }
            else {
                return zoekopdracht.First();            
            
            }

        
        
        }


    }
}