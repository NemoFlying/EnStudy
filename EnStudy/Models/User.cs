using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnStudy.Models
{
    /// <summary>
    /// 用户基本信息表
    /// </summary>
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        /// <summary>
        /// 登陆用户账号
        /// 不能重复
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string AccountNo { get; set; }

        /// <summary>
        /// 登陆密码【MD5加密】
        /// </summary>
        [MaxLength(150)]
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(50)]
        public string NikeName { get; set; }

        /// <summary>
        /// 性别
        /// M/F
        /// </summary>
        [MaxLength(1)]
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
        public DateTime RegistDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 学习计划
        /// </summary>
        public virtual ICollection<StudySchedue> StudySchedue { get; set; } = new List<StudySchedue>();

        /// <summary>
        /// 学习心得
        /// </summary>
        public virtual ICollection<UserSpeak> UserSpeak { get; set; } = new List<UserSpeak>();

        /// <summary>
        /// 学习心得评论
        /// </summary>
        public virtual ICollection<SpeakComents> SpeakComents { get; set; } = new List<SpeakComents>();

        /// <summary>
        /// 朋友列表
        /// </summary>
        public virtual ICollection<UserFriend> Friends { get; set; } = new List<UserFriend>();

        /// <summary>
        /// 笔记类型列表
        /// </summary>
        public virtual ICollection<StudyNotesType> StudyNotesType { get; set; } = new List<StudyNotesType>();

        /// <summary>
        /// 学习笔记
        /// </summary>
        public virtual ICollection<StudyNodes> StudyNodes { get; set; } = new List<StudyNodes>();

    }
}