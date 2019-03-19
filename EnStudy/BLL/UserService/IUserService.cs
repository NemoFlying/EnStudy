using EnStudy.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnStudy.BLL
{
    public interface IUserService
    {
        /// <summary>
        /// 登录认证
        /// </summary>
        /// <param name="userName">登录账号</param>
        /// <param name="password">密码</param>
        /// <returns>
        /// 返回登录信息
        /// </returns>
        ResultOutput LogonAuthen(string accountNo, string password);

        /// <summary>
        /// 新用户注册
        /// </summary>
        /// <param name="newUserInfo"></param>
        /// <returns></returns>
        ResultOutput RegistUser(IUserReistInput input);

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ResultOutput UpdateUser(IUserUpdateInput input);

        /// <summary>
        /// 添加学习计划
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <param name="input">学习计划内容</param>
        /// <returns></returns>

        ResultOutput AddStudySchedue(int uId, IStudySchedueInput input);

        /// <summary>
        /// 删除学习计划
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="schId"></param>
        /// <returns></returns>
        ResultOutput DeleteStudySchedue(int uId, int schId);


        /// <summary>
        /// 用户发表心情
        /// </summary>
        /// <param name="uId">用户Id</param>
        /// <param name="contents">内容</param>
        /// <returns></returns>
        ResultOutput AddUserSpeak(int uId,string contents);

        /// <summary>
        /// 删除心情
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <param name="usId">心情ID</param>
        /// <returns></returns>
        ResultOutput DeleteUserSpeak(int uId, int usId);

        ResultOutput AddFriend(int UId, int FId);

        /// <summary>
        /// 获取朋友圈信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ResultOutput GetFriendSpeakPage(GetFriendSpeakPageInput input);

        /// <summary>
        /// 针对心情留言
        /// </summary>
        /// <returns></returns>
        ResultOutput AddSpeakComents(AddSpeakComentsInput input);

        /// <summary>
        /// 根据用户Id获取文章类型列表
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        ResultOutput GetStudyNotesType(int uId);

        /// <summary>
        /// 删除文章类型
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        ResultOutput DeleteStudyNotesType(int uId, int id);

        /// <summary>
        /// 添加文章类型
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="tId"></param>
        /// <returns></returns>
        ResultOutput AddStudyNotesType(int uId, string TypeName, string Description);

        /// <summary>
        /// 根据文章类型获取文章列
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="tId"></param>
        /// <returns></returns>
        ResultOutput GetStudyNotesBriefByType(int uId, int tId);

        /// <summary>
        /// 根据文章Id获取文章详细
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="nId"></param>
        /// <returns></returns>
        ResultOutput GetStudyNotesDetailById(int uId, int nId);

        /// <summary>
        /// 根据学习笔记ID删除
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="nId"></param>
        /// <returns></returns>
        ResultOutput DeleteStudyNotesById(int uId, int nId);

        /// <summary>
        /// 添加学习笔记
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ResultOutput AddStudyNotes(StudyNotesInput input);

        /// <summary>
        /// 根据关键模糊查找学习笔记
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        ResultOutput SearchStudyNotes(int uId, string keyWord);

    }
}