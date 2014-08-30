using Domain;
using Service;
using Spring.Context;
using Spring.Context.Support;
using Spring.Web.Mvc;
using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : SpringMvcApplication
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger("Logger");
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected override void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var guidRegx = @"^\w{8}-(\w{4}-){3}\w{12}$";

            routes.MapRoute(
                "Admin", // 路由名称
                "Admin", // 带有参数的 URL
                new { controller = "Home", action = "Admin" } // 参数默认值
            );

            routes.MapRoute(
                "LogOn", // 路由名称
                "LogOn", // 带有参数的 URL
                new { controller = "Home", action = "LogOn" } // 参数默认值
            );
            
            routes.MapRoute(
                "CategoryById", // 路由名称
                "{forumId}/{id}/Category.html", // 带有参数的 URL
                new { controller = "Category", action = "List", id = UrlParameter.Optional }, // 参数默认值
                new { forumId = guidRegx, id = guidRegx }
            );

            routes.MapRoute(
                "Category", // 路由名称
                "{forumId}/Category.html", // 带有参数的 URL
                new { controller = "Category", action = "List" }, // 参数默认值
                new { forumId = guidRegx }
            );

            routes.MapRoute(
                "ProductList",
                "{forumId}/PList.html",
                new { controller = "Category", action = "Product" },
                new { forumId = guidRegx }
            );

            routes.MapRoute(
                "Article", // 路由名称
                "Article/{id}/html", // 带有参数的 URL
                new { controller = "Article", action = "Get" }, // 参数默认值
                new { id = guidRegx }
            );


            routes.MapRoute(
                "Index", // 路由名称
                "Index.html", // 带有参数的 URL
                new { controller = "Home", action = "Index" } // 参数默认值
            );



            base.RegisterRoutes(routes);

        }

        protected override void Application_Start(object sender, EventArgs e)
        {

            //初始化log4net
            log4net.Config.XmlConfigurator.Configure();

            
            base.Application_Start(sender, e);

            this.SetInitAccount();
            this.InitHomeSetter();
        }

        /// <summary>
        /// 设置初始账号
        /// </summary>
        private void SetInitAccount()
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            IUserInfoManager manger = (IUserInfoManager)cxt.GetObject("Manager.UserInfo");

            const string account = "admin";
            var user = manger.Get(account);
            if (user == null)
            {
                user = new Domain.UserInfo
                {
                    Account = account,
                    Name = "管理员",
                    ID = Guid.NewGuid(),
                    CreateTime = DateTime.Now,
                    IsEnabled = true
                };

                manger.Save(user);
            }
        }

        /// <summary>
        /// 初始化首页配置项
        /// </summary>
        private void InitHomeSetter()
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            ISetterManager SetterManager = (ISetterManager)cxt.GetObject("Manager.Setter");

            //四张海报轮播
            const string lba = "home_key_slider_a";
            const string lbb = "home_key_slider_b";
            const string lbc = "home_key_slider_c";
            const string lbd = "home_key_slider_d";

            var slidera = SetterManager.Get(lba);
            var sliderb = SetterManager.Get(lbb);
            var sliderc = SetterManager.Get(lbc);
            var sliderd = SetterManager.Get(lbd);

            if (slidera == null)
            {
                slidera = new Setter { NKey = lba, ID = Guid.NewGuid(), Valuea = "海报2234|haibao2", Valued = "/userfiles/hb/DSC_0849.JPG", Valuec = "/Article/Product/cdd70b17-ef96-4ca2-a972-432e5ec2d7a9" };
                SetterManager.Save(slidera);
            }
            if (sliderb == null)
            {
                sliderb = new Setter { NKey = lbb, ID = Guid.NewGuid(), Valuea = "海报1|haibao1", Valued = "/userfiles/hb/DSC_0849.JPG", Valuec = "/Article/Product/9a196b79-a316-4f1d-9e83-8e523e8713f3" };
                SetterManager.Save(sliderb);
            }
            if (sliderc == null)
            {
                sliderc = new Setter { NKey = lbc, ID = Guid.NewGuid(), Valuea = "海报3|haibao3", Valued = "/userfiles/hb/DSC_0004.JPG", Valuec = "979ad2a3ac44" };
                SetterManager.Save(sliderc);
            }
            if (sliderd == null)
            {
                sliderd = new Setter { NKey = lbd, ID = Guid.NewGuid(), Valuea = "海报4|haibao4", Valued = "/userfiles/hb/DSC_0007.JPG", Valuec = "066c2b6d4df8" };
                SetterManager.Save(sliderd);
            }

            //三张类别图片
            const string ctga = "home_key_category_a";
            const string ctgb = "home_key_category_b";
            const string ctgc = "home_key_category_c";

            var categorya = SetterManager.Get(ctga);
            var categoryb = SetterManager.Get(ctgb);
            var categoryc = SetterManager.Get(ctgc);

            if (categorya == null)
            {
                categorya = new Setter { NKey = ctga, ID = Guid.NewGuid(), Valuea = "海报2234|haibao2", Valued = "/userfiles/shouji/pg_180x180.jpg", Valuec = "/c123" };
                SetterManager.Save(categorya);
            }
            if (categoryb == null)
            {
                categoryb = new Setter { NKey = ctgb, ID = Guid.NewGuid(), Valuea = "海报1|haibao1", Valued = "/userfiles/shouji/d120876f6e5f0ad4019f09c5c2b0_500_500.jpg",Valuec = "/sdf"};
                SetterManager.Save(categoryb);
            }
            if (categoryc == null)
            {
                categoryc = new Setter { NKey = ctgc, ID = Guid.NewGuid(), Valuea = "海报3|haibao3", Valued = "/userfiles/shouji/93c8c6fc7645e62981761fbde1da_600_600_1_1.jpeg",Valuec = "/sdfd"};
                SetterManager.Save(categoryc);
            }
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            if (this.Server.GetLastError() == null)
            {
                return;
            }

            Exception ex = this.Server.GetLastError().GetBaseException();
            StringBuilder sb = new StringBuilder();

            sb.Append(ex.Message);
            sb.Append("\r\nSOURCE: " + ex.Source);
            if (Request.Form != null)
            {
                sb.Append("\r\nFORM: " + this.Request.Form.ToString());
            }
            if (Request.QueryString != null)
            {
                sb.Append("\r\nQUERYSTRING: " + this.Request.QueryString.ToString());
            }

            sb.Append("\r\n引发当前异常的原因: " + ex.TargetSite);
            sb.Append("\r\n堆栈跟踪: " + ex.StackTrace);
            logger.Error(sb.ToString());

            var key = System.Configuration.ConfigurationManager.AppSettings["IsDebug"];
            bool isDebug;
            if (!bool.TryParse(key, out isDebug) || !isDebug)
            {
                this.Server.ClearError();
            }
        }

        protected void Session_Start()
        {
            this.Session["isCN"] = this.Request.UserLanguages.Length < 1
                || string.IsNullOrEmpty(this.Request.UserLanguages[0])
                || this.Request.UserLanguages[0].ToLower() == "zh-cn"
                || this.Request.UserLanguages[0].ToLower() == "zh-hans-cn";
        }
    }
}