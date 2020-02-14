using System;
using System.Collections.Generic;
using System.Text;

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

        public void PrintAlles() {
            foreach (Partij partij in Alles)
                Console.WriteLine(partij);
        
        }
    


    }
}
