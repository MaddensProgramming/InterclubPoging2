using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interclub
{
    public class Partijen
    {
        public Partijen()
        {
            Alles = new List<Partij>();
        }

        public List<Partij> Alles { get; set; }


        public void PartijToevoegen(Partij partij)
        {
            this.Alles.Add(partij);
        }

        public void PrintAlles()
        {
            foreach (Partij partij in Alles)
                Console.WriteLine(partij);

        }

        public void PrintSpeler(Speler speler)
        {
            var lijst = from partij in Alles
                        where partij.Wit == speler || partij.Zwart == speler
                        select partij;
            foreach (Partij partij in lijst)
                Console.WriteLine(partij);



        }

        public decimal PrintPunten(Speler speler)
        {
            decimal punten = 0;

            var lijstwit = from partij in Alles
                           where partij.Wit == speler
                           select partij;
            var lijstzwart = from partij in Alles
                             where partij.Zwart == speler
                             select partij;

            foreach (Partij partij in lijstwit)
            {
                if (partij.Resultaat == 1) punten++;
                if (partij.Resultaat == 2) punten += 0.5m;
            }
            foreach (Partij partij in lijstzwart)
            {
                if (partij.Resultaat == 3) punten++;
                if (partij.Resultaat == 2) punten += 0.5m;
            }

            return punten;

        }

        public decimal GemiddeldeElo(Ploeg team)
        {
            int totaalpunten = 0;
            int aantalpartijen = 0;
            var teamwit = from partij in Alles
                          where partij.ClubWit == team
                          select partij.Wit.Rating;


            foreach (int rating in teamwit) {
                totaalpunten += rating;
                aantalpartijen++;
            }
            var teamzwart = from partij in Alles
                          where partij.ClubZwart == team
                          select partij.Zwart.Rating;


            foreach (int rating in teamzwart)
            {
                totaalpunten += rating;
                aantalpartijen++;
            }

            return Math.Round(((decimal)totaalpunten / ((decimal)aantalpartijen)));




        }


    }
}
