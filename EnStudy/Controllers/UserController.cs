using EnStudy.BLL;
using EnStudy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnStudy.Controllers
{
    public class UserController : EnStudyBaseController
    {
        private IUserService _userService { get; set; }

        public UserController()
        {
            _userService = new UserService();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 【用户认证】
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public JsonResult LogonAuthen(string Account, string Password)
        {

            var result = _userService.LogonAuthen(Account, Password);
            if (result.Status)
            {
                //表示认证通过
                //Keep Session
                HttpContext.Session["userinfo"] = result.Data;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 【注册新用户接收方法】
        /// </summary>
        /// <returns></returns>
        public JsonResult RegistUser(UserReistInput newUser)
        {
            return Json(_userService.RegistUser(newUser), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改用户基本信息
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public JsonResult UpdateUser(UserUpdateInput newUser)
        {
            var result = _userService.UpdateUser(newUser);
            if (result.Status)
            {
                //表示认证通过
                //Keep Session
                HttpContext.Session["userinfo"] = result.Data;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}