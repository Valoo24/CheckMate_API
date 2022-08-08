using CheckMate_BLL.BLL_Entities;
using CheckMate_DAL.DAL_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class Mappers
    {
        public static CheckMate_BLL.BLL_Entities.Member FromDALToBLL(this CheckMate_DAL.DAL_Entities.Member member)
        {
            return new CheckMate_BLL.BLL_Entities.Member
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
        public static CheckMate_DAL.DAL_Entities.Member FromBLLToDal(CheckMate_BLL.BLL_Entities.Member member)
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
        public static CheckMate_BLL.BLL_Entities.Match FromDALToBLL(this CheckMate_DAL.DAL_Entities.Match match)
        {
            return new CheckMate_BLL.BLL_Entities.Match
            {
                Id = match.Id,
                FkTournamentId = match.FkTournamentId,
                FkWhitePlayer = match.FkWhitePlayer,
                FkBlackPlayer = match.FkBlackPlayer,
                MatchRound = match.MatchRound,
                Result = match.Result,
            };
        }
        public static CheckMate_DAL.DAL_Entities.Match FromBLLToDAL(this CheckMate_BLL.BLL_Entities.Match match)
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
        public static CheckMate_BLL.BLL_Entities.Tournament FromDALToBLL(this CheckMate_DAL.DAL_Entities.Tournament tournament)
        {
            return new CheckMate_BLL.BLL_Entities.Tournament
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
        public static CheckMate_DAL.DAL_Entities.Tournament FromBLLToDAL(this CheckMate_BLL.BLL_Entities.Tournament tournament)
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
    }
}
