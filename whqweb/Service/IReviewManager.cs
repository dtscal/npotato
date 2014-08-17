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
        /// 分页获取某一篇文章的品论
        /// </summary>
        /// <param name="total">总行数</param>
        /// <param name="articleId">文章编码</param>
        /// <param name="page">当前页</param>
        /// <param name="row">每页大小</param>
        /// <param name="ordery">排序字段以空格分开</param>
        /// <param name="isEnabled">是否显示默认如果是false,将返回所有评论</param>
        /// <returns></returns>
        IList<Review> LoadAllWithPage(out long total,Guid articleId,int page,int row,bool isEnabled,string order,string sort);

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
