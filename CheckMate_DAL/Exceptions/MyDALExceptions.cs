﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.Exceptions
{
    public class MyDALExceptions { }
    public class ConnectionFailedException : Exception 
    {
        public ConnectionFailedException(string message) : base(message) { }
    }

    public class QuerryFailedException : Exception
    {
        public QuerryFailedException(string message) : base(message) { }
    }

    public class MemberNotFoundException : Exception
    {
        public MemberNotFoundException(string message) : base(message) { }
    }
}
