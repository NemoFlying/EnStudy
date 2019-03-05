using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using AutoMapper;
using EnStudy.BLL.Dto;
using EnStudy.DAL;
using EnStudy.Models;

namespace EnStudy.BLL
{
    public class UserService : IUserService
    {
        private readonly IUserDAL _userDAL;

        public UserService()
        {
            _userDAL = new UserDAL();
        }

        /// <summary>
        /// 登录认证
        /// </summary>
        /// <param name="userName">登录账号</param>
        /// <param name="password">密码</param>
        /// <returns>
        /// 返回登录信息
        ResultOutput IUserService.LogonAuthen(string accountNo, string password)
        {
            //为空检测
            if(string.IsNullOrEmpty(accountNo)||string.IsNullOrEmpty(password))
            {
                return new ResultOutput() { Status = false, Msg = "Param Validate Error" };
            }
            //密码加密
            var md5 = new MD5CryptoServiceProvider();
            var pwd = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(accountNo.Trim() + password)));
            pwd = pwd.Replace("-", "");
            var user = _userDAL.GetModels(con => con.AccountNo == accountNo.Trim()).FirstOrDefault();
            var result = new ResultOutput() { Status = false };
            if (user is null)
            {
                //表示没有注册
                result.Msg = "用户尚未注册";
            }
            else if (user.Password != pwd)
            {
                //密码错误
                result.Msg = "用户密码错误";
            }
            else
            {
                //认证通过
                result.Status = true;
                result.Data = user;
                result.Data = ((User)(result.Data)).Password = "";
            }
            return result;
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新用户注册
        /// </summary>
        /// <param name="newUserInfo"></param>
        /// <returns></returns>
        ResultOutput IUserService.RegistUser(IUserReistInput input)
        {

            var result = new ResultOutput();
            //验证输入参数【省略】


            var user = _userDAL.GetModels(con => con.AccountNo == input.AccountNo.Trim()).FirstOrDefault();
            if (user != null)
            {
                //用户名存在
                result.Status = false;
                result.Msg = "用户名已经存在！";
                return result;
            }
            else
            {
                _userDAL.Add(Mapper.Map<User>(input));
            }
            try
            {
                _userDAL.SaveChanges();
                result.Status = true;
            }
            catch(Exception ex)
            {
                result.Status = false;
                result.Msg = "Regist Failed!";
                result.Data = ex;
            }
            return result;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="updateUserInfo"></param>
        /// <returns></returns>
        ResultOutput IUserService.UpdateUser(IUserUpdateInput input)
        {
            var result = new ResultOutput();
            //验证输入参数【省略】


            var user = _userDAL.GetModels(con => con.Id == input.Id).FirstOrDefault();
            Mapper.Map(input, user);

            try
            {
                _userDAL.SaveChanges();
                result.Status = true;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Msg = "Update Failed!";
                result.Data = ex;
            }
            return result;
        }

        /// <summary>
        /// 添加学习计划
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <param name="input">学习计划内容</param>
        /// <returns></returns>

        public ResultOutput AddStudySchedue(int uId, IStudySchedueInput input)
        {
            var result = new ResultOutput();
            //验证输入参数【省略】

            var user = _userDAL.GetModels(con => con.Id == uId).FirstOrDefault();
            if(user is null)
            {
                result.Status = false;
                result.Msg = "User Not Found!";
            }
            else
            {
                if(user.StudySchedue is null)
                {
                    user.StudySchedue = new List<StudySchedue>()
                    {
                        Mapper.Map<StudySchedue>(input)
                    };
                }else
                {
                    user.StudySchedue.Add(Mapper.Map<StudySchedue>(input));
                }
                try
                {
                    _userDAL.SaveChanges();
                    result.Status = true;
                    result.Data = user.StudySchedue.ToList();
                }
                catch(Exception ex)
                {
                    result.Status = false;
                    result.Data = ex;
                    result.Msg = "Add Schedue Failed!";
                }
            }
            return result;
        }

        /// <summary>
        /// 删除学习计划
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="schId"></param>
        /// <returns></returns>
        public ResultOutput DeleteStudySchedue(int uId, int schId)
        {
            var result = new ResultOutput();
            //验证输入参数【省略】
            var user = _userDAL.GetModels(con => con.Id == uId).FirstOrDefault();
            user.StudySchedue.Remove(user.StudySchedue.Where(con => con.Id == schId).FirstOrDefault());
            try
            {
                _userDAL.SaveChanges();
                result.Status = true;
                result.Data = user.StudySchedue.ToList();
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Data = ex;
                result.Msg = "Add Schedue Failed!";
            }
            return result;
        }


    }
}