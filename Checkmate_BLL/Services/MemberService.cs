﻿using CheckMate_BLL.BLL_Entities;
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
    /// <summary>
    /// Service qui permet de faire le lien des données correspondant aux Member entre la DAL et l'API.
    /// </summary>
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

<<<<<<< HEAD
=======
        #region A FAIRE !!!!!
>>>>>>> d2659366d949335ce68195efa2a22fc08e6a8685
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