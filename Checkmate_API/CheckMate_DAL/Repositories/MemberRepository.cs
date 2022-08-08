using CheckMate_DAL.DAL_Entities;
using CheckMate_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.Repositories
{
    public class MemberRepository : IRepository<Member, int>
    {
        public int Create(Member entity)
        {
            throw new NotImplementedException();
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
