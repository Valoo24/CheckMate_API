using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_BLL.Tools
{
    /// <summary>
    /// Classe dans laquelle il faut écrire les méthode d'extensions pour chaque Objet à transformer de la BLL à la DAL et inversément.
    /// </summary>
    public static class Mappers
    {
        #region Mapper Member
        /// <summary>
        /// Transforme un Member de la DAL en un Member de la BLL.
        /// </summary>
        /// <param name="member">Objet de type Member de la DAL à transformer.</param>
        /// <returns>Renvoie un objet de typer Member de la BLL.</returns>
        public static BLL_Entities.Member FromDALToBLL(this CheckMate_DAL.DAL_Entities.Member member)
        {
            return new BLL_Entities.Member
            {
                Id = member.Id,
                Pseudo = member.Pseudo,
                Mail = member.Mail,
                PasswordHash = member.PasswordHash,
                Birthdate = member.Birthdate,
                Gender = member.Gender,
                Elo = member.Elo,
                IsAdmin = member.IsAdmin,
            };
        }
        /// <summary>
        /// Transforme un Member de la BLL en un Member de la DAL.
        /// </summary>
        /// <param name="member">Objet de type Member de la BLL à transformer</param>
        /// <returns>Renvoie un objet de typer Member de la DAL.</returns>
        public static CheckMate_DAL.DAL_Entities.Member FromBLLToDal(this BLL_Entities.Member member)
        {
            return new CheckMate_DAL.DAL_Entities.Member
            {
                Id = member.Id,
                Pseudo = member.Pseudo,
                Mail = member.Mail,
                PasswordHash = member.PasswordHash,
                Birthdate = member.Birthdate,
                Gender = member.Gender,
                Elo = member.Elo,
                IsAdmin = member.IsAdmin,
            };
        }
        #endregion

        #region Mapper Match
        /// <summary>
        /// Transforme un Match de la DAL en un Match de la BLL.
        /// </summary>
        /// <param name="match">Objet de type Match de la DAL à transformer</param>
        /// <returns>Renvoie un objet de typer Match de la BLL.</returns>
        public static BLL_Entities.Match FromDALToBLL(this CheckMate_DAL.DAL_Entities.Match match)
        {
            return new BLL_Entities.Match
            {
                Id = match.Id,
                FkTournamentId = match.FkTournamentId,
                FkWhitePlayer = match.FkWhitePlayer,
                FkBlackPlayer = match.FkBlackPlayer,
                MatchRound = match.MatchRound,
                Result = match.Result,
            };
        }
        /// <summary>
        /// Transforme un Match de la DAL en un Match de la BLL.
        /// </summary>
        /// <param name="match">Objet de type Match de la DAL à transformer.</param>
        /// <returns>Renvoie un objet de typer Match de la BLL.</returns>
        public static CheckMate_DAL.DAL_Entities.Match FromBLLToDAL(this BLL_Entities.Match match)
        {
            return new CheckMate_DAL.DAL_Entities.Match
            {
                Id = match.Id,
                FkTournamentId = match.FkTournamentId,
                FkWhitePlayer = match.FkWhitePlayer,
                FkBlackPlayer = match.FkBlackPlayer,
                MatchRound = match.MatchRound,
                Result = match.Result,
            };
        }
        #endregion

        #region Mapper Tournament
        /// <summary>
        /// Transforme un Tournament de la DAL en un Tournament de la BLL.
        /// </summary>
        /// <param name="tournament">Objet de type Tournament de la DAL à transformer</param>
        /// <returns>Renvoie un objet de typer Tournament de la BLL.</returns>
        public static BLL_Entities.Tournament FromDALToBLL(this CheckMate_DAL.DAL_Entities.Tournament tournament)
        {
            return new BLL_Entities.Tournament
            {
                Id = tournament.Id,
                Place = tournament.Place,
                MinPlayer = tournament.MinPlayer,
                MaxPlayer = tournament.MaxPlayer,
                MinElo = tournament.MinElo,
                MaxElo = tournament.MaxElo,
                Category = tournament.Category,
                TournamentStatus = tournament.TournamentStatus,
                TournamentRound = tournament.TournamentRound,
                IsWomenOnly = tournament.IsWomenOnly,
                CreationDate = tournament.CreationDate,
                UpdateDate = tournament.UpdateDate,
            };
        }
        /// <summary>
        /// Transforme un Tournament de la DAL en un Tournament de la BLL.
        /// </summary>
        /// <param name="tournament">Objet de type Tournament de la DAL à transformer.</param>
        /// <returns>Renvoie un objet de type Tournament de la BLL.</returns>
        public static CheckMate_DAL.DAL_Entities.Tournament FromBLLToDAL(this BLL_Entities.Tournament tournament)
        {
            return new CheckMate_DAL.DAL_Entities.Tournament
            {
                Id = tournament.Id,
                Place = tournament.Place,
                MinPlayer = tournament.MinPlayer,
                MaxPlayer = tournament.MaxPlayer,
                MinElo = tournament.MinElo,
                MaxElo = tournament.MaxElo,
                Category = tournament.Category,
                TournamentStatus = tournament.TournamentStatus,
                TournamentRound = tournament.TournamentRound,
                IsWomenOnly = tournament.IsWomenOnly,
                CreationDate = tournament.CreationDate,
                UpdateDate = tournament.UpdateDate,
            };
        }
        #endregion
    }
}
