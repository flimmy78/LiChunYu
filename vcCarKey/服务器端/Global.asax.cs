﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;
using DAL;

namespace 服务器端
{
    public class Global : System.Web.HttpApplication
    {
        public static bool bRun;
        public static string txtLogFolder = "D:\\lcyWeb\\log\\";
        public static string hexBINFolder = "D:\\lcyWeb\\hexBIN\\";
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            //txtLogFolder = WFNetLib.aspNetFunc.GetRootPath();
            WFNetLib.ADO.SQLServerOP.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
            ESLQueueDataDBOption.deleteAll();
            bRun = true;
            Thread t = new Thread(ESLWork.ESLPass);
            t.Start();
            KeyDataQueueDataDBOption.deleteAll();
            Thread t1 = new Thread(KeyDataWork.KeyDataWorkThread);
            t1.Start();
            Thread t2 = new Thread(ClearHPassLog.ClearHPassLogThread);
            t2.Start();
            WFNetLib.Log.TextLog.AddTextLog("web Start", Global.txtLogFolder + "workLog.txt", true);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码      
            bRun = false;
        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
            WFNetLib.Log.TextLog.AddTextLog(e.ToString(), Global.txtLogFolder + "errLog.txt", true);
        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码

        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

        }
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            HttpContext.Current.Response.Cache.SetNoStore();
        }  
    }
}
