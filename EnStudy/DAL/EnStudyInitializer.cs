using EnStudy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnStudy.DAL
{
    /// <summary>
    /// 数据库初始化数据
    /// </summary>
    public class EnStudyInitializer : DropCreateDatabaseIfModelChanges<EnStudyContext>
    {
        protected override void Seed(EnStudyContext context)
        {
            //添加管理员信息
            //admin/admin
            var user = new User()
            {
                AccountNo = "admin",
                Password = "F6FDFFE48C908DEB0F4C3BD36C032E72",
                QqId = "895190626"
            };
            
            var speak = new UserSpeak()
            {
                Contents = "今天天气真好！",
                //SpeakComents = new List<SpeakComents>() { Coments}
            };
            //发表一条说说
            user.UserSpeak = new List<UserSpeak>() { speak };
            context.User.Add(user);

            var Coments = new SpeakComents()
            {
                Contents = "一楼",
                //UserSpeak = speak,
                User = user
            };
            user.UserSpeak.FirstOrDefault().SpeakComents = new List<SpeakComents>()
            {
                Coments
            };


            ////添加Nemo
            var nemo = new User()
            {
                AccountNo = "Nemo",
                Password = "aaaaa",
                QqId = "895190626"
            };

            var nemoConments = new SpeakComents()
            {
                Contents = "二楼",
                UserSpeak = speak,
                User = nemo
            };
            user.UserSpeak.FirstOrDefault().SpeakComents.Add(nemoConments);

            var rAdmin = new SpeakComents()
            {
                Contents = "回复一楼",
                User = nemo
            };
            Coments.CSpeakComents = rAdmin;
            user.UserSpeak.FirstOrDefault().SpeakComents.FirstOrDefault().CSpeakComents = rAdmin;

            //context.User.Add(nemo);

            context.SaveChanges();


            base.Seed(context);
        }
    }
}