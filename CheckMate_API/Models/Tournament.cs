using System.ComponentModel.DataAnnotations;

namespace CheckMate_API.Models
{
    /// <summary>
    /// Model principal de Tournament.
    /// </summary>
    public class Tournament
    {
        public string Name { get; set; }
        public int TournamentId { get; set; }
        public string Place { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public int MinElo { get; set; }
        public int MaxElo { get; set; }
        public string Category { get; set; }
        public string TournamentStatus { get; set; }
        public int TournamentRound { get; set; }
        public bool IsWomenOnly { get; set; }
        public int MemberRegisteredForTournament { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime EndDate 
        { 
            get
            {
                return new DateTime(CreationDate.AddDays((double)MinPlayer).Year, CreationDate.AddDays((double)MinPlayer).Month, CreationDate.AddDays((double)MinPlayer).Day, 23, 59, 59);
            }
        }
        public DateTime SavedEndDate { get; set; }
    }

    /// <summary>
    /// Model de formulaire pour les Tournament
    /// </summary>
    public class TournamentForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        [Range(2,32)]
        public int MinPlayer { get; set; }
        [Required]
        [Range(2, 32)]
        public int MaxPlayer { get; set; }
        [Range(0, 3000)]
        public int MinElo { get; set; }
        [Range(0, 3000)]
        public int MaxElo { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public bool IsWomenOnly { get; set; }
    }
}
