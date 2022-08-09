using CheckMate_BLL.BLL_Entities;
using CheckMate_BLL.Tools;
using CheckMate_DAL.Interfaces;
using CheckMate_DAL.Interfaces;
using CheckMate_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_BLL.Services
{
    /// <summary>
    /// Service qui permet de faire le lien des données correspondant aux Tournament entre la DAL et l'API.
    /// </summary>
    public class TournamentService : IRepository<Tournament, int>
    {
        #region Propriétés et constructeurs
        private TournamentRepository Repository;
        public TournamentService(TournamentRepository repository)
        {
            Repository = repository;
        }
        #endregion

        #region A FAIRE !!!!!
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
        #endregion
    }
}
