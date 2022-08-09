using CheckMate_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.DAL_Entities
{
    /// <summary>
    /// Objet Match de la DAL.
    /// </summary>
    public class Match : IEntity<int>
    {
        public int Id { get; set; }
        public int FkTournamentId { get; set; }
        public int FkWhitePlayer { get; set; }
        public int FkBlackPlayer { get; set; }
        public int MatchRound { get; set; }
        public char? Result { get; set; }
    }
}
