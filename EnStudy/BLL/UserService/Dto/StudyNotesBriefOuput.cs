using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnStudy.BLL.Dto
{
    public class StudyNotesBriefOuput
    {
        public int Id { get; set; }

        /// <summary>
        /// 学习笔记标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWords { get; set; }
    }
}