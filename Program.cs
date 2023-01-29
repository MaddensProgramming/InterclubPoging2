using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Interclub
{
    public class Program
    {
        static void Main(string[] args)

        {


            List<Tuple<int, int>> round1 = new List<Tuple<int, int>>() { Tuple.Create(1, 12), Tuple.Create(2, 11), Tuple.Create(3, 10), Tuple.Create(4, 9), Tuple.Create(5, 8), Tuple.Create(6, 7) };
            List<Tuple<int, int>> round2 = new List<Tuple<int, int>>() { Tuple.Create(12, 7), Tuple.Create(8, 6), Tuple.Create(9, 5), Tuple.Create(10, 4), Tuple.Create(11, 3), Tuple.Create(1, 2) };
            List<Tuple<int, int>> round3 = new List<Tuple<int, int>>() { Tuple.Create(2, 12), Tuple.Create(3, 1), Tuple.Create(4, 11), Tuple.Create(5, 10), Tuple.Create(6, 9), Tuple.Create(7, 8) };
            List<Tuple<int, int>> round4 = new List<Tuple<int, int>>() { Tuple.Create(12, 8), Tuple.Create(9, 7), Tuple.Create(10, 6), Tuple.Create(11, 5), Tuple.Create(1, 4), Tuple.Create(2, 3) };
            List<Tuple<int, int>> round5 = new List<Tuple<int, int>>() { Tuple.Create(3, 12), Tuple.Create(4, 2), Tuple.Create(5, 1), Tuple.Create(6, 11), Tuple.Create(7, 10), Tuple.Create(8, 9) };
            List<Tuple<int, int>> round6 = new List<Tuple<int, int>>() { Tuple.Create(12, 9), Tuple.Create(10, 8), Tuple.Create(11, 7), Tuple.Create(1, 6), Tuple.Create(2, 5), Tuple.Create(3, 4) };
            List<Tuple<int, int>> round7 = new List<Tuple<int, int>>() { Tuple.Create(4, 12), Tuple.Create(5, 3), Tuple.Create(6, 2), Tuple.Create(7, 1), Tuple.Create(8, 11), Tuple.Create(9, 10) };
            List<Tuple<int, int>> round8 = new List<Tuple<int, int>>() { Tuple.Create(12, 10), Tuple.Create(11, 9), Tuple.Create(1, 8), Tuple.Create(2, 7), Tuple.Create(3, 6), Tuple.Create(4, 5) };
            List<Tuple<int, int>> round9 = new List<Tuple<int, int>>() { Tuple.Create(5, 12), Tuple.Create(6, 4), Tuple.Create(7, 3), Tuple.Create(8, 2), Tuple.Create(9, 1), Tuple.Create(10, 11) };
            List<Tuple<int, int>> round10 = new List<Tuple<int, int>>() { Tuple.Create(12, 11), Tuple.Create(1, 10), Tuple.Create(2, 9), Tuple.Create(3, 8), Tuple.Create(4, 7), Tuple.Create(5, 6) };
            List<Tuple<int, int>> round11 = new List<Tuple<int, int>>() { Tuple.Create(6, 12), Tuple.Create(7, 5), Tuple.Create(8, 4), Tuple.Create(9, 3), Tuple.Create(10, 2), Tuple.Create(11, 1) };
            var rounds = new List<List<Tuple<int, int>>>() { round1, round2, round3, round4, round5, round6, round7, round8, round9, round10, round11 };

            string[] shitPloegen = new string[] { "2 FOUS DIOGENE", "2 Fous Diogène", "LE 666", "Le 666", "Pion 68", "PION 68", "666", "2 Fous Diogene" };
            for (int i = 2022; i <= 2022; i++)
            {



                Ploegen ploegen = new Ploegen();
                Spelers spelers = new Spelers();
                Partijen partijen = new Partijen();

                #region Load Data
                for (int round = 1; round <= 6; round++)
                    using (StreamReader reader = new StreamReader($"rounds/{i}/ronde{round}.txt"))
                    {
                        #region initialize

                        string regel;
                        string reeks = "A";
                        int klasse = 1;
                        int board = 1;

                        int clubthuisNummer;
                        string clubthuisNaam;
                        int clubthuisPloegNummer;

                        int clubuitNummer;
                        string clubuitNaam;
                        int clubuitPloegNummer;

                        Team clubThuis = new Team(309, "Roeselare", 1, 4, "B");
                        Team clubUit = new Team(309, "Roeselare", 1, 4, "B");
                        #endregion

                        while ((regel = reader.ReadLine()) != null)
                        {


                            if (regel.StartsWith("Division") || regel.StartsWith("Afdeling"))
                            {
                                klasse = int.Parse(regel.Substring(regel.IndexOf(" ") + 1, 1));
                                reeks = regel.Substring(regel.Length - 1);
                            }




                            if (regel.Length > 6 && !regel.Contains('>') &&!regel.EndsWith('-') && regel[2]!='-')
                            {
                                #region Ploegen Inlezen
                                if (int.TryParse(regel.Substring(0, 3), out _) || regel.StartsWith("0 BYE"))
                                {

                                    clubthuisNummer = int.Parse(regel.Substring(0, regel.IndexOf(" ")));
                                    ForwardTillAfterWhitspace(ref regel);
                                    clubthuisNaam = "";

                                    if (shitPloegen.Any(name => regel.StartsWith(name)))
                                    {
                                        clubthuisNaam = shitPloegen.First(name => regel.StartsWith(name));
                                        regel = regel.Substring(clubthuisNaam.Length + 1);
                                    }
                                    else
                                    {
                                        while (!int.TryParse(regel.Substring(0, regel.IndexOf(" ")), out _) && !clubthuisNaam.StartsWith("BYE"))
                                        {
                                            clubthuisNaam += regel.Substring(0, regel.IndexOf(" ")) + " ";
                                            ForwardTillAfterWhitspace(ref regel);
                                        }
                                    }
                                    if (clubthuisNaam.StartsWith("BYE"))
                                        clubthuisPloegNummer = 0;
                                    else
                                    {
                                        clubthuisPloegNummer = int.Parse(regel.Substring(0, regel.IndexOf(" ")));
                                        ForwardTillAfterWhitspace(ref regel);
                                    }
                                    clubthuisNaam.Trim();

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
                                            clubuitNaam += regel.Substring(0, regel.IndexOf(" ")) + " ";
                                            ForwardTillAfterWhitspace(ref regel);
                                        }
                                    }


                                    if (clubuitNaam.StartsWith("BYE"))
                                        clubuitPloegNummer = 0;
                                    else
                                    {
                                        clubuitPloegNummer = int.Parse(regel.Substring(0, regel.IndexOf(" ")));
                                        ForwardTillAfterWhitspace(ref regel);
                                    }
                                    clubuitNaam.Trim();

                                    clubuitNummer = int.Parse(regel);

                                    clubThuis = ploegen.AddPloeg(clubthuisNummer, clubthuisNaam, clubthuisPloegNummer, klasse, reeks);
                                    clubUit = ploegen.AddPloeg(clubuitNummer, clubuitNaam, clubuitPloegNummer, klasse, reeks);

                                }
                                #endregion

                                #region Partijen Inlezen
                                if (int.TryParse(regel.Substring(0, 1), out board) && board != 0 && regel.IndexOf(" ") == 1)
                                {


                                    ForwardTillAfterWhitspace(ref regel);
                                    if (!regel.StartsWith('-') && regel[regel.Length - 5] != '-')
                                    {

                                        #region ReadWhite
                                        int witstamnummer = int.Parse(TillNextWhiteSpace(regel));
                                        ForwardTillAfterWhitspace(ref regel);
                                        string witspelerNaam = ReadName(ref regel);
                                        int witrating = int.Parse(TillNextWhiteSpace(regel));
                                        ForwardTillAfterWhitspace(ref regel);
                                        var white = spelers.ZoekSpeler(witstamnummer, witspelerNaam, witrating, clubThuis.ClubId, clubThuis.ClubName);
                                        #endregion

                                        int resultaat = ZoekResultaat(regel.Substring(0, regel.IndexOf(" ")));
                                        ForwardTillAfterWhitspace(ref regel);

                                        #region ReadBlack
                                        int zwartstamnummer = int.Parse(TillNextWhiteSpace(regel));
                                        ForwardTillAfterWhitspace(ref regel);
                                        string zwartspelerNaam = ReadName(ref regel);
                                        int zwartrating = int.Parse(regel);
                                        var black = spelers.ZoekSpeler(zwartstamnummer, zwartspelerNaam, zwartrating, clubUit.ClubId, clubUit.ClubName);
                                        #endregion


                                        if (board % 2 == 1)
                                            partijen.PartijToevoegen(new Game(board, white, black, clubThuis, clubUit, resultaat, round));
                                        else partijen.PartijToevoegen(new Game(board, black, white, clubUit, clubThuis, SwapResult(resultaat), round));

                                    }
                                }
                                #endregion
                            }

                        }

                    }
                #endregion


                spelers.VulGegevensIn(partijen);

                var clubs = new List<Club>();

                ploegen.Lijst.ForEach(ploeg => TryAddClub(ploeg, clubs));

                partijen.Alles.ForEach(partij => AddGame(partij, clubs));

                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    // WriteIndented = true
                };


                using (StreamReader reader = new StreamReader($"Pairingsnumbers/pairingsnumbers.txt"))
                {
                    string regel;

                    while ((regel = reader.ReadLine()) != null)
                    {
                        int.TryParse(regel.Substring(0, 2).Trim(), out int pairingsnumber);
                        int.TryParse(regel.Substring(regel.IndexOf('\t') + 1, 3), out int clubnumber);
                        int.TryParse(regel.Substring(regel.Length - 2, 2).Trim(), out int teamnumber);
                        var club = clubs.Find(club => club.Id == clubnumber);
                        if (club != null)
                        {
                            var team = club.Teams.Find(team => team.Id == teamnumber);
                            team.PairingsNumber = pairingsnumber;

                        }
                    }

                }

                var teams = clubs.SelectMany(club => club.Teams);

                foreach (var team in teams)
                {
                    for (int roundnumber = 1; roundnumber < 12; roundnumber++)
                    {
                        if (!team.Rounds.Exists(round => round.Id == roundnumber))
                        {
                            var pairing = rounds[roundnumber - 1].FirstOrDefault(pairing => pairing.Item1 == team.PairingsNumber || pairing.Item2 == team.PairingsNumber);
                            if (pairing?.Item1 == team.PairingsNumber)
                            {
                                var enemy = teams.FirstOrDefault(enemy => enemy.Division == team.Division && enemy.Class == team.Class && enemy.PairingsNumber == pairing.Item2);
                                team.Rounds.Add(new Round() { Id = roundnumber, ScoreAway = 0, ScoreHome = 0, Games = new List<Game>(), TeamHome = team?.ShallowCopy(), TeamAway = enemy?.ShallowCopy() });
                            }

                            if (pairing?.Item2 == team.PairingsNumber)
                            {
                                var enemy = teams.FirstOrDefault(enemy => enemy.Division == team.Division && enemy.Class == team.Class && enemy.PairingsNumber == pairing.Item1);
                                team.Rounds.Add(new Round() { Id = roundnumber, ScoreAway = 0, ScoreHome = 0, Games = new List<Game>(), TeamHome = enemy?.ShallowCopy(), TeamAway = team?.ShallowCopy() });
                            }
                        }
                    }
                }


                var jsonString = JsonSerializer.Serialize(clubs, serializeOptions);

                FileStream fParameter = new FileStream($"{i}.json", FileMode.Create, FileAccess.Write);
                StreamWriter m_WriterParameter = new StreamWriter(fParameter);
                m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
                m_WriterParameter.Write(jsonString);
                m_WriterParameter.Flush();
                m_WriterParameter.Close();



            }




        }

        private static string TillNextWhiteSpace(string regel)
        {
            return regel.Substring(0, regel.IndexOf(" ") + 1);
        }

        private static void ForwardTillAfterWhitspace(ref string regel)
        {
            regel = regel.Substring(regel.IndexOf(" ") + 1);

        }

        private static string ReadName(ref string regel)
        {
            string name = "";
            while (regel.Contains(' ') && !int.TryParse(regel.Substring(0, regel.IndexOf(" ")), out _))
            {
                name += regel.Substring(0, regel.IndexOf(" ")) + " ";
                ForwardTillAfterWhitspace(ref regel);
            }
            return name;
        }

        private static void AddGame(Game game, List<Club> club)
        {
            var clubWit = club.Find(club => club.Id == game.TeamWhite.ClubId);
            if (!clubWit.Players.Contains(game.White))
            {
                clubWit.Players.Add(game.White);
            }
            game.White.Games.Add(new Game(game));
            var teamWit = clubWit.Teams.Find(team => team.Id == game.TeamWhite.Id);


            var clubZwart = club.Find(club => club.Id == game.TeamBlack.ClubId);
            if (!clubZwart.Players.Contains(game.Black))
            {
                clubZwart.Players.Add(game.Black);
            }
            game.Black.Games.Add(new Game(game));
            var teamZwart = clubZwart.Teams.Find(team => team.Id == game.TeamBlack.Id);


            var round = teamWit.Rounds.Find(round => round.Id == game.Round);
            if (round is null)
            {
                if (game.Board % 2 == 1)
                {
                    round = new Round()
                    {
                        Id = game.Round,
                        ScoreAway = 0,
                        ScoreHome = 0,
                        TeamAway = teamZwart.ShallowCopy(),
                        TeamHome = teamWit.ShallowCopy(),
                        Games = new List<Game>()

                    };
                }
                else
                {
                    round = new Round()
                    {
                        Id = game.Round,
                        ScoreAway = 0,
                        ScoreHome = 0,
                        TeamAway = teamWit.ShallowCopy(),
                        TeamHome = teamZwart.ShallowCopy(),
                        Games = new List<Game>()
                    };
                }

                teamWit.Rounds.Add(round);
            }
            round.Games.Add(game.RemoveGamesFromPlayer());
            if (game.Board % 2 == 1)
            {
                round.ScoreAway += GetPointsBlack(game.Result);
                round.ScoreHome += GetPointsWhite(game.Result);
            }
            else
            {
                round.ScoreAway += GetPointsWhite(game.Result);
                round.ScoreHome += GetPointsBlack(game.Result);
            }

            round = teamZwart.Rounds.Find(round => round.Id == game.Round);
            if (round is null)
            {
                if (game.Board % 2 == 0)
                {
                    round = new Round()
                    {
                        Id = game.Round,
                        ScoreAway = 0,
                        ScoreHome = 0,
                        TeamAway = teamWit.ShallowCopy(),
                        TeamHome = teamZwart.ShallowCopy(),
                        Games = new List<Game>()

                    };
                }
                else
                {
                    round = new Round()
                    {
                        Id = game.Round,
                        ScoreAway = 0,
                        ScoreHome = 0,
                        TeamAway = teamZwart.ShallowCopy(),
                        TeamHome = teamWit.ShallowCopy(),
                        Games = new List<Game>()
                    };
                }

                teamZwart.Rounds.Add(round);
            }

            round.Games.Add(game.RemoveGamesFromPlayer());
            if (game.Board % 2 == 1)
            {
                round.ScoreAway += GetPointsBlack(game.Result);
                round.ScoreHome += GetPointsWhite(game.Result);
            }
            else
            {
                round.ScoreAway += GetPointsWhite(game.Result);
                round.ScoreHome += GetPointsBlack(game.Result);
            }

        }

        private static void TryAddClub(Team ploeg, List<Club> clubs)
        {
            var club = clubs.Find(c => c.Id == ploeg.ClubId);

            if (club == null)
            {
                club = new Club { Name = ploeg.ClubName, Id = ploeg.ClubId, Players = new List<Speler>(), Teams = new List<Team>() };
                clubs.Add(club);
            }
            club.Teams.Add(ploeg);

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
            if (resultaat == "0F-0F")
                return 6;

            return 0;

        }

        static decimal GetPointsWhite(int result)
        {
            switch (result)
            {
                case 1: return 1;
                case 2: return 0.5M;
                case 3: return 0;
                case 4: return 1;
                case 5: return 0;
                case 6: return 0;

                default: return result;
            }
        }

        static decimal GetPointsBlack(int result)
        {
            switch (result)
            {
                case 1: return 0;
                case 2: return 0.5M;
                case 3: return 1;
                case 4: return 0;
                case 5: return 1;
                case 6: return 0;

                default: return result;
            }
        }



        static int SwapResult(int result)
        {
            switch (result)
            {
                case 1: return 3;
                case 2: return 2;
                case 3: return 1;
                case 4: return 5;
                case 5: return 4;
                case 6: return 6;

                default: return result;
            }

        }

    }
}





