using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnStudy.Models
{
    /// <summary>
    /// 用户发表学习心得【说说】
    /// </summary>
    public class UserSpeak
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime SpeakTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 发表内容【加密存储】
        /// </summary>
        [Required]
        public string Contents { get; set; }

        /// <summary>
        /// 权限
        /// Public 所有人可见
        /// Private 仅个人可见
        /// </summary>
        public string Permission { get; set; } = "Public";

        /// <summary>
        /// 用户信息
        /// </summary>
        public virtual User user { get; set; }

        /// <summary>
        /// 多条用户评论
        /// </summary>
        public virtual ICollection<SpeakComents> SpeakComents { get; set; }
    }
}