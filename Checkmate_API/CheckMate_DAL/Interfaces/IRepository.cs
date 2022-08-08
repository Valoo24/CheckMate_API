using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.Interfaces
{
    public interface IRepository<Tentity, TKey> where Tentity : IEntity<TKey>
    {
        public TKey Create(Tentity entity);
        public Tentity Read(TKey id);
        public IEnumerable<Tentity> ReadAll();
        public TKey Update(Tentity entity);
        public TKey Delete(Tentity entity);
    }
}
