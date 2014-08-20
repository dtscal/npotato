using System.Linq;
using Domain;

namespace Dao.Implement
{
    public class SetterRepository : RepositoryBase<Setter>,ISetterRepository
    {

        public Setter Get(string Key)
        {
            return this.LoadAll().FirstOrDefault(s => s.NKey == Key);
        }

        public IQueryable<Setter> GetLike(string Key)
        {
            return this.LoadAll().Where(s => s.NKey.Contains(Key));
        }
    }
}