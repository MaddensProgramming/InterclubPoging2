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
            Alles = new List<Game>();
        }

        public List<Game> Alles { get; set; }


        public void PartijToevoegen(Game partij)
        {
            Alles.Add(partij);
        }      

        public int ScorePercentage(Speler speler, out int numberOfGames, out decimal punten)
        {


            punten = 0;
            numberOfGames = 0;

            var lijstwit = from partij in Alles
                           where partij.White == speler
                           select partij;
            var lijstzwart = from partij in Alles
                             where partij.Black == speler
                             select partij;

            foreach (Game partij in lijstwit)
            {
               switch (partij.Result)
                {
                    case 1: punten++; numberOfGames++;
                        break;
                    case 2: punten += 0.5M; numberOfGames++;
                        break;
                    case 3: numberOfGames++;
                        break;                    
                }
            }
            foreach (Game partij in lijstzwart)
            {
                switch (partij.Result)
                {
                    case 1:
                        numberOfGames++;
                        break;
                    case 2:
                        punten += 0.5M; numberOfGames++;
                        break;
                    case 3:
                        numberOfGames++; punten++;
                        break;
                }
            }
            if (numberOfGames == 0) return 0;
            return (int)Math.Round(punten / (numberOfGames) * 100); 


        }


        public int TPR(Speler speler)
        {
            var percentage = ScorePercentage(speler, out int numberOfGames, out decimal punten);

            if (numberOfGames == 0) return 0;
            return (int)GemiddeldeEloTegenstander(speler) + GetTpr(percentage);

        }

        public decimal GemiddeldeEloTegenstander(Speler speler)
        {


            decimal rating = 0;
            var lijstwit = from partij in Alles
                           where partij.White == speler&&(partij.Result==1 || partij.Result ==2 ||partij.Result==3)
                           select partij;
            var lijstzwart = from partij in Alles
                             where partij.Black == speler && (partij.Result == 1 || partij.Result == 2 || partij.Result == 3)
                             select partij;

            foreach (Game partij in lijstwit)
            {
                rating += partij.Black.Rating;
            }
            foreach (Game partij in lijstzwart)
            {
                rating += partij.White.Rating;
            }

            return rating / ((decimal)(lijstwit.Count() + lijstzwart.Count()));

        }

        public static int GetTpr(int percentage)
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
                default: return -1 * GetTpr(100 - percentage);


            }
        }     

    }
}



