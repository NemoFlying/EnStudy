using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnStudy.BLL.Dto
{
    public class StudyNoteTypeOutput
    {
        public int Id { get; set; }

        /// <summary>
        /// 学习笔记类型
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 包含的文章简介
        /// </summary>
        public List<StudyNotesOutput> StudyNotesBrief { get; set; } = new List<StudyNotesOutput>();
    }
}