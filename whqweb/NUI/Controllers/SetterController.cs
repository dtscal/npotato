using System.Web.Mvc;
using NUI.Models;
using Service;

namespace NUI.Controllers
{
    public class SetterController : Controller
    {
        public ISetterManager SetterManager { get; set; }

        [Authorize]
        public ActionResult Index()
        {
            const string lba = "home_key_slider_a";
            const string lbb = "home_key_slider_b";
            const string lbc = "home_key_slider_c";
            const string lbd = "home_key_slider_d";

            ViewData["slidera"] = SetterManager.Get(lba);
            ViewData["sliderb"] = SetterManager.Get(lbb);
            ViewData["sliderc"] = SetterManager.Get(lbc);
            ViewData["sliderd"] = SetterManager.Get(lbd);

            const string ctga = "home_key_category_a";
            const string ctgb = "home_key_category_b";
            const string ctgc = "home_key_category_c";

            ViewData["categorya"] = SetterManager.Get(ctga);
            ViewData["categoryb"] = SetterManager.Get(ctgb);
            ViewData["categoryc"] = SetterManager.Get(ctgc);

            return View();
        }

        [Authorize]
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveSlider(USetter entity)
        {
            if (entity == null)
            {
                return Json(new { IsSuccess = true, Message = "修改失败" },
                                "text/x-json", JsonRequestBehavior.AllowGet);
            }
            var setter = SetterManager.Get(entity.ID);
//            setter.Valuea = entity.Name+"|"+entity.NameEn;
//            setter.Valueb = entity.Desc+"|"+entity.DescEn;
            setter.Valuec = entity.Valuec;
            setter.Valued = entity.Valued;
            setter.Valuee = "";

            SetterManager.Update(setter);

            return Json(new { IsSuccess = true, Message = "修改成功" },
                                "text/x-json", JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveCate(USetter entity)
        {
            if (entity == null)
            {
                return Json(new { IsSuccess = true, Message = "修改失败" },
                                "text/x-json", JsonRequestBehavior.AllowGet);
            }
            var setter = SetterManager.Get(entity.ID);
            setter.Valuea = entity.Name + "|" + entity.NameEn;
            setter.Valuec = entity.Valuec;
            setter.Valued = entity.Valued;
            setter.Valuee = "";

            SetterManager.Update(setter);

            return Json(new { IsSuccess = true, Message = "修改成功" },
                                "text/x-json", JsonRequestBehavior.AllowGet);
        }
    }
}
