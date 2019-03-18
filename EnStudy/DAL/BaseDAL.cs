using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EnStudy.DAL
{
    public class BaseDAL<T> where T:class,new()
    {
        private EnStudyContext dbContext = EnStudyContextFactory.GetdbContext();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            dbContext.Set<T>().AddOrUpdate(entity);
        }

        /// <summary>
        /// 根据条件获取数据列表
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda);
        }

        /// <summary>
        /// 带分页的数据返回结果
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="isAsc"></param>
        /// <param name="OrderByLambda"></param>
        /// <param name="WhereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            //是否升序
            if (isAsc)
            {
                return dbContext.Set<T>().Where(WhereLambda).OrderBy(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return dbContext.Set<T>().Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

        /// <summary>
        /// 提交到数据库
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }
        public void RollBack()
        {
        }
    }
}