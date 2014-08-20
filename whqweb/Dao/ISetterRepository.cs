using Domain;
using System.Linq;

namespace Dao
{
    public interface ISetterRepository : IRepository<Setter>
    {
         Setter Get(string Key);

         IQueryable<Setter> GetLike(string Key);
    }
}