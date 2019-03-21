using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnStudy.BLL.Dto
{
    public class StudyNotesInput
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }

        /// <summary>
        /// 类型ID
        /// </summary>
        public int TypeId { get;set; }

        /// <summary>
        /// 学习笔记标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public string Contents { get; set; }
    }
}