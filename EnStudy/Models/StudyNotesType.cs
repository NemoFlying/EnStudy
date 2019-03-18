using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnStudy.Models
{
    /// <summary>
    /// 学习笔记类型
    /// </summary>
    public class StudyNotesType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        /// <summary>
        /// 学习笔记类型
        /// </summary>
        [Required]
        public string TypeName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 文章列表
        /// </summary>
        public virtual ICollection<StudyNodes> StudyNodes { get; set; } = new List<StudyNodes>();

    }
}