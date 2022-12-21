using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimpleSqlSugar
{
    /// <summary>
    /// 插入参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AddParams<T> : BaseParams where T : class, new()
    {

        /// <summary>
        /// 指定插入字段
        /// </summary>
        public Expression<Func<T, object>> InsertColumns { get; set; }

        /// <summary>
        /// 是否分表
        /// </summary>
        public bool IsSpliteTable { get; set; } = false;

    }

    /// <summary>
    /// 实体插入参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AddOneParams<T> : AddParams<T> where T : class, new()
    {
        /// <summary>
        /// 实体类
        /// </summary>
        public T Entity { get; set; }

        /// <summary>
        /// 是否忽略空
        /// </summary>
        public bool IgnoreColumns { get; set; } = true;

    }


    /// <summary>
    /// 批量实体插入参数
    /// </summary>
    public class AddListParams<T> : AddParams<T> where T : class, new()
    {

        /// <summary>
        /// 实体类
        /// </summary>
        public List<T> Entities { get; set; }


        /// <summary>
        /// 指定插入字段
        /// </summary>
        public Expression<Func<T, object>> IgnoreColumns { get; set; }
    }
}
