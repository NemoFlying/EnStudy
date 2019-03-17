using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnStudy.ViewModels
{
    public class StudySchedueVieModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 学习日期【By 天】
        /// </summary>
        public DateTime StudyDay { get; set; }

        /// <summary>
        /// 学习内容
        /// </summary>
        public string StudyContents { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}