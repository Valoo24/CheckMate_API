using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.Interfaces
{
    /// <summary>
    /// Interface à implémenter pour chaque Entity présent dans la DAL. Définit un type de donnée en tant qu'identifiant pour l'objet qui implémente l'interface.
    /// </summary>
    /// <typeparam name="Tkey">Type de donnée à utiliser en tant qu'ID pour l'objet qui implément l'interface IEntity.</typeparam>
    public interface IEntity<Tkey>
    {
        public Tkey Id { get; set; }
    }
}
