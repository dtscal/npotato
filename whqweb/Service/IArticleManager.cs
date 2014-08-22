using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface IArticleManager : IGenericManager<Article>
    {
        IList<Article> LoadAllByPage(out long total, Guid categoryId, int page, int rows, string order, string sort);

        IList<Article> LoadAllEnable(Guid categoryId);

        IList<Article> LoadHotProducts(); 

        void ViewsAdd(Guid id);
    }
}
