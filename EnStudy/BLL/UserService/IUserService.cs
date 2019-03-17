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
        /// 获取自己说说列表【不进行分页，获取最近10条】
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        ResultOutput GetUserSpeak(int uId);

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



    }
}