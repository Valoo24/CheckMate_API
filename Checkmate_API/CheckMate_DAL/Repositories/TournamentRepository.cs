using CheckMate_DAL.DAL_Entities;
using CheckMate_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.Repositories
{
    public class TournamentRepository : IRepository<Tournament, int>
    {
        public int Create(Tournament entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Tournament entity)
        {
            throw new NotImplementedException();
        }

        public Tournament Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tournament> ReadAll()
        {
            throw new NotImplementedException();
        }

        public int Update(Tournament entity)
        {
            throw new NotImplementedException();
        }
    }
}
