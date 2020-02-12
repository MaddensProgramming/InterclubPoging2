using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Interclub
{
    public class Program
    {
        static void Main(string[] args)
        {
            Ploegen database = new Ploegen();



            using (StreamReader reader = new StreamReader(@"C:\Users\User\Documents\ronde1.txt"))
            {
                string regel;
                string reeks = "A";
                int klasse = 1;

                int clubthuisNummer;
                string clubthuisNaam;
                int clubthuisPloegNummer;

                int clubuitNummer;
                string clubuitNaam;
                int clubuitPloegNummer;

                Ploeg clubThuis;
                Ploeg clubUit;



                while ((regel = reader.ReadLine()) != null)
                {


                    if (regel.StartsWith("Division"))
                    {
                        klasse = int.Parse(regel.Substring(regel.IndexOf(" ") + 1, 1));
                        reeks = regel.Substring(regel.Length - 1);
                    }




                    if (regel.Length > 3)
                        //ploegen inlezen
                        if (int.TryParse(regel.Substring(0, 3), out _) || regel.StartsWith("0 BYE"))
                        {

                            clubthuisNummer = int.Parse(regel.Substring(0, regel.IndexOf(" ")));
                            regel = regel.Substring(regel.IndexOf(" ") + 1);
                            clubthuisNaam = "";
                            if (regel.StartsWith("2 FOUS DIOGENE") || regel.StartsWith("LE 666"))
                            {
                                if (regel.StartsWith("2 FOUS DIOGENE"))
                                    clubthuisNaam = "2 FOUS DIOGENE";
                                if (regel.StartsWith("LE 666"))
                                    clubthuisNaam = "LE 666";
                                regel = regel.Substring(clubthuisNaam.Length + 1);
                            }
                            else
                            {
                                while (!int.TryParse(regel.Substring(0, regel.IndexOf(" ")), out _))
                                {
                                    clubthuisNaam += regel.Substring(0, regel.IndexOf(" "));
                                    regel = regel.Substring(regel.IndexOf(" ") + 1);
                                }
                            }
                            if (clubthuisNaam.StartsWith("BYE"))
                                clubthuisPloegNummer = 0;
                            else
                            {
                                clubthuisPloegNummer = int.Parse(regel.Substring(0, regel.IndexOf(" ")));
                                regel = regel.Substring(regel.IndexOf(" ") + 1);
                            }

                            clubuitNaam = "";
                            if (regel.StartsWith("2 FOUS DIOGENE") || regel.StartsWith("LE 666"))
                            {
                                if (regel.StartsWith("2 FOUS DIOGENE"))
                                    clubuitNaam = "2 FOUS DIOGENE";
                                if (regel.StartsWith("LE 666"))
                                    clubuitNaam = "LE 666";
                                regel = regel.Substring(clubuitNaam.Length + 1);
                            }
                            else
                            {

                                while (regel.Contains(' ') && !int.TryParse(regel.Substring(0, regel.IndexOf(" ")), out _))
                                {
                                    clubuitNaam += regel.Substring(0, regel.IndexOf(" "));
                                    regel = regel.Substring(regel.IndexOf(" ") + 1);
                                }
                            }


                            if (clubuitNaam.StartsWith("BYE"))
                                clubuitPloegNummer = 0;
                            else
                            {
                                clubuitPloegNummer = int.Parse(regel.Substring(0, regel.IndexOf(" ")));
                                regel = regel.Substring(regel.IndexOf(" ") + 1);
                            }

                            clubuitNummer = int.Parse(regel);

                            clubThuis=database.AddPloeg(clubthuisNummer, clubthuisNaam, clubthuisPloegNummer, klasse, reeks);
                            clubUit=database.AddPloeg(clubuitNummer, clubuitNaam, clubuitPloegNummer, klasse, reeks);

                        }


                    


                }







            }


            database.PrintAllePloegen();
        }
    }
}
