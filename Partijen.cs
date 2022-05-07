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



        public decimal PrintPunten(Speler speler, out int aantalPartijen)
        {
            decimal punten = 0;

            var lijstwit = from partij in Alles
                           where partij.White == speler
                           select partij;
            var lijstzwart = from partij in Alles
                             where partij.Black == speler
                             select partij;

            foreach (Partij partij in lijstwit)
            {
                if (partij.Result == 1 || partij.Result == 4) punten++;
                if (partij.Result == 2) punten += 0.5m;
            }
            foreach (Partij partij in lijstzwart)
            {
                if (partij.Result == 3 || partij.Result == 5) punten++;
                if (partij.Result == 2) punten += 0.5m;
            }
            aantalPartijen = lijstwit.Count() + lijstzwart.Count();

            return punten;

        }

        public decimal GemiddeldeElo(Ploeg team)
        {
            int totaalpunten = 0;
            int aantalpartijen = 0;
            var teamwit = from partij in Alles
                          where partij.TeamWhite == team
                          select partij.White.Rating;


            foreach (int rating in teamwit)
            {
                totaalpunten += rating;
                aantalpartijen++;
            }
            var teamzwart = from partij in Alles
                            where partij.TeamBlack == team
                            select partij.Black.Rating;


            foreach (int rating in teamzwart)
            {
                totaalpunten += rating;
                aantalpartijen++;
            }

            return Math.Round(((decimal)totaalpunten / ((decimal)aantalpartijen)));




        }

        public int ScorePercentage(Speler speler)
        {


            decimal punten = 0;

            var lijstwit = from partij in Alles
                           where partij.White == speler
                           select partij;
            var lijstzwart = from partij in Alles
                             where partij.Black == speler
                             select partij;

            foreach (Partij partij in lijstwit)
            {
                if (partij.Result == 1 || partij.Result == 4) punten++;
                if (partij.Result == 2) punten += 0.5m;
            }
            foreach (Partij partij in lijstzwart)
            {
                if (partij.Result == 3 || partij.Result == 5) punten++;
                if (partij.Result == 2) punten += 0.5m;
            }

            return (int)Math.Round(punten / (lijstwit.Count() + lijstzwart.Count()) * 100);


        }


        public int TPR(Speler speler)
        {


            return (int)GemiddeldeEloTegenstander(speler) + BerekenPrestatie(ScorePercentage(speler));

        }

        public decimal GemiddeldeEloTegenstander(Speler speler)
        {

            decimal rating = 0;

            var lijstwit = from partij in Alles
                           where partij.White == speler
                           select partij;
            var lijstzwart = from partij in Alles
                             where partij.Black == speler
                             select partij;

            foreach (Partij partij in lijstwit)
            {
                rating += partij.Black.Rating;
            }
            foreach (Partij partij in lijstzwart)
            {
                rating += partij.White.Rating;
            }

            return rating / ((decimal)(lijstwit.Count() + lijstzwart.Count()));

        }

        public void PrintPartijen(Speler speler)
        {


            var lijst = from partij in Alles
                        where partij.White == speler || partij.Black == speler
                        select partij;

            foreach (var partij in lijst)
                Console.WriteLine(partij);


        }

        public static int BerekenPrestatie(int percentage)
        {
            switch (percentage)
            {
                case 0: return -800;
                case 1: return -677;
                case 2: return -589;
                case 3: return -538;
                case 4: return -501;
                case 5: return -470;
                case 6: return -444;
                case 7: return -422;
                case 8: return -401;
                case 9: return -383;
                case 10: return -366;
                case 11: return -351;
                case 12: return -336;
                case 13: return -322;
                case 14: return -309;
                case 15: return -296;
                case 16: return -284;
                case 17: return -273;
                case 18: return -262;
                case 19: return -251;
                case 20: return -240;
                case 21: return -230;
                case 22: return -220;
                case 23: return -211;
                case 24: return -202;
                case 25: return -193;
                case 26: return -184;
                case 27: return -175;
                case 28: return -166;
                case 29: return -158;
                case 30: return -149;
                case 31: return -141;
                case 32: return -133;
                case 33: return -125;
                case 34: return -117;
                case 35: return -110;
                case 36: return -102;
                case 37: return -95;
                case 38: return -87;
                case 39: return -80;
                case 40: return -72;
                case 41: return -65;
                case 42: return -57;
                case 43: return -50;
                case 44: return -43;
                case 45: return -36;
                case 46: return -29;
                case 47: return -21;
                case 48: return -14;
                case 49: return -7;
                case 50: return 0;
                default: return -1 * BerekenPrestatie(100 - percentage);


            }




        }


        public void ZoekTegenstander(Ploeg ploeg, int bord)
        {

            var lijst = from partij in Alles
                        where (partij.TeamWhite == ploeg || partij.TeamBlack == ploeg) && partij.Board == bord
                        select partij;

            foreach (var partij in lijst)
                Console.WriteLine(partij + " " + partij.TeamWhite + "-" + partij.TeamBlack);

        }
        public void PloegOpstelling(Ploeg ploeg, Spelers spelersdata)
        {
            var lijstwit = from partij in Alles
                           where partij.TeamWhite == ploeg
                           select new { naam = partij.White.Naam, bord = partij.Board };

            var lijstzwart = from partij in Alles
                             where partij.TeamBlack == ploeg
                             select new { naam = partij.Black.Naam, bord = partij.Board };





            List<Speler> spelers = new List<Speler>();

            foreach (var partij in lijstwit)
            {
                Speler lid = spelersdata.ZoekSpeler(partij.naam);
                if (!spelers.Contains(lid))
                    spelers.Add(lid);
            }
            foreach (var partij in lijstzwart)
            {
                Speler lid = spelersdata.ZoekSpeler(partij.naam);
                if (!spelers.Contains(lid))
                    spelers.Add(lid);
            }

            var spelers2 = from speler in spelers
                           orderby speler.Rating descending
                           select speler;


            foreach (Speler speler in spelers2)
            {

                Console.Write(speler.Naam + ": " + speler.Rating + "  " + speler.Score + "/" + speler.NumberOfGames + " TPR: " + speler.TPR + "\t Speelde op borden: ");
                foreach (var partij in lijstwit)
                    if (partij.naam == speler.Naam)
                        Console.Write(partij.bord + ", ");
                foreach (var partij in lijstzwart)
                    if (partij.naam == speler.Naam)
                        Console.Write(partij.bord + ", ");



                Console.WriteLine();

            }


        }

    }
}



