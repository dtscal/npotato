using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;

namespace NUI.Controllers
{
    public class SetterController : Controller
    {
        public ISetterManager SetterManager { get; set; }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Save(Setter entity)
        {
            if (entity == null)
            {
                return Json(new { IsSuccess = true, Message = "修改失败" },
                                "text/x-json", JsonRequestBehavior.AllowGet);
            }
            var setter = SetterManager.Get(entity.ID);
            setter.Valuea = entity.Valuea;
            setter.Valueb = entity.Valueb;
            setter.Valuec = entity.Valuec;
            setter.Valued = entity.Valued;
            setter.Valuee = entity.Valuee;

            SetterManager.Update(setter);

            return Json(new { IsSuccess = true, Message = "修改成功" },
                                "text/x-json", JsonRequestBehavior.AllowGet);
        }
    }
}
