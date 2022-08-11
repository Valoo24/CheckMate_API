using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_BLL.Exceptions
{
    public class MyExceptions
    {

    }

    public class MailNotSentExceptions : Exception 
    {
        public MailNotSentExceptions(string message) : base(message)
        {

        }
    }
}