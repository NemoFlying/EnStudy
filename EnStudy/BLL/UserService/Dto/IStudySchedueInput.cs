using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnStudy.BLL.Dto
{
    public interface IStudySchedueInput
    {
        /// <summary>
        /// 学习日期【By 天】
        /// </summary>
        [Required]
        DateTime StudyDay { get; set; }

        /// <summary>
        /// 学习内容
        /// </summary>
        [Required]
        string StudyContents { get; set; }
    }
}