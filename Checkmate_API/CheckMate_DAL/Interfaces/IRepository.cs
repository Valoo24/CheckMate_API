using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.Interfaces
{
    public interface IRepository<Tentity, TKey> where Tentity : IEntity<TKey>
    {
        // Implémenter ici les méthodes du CRUD
    }
}
