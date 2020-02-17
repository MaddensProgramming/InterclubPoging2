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

        public Speler ZoekSpeler(int stamnummer, string naam, int rating)
        {
            foreach (Speler item in Lijst)
                if (item.Stamnummer == stamnummer)
                {  return item; }

            Speler nieuweSpeler= new Speler(stamnummer,rating, naam);
            SpelerToevoegen(nieuweSpeler);
            return nieuweSpeler;            

        }

        public Speler ZoekSpeler(string naam) {

            foreach (Speler item in Lijst)
                if (item.Naam==naam)
                { return item; }


            return null;

        }

        public Speler ZoekSpeler(int stamnummer)
        {
            foreach (Speler item in Lijst)
                if (item.Stamnummer == stamnummer)
                { return item; }

            
            return null;

        }

        public void PrintTalenten(Partijen partijen) {

            VulGegevensIn(partijen);
            var lijst = from speler in Lijst
                        orderby speler.TPR descending, speler.Punten descending
                        where speler.AantalPartijen>3                      
                        select speler;
            int i = 1;
            foreach (Speler speler in lijst)
            {
                Console.WriteLine(i + ". " + speler + ", " + speler.Rating + ": " + speler.Punten +"/" + speler.AantalPartijen + " TPR: " + speler.TPR);
                i++;
            }


        }

        public void VulGegevensIn(Partijen partijen) {

            foreach (Speler speler in Lijst)
            {
                speler.Punten = partijen.PrintPunten(speler, out int aantalPartijen);
                speler.TPR = partijen.TPR(speler);
                speler.AantalPartijen = aantalPartijen;
            }

        }

        
    }

}
