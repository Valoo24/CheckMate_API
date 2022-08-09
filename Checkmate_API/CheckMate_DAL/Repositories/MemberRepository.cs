using CheckMate_DAL.DAL_Entities;
using CheckMate_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.Repositories
{
    public class MemberRepository : IRepository<Member, int>
    {
        protected IDbConnection _Connection;
        public MemberRepository(IDbConnection connection) /*: base(connection, "Member", "Id")*/
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
        protected Member Convert(IDataRecord record)
        {
            return new Member
            {
                Id = (int)record["Id"],
                Pseudo = (string)record["Pseudo"],
                Mail = (string)record["Email"],
                PasswordHash = (string)record["Password_Hash"],
                Birthdate = (DateTime)record["Birthdate"],
                Gender = (char)record["Gender"],
                Elo = (int)record["Elo"],
                IsAdmin = (bool)record["IsAdmin"]
            };
        }


        public int Create(Member entity)
        {
            using(IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "Insert into [Member] ([Pseudo] , Mail , Password_Hash, Birthdate , Gender , Elo , Is_Admin) Output inserted.Member_Id Values (@Pseudo , @Mail, @PasswordHash , @Birthdate , @Gender , @Elo , @IsAdmin)";

                // Ajout parametre SQL 
                AddParameter(cmd, "@Pseudo", entity.Pseudo);
                AddParameter(cmd, "@Mail", entity.Mail);
                AddParameter(cmd, "@PasswordHash", entity.PasswordHash);
                AddParameter(cmd, "@Birthdate", entity.Birthdate);
                AddParameter(cmd, "@Gender", entity.Gender);
                AddParameter(cmd, "@Elo", entity.Elo);
                AddParameter(cmd, "@IsAdmin", entity.IsAdmin);

                ConnectionOpen();
                int id = (int)cmd.ExecuteScalar();
                _Connection.Close();
                return id;
            }
        }

        public int Delete(Member entity)
        {
            throw new NotImplementedException();
        }

        public Member Read(int id)
        {

            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM Member WHERE Member_Id = @Id";
                AddParameter(cmd, "@Id", id);

                ConnectionOpen();
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return Convert(reader);
                    return null;
                }
            }
        }

        public IEnumerable<Member> ReadAll()
        {
            throw new NotImplementedException();
        }

        public int Update(Member entity)
        {
            throw new NotImplementedException();
        }
    }
}
