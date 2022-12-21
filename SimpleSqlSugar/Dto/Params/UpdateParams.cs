using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimpleSqlSugar
{
    /// <summary>
    /// 修改参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UpdateParams<T> : BaseParams where T : class, new()
    {
        /// <summary>
        /// 是否分表
        /// </summary>
        public bool IsSpliteTable { get; set; } = false;

        /// <summary>
        /// 更新添加条件
        /// /如果是集合操作请更新到5.0.4版本之前版本禁止使用, 并且只有部分库支持
        /// </summary>
        public Expression<Func<T, bool>> Where { get; set; }

        /// <summary>
        /// 只更新某列
        /// </summary>
        public Expression<Func<T, object>> UpdateColumns { get; set; }


        /// <summary>
        /// 不更新某列
        /// </summary>
        public Expression<Func<T, object>> IgnoreColumns { get; set; }

        /// <summary>
        /// 无主键/指定列
        /// </summary>
        public Expression<Func<T, object>> WhereColumns { get; set; }



        /// <summary>
        /// 指定字段
        /// </summary>
        public Expression<Func<T, bool>> SetsColumns { get; set; }

    }

    /// <summary>
    /// 修改一条参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UpdateOneParams<T> : UpdateParams<T> where T : class, new()
    {
        /// <summary>
        /// 实体类
        /// </summary>
        public T Entity { get; set; }


        /// <summary>
        /// 是否忽略空
        /// </summary>
        public bool IgnoreNullColumns { get; set; } = true;


    }

    /// <summary>
    /// 批量更新参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UpdateListParams<T> : UpdateParams<T> where T : class, new()
    {
        /// <summary>
        /// 实体类
        /// </summary>
        public List<T> Entities { get; set; }


    }
}
