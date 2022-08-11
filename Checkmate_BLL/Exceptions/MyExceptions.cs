using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_BLL.Exceptions
{
    public class MyExceptions
    {
        /// <summary>
        /// Exception Levée si la connexion à la Base de donnée à Échouée.
        /// </summary>
        public class ConnectionFailedException : Exception { }
    }
}
