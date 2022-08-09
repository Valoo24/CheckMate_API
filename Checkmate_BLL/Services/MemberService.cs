using CheckMate_BLL.BLL_Entities;
using CheckMate_BLL.Interfaces;
using CheckMate_DAL.Repositories;
using CheckMate_BLL.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMate_DAL.Interfaces;

namespace CheckMate_BLL.Services
{
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
            return Repository.Create(entity.FromBLLToDal());
        }
        #endregion

        #region A FAIRE !!!!!
        public bool Delete(int id)
        {
            throw new NotImplementedException();
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