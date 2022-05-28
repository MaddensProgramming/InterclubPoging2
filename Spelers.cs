using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interclub
{
   public class Spelers
    {
        public List<Speler> Lijst { get; set; }

        public Spelers() {
        Lijst=new List<Speler>();        
        }

        public void SpelerToevoegen(Speler speler) {
            Lijst.Add(speler);
        }

        public Speler ZoekSpeler(int stamnummer, string naam , int rating, int clubId, string clubName)
        {
            foreach (Speler item in Lijst)
                if (item.Id == stamnummer)
                {  return item; }

            var namen = naam.Split(',');


            Speler nieuweSpeler= new Speler(stamnummer,rating, namen[1].Trim(), namen[0] , clubId, clubName);
            SpelerToevoegen(nieuweSpeler);
            return nieuweSpeler;            

        }


        public Speler ZoekSpeler(string naam) {

            foreach (Speler item in Lijst)
                if (item.Name==naam)
                { return item; }


            return null;

        }

    

        public void VulGegevensIn(Partijen partijen) {

            foreach (Speler speler in Lijst)
            {
                partijen.ScorePercentage(speler, out int aantalPartijen, out decimal punten);
                speler.Score = punten;
                speler.Tpr = partijen.TPR(speler);
                speler.NumberOfGames = aantalPartijen;
            }

        }

        
    }

}
