﻿using System.Drawing;
using System.IO;
using System.Web.Security;
using Service;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Imaging;

namespace NUI.Controllers
{
    public class HomeController : Controller
    {
        public IUserInfoManager UserInfoManager { get; set; }

        public ICategoryManager CategoryManager { get; set; }

        public IForumManager ForumManager { get; set; }

        public ActionResult Index()
        {
            var list = this.ForumManager.LoadAllEnable();
            this.ViewData["ForumList"] = list;

            return View();
        }

        public ActionResult ChangeLanguage(string language)
        {
            this.Session["isCN"] = this.Session["isCN"] == null
               || language.ToLower() == "zh-cn";
            var url = this.Request.UrlReferrer.ToString();
            return Redirect(url);
        }

        [Authorize]
        public ActionResult Admin()
        {
            ViewData["User"] = this.UserInfoManager.Get(Guid.Parse(this.User.Identity.Name));

            var list = this.CategoryManager.LoadAllEnable().Where(w => w.CategoryType == "列表");
            this.ViewData["CategoryList"] = list.ToList();
            return View();
        }

        public ActionResult LogOn()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/LogOn/");
        }

        public ActionResult LogOnByAndPassword(string account, string password, string code)
        {
            if (this.Session["ValidateCode"] == null || code != this.Session["ValidateCode"].ToString())
            {
                return Json(new { IsSuccess = false, Message = "验证码错误，请重新输入" });
            }

            var entity = this.UserInfoManager.Get(account, password);
            if (entity == null)
            {
                return Json(new { IsSuccess = false, Message = "用户名或密码错误" });
            }

            if (!entity.IsEnabled)
            {
                return Json(new { IsSuccess = false, Message = "您的账号已被禁用，请联系管理员" });
            }

            FormsAuthentication.SetAuthCookie(entity.ID.ToString(), false);
            return Json(new { IsSuccess = true, Message = "登陆成功" });
        }

        [Authorize]
        public ActionResult ChangedPassword(string password, string oldPassword)
        {
            var entity = this.UserInfoManager.Get(Guid.Parse(this.User.Identity.Name));
            if (entity == null || this.UserInfoManager.Get(entity.Account, oldPassword) == null)
            {
                return Json(new { IsSuccess = false, Message = "密码错误" },
                    "text/x-json", JsonRequestBehavior.AllowGet);
            }

            this.UserInfoManager.Update(entity, password);
            return Json(new { IsSuccess = true, Message = "修改成功" },
                                "text/x-json", JsonRequestBehavior.AllowGet);
        }

        #region 验证码

        public ActionResult ValidateCode()
        {
            var code = this.CreateValidateNumber(4);
            this.Session["ValidateCode"] = code;
            return File(this.CreateValidateGraphic(code), "image/jpeg");
        }

        private string CreateValidateNumber(int length)
        {
            int[] randMembers = new int[length];
            int[] validateNums = new int[length];
            System.Text.StringBuilder validateNumberStr = new System.Text.StringBuilder();
            //生成起始序列值
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
            int[] seeks = new int[length];
            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seeks[i] = beginSeek;
            }
            //生成随机数字
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random(seeks[i]);
                int pownum = 1 * (int)Math.Pow(10, length);
                randMembers[i] = rand.Next(pownum, Int32.MaxValue);
            }
            //抽取随机数字
            for (int i = 0; i < length; i++)
            {
                string numStr = randMembers[i].ToString();
                int numLength = numStr.Length;
                Random rand = new Random();
                int numPosition = rand.Next(0, numLength - 1);
                validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
            }
            //生成验证码
            for (int i = 0; i < length; i++)
            {
                validateNumberStr.Append(validateNums[i].ToString());
            }
            return validateNumberStr.ToString();
        }

        private byte[] CreateValidateGraphic(string validateNum)
        {
            using (Bitmap image = new Bitmap((int)Math.Ceiling(validateNum.Length * 12.5), 22))
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    //生成随机生成器
                    Random random = new Random();
                    //清空图片背景色
                    g.Clear(Color.White);
                    //画图片的干扰线
                    for (int i = 0; i < 25; i++)
                    {
                        int x1 = random.Next(image.Width);
                        int x2 = random.Next(image.Width);
                        int y1 = random.Next(image.Height);
                        int y2 = random.Next(image.Height);
                        g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                    }
                    Font font = new Font("Arial", 14, (FontStyle.Bold | FontStyle.Italic));
                    LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                     Color.Blue, Color.DarkRed, 1.2f, true);
                    g.DrawString(validateNum, font, brush, 3, 2);
                    //画图片的前景干扰点
                    for (int i = 0; i < 100; i++)
                    {
                        int x = random.Next(image.Width);
                        int y = random.Next(image.Height);
                        image.SetPixel(x, y, Color.FromArgb(random.Next()));
                    }
                    //画图片的边框线
                    g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                    //保存图片数据
                    using (MemoryStream stream = new MemoryStream())
                    {
                        image.Save(stream, ImageFormat.Jpeg);
                        return stream.ToArray();
                    }
                }
            }
        }

        #endregion

        public ActionResult Contact()
        {
            return View();
        }
    }
}
