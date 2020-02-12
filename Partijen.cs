using System;
using System.Collections.Generic;
using System.Text;

namespace Interclub
{
    public class Partijen
    {
       public static List<Partij> alles { get; set; }

        public static void PartijToevoegen(Partij partij)
        {
            alles.Add(partij);
        }

    


    }
}
