using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

       
        public Speler ZoekSpeler(int stamnummer)
        {
            foreach (Speler item in Lijst)
                if (item.Stamnummer == stamnummer)
                { return item; }

            
            return null;

        }

        public void PrintTalenten(Partijen partijen) {

            foreach (Speler speler in Lijst)            
                speler.Punten = partijen.PrintPunten(speler);
            var lijst = from speler in Lijst                        
                        orderby speler.Punten descending, speler.Rating descending
                        select speler;
            int i = 1;
            foreach (Speler speler in lijst)
            {
                Console.WriteLine(i + ". " + speler + ": " + speler.Punten + " " + speler.Rating);
                i++;
            }


        }

        
    }

}
