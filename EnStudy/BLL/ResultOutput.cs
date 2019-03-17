﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnStudy.BLL
{
    public class ResultOutput
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; } = false;

        /// <summary>
        /// 返回文本信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }

    }
}