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
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCurrentUserInfo()
        {
            return Json(_userService.GetUserInfo(GUserInfo.Id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改用户基本信息
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public JsonResult UpdateUser(UserUpdateInput newUser)
        {
            var result = _userService.UpdateUser(newUser);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /////学习计划部分

        /// <summary>
        /// 获取学习计划
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUserStudySchedue()
        {
            var result = new ResultOutput();
            try
            {
                result.Data = Mapper.Map<List<StudySchedueVieModel>>( GUserInfo.StudySchedue.Where(con => con.StudyDay >= DateTime.Today).ToList());
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
            //input.UserId = 1;
            input.UserId = GUserInfo.Id;
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
            input.FromUserId = GUserInfo.Id;
            //input.FromUserId = 1;
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
            return Json(_userService.AddUserSpeak(GUserInfo.Id, contents), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加笔记本类型
        /// </summary>
        /// <param name="TypeName"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public JsonResult AddStudyNotesType(string TypeName, string Description)
        {
            return Json(_userService.AddStudyNotesType(GUserInfo.Id, TypeName, Description), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据Id删除笔记本类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteStudyNotesType(int id)
        {
            return Json(_userService.DeleteStudyNotesType(GUserInfo.Id, id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取笔记本类型列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetStudyNotesType()
        {
            return Json(_userService.GetStudyNotesType(GUserInfo.Id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据笔记本类型获得简要列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetStudyNotesBriefByTypeId(int id)
        {
            return Json(_userService.GetStudyNotesBriefByType(GUserInfo.Id, id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据ID获取文章详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetStudyNotesById(int id)
        {
            return Json(_userService.GetStudyNotesDetailById(GUserInfo.Id, id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据ID删除学习笔记
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteStudyNotesById(int id)
        {
            return Json(_userService.DeleteStudyNotesById(GUserInfo.Id, id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加学习笔记
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public JsonResult AddStudyNotes(StudyNotesInput input)
        {
            input.Uid = GUserInfo.Id;
            return Json(_userService.AddStudyNotes(input), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据关键字获取笔记类容（列表）
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public JsonResult SearchStudyNotes(string Key)
        {
            return Json(_userService.SearchStudyNotes(GUserInfo.Id, Key), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 获取当前登录人员朋友列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUserFriends()
        {
            return Json(_userService.GetUserFriends(GUserInfo.Id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查询人员列表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public JsonResult GetUserList(string key)
        {
            return Json(_userService.SeachUser(key.Trim()), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UId"></param>
        /// <returns></returns>
        public JsonResult DeleteUser(int UId)
        {
            return Json(_userService.DeleteUser(UId), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加朋友
        /// </summary>
        /// <param name="fUId"></param>
        /// <returns></returns>
        public JsonResult AddFriend(int fUId)
        {
            return Json(_userService.AddFriend(GUserInfo.Id, fUId), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 删除朋友
        /// </summary>
        /// <param name="UId"></param>
        /// <param name="FId"></param>
        /// <returns></returns>
        public JsonResult DeleteFriend(int FId)
        {
            return Json(_userService.DeleteFriend(GUserInfo.Id, FId), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取用户电影
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUserMovies()
        {
            var result = new ResultOutput(true);
            result.Data = Mapper.Map<List<UserMovieViewModel>>(GUserInfo.UserMovie.ToList());

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteUserMovie(int mId)
        {
            return Json(_userService.DeleteUserMovie(GUserInfo.Id, mId), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddUserMovie(AddMovieInput input)
        {
            if (input.HandleStatus == "FORMSAVE")
            {
                //保存表單數據
                return Json(_userService.AddUserMovie(GUserInfo.Id,new UserMovieViewModel() {
                     MovieName = input.MovieName,
                     MovieDesc = input.MovieDesc,
                     MovieUrl = input.MovieUrl
                }), JsonRequestBehavior.AllowGet);
            }
            else
            {
                //繼續保存文件
                //return new AbpJsonResult
                //{
                //    Data = ,
                //    CamelCase = false,
                //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                //};
                return Json(input.SaveFile(), JsonRequestBehavior.AllowGet);
            }
        }



    }
}