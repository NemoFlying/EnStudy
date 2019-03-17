using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnStudy.BLL.Dto
{
    public interface IUserReistInput
    {
        /// <summary>
        /// 登陆用户账号
        /// 不能重复
        /// </summary>
        [Required]
        [MaxLength(50)]
        string AccountNo { get; set; }

        /// <summary>
        /// 登陆密码【MD5加密】
        /// </summary>
        [MaxLength(150)]
        [Required]
        string Password { get; set; }

    }
}
