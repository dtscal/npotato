using System.Text;
using Domain;
using NUI.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NUI.Controllers
{
    public class ArticleController : Controller
    {
        public IArticleManager ArticleManager { get; set; }

        public ICategoryManager CategoryManager { get; set; }

        public IForumManager ForumManager { get; set; }

        public IReviewManager ReviewManager { get; set; }

        public ActionResult Index()
        {

            return View();
        }

        [Authorize]
        public ActionResult Admin(Guid id)
        {
            this.ViewData["entity"] = this.CategoryManager.Get(id);
            return View();
        }

        [Authorize]
        public ActionResult LoadAllByPage(Guid categoryId, int page, int rows, string order, string sort)
        {
            long total = 0;
            var list =
                this.ArticleManager.LoadAllByPage(out total, categoryId, page, rows, order, sort).Select(entity => new
                    {
                        entity.Name,
                        entity.NameEn,
                        entity.ID,
                        entity.CreateDate,
                        entity.UpdateDate,
                        entity.IsEnabled,
                        entity.IsFirst,
                        entity.ViewCount,
                        entity.From,
                        CategoryId = entity.Category.ID,
                        CategoryName = entity.Category.Name
                    });

            var result = new {total = total, rows = list.ToList()};

            return Json(result);
        }

        [Authorize]
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Save(Article entity, Guid categoryId)
        {
            var category = this.CategoryManager.Get(categoryId);
            if (category == null)
            {
                return Json(new
                    {
                        IsSuccess = false,
                        Message = "未选择分类，保存失败！"
                    }, "text/html", JsonRequestBehavior.AllowGet);
            }

            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid();
                entity.CreateDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
                entity.From = "本站";
                entity.Category = category;
                this.ArticleManager.Save(entity);
            }
            else
            {
                var model = this.ArticleManager.Get(entity.ID);
                model.Name = entity.Name;
                model.NameEn = entity.NameEn;
                model.UpdateDate = DateTime.Now;
                model.IsEnabled = entity.IsEnabled;
                model.Keyword = entity.Keyword;
                model.KeywordEn = entity.KeywordEn;
                model.Content = entity.Content;
                model.ContentEn = entity.ContentEn;
                model.Description = entity.Description;
                model.DescriptionEn = entity.DescriptionEn;
                model.IsFirst = entity.IsFirst;
                model.From = entity.From;
                model.BuyLink = entity.BuyLink;
                model.PImagea = entity.PImagea;
                model.PImageb = entity.PImageb;
                model.PImagec = entity.PImagec;
                model.PImaged = entity.PImaged;
                model.PImagee = entity.PImagee;

                entity.Category = category;
                this.ArticleManager.Update(model);
            }

            return Json(new {IsSuccess = true, Message = "保存成功"}, "text/html", JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult View(Guid? id, Guid categoryId)
        {
            var category = this.CategoryManager.Get(categoryId);
            this.ViewData["Category"] = category;

            Article entity = null;
            if (id != null)
            {
                entity = this.ArticleManager.Get(id.Value);
            }
            entity = entity ?? new Article
                {
                    Name = string.Empty,
                    NameEn = string.Empty,
                };

            this.ViewData["entity"] = entity;
            return View();
        }

        [Authorize]
        public ActionResult Delete(IList<Guid> idList)
        {
            this.ArticleManager.Delete(idList.Cast<object>().ToList());
            return Json(new {IsSuccess = true, Message = "删除成功"});
        }

        public ActionResult Get(Guid id)
        {
            var entity = this.ArticleManager.Get(id);
            if (entity == null)
            {
                return Redirect(this.Request.UrlReferrer.ToString());
            }
            this.ViewData["entity"] = entity;
            this.ViewData["hotp"] = ArticleManager.LoadHotProducts();
            this.ArticleManager.ViewsAdd(id);
            return this.View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Review(Review entity, Guid articleId)
        {
            Review review = new Review();

            Article arti = ArticleManager.Get(articleId);
            entity.Article = arti;
            entity.ID = Guid.NewGuid();
            entity.ReviewDate = DateTime.Now;
            entity.ReplyDate = DateTime.Now;
            ReviewManager.Save(entity);
            return RedirectToAction("get", "Article", new {id = articleId});
        }

        public ActionResult Product(Guid id)
        {
            var entity = this.ArticleManager.Get(id);
            if (entity == null)
            {
                return Redirect(this.Request.UrlReferrer.ToString());
            }


            var categoryList = this.CategoryManager.LoadAllEnable(entity.Category.Forum.ID);
            long total = 0;

            var reviews = this.ReviewManager.LoadAllWithPage(out total, entity.ID, 1, 5, true, "desc", "ReviewDate");

            this.ViewData["entity"] = entity;
            this.ViewData["reviews"] = reviews;
            this.ViewData["hotp"] = ArticleManager.LoadHotProducts();
            this.ViewData["CategoryList"] = categoryList;
            this.ViewData["pimages"] = this.PImages(entity);
            this.ArticleManager.ViewsAdd(id);
            return this.View();

        }

        private String PImages(Domain.Article article)
        {
            StringBuilder sb = new StringBuilder("{\"prod_1\":{\"main\":{\"orig\":");
            sb.Append("\"" + article.PImagea + "\"")
              .Append(",\"main\":")
              .Append("\"" + article.PImagea)
              .Append("?width=380&height=450\"");
            sb.Append(",\"thumb\":").Append("\"" + article.PImagea).Append("?width=100&height=100\"");
            sb.Append(",\"label\":\"\"},\"gallery\":{\"item_0\":{\"orig\":");
            sb.Append("\"" + article.PImagea + "\"")
              .Append(",\"main\":")
              .Append("\"" + article.PImagea)
              .Append("?width=380&height=450\"");
            sb.Append(",\"thumb\":").Append("\"" + article.PImagea).Append("?width=100&height=100\"");
            sb.Append(",\"label\":\"\"}");
            if (!String.IsNullOrEmpty(article.PImageb))
            {
                sb.Append(",\"item_1\":{\"orig\":");
                sb.Append("\"" + article.PImageb + "\"")
                  .Append(",\"main\":")
                  .Append("\"" + article.PImageb)
                  .Append("?width=380&height=450\"");
                sb.Append(",\"thumb\":").Append("\"" + article.PImageb).Append("?width=100&height=100\"");
                sb.Append(",\"label\":\"\"}");
            }
            if (!String.IsNullOrEmpty(article.PImagec))
            {
                sb.Append(",\"item_2\":{\"orig\":");
                sb.Append("\"" + article.PImagec + "\"")
                  .Append(",\"main\":")
                  .Append("\"" + article.PImagec)
                  .Append("?width=380&height=450\"");
                sb.Append(",\"thumb\":").Append("\"" + article.PImagec).Append("?width=100&height=100\"");
                sb.Append(",\"label\":\"\"}");
            }
            if (!String.IsNullOrEmpty(article.PImaged))
            {
                sb.Append(",\"item_3\":{\"orig\":");
                sb.Append("\"" + article.PImaged + "\"")
                  .Append(",\"main\":")
                  .Append("\"" + article.PImaged)
                  .Append("?width=380&height=450\"");
                sb.Append(",\"thumb\":").Append("\"" + article.PImaged).Append("?width=100&height=100\"");
                sb.Append(",\"label\":\"\"}");
            }
            if (!String.IsNullOrEmpty(article.PImagee))
            {
                sb.Append(",\"item_4\":{\"orig\":");
                sb.Append("\"" + article.PImagee + "\"")
                  .Append(",\"main\":")
                  .Append("\"" + article.PImagee)
                  .Append("?width=380&height=450\"");
                sb.Append(",\"thumb\":").Append("\"" + article.PImagee).Append("?width=100&height=100\"");
                sb.Append(",\"label\":\"\"}");
            }
            sb.Append("},\"type\":").Append("\"").Append("simple").Append("\"").Append(",\"video\":false}}");
            var s = sb.ToString();
            return s;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SearchView(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Redirect("/Home/Index");
            }
            var result = this.ArticleManager.SearchProducts(name);
            this.ViewData["resultList"] = result;
            this.ViewData["hotp"] = ArticleManager.LoadHotProducts();
            return View();
        }
}
}
