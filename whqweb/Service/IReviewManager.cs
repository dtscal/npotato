using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IReviewManager : IGenericManager<Review>
    {

        /// <summary>
        /// 分页获取所有文章的评论
        /// </summary>
        /// <param name="total">总行数</param>
        /// <param name="page">当前页必须大于等于1</param>
        /// <param name="row">页大小</param>
        /// <param name="isEnabled">是否显示</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">是否降序</param>
        /// <returns></returns>
        IList<Review> LoadAllWithPage(out long total, int page, int row, bool isEnabled, string order, string sort, bool isReply);
    }
}
