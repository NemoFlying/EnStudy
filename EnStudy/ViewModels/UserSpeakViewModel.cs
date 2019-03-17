using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnStudy.ViewModels
{
    /// <summary>
    /// 用户发表学习心得【说说】
    /// </summary>
    public class UserSpeakViewModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime SpeakTime { get; set; }

        /// <summary>
        /// 发表内容【加密存储】
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public UserViewModel user { get; set; }

        public List<UserSpeakComentViewModel> Coment { get; set; }


    }
}