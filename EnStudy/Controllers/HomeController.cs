using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnStudy.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Logon()
        {
            return View();
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult LogonSignup()
        {
            return View();
        }

        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 管理员主页
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminIndex()
        {
            return View();
        }
        /// <summary>
        /// 管理员书籍
        /// </summary>
        /// <returns></returns>
        public ActionResult Book()
        {
            return View();
        }
        /// <summary>
        /// 个人信息管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Mine()
        {
            return View();
        }

        /// <summary>
        /// 好友管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Friends()
        {
            return View();
        }
        /// <summary>
        /// 添加好友管理
        /// </summary>
        /// <returns></returns>
        public ActionResult SearchFriends()
        {
            return View();
        }
        /// <summary>
        /// 笔记本
        /// </summary>
        /// <returns></returns>

        public ActionResult Notebook()
        {
            return View();
        }

        /// <summary>
        /// 学习日程提醒
        /// </summary>
        /// <returns></returns>
        public ActionResult Schedule()
        {
            return View();
        }

        /// <summary>
        /// 词汇短语语法管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Vocabulary()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}