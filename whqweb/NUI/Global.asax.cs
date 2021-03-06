﻿using Service;
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
                "Article", // 路由名称
                "Article/{id}.html", // 带有参数的 URL
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