using System.ComponentModel.DataAnnotations;

namespace CheckMate_API.Models
{
    /// <summary>
    /// Model principal de Tournament.
    /// </summary>
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string Place { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public int MinElo { get; set; }
        public int MaxElo { get; set; }
        public char Category { get; set; }
        public char TournamentStatus { get; set; }
        public int TournamentRound { get; set; }
        public bool IsWomenOnly { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateTime { get; set; }

    }

    /// <summary>
    /// Model de formulaire pour les Tournament
    /// </summary>
    public class TournamentForm
    {

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
        public char Category { get; set; }
        [Required]
        public bool IsWomenOnly { get; set; }
    }
}
