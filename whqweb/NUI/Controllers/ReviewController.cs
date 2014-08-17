using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NUI.Controllers
{
    public class ReviewController : Controller
    {
        public IReviewManager ReviewManager { get; set; }

        public IArticleManager ArticleManager { get; set; }

        [Authorize]
        public ActionResult LoadAllByPage(int page, int rows, string order, string sort, bool isEnabled, bool isReply)
        {
            long total = 0;
            var list = this.ReviewManager.LoadAllWithPage(out total, page, rows, isEnabled, order, sort, isReply).Select(entity => new
                {
                    entity.ID,
                    AName = entity.Article.Name,
                    entity.Name,
                    entity.Email,
                    entity.ReviewDate,
                    entity.Content,
                    entity.Rating,
                    entity.IsEnabled
                });
            var result = new { total = total, rows = list.ToList() };
            return Json(result);
        }

        [Authorize]
        public ActionResult View(Guid id)
        {
            var review = this.ReviewManager.Get(id);

            ViewData["review"] = review;
            return View();
        }

        [Authorize]
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Save(Guid id, string reply, Guid articleId, bool isEnabled)
        {
            var article = ArticleManager.Get(articleId);
            if (article == null)
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = "文章不存在不能更新留言！"
                }, "text/html", JsonRequestBehavior.AllowGet);
            }
            var review = this.ReviewManager.Get(id);
            if (review == null)
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = "留言记录不存在不能更新留言！"
                }, "text/html", JsonRequestBehavior.AllowGet);
            }
            review.IsEnabled = isEnabled;
            review.Reply = reply;
            review.ReplyDate = DateTime.Now;

            this.ReviewManager.Update(review);
            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Review/

        public ActionResult Index()
        {
            return View();
        }

    }
}
