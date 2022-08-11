using CheckMate_DAL.DAL_Entities;
using CheckMate_DAL.Interfaces;
using CheckMate_DAL.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.Repositories
{
    /// <summary>
    /// Repository où sont définies toutes les méthodes d'accès aux données dans la base de donnée pour les Tournanment.
    /// </summary>
    public class TournamentRepository : IRepository<Tournament, int>
    {
        #region Propriétés et constructeurs
        protected IDbConnection _Connection;
        public TournamentRepository(IDbConnection connection)
        { _Connection = connection; }
        #endregion

        #region Méthodes Custom
        public IEnumerable<Tournament> GetTop10ByUpdateTime()
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT Top 10 * FROM V_Tournaments2 ORDER BY Update_Date";

                DataAccess.ConnectionOpen(_Connection);
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return Convert(reader);
                    }
                }
            }
        }
        protected Tournament Convert(IDataRecord record)
        {
            int nbreJoueur;
            if( record["Nombre_Joueurs"] is DBNull)
            { nbreJoueur = 0; }
            else
            { nbreJoueur = (int)record["Nombre_Joueurs"]; }

            return new Tournament
            {
                Id = (int)record["Tournament_Id"],
                Name = (string)record["Name"],
                Place = (string)record["Place"],
                MinPlayer = (int)record["Min_Player"],
                MaxPlayer = (int)record["Max_Player"],
                MinElo = (int)record["Min_Elo"],
                MaxElo = (int)record["Max_Elo"],
                Category = (string)record["Category"],
                TournamentStatus = (string)record["Tournament_Status"],
                TournamentRound = (int)record["Tournament_Round"],
                IsWomenOnly = (bool)record["Is_Women_Only"],
                CreationDate = (DateTime)record["Creation_Date"],
                UpdateDate = (DateTime)record["Update_Date"],
                MemberRegisteredForTournament = nbreJoueur
            };
        }
        public bool Inscription(int idTournoi, int idJoueur)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = " Insert into [Tournament_Inscription] ( [FK_Tournament_Id], [FK_Member_Id] )  Values ( @idTournoi, @idJoueur ) ";

                // Ajout parametre SQL 
                DataAccess.AddParameter(cmd, "@idTournoi", idTournoi);
                DataAccess.AddParameter(cmd, "@idJoueur", idJoueur);

                DataAccess.ConnectionOpen(_Connection);


                return cmd.ExecuteNonQuery() == 1;
                _Connection.Close();
            }
        }
        public bool Unsubscription(int idTournoi, int idJoueur)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = " Delete FROM Tournament_Inscription where FK_Tournament_Id = @idTournoi AND FK_Member_Id = @idJoueur ";

                // Ajout parametre SQL 
                DataAccess.AddParameter(cmd, "@idTournoi", idTournoi);
                DataAccess.AddParameter(cmd, "@idJoueur", idJoueur);

                DataAccess.ConnectionOpen(_Connection);


                return cmd.ExecuteNonQuery() == 1;
                _Connection.Close();
            }
        }

/*public int NumberOfPlayersInTournament(int tournamentId)
{
    using (IDbCommand cmd = _Connection.CreateCommand())
    {
        cmd.CommandText = "SELECT count(*) From Tournament_Inscription where FK_Tournament_Id = @tournamentId GROUP BY FK_Tournament_Id  ";
        // Ajout parametre SQL 
        DataAccess.AddParameter(cmd, "@tournamentId", tournamentId);


        DataAccess.ConnectionOpen(_Connection);

        int id = (int)cmd.ExecuteScalar();
        _Connection.Close();
        return id;
    }
}*/
        public bool CheckInscription(int idTournoi, int idJoueur)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM Tournament_Inscription  WHERE FK_Tournament_Id = @idTournoi AND FK_Member_Id = @idJoueur";
                DataAccess.AddParameter(cmd, "@idTournoi", idTournoi);
                DataAccess.AddParameter(cmd, "@idJoueur", idJoueur);

                DataAccess.ConnectionOpen(_Connection);
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        return true;
                    }


                    else return false;
                }
            }
        }
        public bool PossibleInscription(Tournament tournoi, int eloJoueur, DateTime BirthdateJoueur, string genderJoueur)
        {
            bool PeutInscrire = false;
            bool conditionGenerale = false;
            bool conditionGender = false;
            bool conditionAge = false;
            if (tournoi.TournamentStatus == "W"
                && DateTime.Now <= new DateTime(tournoi.CreationDate.AddDays((double)tournoi.MinPlayer).Year, tournoi.CreationDate.AddDays((double)tournoi.MinPlayer).Month, tournoi.CreationDate.AddDays((double)tournoi.MinPlayer).Day, 23, 59, 59)
                && eloJoueur <= tournoi.MaxElo && eloJoueur >= tournoi.MinElo && tournoi.MemberRegisteredForTournament < tournoi.MaxPlayer)
            { conditionGenerale = true; }

            if ( (tournoi.IsWomenOnly == true && genderJoueur == "F") || (tournoi.IsWomenOnly == false && (genderJoueur =="M" || genderJoueur =="X") ))
            { conditionGender = true; }

            int age = DateTime.Today.Year - BirthdateJoueur.Year;
            if (BirthdateJoueur.Date > DateTime.Today.AddYears(-age))
                age--;
            if ((age < 18 && tournoi.Category == "J") || ((age >= 18 && age < 60) && tournoi.Category == "S") || (age >= 60 && tournoi.Category == "V"))
            { conditionAge = true; }


           
            PeutInscrire = (conditionAge && conditionGender && conditionGenerale);

            return PeutInscrire;

        }

        public bool TournamentStarted(Tournament tournoi)
        {
            if (tournoi.TournamentStatus == "W")
                return false;
            else return true;
        }

        #endregion

        #region Méthodes CRUD
        /// <summary>
        /// Permet de convertir les données de la table Tournament de la base de donnée en un objet Tournament (Entity dans la DAL).
        /// </summary>
        /// <param name="record">Tableau de donnée récupérée de la base de donnée SQL.</param>
        /// <returns>Un objet Tournament (Entity dans la DAL).</returns>
        /*protected Tournament Convert(IDataRecord record)
        {
            return new Tournament
            {
                Id = (int)record["Tournament_Id"],
                Name = (string)record["Name"],
                Place = (string)record["Place"],
                MinPlayer = (int)record["Min_Player"],
                MaxPlayer = (int)record["Max_Player"],
                MinElo = (int)record["Min_Elo"],
                MaxElo = (int)record["Max_Elo"],
                Category = (string)record["Category"],
                TournamentStatus = (string)record["Tournament_Status"],
                TournamentRound = (int)record["Tournament_Round"],
                IsWomenOnly = (bool)record["Is_Women_Only"],
                CreationDate = (DateTime)record["Creation_Date"],
                UpdateDate = (DateTime)record["Update_Date"]
                
            };
        }*/
        /// <summary>
        /// Méthode permettant d'enregistrer un tournoi dans la base de donnée.
        /// </summary>
        /// <param name="entity">Objet Tournoi à enregistrer dans la base de donnée.</param>
        /// <returns>l'ID du tournoi crée.</returns>
        public int Create(Tournament entity)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "Insert into [Tournament] (Name, [Place] , Min_Player , Max_Player, Min_Elo , Max_Elo,  Category , Tournament_Status , Tournament_Round, Is_Women_Only, Creation_Date, Update_Date)  Output inserted.Tournament_Id Values (@Name, @Place , @MinPlayer, @MaxPlayer , @MinElo, @MaxElo , @Category , @TournamentStatus , @TournamentRound , @IsWomenOnly , @CreationDate , @UpdateDate)";

                // Ajout parametre SQL 
                DataAccess.AddParameter(cmd, "@Name", entity.Name);
                DataAccess.AddParameter(cmd, "@Place", entity.Place);
                DataAccess.AddParameter(cmd, "@MinPlayer", entity.MinPlayer);
                DataAccess.AddParameter(cmd, "@MaxPlayer", entity.MaxPlayer);
                DataAccess.AddParameter(cmd, "@MinElo", entity.MinElo);
                DataAccess.AddParameter(cmd, "@MaxElo", entity.MaxElo);
                DataAccess.AddParameter(cmd, "@Category", entity.Category);
                DataAccess.AddParameter(cmd, "@TournamentStatus", 'W');
                DataAccess.AddParameter(cmd, "@TournamentRound", 0);
                DataAccess.AddParameter(cmd, "@IsWomenOnly", entity.IsWomenOnly);
                DataAccess.AddParameter(cmd, "@CreationDate", DateTime.Now);
                DataAccess.AddParameter(cmd, "@UpdateDate", DateTime.Now);


                DataAccess.ConnectionOpen(_Connection);
                int id = (int)cmd.ExecuteScalar();
                _Connection.Close();
                return id;
            }
        }
        /// <summary>
        /// Supprime un Tournament dans la base de donnée.
        /// </summary>
        /// <param name="id">ID du Tournament à supprimer</param>
        /// <returns>True si le Tournament à été supprimé correctement, False si ce n'est pas le cas.</returns>
        public bool Delete(int id)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"DELETE FROM Tournament WHERE Tournament_Id = @id";
                DataAccess.AddParameter(cmd, "@id", id);

                DataAccess.ConnectionOpen(_Connection);
                return cmd.ExecuteNonQuery() == 1;
            }
        }
        /// <summary>
        /// Récupère un Tournament de la base de donnée via une ID.
        /// </summary>
        /// <param name="id">ID du Tournament à récupérer.</param>
        /// <returns>Le Tournament(Entity de la DAL) correspondant à l'ID.</returns>
        /// <exception cref="ArgumentNullException">Une exception est levée si l'ID ne correspond à aucun Tournament dans la base de donnée.</exception>
        public Tournament Read(int id)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM V_Tournaments2 WHERE Tournament_Id = @id";
                DataAccess.AddParameter(cmd, "@id", id);

                DataAccess.ConnectionOpen(_Connection);
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return Convert(reader);
                    throw new ArgumentNullException($"Tournoi inexistant");
                }
            }
        }
        /// <summary>
        /// Récupère tous les Tournament de la base de données.
        /// </summary>
        /// <returns>Une liste (sous four de IEnumerable) de tous les Tournament présent dans la base de données.</returns>
        public IEnumerable<Tournament> ReadAll()
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM V_Tournaments2";

                DataAccess.ConnectionOpen(_Connection);
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return Convert(reader);
                    }
                }
                _Connection.Close();
            }
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
