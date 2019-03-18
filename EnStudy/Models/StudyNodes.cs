using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnStudy.Models
{
    /// <summary>
    /// 学习笔记
    /// </summary>
    public class StudyNodes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        /// <summary>
        /// 学习笔记标题
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 笔记类型
        /// </summary>
        public virtual StudyNotesType StudyNotesType { get; set; }

    }
}