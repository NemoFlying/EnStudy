using AutoMapper;
using EnStudy.BLL;
using EnStudy.BLL.Dto;
using EnStudy.Models;
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

                result.Data = Mapper.Map<UserViewModel>((User)(result.Data));
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


        /////学习计划部分

        /// <summary>
        /// 获取当前登录学员的登陆信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUserStudySchedue()
        {
            var result = new ResultOutput();
            try
            {
                result.Data = GUserInfo.StudySchedue.Where(con => con.StudyDay >= DateTime.Today).ToList();
                result.Status = true;
            }
            catch(Exception ex)
            {
                result.Status = false;
                result.Msg = "Get Schedue Failed!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        /// <summary>
        /// 添加学习计划
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public JsonResult AddUserStudySchedue(StudySchedueInput input)
        {
            var result = _userService.AddStudySchedue(GUserInfo.Id, input);
            if (result.Status)
            {
                result.Data = Mapper.Map<List<StudySchedueVieModel>>(result.Data);
            }
            else
            {
                //Write Log
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除计划信息
        /// </summary>
        /// <param name="SchedueId"></param>
        /// <returns></returns>
        public JsonResult DeleteStudySchedue(int SchedueId)
        {
            var result = _userService.DeleteStudySchedue(GUserInfo.Id,SchedueId);
            if (result.Status)
            {
                result.Data = Mapper.Map<List<StudySchedueVieModel>>(result.Data);
            }
            else
            {
                //Write Log
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetOwnerUserSpeak(int uId)
        {
            var result = _userService.GetUserSpeak(uId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AddSpeakComents(int fUid, int toUId, int usId, int? pscId, string contents)
        {
            var result = _userService.AddSpeakComents(fUid, toUId, usId, pscId, contents);
            return Json(result, JsonRequestBehavior.AllowGet); ;
        }

        public void tt()
        {



            _userService.AddFriend(1, 2);
        }

    }
}