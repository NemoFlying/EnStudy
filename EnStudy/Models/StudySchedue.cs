using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnStudy.Models
{
    /// <summary>
    /// 学习日程
    /// </summary>
    public class StudySchedue
    {
        public StudySchedue()
        {
            CreateTime = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        /// <summary>
        /// 学习日期【By 天】
        /// </summary>
        [Required]
        public DateTime StudyDay { get; set; }

        /// <summary>
        /// 学习内容
        /// </summary>
        [Required]
        public string StudyContents { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public virtual User user { get; set; }

    }
}