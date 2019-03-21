using EnStudy.BLL;
using EnStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnStudy.Controllers
{
    public class RecommendedBookController : Controller
    {
        public readonly IRecommendedBookService _bookService;

        public RecommendedBookController()
        {
            _bookService = new RecommendedBookService();
        }

        // GET: RecommendedBook
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取所有推荐书籍列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRecommendedBooks()
        {
            return Json(_bookService.GetRecommendedBooks(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加推荐书籍
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public JsonResult AddRecommendedBook(RecommendedBook input)
        {
            //权限判断只有admin才有权限去添加
            return Json(_bookService.AddRecommendedBook(input), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteRecommendedBook(int bookId)
        {
            //权限判断
            return Json(_bookService.DeleteRecommendedBook(bookId), JsonRequestBehavior.AllowGet);
        }
        
    }
}