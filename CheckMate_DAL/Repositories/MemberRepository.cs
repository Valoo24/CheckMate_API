﻿using CheckMate_DAL.DAL_Entities;
using CheckMate_DAL.Exceptions;
using CheckMate_DAL.Interfaces;
using CheckMate_DAL.Tools;
using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.Repositories
{
    /// <summary>
    /// Repository où sont définies toutes les méthodes d'accès aux données dans la base de donnée pour les Member.
    /// </summary>
    public class MemberRepository : IRepository<Member, int>
    {
        #region propriétés et Constructeur
        protected IDbConnection _Connection;
        public MemberRepository(IDbConnection connection) //: base(connection, "Member", "Id")
        { _Connection = connection; }
        #endregion

        #region Méthodes CRUD
        /// <summary>
        /// Permet de convertir les données de la table Member de la base de donnée en un objet Member (Entity de la DAL).
        /// </summary>
        /// <param name="record">Tableau de donnée récupérée dpuis la base de donnée.</param>
        /// <returns>Un Member (Entity de la DAL).</returns>
        protected Member Convert(IDataRecord record)
        {
            return new Member
            {
                Id = (int)record["Member_Id"],
                Pseudo = (string)record["Pseudo"],
                Mail = (string)record["Mail"],
                PasswordHash = (string)record["Password_Hash"],
                Birthdate = (DateTime)record["Birthdate"],
                Gender = (string)record["Gender"],
                Elo = (int)record["Elo"],
                IsAdmin = (bool)record["Is_Admin"]
            };
        }

        /// <summary>
        /// Permet d'enregistrer un Member (Entity de la DAL) dans la base de donnée.
        /// </summary>
        /// <param name="entity">Objet Member à enregistrer dans la base de donnée.</param>
        /// <returns>L'ID du Member crée dans la base de donnée.</returns>
        public int Create(Member entity)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "Insert into [Member] ([Pseudo] , Mail , Password_Hash, Birthdate , Gender , Elo , Is_Admin) Output inserted.Member_Id Values (@Pseudo , @Mail, @PasswordHash , @Birthdate , @Gender , @Elo , @IsAdmin)";

                // Ajout parametre SQL 
                DataAccess.AddParameter(cmd, "@Pseudo", entity.Pseudo);
                DataAccess.AddParameter(cmd, "@Mail", entity.Mail);
                DataAccess.AddParameter(cmd, "@PasswordHash", entity.PasswordHash);
                DataAccess.AddParameter(cmd, "@Birthdate", entity.Birthdate);
                DataAccess.AddParameter(cmd, "@Gender", entity.Gender);
                DataAccess.AddParameter(cmd, "@Elo", entity.Elo);
                DataAccess.AddParameter(cmd, "@IsAdmin", entity.IsAdmin);

                try
                {
                    DataAccess.ConnectionOpen(_Connection);
                }
                catch (ConnectionFailedException e)
                {
                    throw new ConnectionFailedException(e.Message);
                }

                try
                {
                    int id = (int)cmd.ExecuteScalar();
                    return id;
                }
                catch (Exception e)
                {
                    throw new QuerryFailedException(e.Message);
                }
            }
        }

        /// <summary>
        /// Permet de récupérer un Member dans la base de donnée selon l'ID introduit.
        /// </summary>
        /// <param name="id">ID du Member à récupérer dans la base de donnée</param>
        /// <returns>Un Member (Entity de la DAL).</returns>
        public Member Read(int id)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM Member WHERE Member_Id = @Id";
                DataAccess.AddParameter(cmd, "@Id", id);

                try
                {
                    DataAccess.ConnectionOpen(_Connection);
                }
                catch (ConnectionFailedException e)
                {
                    throw new ConnectionFailedException(e.Message);
                }

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Convert(reader);
                    }
                    else
                    {
                        throw new MemberNotFoundException($"Aucun Member correspondant à l'ID n°{id} n'a été trouvé dans la base de donnée.");
                    }
                }
            }
        }

        /// <summary>
        /// Permet de récupérer tous les Member de la base de donnée.
        /// </summary>
        /// <returns>Un IEnumerable des Members présents dans la base de donnée.</returns>
        /// <exception cref="ConnectionFailedException">Exception levée si la connexion à la base de donnée à échoué.</exception>
        /// <exception cref="Exception">Exception levée si pour une raison il est impossible de lire et de convertir les données de la base de donnée.</exception>
        public IEnumerable<Member> ReadAll()
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM Member";

                try
                {
                    DataAccess.ConnectionOpen(_Connection);
                }
                catch (ConnectionFailedException e)
                {
                    throw new ConnectionFailedException(e.Message);
                }

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        do
                        {
                            yield return Convert(reader);
                        } while (reader.Read());
                    }
                    else
                    {
                        throw new Exception("Impossible de lire les données du tableau");
                    }
                }
            }
        }

        /// <summary>
        /// Permet de supprimer un Member dans la base de donée selon l'ID introduit.
        /// </summary>
        /// <param name="id">ID du Member à supprimer dans la base de donnée.</param>
        /// <returns>True si le Member a été supprimé correctement, False si une erreur s'est produite.</returns>
        public bool Delete(int id)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"DELETE FROM Member WHERE Member_Id = @id";
                DataAccess.AddParameter(cmd, "@id", id);

                try
                {
                    DataAccess.ConnectionOpen(_Connection);
                }
                catch (ConnectionFailedException e)
                {
                    throw new ConnectionFailedException(e.Message);
                }

                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public bool Update(Member entity)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"UPDATE Member SET Pseudo = @pseudo, Mail = @mail, Birthdate = @birthdate, Gender = @gender, Elo = @elo WHERE Member_Id = @id";

                DataAccess.AddParameter(cmd, "@pseudo", entity.Pseudo);
                DataAccess.AddParameter(cmd, "@mail", entity.Mail);
                DataAccess.AddParameter(cmd, "@birthdate", entity.Birthdate);
                DataAccess.AddParameter(cmd, "@gender", entity.Gender);
                DataAccess.AddParameter(cmd, "@elo", entity.Elo);
                DataAccess.AddParameter(cmd, "@id", entity.Id);

                try
                {
                    DataAccess.ConnectionOpen(_Connection);
                }
                catch(ConnectionFailedException e)
                {
                    throw new ConnectionFailedException(e.Message);
                }

                return cmd.ExecuteNonQuery() == 1;
            }
        }
        #endregion

        #region Méthodes Custom

        /// <summary>
        /// Récupère le mot de passe Hashé et stocké dans la base de donnée selon le credential (Pseudo ou Adresse Mail) en paramètre.
        /// </summary>
        /// <param name="credential">Pseudo ou Mail introduit par l'utilisateur.</param>
        /// <returns>Le mot de passe Hashé de l'utilisateur.</returns>
        public string GetHashByCredential(string credential)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT Password_Hash FROM Member WHERE Pseudo = @Credential OR Mail = @Credential";
                DataAccess.AddParameter(cmd, "@Credential", credential);

                try
                {
                    DataAccess.ConnectionOpen(_Connection);
                }
                catch (ConnectionFailedException e)
                {
                    throw new ConnectionFailedException(e.Message);
                }

                object result = cmd.ExecuteScalar();

                return result is DBNull ? null : (string)result;
            }
        }
        /// <summary>
        /// Récupère un Member dans la base de donnée selon le credential (Pseudo ou Mail) en paramètre.
        /// </summary>
        /// <param name="credential">Pseudo ou Mail introduit par l'utilisateur.</param>
        /// <returns>Le Member correspondant au Pseudo ou Mail introduit.</returns>
        public Member GetByCredential(string credential)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM Member WHERE Pseudo = @Credential OR Mail = @Credential";
                DataAccess.AddParameter(cmd, "@Credential", credential);

                try
                {
                    DataAccess.ConnectionOpen(_Connection);
                }
                catch (ConnectionFailedException e)
                {
                    throw new ConnectionFailedException(e.Message);
                }

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return Convert(reader);
                    return null;
                }
            }
        }

        #endregion
    }
}