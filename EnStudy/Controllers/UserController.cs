﻿using AutoMapper;
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

        /// <summary>
        /// 获取朋友圈
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public JsonResult GetFriendSpeak(GetFriendSpeakPageInput input)
        {
            //默认
            input.UserId = 1;
            //input.UserId = GUserInfo.Id;
            var result = _userService.GetFriendSpeakPage(input);
            return Json(result, JsonRequestBehavior.AllowGet);
            
        }

        /// <summary>
        /// 添加留言信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public JsonResult AddSpeakComents(AddSpeakComentsInput input)
        {
            //input.FromUserId = GUserInfo.Id;
            input.FromUserId = 1;
            var result = _userService.AddSpeakComents(input);
            return Json(result, JsonRequestBehavior.AllowGet); ;
        }

        /// <summary>
        /// 发表说说
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        public JsonResult AddNewSpeak(string contents)
        {
            return Json(_userService.AddUserSpeak(1, contents), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加笔记本类型
        /// </summary>
        /// <param name="TypeName"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public JsonResult AddStudyNotesType(string TypeName, string Description)
        {
            return Json(_userService.AddStudyNotesType(1, TypeName, Description), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据Id删除笔记本类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteStudyNotesType(int id)
        {
            return Json(_userService.DeleteStudyNotesType(1,id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取笔记本类型列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetStudyNotesType()
        {
            return Json(_userService.GetStudyNotesType(1), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据笔记本类型获得简要列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetStudyNotesBriefByTypeId(int id)
        {
            return Json(_userService.GetStudyNotesBriefByType(1, id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据ID获取文章详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetStudyNotesById(int id)
        {
            return Json(_userService.GetStudyNotesDetailById(1, id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据ID删除学习笔记
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteStudyNotesById(int id)
        {
            return Json(_userService.DeleteStudyNotesById(1, id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加学习笔记
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public JsonResult AddStudyNotes(StudyNotesInput input)
        {
            input.Uid = 1;
            return Json(_userService.AddStudyNotes(input), JsonRequestBehavior.AllowGet);
        }



        public void tt()
        {



            _userService.AddFriend(1, 2);
        }

    }
}