using CheckMate_BLL.BLL_Entities;
using CheckMate_BLL.Interfaces;
using CheckMate_BLL.Tools;
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
            return Repository.Create(entity.FromBLLToDAL());
        }

        public bool Delete(int id)
        {
            return Repository.Delete(id);
        }

        public Tournament Read(int id)
        {
           return Repository.Read(id).FromDALToBLL();
        }

        public IEnumerable<Tournament> ReadAll()
        {
            return Repository.ReadAll().Select(x => x.FromDALToBLL());
        }

        public bool Update(Tournament entity)
        {
            throw new NotImplementedException();
        }
    }
}
