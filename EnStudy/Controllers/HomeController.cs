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
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 学友管理
        /// </summary>
        /// <returns></returns>
        public ActionResult StudyNotes()
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