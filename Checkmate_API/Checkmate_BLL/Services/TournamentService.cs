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
    public class TournamentService : ITournamentService
    {
        private TournamentRepository Repository;

        public TournamentService(TournamentRepository repository)
        {
            Repository = repository;
        }

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
