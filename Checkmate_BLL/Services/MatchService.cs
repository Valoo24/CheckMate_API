using CheckMate_BLL.BLL_Entities;
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
    /// Service qui permet de faire le lien des données correspondant aux Match entre la DAL et l'API.
    /// </summary>
    public class MatchService : IRepository<Match, int>
    {
        #region Propriétés et Constructeurs
        private MatchRepository Repository;
        public MatchService(MatchRepository repository)
        {
            repository = Repository;
        }
        #endregion

        #region A FAIRE !!!!!
        public int Create(Match entity)
        {
            throw new NotImplementedException();
        }
<<<<<<< HEAD

=======
>>>>>>> d2659366d949335ce68195efa2a22fc08e6a8685
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
        #endregion
    }
}
