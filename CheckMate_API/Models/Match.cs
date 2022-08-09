namespace CheckMate_API.Models
{
    public class Match
    {
        public int MatchId { get; set; }

        public int TournamentId { get; set; }

        public int Round { get; set; }

        public int WhiteMemberId { get; set; }

        public int BlackMemberId { get; set; }

        public string Result { get; set; }
    }
}
