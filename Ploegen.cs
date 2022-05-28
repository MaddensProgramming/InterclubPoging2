using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interclub
{
    public class Ploegen
    {
        public Ploegen()
        {
            Lijst = new List<Team>();
        }

        public List<Team> Lijst { get; set; }



        public void PrintAllePloegen() {

            var alfabetisch = from ploeg in Lijst
                              orderby ploeg.ClubName,ploeg.Id
                              select ploeg;
            foreach (Team ploeg in alfabetisch)
                Console.WriteLine(ploeg);
        
        }

        public Team AddPloeg(int clubnummer, string clubnaam, int ploegnummer, int klasse, string reeks) {

            var zoekopdracht = from ploeg in Lijst
                                       where (clubnummer == ploeg.ClubId) && (ploegnummer == ploeg.Id)
                                       select ploeg;

            if (zoekopdracht.Count() == 0)
            {

                Team terug = new Team(clubnummer, clubnaam, ploegnummer, klasse, reeks);
                Lijst.Add(terug);
                return terug;


            }
            else {
                return zoekopdracht.First();            
            
            }

        
        
        }


        public Team ZoekPloeg(string clubnaam, int ploegnummer) {

            var zoekopdracht = from ploeg in Lijst
                               where (clubnaam == ploeg.ClubName) && (ploegnummer == ploeg.Id)
                               select ploeg;
            return zoekopdracht.First();
        }

    }
}
