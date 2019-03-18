using EnStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnStudy.BLL
{
    public interface IRecommendedBookService
    {

        /// <summary>
        /// 获取推荐书籍列表
        /// </summary>
        /// <returns></returns>
        ResultOutput GetRecommendedBooks();

        /// <summary>
        /// 添加推荐书籍
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ResultOutput AddRecommendedBook(RecommendedBook input);

        /// <summary>
        /// 删除推荐书籍
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResultOutput DeleteRecommendedBook(int id);
    }
}
