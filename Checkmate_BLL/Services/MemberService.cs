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


            // Récupération du member

            try
            {
                return Repository.Create(DBEntity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region Méthode Custom
        public Member Login(string credential, string password)
        {
            // Récuperation le Hash lié au compte
            string hash = Repository.GetHashByCredential(credential);

            if (string.IsNullOrWhiteSpace(hash))
            {
                throw new Exception("Member inexistant");
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

        public bool Delete(int id)
        {
            bool IsDeleted = false;

            try
            {
                IsDeleted = Repository.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return IsDeleted;
        }

        public Member Read(int id)
        {
            try
            {
                return Repository.Read(id).FromDALToBLL();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Member> ReadAll()
        {
            IList<CheckMate_DAL.DAL_Entities.Member> DALMemberList = new List<CheckMate_DAL.DAL_Entities.Member>();

            try
            {
                foreach (CheckMate_DAL.DAL_Entities.Member member in Repository.ReadAll())
                {
                    DALMemberList.Add(member);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            foreach(CheckMate_DAL.DAL_Entities.Member member in DALMemberList)
            {
                yield return member.FromDALToBLL();
            }
        }

        public bool Update(Member entity)
        {
            try
            {
                return Repository.Update(entity.FromBLLToDal());
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}