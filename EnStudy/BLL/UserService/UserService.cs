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
using EnStudy.ViewModels;

namespace EnStudy.BLL
{
    public class UserService : IUserService
    {
        private readonly IUserDAL _userDAL;
        private readonly IUserSpeakDAL _userSpeakDAL;
        private readonly IUserFriendDAL _userFriendDAL;
        public UserService()
        {
            _userDAL = new UserDAL();
            _userSpeakDAL = new UserSpeakDAL();
            _userFriendDAL = new UserFriendDAL();
        }

        /// <summary>
        /// 登录认证
        /// </summary>
        /// <param name="userName">登录账号</param>
        /// <param name="password">密码</param>
        /// <returns>
        /// 返回登录信息
        public ResultOutput LogonAuthen(string accountNo, string password)
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
            }
            return result;
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新用户注册
        /// </summary>
        /// <param name="newUserInfo"></param>
        /// <returns></returns>
        public ResultOutput RegistUser(IUserReistInput input)
        {

            var result = new ResultOutput();
            //验证输入参数【省略】
            //密码加密
            var md5 = new MD5CryptoServiceProvider();
            var pwd = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(input.AccountNo.Trim() + input.Password)));
            pwd = pwd.Replace("-", "");
            input.Password = pwd;
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
        /// 获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResultOutput GetUserInfo(int id)
        {
            var result = new ResultOutput(true);
            result.Data = Mapper.Map<UserViewModel>(_userDAL.GetModels(con => con.Id == id).FirstOrDefault());
            return result;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="updateUserInfo"></param>
        /// <returns></returns>
        public ResultOutput UpdateUser(IUserUpdateInput input)
        {
            var result = new ResultOutput();
            //验证输入参数【省略】
            
            var user = _userDAL.GetModels(con => con.Id == input.Id).FirstOrDefault();
            if (!string.IsNullOrEmpty(input.Password))
            {
                var md5 = new MD5CryptoServiceProvider();
                var pwd = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(user.AccountNo.Trim() + input.Password)));
                pwd = pwd.Replace("-", "");
                input.Password = pwd;
            }else
            {
                input.Password = user.Password;
            }
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

        /// <summary>
        /// 用户发表心情
        /// </summary>
        /// <param name="uId">用户Id</param>
        /// <param name="contents">内容</param>
        /// <returns></returns>
        public ResultOutput AddUserSpeak(int uId, string contents)
        {
            var result = new ResultOutput() ;
            //验证输入参数
            if(string.IsNullOrEmpty(contents))
            {
                result.Msg = "Params Is Null";
                return result;
            }
            var user = _userDAL.GetModels(con => con.Id == uId).FirstOrDefault();
            if(user is null)  //用户为空
            {
                result.Msg = "User Can't Be Find!";
                return result;
            }
            if(user.UserSpeak is null)
            {
                user.UserSpeak = new List<UserSpeak>();
            }
            user.UserSpeak.Add(
                new UserSpeak()
                {
                    Contents = contents
                }
                );
            try
            {
                _userDAL.SaveChanges();
                result = GetFriendSpeakPage(new GetFriendSpeakPageInput()
                {
                    UserId = uId,
                    CurrentPage = 0
                });
            }
            catch (Exception ex)
            {
                result.Data = ex;
                result.Msg = "Add UserSpeak Failed!";
            }
            return result;

        }


        /// <summary>
        /// 删除心情
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <param name="usId">心情ID</param>
        /// <returns></returns>
        public ResultOutput DeleteUserSpeak(int uId, int usId)
        {
            var result = new ResultOutput();
            //验证输入参数
            var user = _userDAL.GetModels(con => con.Id == uId).FirstOrDefault();
            if (user is null)  //用户为空
            {
                result.Msg = "User Can't Be Find!";
                return result;
            }
            if(user.UserSpeak!=null)
            {
                user.UserSpeak.Remove(user.UserSpeak.Where(con => con.Id == usId).FirstOrDefault());
            }
            try
            {
                _userDAL.SaveChanges();
                result.Status = true;
                //返回前10条说说【默认10条】
                result.Data = user.UserSpeak.OrderByDescending(con => con.SpeakTime).Take(10).ToList();
            }
            catch (Exception ex)
            {
                result.Data = ex;
                result.Msg = "Add UserSpeak Failed!";
            }
            return result;

        }

        /// <summary>
        /// 根据关键字查询学友
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ResultOutput SeachUser(string key)
        {
            var result = new ResultOutput(true);
            var user = new List<User>();
            if (key=="*")
            {
                user = _userDAL.GetModels(con => con.AccountNo!= "admin")?.ToList();
            }
            else
            {
                user = _userDAL.GetModels(con => con.AccountNo.Contains(key) || con.NikeName.Contains(key))
                    .Where(con=>con.AccountNo!="admin")?.ToList();
            }
            result.Data = Mapper.Map<List<UserViewModel>>(user);
            return result;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UId"></param>
        /// <returns></returns>
        public ResultOutput DeleteUser(int UId)
        {
            var result = new ResultOutput(true);
            var user = _userDAL.GetModels(con => con.Id == UId).FirstOrDefault();
            _userDAL.Delete(user);
            try
            {
                _userDAL.SaveChanges();
                result = SeachUser("*");
            }
            catch (Exception ex)
            {
                result.Data = ex;
                result.Msg = "Delete User Failed!";
            }
            return result;
        }

        /// <summary>
        /// 获取朋友列表
        /// </summary>
        /// <param name="UId"></param>
        /// <returns></returns>
        public ResultOutput GetUserFriends(int UId)
        {
            var result = new ResultOutput(true);
            var friend = _userDAL.GetModels(con => con.Id == UId).FirstOrDefault().Friends;
            var user = new List<User>();
            friend.ToList().ForEach(item => user.Add(item.Friend));
            result.Data = Mapper.Map<List<UserViewModel>>(user);
            return result;
        }

        /// <summary>
        /// 添加朋友
        /// </summary>
        /// <param name="UId"></param>
        /// <param name="FId"></param>
        /// <returns></returns>
        public ResultOutput AddFriend(int UId,int FId)
        {
            var result = new ResultOutput(false);
            var user = _userDAL.GetModels(con => con.Id == UId).FirstOrDefault();
            var fuser = _userDAL.GetModels(con => con.Id == FId).FirstOrDefault();
            if (user.Friends.Where(con => con.Friend.Id == fuser.Id).FirstOrDefault() != null)
                return result;
            user.Friends.Add(new UserFriend() { Friend = fuser });
            fuser.Friends.Add(new UserFriend() { Friend = user });
            try
            {
                _userDAL.SaveChanges();
                result = GetUserFriends(UId);
            }
            catch (Exception ex)
            {
                result.Data = ex;
                result.Msg = "Add UserSpeak Failed!";
            }
            return result;
        }

        /// <summary>
        /// 删除朋友
        /// </summary>
        /// <param name="UId"></param>
        /// <param name="FId"></param>
        /// <returns></returns>
        public ResultOutput DeleteFriend(int UId,int FId)
        {
            var result = new ResultOutput(false);
            var user = _userDAL.GetModels(con => con.Id == UId).FirstOrDefault();
            var fuser = _userDAL.GetModels(con => con.Id == FId).FirstOrDefault();
            _userFriendDAL.Delete(_userFriendDAL.GetModels(con => con.user.Id == user.Id && con.Friend.Id == fuser.Id).FirstOrDefault());
            _userFriendDAL.Delete(_userFriendDAL.GetModels(con => con.user.Id == fuser.Id && con.Friend.Id == user.Id).FirstOrDefault());
            try
            {
                _userFriendDAL.SaveChanges();
                result = GetUserFriends(UId);
            }
            catch (Exception ex)
            {
                result.Data = ex;
                result.Msg = "Add UserSpeak Failed!";
            }
            return result;
        }


        /// <summary>
        /// 获取朋友圈信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ResultOutput GetFriendSpeakPage(GetFriendSpeakPageInput input)
        {
            var result = new ResultOutput();
            var user = _userDAL.GetModels(con => con.Id == input.UserId).FirstOrDefault();
            var userList = new List<int>();
            user.Friends.ToList().ForEach(item => userList.Add(item.user.Id));
            userList.Add(user.Id);
            var userSpeakList = _userSpeakDAL.GetModels(
                con => userList.Contains(con.user.Id)
                ).OrderByDescending(con => con.SpeakTime).Skip(input.PageSize * input.CurrentPage).Take(input.PageSize);

            var output = new GetFriendSpeakPageOutput()
            {
                PageSize = input.PageSize,
                CurrentPage = input.CurrentPage + 1,
                userSpeak = new List<UserSpeakViewModel>()
            };
            userSpeakList.ToList().ForEach(
                userSpeak =>
                {
                    var userSpeakView = new UserSpeakViewModel()
                    {
                        user = Mapper.Map<UserViewModel>(userSpeak.user),
                        Contents = userSpeak.Contents,
                        SpeakTime = userSpeak.SpeakTime,
                        Id = userSpeak.Id,
                        Coment = new List<UserSpeakComentViewModel>()
                    };
                    var coments = userSpeak.SpeakComents.Where(con => con.PSpeakComents is null).OrderBy(con => con.ComentTime);
                    coments.ToList().ForEach(fComent =>
                    {
                        userSpeakView.Coment.Add(ConvertSpeakComents(userSpeak, fComent));

                    });

                    output.userSpeak.Add(userSpeakView);
                });

            result.Status = true;
            result.Data = output;
            return result;
        }

        /// <summary>
        /// 递归获取留言列表
        /// </summary>
        /// <param name="userSpeak"></param>
        /// <param name="coments"></param>
        /// <returns></returns>

        private UserSpeakComentViewModel ConvertSpeakComents(UserSpeak userSpeak,SpeakComents coments)
        {
            //找到是否有子集
            var childComent = userSpeak.SpeakComents.Where(con => con.PSpeakComents == coments).ToList();
            if (childComent.Count > 0)
            {
                var ComentsView = Mapper.Map<UserSpeakComentViewModel>(coments);
                ComentsView.CSpeakComent = new List<UserSpeakComentViewModel>();
                //表示还有子集
                childComent.ForEach(item =>
                {
                    //继续寻找子集
                    ComentsView.CSpeakComent.Add(ConvertSpeakComents(userSpeak, item));
                });
                return ComentsView;
            }
            else
            {
                //表示没有子集
                return Mapper.Map<UserSpeakComentViewModel>(coments);
            }
            
        }

        /// <summary>
        /// 添加留言信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ResultOutput AddSpeakComents(AddSpeakComentsInput input)
        {
            var result = new ResultOutput();
            var fromUser = _userDAL.GetModels(con => con.Id == input.FromUserId).FirstOrDefault();
            var toUser = _userDAL.GetModels(con => con.Id == input.ToUserId).FirstOrDefault();
            var userSpeak = new UserSpeak();
            //默认都可以发表评论
            if (toUser != null)
            {
                userSpeak = toUser.UserSpeak.Where(con => con.Id == input.SpeakId).FirstOrDefault();
            }
            else
            {
                result.Msg = "Params Is Valited Failed!";
                return result;
            }
            if (userSpeak is null || fromUser is null)
            {
                result.Msg = "Params Is Valited Failed!";
                return result;
            }
            //创建留言Model
            var newComent = new SpeakComents()
            {
                Contents = input.Msg
            };

            if (input.ComentId.HasValue)
            {
                //添加父级
                newComent.PSpeakComents = userSpeak.SpeakComents.Where(con => con.Id == input.ComentId.Value).FirstOrDefault();
            }
            newComent.User = fromUser;
            userSpeak.SpeakComents.Add(newComent);
            try
            {
                _userDAL.SaveChanges();
                result.Status = true;
                var comentsViewModel = new List<UserSpeakComentViewModel>();

                //返回所有评论
                var coments = userSpeak.SpeakComents.Where(con => con.PSpeakComents is null).OrderBy(con => con.ComentTime);
                coments.ToList().ForEach(fComent =>
                {
                    comentsViewModel.Add(ConvertSpeakComents(userSpeak, fComent));

                });
                result.Data = comentsViewModel;
            }
            catch (Exception ex)
            {
                result.Data = ex;
                result.Msg = "Add UserSpeak Failed!";
            }
            return result;
        }


        /// <summary>
        /// 根据用户Id获取文章类型列表
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public ResultOutput GetStudyNotesType(int uId)
        {
            var result = new ResultOutput();
            result.Status = true;
            result.Data = Mapper.Map<List<StudyNoteTypeOutput>>(_userDAL.GetModels(con => con.Id == uId)
                .FirstOrDefault()
                .StudyNotesType.ToList()
                );
            return result;
        }

        /// <summary>
        /// 删除文章类型
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResultOutput DeleteStudyNotesType(int uId,int id)
        {
            var result = new ResultOutput();
            var NotesTypes = _userDAL.GetModels(con => con.Id == uId)
                .FirstOrDefault().StudyNotesType;
            NotesTypes.Remove(NotesTypes.Where(con => con.Id == id).FirstOrDefault());
            try
            {
                _userDAL.SaveChanges();
                result.Status = true;
                result.Data = Mapper.Map<List<StudyNoteTypeOutput>>(NotesTypes.ToList());
            }
            catch(Exception ex)
            {
                result.Data = ex;
            }
            return result;

        }
        /// <summary>
        /// 添加文章类型
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public ResultOutput AddStudyNotesType(int uId,string TypeName,string Description)
        {
            var result = new ResultOutput();
            var NotesTypes = _userDAL.GetModels(con => con.Id == uId)
                .FirstOrDefault().StudyNotesType;
            var newType = new StudyNotesType()
            {
                TypeName = TypeName,
                Description = Description
            };
            NotesTypes.Add(newType);
            try
            {
                _userDAL.SaveChanges();
                result.Status = true;
                result.Data = Mapper.Map<List<StudyNoteTypeOutput>>(NotesTypes.ToList());
            }
            catch (Exception ex)
            {
                result.Data = ex;
            }
            return result;
        }

        /// <summary>
        /// 根据文章类型获取文章列
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="tId"></param>
        /// <returns></returns>
        public ResultOutput GetStudyNotesBriefByType(int uId,int tId)
        {
            var result = new ResultOutput(true);
            result.Data = Mapper.Map<List<StudyNotesBriefOuput>>(_userDAL.GetModels(con => con.Id == uId)
                .FirstOrDefault().StudyNotesType.Where(con => con.Id == tId).FirstOrDefault().StudyNodes.ToList()
                );
            return result;
        }

        /// <summary>
        /// 根据文章Id获取文章详细
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="nId"></param>
        /// <returns></returns>
        public ResultOutput GetStudyNotesDetailById(int uId,int nId)
        {
            var result = new ResultOutput() { Status = true };
            result.Data = Mapper.Map<StudyNotesOutput>(_userDAL.GetModels(con => con.Id == uId)
                .FirstOrDefault().StudyNodes.Where(con => con.Id == nId).FirstOrDefault());
            return result;
        }

        /// <summary>
        /// 根据学习笔记ID删除
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="nId"></param>
        /// <returns></returns>
        public ResultOutput DeleteStudyNotesById(int uId,int nId)
        {
            var result = new ResultOutput();
            var Notes = _userDAL.GetModels(con => con.Id == uId)
                .FirstOrDefault().StudyNodes;
            var delNote = Notes.Where(con => con.Id == nId).FirstOrDefault();
            Notes.Remove(delNote);
            try
            {
                _userDAL.SaveChanges();
                result.Status = true;
            }
            catch (Exception ex)
            {
                result.Data = ex;
            }
            return result;
        }

        /// <summary>
        /// 添加学习笔记
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ResultOutput AddStudyNotes(StudyNotesInput input)
        {
            var result = new ResultOutput();
            var NotesType = _userDAL.GetModels(con => con.Id == input.Uid).FirstOrDefault()
                .StudyNotesType.Where(con => con.Id == input.TypeId).FirstOrDefault();
            var user = _userDAL.GetModels(con => con.Id == input.Uid).FirstOrDefault();
            if(NotesType!= null)
            {
                var nodes = Mapper.Map<StudyNodes>(input);
                nodes.StudyNotesType = NotesType;
                user.StudyNodes.Add(nodes);
            }
            try
            {
                _userDAL.SaveChanges();
                result.Status = true;
            }
            catch (Exception ex)
            {
                result.Data = ex;
            }
            return result;
        }

        /// <summary>
        /// 根据关键模糊查找学习笔记
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public ResultOutput SearchStudyNotes(int uId,string keyWord)
        {
            var result = new ResultOutput(true);
            result.Data = Mapper.Map<List<StudyNotesBriefOuput>>(
                _userDAL.GetModels(con => con.Id == uId).FirstOrDefault()
                .StudyNodes.Where(con => con.KeyWords.Contains(keyWord))
                .ToList()
                );
            return result;
        }



        /// <summary>
        /// 删除用户电影
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <param name="usId">心情ID</param>
        /// <returns></returns>
        public ResultOutput DeleteUserMovie(int uId, int mId)
        {
            var result = new ResultOutput(true);
            //验证输入参数
            var user = _userDAL.GetModels(con => con.Id == uId).FirstOrDefault();
            if (user is null)  //用户为空
            {
                result.Msg = "User Can't Be Find!";
                return result;
            }
            if (user.UserMovie != null)
            {
                user.UserMovie.Remove(user.UserMovie.Where(con => con.Id == mId).FirstOrDefault());
            }
            try
            {
                _userDAL.SaveChanges();
                result.Status = true;
                result.Data = Mapper.Map<List<UserMovieViewModel>>  (user.UserMovie.OrderByDescending(con => con.MovieName).ToList());
            }
            catch (Exception ex)
            {
                result.Data = ex;
                result.Msg = "Add UserSpeak Failed!";
            }
            return result;
        }


        /// <summary>
        /// 添加用户电影
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <param name="usId">心情ID</param>
        /// <returns></returns>
        public ResultOutput AddUserMovie(int uId, UserMovieViewModel movie)
        {
            var result = new ResultOutput(true);
            //验证输入参数
            var user = _userDAL.GetModels(con => con.Id == uId).FirstOrDefault();
            if (user is null)  //用户为空
            {
                result.Msg = "User Can't Be Find!";
                return result;
            }
            var newmovie = new UserMovie()
            {
                MovieName = movie.MovieName,
                MovieUrl = movie.MovieUrl,
                MovieDesc = movie.MovieDesc
            };
            user.UserMovie.Add(newmovie);
            try
            {
                _userDAL.SaveChanges();
                result.Status = true;
                result.Data = Mapper.Map<List<UserMovieViewModel>> (user.UserMovie.OrderByDescending(con => con.MovieName).ToList());
            }
            catch (Exception ex)
            {
                result.Data = ex;
                result.Msg = "Add UserSpeak Failed!";
            }
            return result;
        }


    }
}