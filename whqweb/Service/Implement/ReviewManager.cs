using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Implement
{
    public class ReviewManager : GenericManagerBase<Review>,IReviewManager
    {

        public IList<Review> LoadAllWithPage(out long total, Guid articleId, int page, int row, bool isEnabled,string order,string sort)
        {
            return ((Dao.IReviewRepository) (this.CurrentRepository)).LoadAllWithPage(out total, articleId, page, row,isEnabled,order,sort).ToList();
        }


        public IList<Review> LoadAllWithPage(out long total, int page, int row, bool isEnabled, string order, string sort, bool isReply)
        {
            return ((Dao.IReviewRepository)(this.CurrentRepository)).LoadAllWithPage(out total, page, row, isEnabled, order, sort,isReply).ToList();
        }
    }
}
