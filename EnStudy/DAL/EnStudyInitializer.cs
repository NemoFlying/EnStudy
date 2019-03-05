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
            context.User.Add(user);
            context.SaveChanges();


            base.Seed(context);
        }
    }
}