using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnStudy.BLL.Dto
{
    public interface IUserUpdateInput
    {
        int Id { get; set; }

        string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(50)]
        string NikeName { get; set; }

        /// <summary>
        /// 性别
        /// M/F
        /// </summary>
        [MaxLength(1)]
        string Sex { get; set; }

        ///// <summary>
        ///// 生日
        ///// </summary>
        //[MaxLength(500)]
        //DateTime BirthDay { get; set; }

        /// <summary>
        /// QQ
        /// 头像默认为QQ头像
        /// </summary>
        string QqId { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        string HeadPortrait { get; set; }

        /// <summary>
        /// 大学名称
        /// </summary>
        string UniversityName { get; set; }


        /// <summary>
        /// 所在地【省】
        /// </summary>
        string Addr { get; set; }


        /// <summary>
        /// 手机号码
        /// </summary>
        string Phone { get; set; }

        /// <summary>
        /// 个性标签
        /// </summary>
        string PersonalLabel { get; set; }

        /// <summary>
        /// 个性签名
        /// </summary>
        string Signature { get; set; }
    }
}
