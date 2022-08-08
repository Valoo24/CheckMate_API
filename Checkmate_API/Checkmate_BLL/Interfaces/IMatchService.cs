using CheckMate_BLL.BLL_Entities;
using CheckMate_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_BLL.Interfaces
{
    internal interface IMatchService : IRepository<Match,int>
    {
    }
}
