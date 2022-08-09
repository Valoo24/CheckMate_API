using CheckMate_BLL.BLL_Entities;
using CheckMate_BLL.Interfaces;
using CheckMate_DAL.Repositories;
using CheckMate_BLL.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_BLL.Services
{
    public class MemberService : IMemberService
    {
        private MemberRepository Repository;

        public MemberService(MemberRepository repository)
        {
            Repository = repository;
        }

        public int Create(Member entity)
        {
            return Repository.Create(entity.FromBLLToDal());
        }

        public int Delete(Member entity)
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

        public int Update(Member entity)
        {
            throw new NotImplementedException();
        }
    }
}
