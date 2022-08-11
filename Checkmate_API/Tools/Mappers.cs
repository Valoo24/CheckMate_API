﻿using CheckMate_API.Models;

namespace CheckMate_API.Tools
{
    /// <summary>
    /// Classe dans laquelle il faut écrire les méthode d'extensions pour chaque Objet à transformer de l'API à la BLL et inversément.
    /// </summary>
    public static class Mappers
    {
        #region Member Mapper
        /// <summary>
        /// Permet de transformer un Member (Entity de la BLL) en un Model Member.
        /// </summary>
        /// <param name="member">Member (Entity de la BLL) à transformer.</param>
        /// <returns>Un model Member.</returns>
        public static Member FromBLLToModel(this CheckMate_BLL.BLL_Entities.Member member)
        {
            return new Member
            {
                MemberId = member.Id,
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
        /// Permet de transformer un model Member en un Member (Entity de la BLL).
        /// </summary>
        /// <param name="member">Model Member à transformer.</param>
        /// <returns>Un objet Member (Entity de la BLL).</returns>
        public static CheckMate_BLL.BLL_Entities.Member FromModelToBLL(this Member member)
        {
            return new CheckMate_BLL.BLL_Entities.Member
            {
                Id = member.MemberId,
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
        /// Permet de tranformer un formulaire de création d'un Member en un model Member.
        /// </summary>
        /// <param name="form">Formulaire de création d'un Member.</param>
        /// <returns>Un model Member.</returns>
        public static Member FromRegisterFormToModel(this MemberRegisterForm form)
        {
            return new Member
            {
                Pseudo = form.Pseudo,
                Mail = form.Mail,
                PasswordHash = form.Password,
                Birthdate = form.Birthdate,
                Gender = form.Gender,
                Elo = form.Elo
            };
        }
        /// <summary>
        /// Permet de transformer un model Member en un formulaire de création de Member.
        /// </summary>
        /// <param name="member">model Member à transformer.</param>
        /// <returns>Un formulaire de création de Member.</returns>
        public static MemberRegisterForm FromModelToRegisterForm(this Member member)
        {
            return new MemberRegisterForm
            {
                Pseudo = member.Pseudo,
                Mail = member.Mail,
                Password = member.PasswordHash,
                Birthdate = member.Birthdate,
                Gender = member.Gender,
                Elo = member.Elo,
            };
        }
        /// <summary>
        /// Permet de transformer un formulaire de Login en un model Member.
        /// </summary>
        /// <param name="form">formulaire de login à transformer.</param>
        /// <returns>Renvoie un Member sous forme de formulaire de login.</returns>
        public static Member FromLoginFormToModel(this MemberLoginForm form)
        {
            return new Member
            {
                Pseudo = form.Credentials,
                Mail = form.Credentials,
                PasswordHash = form.Password
            };
        }
        /// <summary>
        /// Permet de transformer un model Member en un formulaire de connexion de Member.
        /// </summary>
        /// <param name="member">model Member à transformer.</param>
        /// <returns>Un formulaire de création de Member.</returns>
        public static MemberLoginForm FromModelToLoginForm(this Member member)
        {
            return new MemberLoginForm
            {
                Credentials = member.Pseudo + " " + member.Mail,
                Password = member.PasswordHash,
            };
        }
        /// <summary>
        /// Permet de transformer un MemberUpdateForm en un model member.
        /// </summary>
        /// <param name="form">MemberModelForm à transformer.</param>
        /// <returns>Un model Member.</returns>
        public static Member FromUpdateFormToModel(this MemberUpdateForm form)
        {
            return new Member
            {
                Pseudo = form.Pseudo,
                Mail = form.Mail,
                Birthdate = form.Birthdate,
                Gender = form.Gender,
                Elo = form.Elo,
            };
        }
        #endregion

        #region Mapper Tournament
        /// <summary>
        /// Permet de transfromer un formulaire de création de Tournament en un model Tournament.
        /// </summary>
        /// <param name="tournament">Formulaire de création de Tournament à transformer.</param>
        /// <returns>Un model Tournament.</returns>
        public static Tournament FromTournamentFormToModel( this TournamentForm tournament)
        {
            return new Tournament
            {
                Name = tournament.Name,
                Place = tournament.Place,
                MinPlayer = tournament.MinPlayer,
                MaxPlayer = tournament.MaxPlayer,
                MinElo = tournament.MinElo,
                MaxElo = tournament.MaxElo,
                Category = tournament.Category,
                CreationDate = DateTime.Now,
                UpdateTime = DateTime.Now,
                TournamentStatus = "W",
                TournamentRound = 0,
                IsWomenOnly = tournament.IsWomenOnly
            };
        }
        /// <summary>
        /// Permet de transformer un model Tournament un Entity Tournament (Entity de la BLL)
        /// </summary>
        /// <param name="tournament">model de Tournament ) transformer.</param>
        /// <returns>Un Entity de Tournament (Entity de la BLL).</returns>
        public static CheckMate_BLL.BLL_Entities.Tournament FromAPIToBLL(this Tournament tournament)
        {
            return new CheckMate_BLL.BLL_Entities.Tournament
            {
                Name = tournament.Name,
                Place = tournament.Place,
                MinPlayer = tournament.MinPlayer,
                MaxPlayer = tournament.MaxPlayer,
                MinElo = tournament.MinElo,
                MaxElo = tournament.MaxElo,
                Category = tournament.Category,
                CreationDate = tournament.CreationDate,
                UpdateDate = tournament.UpdateTime,
                TournamentStatus = tournament.TournamentStatus,
                TournamentRound = 0,
                IsWomenOnly = tournament.IsWomenOnly
            };
        }
        /// <summary>
        /// Permet de Transformer un Entity Tournament de la BLL en un model Tournament.
        /// </summary>
        /// <param name="tournament">Entity Tournament de la BLL à tranformer.</param>
        /// <returns>un model de Tournament.</returns>
        public static Tournament FromBLLToModel(this CheckMate_BLL.BLL_Entities.Tournament tournament)
        {
            return new Tournament
            {
                Name = tournament.Name,
                Place = tournament.Place,
                MinPlayer = tournament.MinPlayer,
                MaxPlayer = tournament.MaxPlayer,
                MinElo = tournament.MinElo,
                MaxElo = tournament.MaxElo,
                Category = tournament.Category,
                TournamentStatus = tournament.TournamentStatus,
                TournamentRound = 0,
                IsWomenOnly = tournament.IsWomenOnly
            };
        }
        #endregion
    }
} 