﻿using CheckMate_DAL.DAL_Entities;
using CheckMate_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.Repositories
{
    public class MatchRepository : IRepository<Match, int>
    {
        #region Propriétés et constructeurs
        protected IDbConnection _Connection;
        public MatchRepository(IDbConnection connection)
        { _Connection = connection; }
        #endregion

        #region A FAIRE !!!!!
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
        #endregion
    }
}