using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.Exceptions
{
    public class MyDALExceptions { }

    /// <summary>
    /// Exception levée quand la connexion a échouée.
    /// </summary>
    public class ConnectionFailedException : Exception 
    {
        public ConnectionFailedException(string message) : base(message) { }
    }
    /// <summary>
    /// Exception levée quand requête SQL a échouée.
    /// </summary>
    public class QuerryFailedException : Exception
    {
        public QuerryFailedException(string message) : base(message) { }
    }
    /// <summary>
    /// Exception levée quand un Member ne se trouve pas dans la base de donnée.
    /// </summary>
    public class MemberNotFoundException : Exception
    {
        public MemberNotFoundException(string message) : base(message) { }
    }
}
