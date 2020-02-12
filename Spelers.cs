using System;
using System.Collections.Generic;
using System.Text;

namespace Interclub
{
    class Spelers
    {
        public static List<Speler> lijst { get; set; }

        public static void SpelerToevoegen(Speler speler) {
            lijst.Add(speler);
        }

        public static bool IsGeregistreerd(int stamnummer, out Speler speler)
        {
            foreach (Speler item in lijst)
                if (item.Stamnummer == stamnummer)
                { speler = item; return true; }

            speler = null;
            return false;
            

        }
    }

}
