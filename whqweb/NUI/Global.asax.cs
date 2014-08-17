using Service;
using Spring.Context;
using Spring.Context.Support;
using Spring.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
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

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

//            routes.MapRoute(
//                "Default", // Route name
//                "{controller}/{action}/{id}", // URL with parameters
//                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
//            );

        }

        protected override void Application_Start(object sender, EventArgs e)
        {

            //初始化log4net
            log4net.Config.XmlConfigurator.Configure();

            
            base.Application_Start(sender, e);

            this.SetInitAccount();


            AreaRegistration.RegisterAllAreas();

            // Use LocalDB for Entity Framework by default
            Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
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