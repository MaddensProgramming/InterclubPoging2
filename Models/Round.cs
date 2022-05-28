using System.Collections.Generic;

namespace Interclub
{
    public class Round
    {
        public int Id { get; set; }
        public decimal ScoreHome { get; set; }
        public decimal ScoreAway { get; set; }
        public Team TeamHome { get; set; }
        public Team TeamAway { get; set; }
        public List<Game> Games { get; set; }
        
    }
}