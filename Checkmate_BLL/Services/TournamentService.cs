using CheckMate_BLL.BLL_Entities;
using CheckMate_BLL.Tools;
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

        #region Méthodes Custom
        public IEnumerable<Tournament> GetTop10ByUpdateTime()
        {
            foreach (CheckMate_DAL.DAL_Entities.Tournament tournament in Repository.GetTop10ByUpdateTime())
            {
                yield return tournament.FromDALToBLL();
            }
        }
        public bool CheckInscription(int idtournoi, int idjoueur)
        {
            return Repository.CheckInscription(idtournoi, idjoueur);
        }
        public bool PossibleInscription(Tournament tournoi, int eloJoueur, DateTime BirthdateJoueur, string genderJoueur)
        {
            return Repository.PossibleInscription(tournoi.FromBLLToDAL(), eloJoueur, BirthdateJoueur, genderJoueur);
        }

        public bool Inscription(int idTournoi, int idJoueur)
        {
            return Repository.Inscription(idTournoi, idJoueur);
        }

        /*public int NumberOfPlayersInTournament(int id)
        {
            return Repository.NumberOfPlayersInTournament(id);
        }*/
        #endregion

        #region Méthodes CRUD
        public int Create(Tournament entity)
        {
            int TournamentCreatedId = 0;
            try
            {
                TournamentCreatedId = Repository.Create(entity.FromBLLToDAL());
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            //Ici envoyer le mail pour les participants qui respectent les condition du tournoi.

            return TournamentCreatedId;
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

        #endregion

        #region A FAIRE !!!!!
        public bool Update(Tournament entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
