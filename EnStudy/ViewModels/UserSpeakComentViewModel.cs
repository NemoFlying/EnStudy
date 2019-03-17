using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnStudy.ViewModels
{
    public class UserSpeakComentViewModel
    {

        public int Id { get; set; }

        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime ComentTime { get; set; }

        /// <summary>
        /// 评论内容【加密存储】
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 嵌套评论
        /// </summary>
        public List<UserSpeakComentViewModel> CSpeakComent { get; set; }
        
    }
}