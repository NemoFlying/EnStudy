using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnStudy.BLL
{
    interface IPage
    {
        /// <summary>
        /// 总数量
        /// </summary>
        int TotalCount { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// 当前请求页面
        /// </summary>
        int CurrentPage { get; set; }
    }
}
