using EnStudy.DAL;
using EnStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnStudy.BLL
{
    public class RecommendedBookService: IRecommendedBookService
    {
        private readonly IRecommendedBookDAL _book;

        public RecommendedBookService()
        {
            _book = new RecommendedBookDAL();
        }

        /// <summary>
        /// 获取推荐书籍列表
        /// </summary>
        /// <returns></returns>
        public ResultOutput GetRecommendedBooks()
        {
            var result = new ResultOutput();
            result.Data = _book.GetModels(con => 1 == 1).ToList();
            result.Status = true;
            return result;
        }

        /// <summary>
        /// 添加推荐书籍
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ResultOutput AddRecommendedBook(RecommendedBook input)
        {
            var result = new ResultOutput();
            var rb = new RecommendedBook() {
                BookImgUrl = input.BookImgUrl,
                BookName = input.BookName,
                BookShopUrl = input.BookShopUrl,
                BookIntroduction = input.BookIntroduction
            };
            _book.Add(rb);

            try
            {
                _book.SaveChanges();
                result.Status = true;
                result.Data = _book.GetModels(con => 1 == 1).ToList();
            }
            catch(Exception e)
            {
                result.Data = e;
            }
            return result;

        }

        /// <summary>
        /// 删除推荐书籍
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResultOutput DeleteRecommendedBook(int id)
        {
            var result = new ResultOutput();
            var book = _book.GetModels(con => con.Id == id).FirstOrDefault();
            if(book!=null)
            {
                _book.Delete(book);
                try
                {
                    _book.SaveChanges();
                    result.Status = true;
                    result.Data = _book.GetModels(con => 1 == 1).ToList();
                }
                catch(Exception e)
                {
                    result.Status = false;
                    result.Data = e;
                }
            }
            else
            {
                result.Status = true;
            }
            return result;
        }






    }
}