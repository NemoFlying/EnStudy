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
        ResultOutput RegistUser(IUserReistInput newUserInfo);

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="updateUserInfo"></param>
        /// <returns></returns>
        ResultOutput UpdateUser(IUserUpdateInput updateUserInfo);
    }
}