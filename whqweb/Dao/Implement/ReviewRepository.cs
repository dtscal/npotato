using Domain;
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Dao.Implement
{
    public class ReviewRepository : RepositoryBase<Review>,IReviewRepository
    {

        

        public IQueryable<Review> LoadAllWithPage(out long total, int page, int row, bool isEnabled, string order, string sort,bool isReply)
        {
            var list = isEnabled ? this.LoadAll().Where(w => w.IsEnabled == true)
                : this.LoadAll();
            list = isReply ? list : list.Where(w => w.Reply == null);

            total = list.LongCount();

            //list = list.OrderByDescending(o => o.ReviewDate);
            list = list.OrderBy(sort + " " + order);

            list = list.Skip((page - 1) * row).Take(row);
                   
            return list;
        }
    }
}
