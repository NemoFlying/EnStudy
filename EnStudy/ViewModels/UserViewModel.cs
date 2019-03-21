using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnStudy.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 登陆用户账号
        /// 不能重复
        /// </summary>
        public string AccountNo { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NikeName { get; set; }

        /// <summary>
        /// 性别
        /// M/F
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// QQ
        /// 头像默认为QQ头像
        /// </summary>
        public string QqId { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string HeadPortrait { get; set; }

        /// <summary>
        /// 大学名称
        /// </summary>
        public string UniversityName { get; set; }


        /// <summary>
        /// 所在地【省】
        /// </summary>
        public string Addr { get; set; }


        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 个性标签
        /// </summary>
        public string PersonalLabel { get; set; }

        /// <summary>
        /// 个性签名
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegistDate { get; set; }
    }
}