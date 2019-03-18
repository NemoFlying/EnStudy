using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnStudy.DAL
{
    public interface IBaseDAL<T> where T:class,new()
    {
        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="t"></param>
        void Add(T t);

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="t"></param>
        void Delete(T t);

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="t"></param>
        void Update(T t);

        

        /// <summary>
        /// 根据条件获得对象列表
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 根据条件获得对象列表
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="isAsc"></param>
        /// <param name="OrderByLambda"></param>
        /// <param name="WhereLambda"></param>
        /// <returns></returns>

        IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda);
        
        /// <summary>
        /// 一个业务中有可能涉及到对多张表的操作,那么可以将操作的数据,打上相应的标记,最后调用该方法,将数据一次性提交到数据库中,避免了多次链接数据库。
        /// true 表示有更改
        /// false 表示没有更改
        /// </summary>
        bool SaveChanges();

        void RollBack();
    }
}
