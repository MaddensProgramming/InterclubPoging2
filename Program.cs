using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Interclub
{
    public class Program
    {
        static void Main(string[] args)

        {

            string[] shitPloegen = new string[] { "2 FOUS DIOGENE", "2 Fous Diogène", "LE 666", "Le 666" };

            Ploegen ploegen = new Ploegen();
            Spelers spelers = new Spelers();
            Partijen partijen = new Partijen();

            #region Initialize data
            for (int i = 1; i <= 11; i++)
                using (StreamReader reader = new StreamReader("rondes/2021/ronde" + i + ".txt"))
                {
                    string regel;
                    string reeks = "A";
                    int klasse = 1;
                    int bord = 1;

                    int clubthuisNummer;
                    string clubthuisNaam;
                    int clubthuisPloegNummer;

                    int clubuitNummer;
                    string clubuitNaam;
                    int clubuitPloegNummer;

                    Ploeg clubThuis = new Ploeg(309, "Roeselare", 1, 4, "B");
                    Ploeg clubUit = new Ploeg(309, "Roeselare", 1, 4, "B");




                    while ((regel = reader.ReadLine()) != null)
                    {


                        if (regel.StartsWith("Division"))
                        {
                            klasse = int.Parse(regel.Substring(regel.IndexOf(" ") + 1, 1));
                            reeks = regel.Substring(regel.Length - 1);
                        }




                        if (regel.Length > 3)
                        {
                            #region Ploegen Inlezen
                            if (int.TryParse(regel.Substring(0, 3), out _) || regel.StartsWith("0 BYE"))
                            {

                                clubthuisNummer = int.Parse(regel.Substring(0, regel.IndexOf(" ")));
                                regel = regel.Substring(regel.IndexOf(" ") + 1);
                                clubthuisNaam = "";

                                if(shitPloegen.Any(name => regel.StartsWith(name))) 
                                {
                                    clubthuisNaam = shitPloegen.First(name => regel.StartsWith(name));
                                    regel = regel.Substring(clubthuisNaam.Length + 1);
                                }
                                else
                                {
                                    while (!int.TryParse(regel.Substring(0, regel.IndexOf(" ")), out _)&& !clubthuisNaam.StartsWith("BYE"))
                                    {
                                        clubthuisNaam += regel.Substring(0, regel.IndexOf(" ")) + " ";
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
                                if (shitPloegen.Any(name => regel.StartsWith(name)))
                                {
                                    clubuitNaam = shitPloegen.First(name => regel.StartsWith(name));
                                    regel = regel.Substring(clubuitNaam.Length + 1);
                                }
                                else
                                {

                                    while (regel.Contains(' ') && !int.TryParse(regel.Substring(0, regel.IndexOf(" ")), out _) && !clubuitNaam.StartsWith("BYE"))
                                    {
                                        clubuitNaam += regel.Substring(0, regel.IndexOf(" "))+ " ";
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

                                clubThuis = ploegen.AddPloeg(clubthuisNummer, clubthuisNaam, clubthuisPloegNummer, klasse, reeks);
                                clubUit = ploegen.AddPloeg(clubuitNummer, clubuitNaam, clubuitPloegNummer, klasse, reeks);

                            }
                            #endregion

                            #region Partijen Inlezen
                            if (int.TryParse(regel.Substring(0, 1), out bord) && bord != 0 && regel.IndexOf(" ") == 1)
                            {

                                regel = regel.Substring(regel.IndexOf(" ") + 1);
                                int witstamnummer = int.Parse(regel.Substring(0, regel.IndexOf(" ") + 1));
                                regel = regel.Substring(regel.IndexOf(" ") + 1);
                                string witspelerNaam = "";
                                while (!int.TryParse(regel.Substring(0, regel.IndexOf(" ")), out _))
                                {
                                    witspelerNaam += regel.Substring(0, regel.IndexOf(" "))+ " ";
                                    regel = regel.Substring(regel.IndexOf(" ") + 1);
                                }
                                int witrating = int.Parse(regel.Substring(0, regel.IndexOf(" ") + 1));
                                regel = regel.Substring(regel.IndexOf(" ") + 1);

                                int resultaat = ZoekResultaat(regel.Substring(0, regel.IndexOf(" ")));
                                regel = regel.Substring(regel.IndexOf(" ") + 1);

                                int zwartstamnummer = int.Parse(regel.Substring(0, regel.IndexOf(" ") + 1));
                                regel = regel.Substring(regel.IndexOf(" ") + 1);
                                string zwartspelerNaam = "";
                                while (regel.Contains(' ') && !int.TryParse(regel.Substring(0, regel.IndexOf(" ")), out _))
                                {
                                    zwartspelerNaam += regel.Substring(0, regel.IndexOf(" "))+ " ";
                                    regel = regel.Substring(regel.IndexOf(" ") + 1);
                                }
                                int zwartrating = int.Parse(regel);

                                partijen.PartijToevoegen(new Partij(bord, spelers.ZoekSpeler(witstamnummer, witspelerNaam, witrating),
                                    spelers.ZoekSpeler(zwartstamnummer, zwartspelerNaam, zwartrating), clubThuis, clubUit, resultaat));

                            }
                            #endregion
                        }

                    }

                }
            #endregion


            //spelers.PrintTalenten(partijen);

            /*decimal totaal = 0;

            var onzeReeks = from ploeg in database.Lijst
                            where ploeg.Reeks == "A" && ploeg.Klasse == 2
                            select ploeg;

            foreach (var team in onzeReeks)
            {
                totaal += partijen.GemiddeldeElo(team);
                Console.WriteLine(team.ToString() + ": " + partijen.GemiddeldeElo(team));   
                    }
            Console.WriteLine("A: " + totaal / 12);
             totaal = 0;
             */



            //spelers.PrintTalenten(partijen);


            spelers.VulGegevensIn(partijen);

            //partijen.PloegOpstelling(database.ZoekPloeg("JEANJAURES", 2),spelers);           

            var club = new List<Club>();

            ploegen.Lijst.ForEach(ploeg => TryAddClub(ploeg, club));

            partijen.Alles.ForEach(partij => AddGame(partij, club));

            var json = JsonSerializer.Serialize(club);

            //Console.WriteLine(json);

            FileStream fParameter = new FileStream("games.json", FileMode.Create, FileAccess.Write);
            StreamWriter m_WriterParameter = new StreamWriter(fParameter);
            m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
            m_WriterParameter.Write(json);
            m_WriterParameter.Flush();
            m_WriterParameter.Close();

            Console.ReadLine();


        }

        private static void AddGame(Partij partij, List<Club> club)
        {
            var clubWit = club.Find(club => club.Id == partij.TeamWhite.Id);
            if (!clubWit.Spelers.Contains(partij.White))
            {
                clubWit.Spelers.Add(partij.White);
            }
            partij.White.Games.Add(new Partij(partij));


            var clubZwart = club.Find(club => club.Id == partij.TeamBlack.Id);
            if (!clubZwart.Spelers.Contains(partij.Black))
            {
                clubZwart.Spelers.Add(partij.Black);
            }
            partij.Black.Games.Add(new Partij(partij));

        }

        private static void TryAddClub(Ploeg ploeg, List<Club> club)
        {
            if (!club.Exists( club => club.Id == ploeg.Id))
                club.Add(new Club { Name = ploeg.Naam, Id= ploeg.Id, Spelers = new List<Speler>() }) ;
            
        }

        static int ZoekResultaat(string resultaat)
        {
            if (resultaat == "1-0")
                return 1;
            if (resultaat == "½-½")
                return 2;
            if (resultaat == "0-1")
                return 3;
            if (resultaat == "1F-0F")
                return 4;
            if (resultaat == "0F-1F")
                return 5;           

            return 0;

        }
    }
}





