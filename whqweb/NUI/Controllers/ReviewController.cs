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
                    entity.Name,
                    entity.Mobile,
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
        public ActionResult Replay(Guid id, bool isEnabled, String reply)
        {
            var entity = this.ReviewManager.Get(id);
            entity.Reply = reply;
            entity.IsEnabled = isEnabled;
            entity.ReplyDate = DateTime.Now;

            this.ReviewManager.Update(entity);
            return Json(new { IsSuccess = true,Message="更新成功！" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Save(string code)
        {
            if (this.Session["ValidateCode"] == null || code != this.Session["ValidateCode"].ToString())
            {
                return Json(new { IsSuccess = false},"text/html", JsonRequestBehavior.AllowGet);
            }

            var entity = new Review()
            {
                ID = Guid.NewGuid(),
                Name = Request["Name"].ToString(),
                Email = Request["Email"].ToString(),
                Content = Request["Content"].ToString(),
                Mobile=Request["Mobile"].ToString(),
                ReviewDate = DateTime.Now,
                ReplyDate = DateTime.Now
            };

            this.ReviewManager.Save(entity);
            return Json(new { IsSuccess = true }, "text/html", JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Review/

        public ActionResult Index()
        {
            return View();
        }

    }
}
