﻿using CheckMate_API.Models;

namespace CheckMate_API.Tools
{
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
                Elo = form.Elo,
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
        #endregion
    }
}