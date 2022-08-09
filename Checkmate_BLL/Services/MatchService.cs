using CheckMate_BLL.BLL_Entities;
using CheckMate_BLL.Interfaces;
using CheckMate_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_BLL.Services
{
    public class MatchService : IMatchService
    {
        private MatchRepository Repository;
        public MatchService(MatchRepository repository)
        {
            repository = Repository;
        }

        public int Create(Match entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Match Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Match> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Match entity)
        {
            throw new NotImplementedException();
        }
    }
}
