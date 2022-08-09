using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.Tools
{
    /// <summary>
    /// Classe où il faut rajouter les méthodes d'accès aux données dans la base de données communes aux Repository.
    /// </summary>
    public static class DataAccess
    {
        /// <summary>
        /// Ouvre correctement la connection à la base de donnée, quelque soit l'état de la connection.
        /// </summary>
        /// <param name="connection">Connection du repository à utiliser pour la gestion de la connection.</param>
        public static void ConnectionOpen(IDbConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
        }
        /// <summary>
        /// Permet de sécuriser l'introduction par l'utilisateur de données dans la base de données.
        /// </summary>
        /// <param name="cmd">Commande SQL à introduire dans le base de donnée.</param>
        /// <param name="name">Nom référencé de la donnée dans la requête SQL.</param>
        /// <param name="data">Donée à sécuriser et à introduire dans la basse de donnée.</param>
        public static void AddParameter(IDbCommand cmd, string name, object data)
        {
            IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = name;
            param.Value = data ?? DBNull.Value;
            cmd.Parameters.Add(param);
        }
    }
}
