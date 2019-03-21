using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnStudy.BLL.Dto
{
    /// <summary>
    /// 添加留言参数
    /// </summary>
    public class AddSpeakComentsInput
    {
        /// <summary>
        /// 留言人ID
        /// </summary>
        public int FromUserId { get; set; }

        /// <summary>
        /// 被留言的用户Id
        /// </summary>
        public int ToUserId { get; set; }

        /// <summary>
        /// 被留言的说说Id
        /// </summary>
        public int SpeakId { get; set; }

        /// <summary>
        /// 被留言的回复的Id
        /// </summary>
        public int? ComentId { get; set; }

        /// <summary>
        /// 留言信息
        /// </summary>
        public string Msg { get; set; }


    }
}