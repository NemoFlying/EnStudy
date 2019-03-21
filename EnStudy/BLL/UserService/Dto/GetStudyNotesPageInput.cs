﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnStudy.BLL.Dto
{
    public class GetStudyNotesPageInput : IPage
    {
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 当前请求页
        /// </summary>
        public int CurrentPage { get; set; } = 0;

        /// <summary>
        /// 请求人ID
        /// </summary>
        public int UserId { get; set; }
    }
}