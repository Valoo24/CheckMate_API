using CheckMate_BLL.BLL_Entities;
using CheckMate_DAL.Repositories;
using CheckMate_BLL.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMate_DAL.Interfaces;
using Isopoh.Cryptography.Argon2;

namespace CheckMate_BLL.Services
{
    /// <summary>
    /// Service qui permet de faire le lien des données correspondant aux Member entre la DAL et l'API.
    /// </summary>
    public class MemberService : IRepository<Member, int>
    {
        #region Propriétés et constructeurs
        private MemberRepository Repository;
        public MemberService(MemberRepository repository)
        {
            Repository = repository;
        }
        #endregion

        #region Méthodes du CRUD
        public int Create(Member entity)
        {
            // Hashage du mot de passe
            string pwdHash = Argon2.Hash(entity.PasswordHash);

            // Ajout du password hashé dans la DB
            CheckMate_DAL.DAL_Entities.Member DBEntity = entity.FromBLLToDal();
            DBEntity.PasswordHash = pwdHash;


            // Recuperation du member
           
            return Repository.Create(DBEntity);
        }
        #endregion

        #region Méthode Custom
        public Member Login(string credential , string password)
        {
            // Récuperation le Hash lier au compte
            string hash = Repository.GetHashByCredential(credential);

            if (string.IsNullOrWhiteSpace(hash))
            {
                throw new Exception("User inexistant");
            }

            // Validation du hash avec le password
            if (Argon2.Verify(hash, password))
            {
                return Repository.GetByCredential(credential).FromDALToBLL();
            }
            else
            {
                throw new Exception("Mot de passe incorrect");
            }
            
            
        }
        #endregion

        #region A FAIRE !!!!!
        public bool Delete(int id)
        {
            return Repository.Delete(id);
        }

        public Member Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Member entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}