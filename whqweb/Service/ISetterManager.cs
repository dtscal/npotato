using System.Collections.Generic;
using Domain;

namespace Service
{
    public interface ISetterManager:IGenericManager<Setter>
    {
        Setter Get(string Key);

        IList<Setter> GetLike(string Key);
    }
}