using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.Interfaces
{
    /// <summary>
    /// Interface à implément pour chaque Repository dans la DAL. Implémente toutes les méthodes "basiques" du CRUD dans chque Repository.
    /// </summary>
    /// <typeparam name="Tentity">Le type d'objet qui implémente IEntity qui sera utilisé par le Repository</typeparam>
    /// <typeparam name="TKey">Type de donnée utilisée par l'objet qui impélmente IEntity en tant que clé comme étant l'ID.</typeparam>
    public interface IRepository<Tentity, TKey> where Tentity : IEntity<TKey>
    {
        public TKey Create(Tentity entity);
        public Tentity Read(TKey id);
        public IEnumerable<Tentity> ReadAll();
        public bool Update(Tentity entity);
        public bool Delete(TKey id);
    }
}