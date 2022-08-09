
using CheckMate_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_BLL.BLL_Entities
{
    /// <summary>
    /// Objet Tournament de la BLL.
    /// </summary>
    public class Tournament : IEntity<int>
    {
        public int Id { get; set; }
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
        public DateTime UpdateDate { get; set; }
    }
}
