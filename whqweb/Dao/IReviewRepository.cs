using Domain;
using System;
using System.Linq;

namespace Dao
{
    public interface IReviewRepository : IRepository<Review>
    {
        
        /// <summary>
        /// 分页获取文章的品论
        /// </summary>
        /// <param name="total">总行数</param>
        /// <param name="page">当前页</param>
        /// <param name="row">每页大小</param>
        /// <param name="ordery">排序字段</param>
        /// <param name="isEnabled">是否显示默认如果是false,将返回所有评论</param>
        /// <returns></returns>
        IQueryable<Review> LoadAllWithPage(out long total, int page, int row, bool isEnabled, string order, string sort,bool isReply);
    }
}
