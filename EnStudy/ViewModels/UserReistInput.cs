using EnStudy.BLL.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnStudy.ViewModels
{
    public class UserReistInput : IUserReistInput
    {
        /// <summary>
        /// 登陆用户账号
        /// 不能重复
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string AccountNo { get; set; }

        /// <summary>
        /// 登陆密码【MD5加密】
        /// </summary>
        [MaxLength(150)]
        [Required]
        public string Password { get; set; }
    }
}