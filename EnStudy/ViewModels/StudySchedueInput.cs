using EnStudy.BLL.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnStudy.ViewModels
{
    public class StudySchedueInput: IStudySchedueInput
    {
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
    }
}