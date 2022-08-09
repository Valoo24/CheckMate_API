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
    public class TournamentRepository : IRepository<Tournament, int>
    {

        protected IDbConnection _Connection;
        public TournamentRepository(IDbConnection connection) /*: base(connection, "Member", "Id")*/
        { _Connection = connection; }

        /// <summary>
        /// Verifie si la connection est bien fermée avant de l'ouvrir, sinon la ferme et rouvre
        /// </summary>
        public void ConnectionOpen()
        {
            if (_Connection.State == ConnectionState.Open)
            {
                _Connection.Close();

            }
            _Connection.Open();

        }
        // Securisation des entrées dans la DB 
        protected void AddParameter(IDbCommand cmd, string name, object data)
        {
            IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = name;
            param.Value = data ?? DBNull.Value;
            cmd.Parameters.Add(param);
        }

        protected Tournament Convert(IDataRecord record)
        {
            return new Tournament
            {
                Id = (int)record["Id"],
                Place = (string)record["Place"],
                MinPlayer = (int)record["Min_Player"],
                MaxPlayer = (int)record["Max_Player"],
                MinElo = (int)record["Min_Elo"],
                MaxElo = (int)record["Max_Elo"],
                Category = (char)record["Category"],
                TournamentStatus = (char)record["Tournament_Status"],
                TournamentRound = (int)record["Tournament_Round"],
                IsWomenOnly = (bool)record["Is_Women_Only"],
                CreationDate = (DateTime)record["Creation_Date"],
                UpdateDate = (DateTime)record["Update_Date"],
            };
        }

        public int Create(Tournament entity)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "Insert into [Tournament] ([Place] , Min_Player , Max_Player, Min_Elo , Max_Elo,  Category , Tournament_Status , Tournament_Round, Is_Women_Only, Creation_Date, Update_Date)  Outpout inserted.Member_Id Values (@Place , @MinPlayer, @MaxPlayer , @MinElo, @MaxElo , @Category , @TournamentStatus , @TournamentRound , @IsWomenOnly , @CreationDate , @UpdateDate ";

                // Ajout parametre SQL 
                AddParameter(cmd, "@Place", entity.Place);
                AddParameter(cmd, "@MinPlayer", entity.MinPlayer);
                AddParameter(cmd, "@MaxPlayer", entity.MaxPlayer);
                AddParameter(cmd, "@MinElo", entity.MinElo);
                AddParameter(cmd, "@MaxElo", entity.MaxElo);
                AddParameter(cmd, "@Category", entity.Category);
                AddParameter(cmd, "@TournamentStatus", 'W');
                AddParameter(cmd, "@TournamentRound", 0);
                AddParameter(cmd, "@IsWomenOnly", entity.IsWomenOnly);
                AddParameter(cmd, "@CreationDate", DateTime.Now);
                AddParameter(cmd, "@UpdateDate", DateTime.Now);


                ConnectionOpen();
                int id = (int)cmd.ExecuteScalar();
                _Connection.Close();
                return id;

            }
        }

        public bool Delete(Tournament entity)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"DELETE FROM Tournament WHERE Id = @id";
                AddParameter(cmd, "@id", entity.Id);

                _Connection.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public Tournament Read(int id)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM Tournament WHERE Id = @id";
                AddParameter(cmd, "@id", id);

                ConnectionOpen();
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return Convert(reader);
                    throw new ArgumentNullException($"Tournoi inexistant");
                }
            }
        }

        public IEnumerable<Tournament> ReadAll()
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM Tournament";

                ConnectionOpen();
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

        public bool Update(Tournament entity)
        {
            throw new NotImplementedException();
        }
    }
}
