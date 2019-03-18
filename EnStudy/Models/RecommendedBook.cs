using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnStudy.Models
{
    /// <summary>
    /// 推荐书籍
    /// </summary>
    public class RecommendedBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自动增长
        public int Id { get; set; }

        /// <summary>
        /// 书籍名称
        /// </summary>
        [Required]
        public string BookName { get; set; }

        /// <summary>
        /// 书籍简介
        /// </summary>
        public string BookIntroduction { get; set; }

        /// <summary>
        /// 书籍图片地址
        /// </summary>
        [Required]
        public string BookImgUrl { get; set; }

        /// <summary>
        /// 书籍购买连接
        /// </summary>
        public string BookShopUrl { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;

    }
}