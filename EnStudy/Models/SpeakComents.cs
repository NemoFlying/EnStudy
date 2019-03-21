using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnStudy.Models
{
    /// <summary>
    /// 学习心得评论&回复
    /// </summary>
    public class SpeakComents
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime ComentTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 评论内容【加密存储】
        /// </summary>
        [Required]
        public string Contents { get; set; }

        /// <summary>
        /// 评论人用户信息
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 针对哪一条评论
        /// </summary>
        public virtual UserSpeak UserSpeak { get; set; }

        /// <summary>
        /// 父级评论是哪条
        /// </summary>
        public virtual SpeakComents PSpeakComents { get; set; }
    }
}