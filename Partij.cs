using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interclub
{
    public class Partij
    {


        public Partij(Partij partij)
        {
            White = partij.White.ShallowCopy();
            Black = partij.Black.ShallowCopy();
            TeamWhite = partij.TeamWhite;
            TeamBlack = partij.TeamBlack;
            Board = partij.Board;
            Result = partij.Result;
            Round = partij.Round;
        }

        public Partij(int bord, Speler wit, Speler zwart, Ploeg clubWit, Ploeg clubZwart, int resultaat, int round)
        {
            White = wit;
            Black = zwart;
            TeamWhite = clubWit;
            TeamBlack = clubZwart;
            Result = resultaat;
            Board = bord;
            Round = round;
        }

        public Speler White { get; set; }
        public Speler Black { get; set; }
        public Ploeg TeamWhite { get; set; }
        public Ploeg TeamBlack { get; set; }
        public int Board { get; set; }
        public int Round { get; set; }
        public int Result { get; set; }

        public string ResultaatWeergeven()
        {
            switch (Result)
            {
                case 1: return "1-0";
                case 2: return "1/2-1/2";
                case 3: return "0-1";
                case 4: return "1-0F";
                case 5: return "0-1F";

                default: return "0-0";
            }

        }

        public override string ToString()
        {
            return White.ToString() + " " + ResultaatWeergeven() + " " + Black.ToString();
        }

    }
}
