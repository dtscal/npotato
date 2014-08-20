using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Service.Implement
{
    public class SetterManager:GenericManagerBase<Setter>,ISetterManager
    {
        public Setter Get(string Key)
        {
            return ((Dao.ISetterRepository)this.CurrentRepository).Get(Key);
        }

        public IList<Setter> GetLike(string Key)
        {
            return ((Dao.ISetterRepository)(this.CurrentRepository)).GetLike(Key).ToList();
        }
    }
}