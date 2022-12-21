using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimpleSqlSugar
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public class QueryParams<T> : BaseParams
    {
        /// <summary>
        /// 条件语句:对应sql的where
        /// </summary>
        public Expression<Func<T, bool>> Where { get; set; }


        /// <summary>
        /// 条件语句表达式:对应sql的where
        /// </summary>
        public Expression<Func<T, object>> SelectExp { get; set; }

        /// <summary>
        /// 输出字段:对应sql的select
        /// </summary>
        public string Select { get; set; }

        /// <summary>
        /// 排序:字符串
        /// </summary>
        public string OrderBy { get; set; } = "";

        /// <summary>
        /// 排序表达式
        /// </summary>
        public Expression<Func<T, object>> OrderbyExp { get; set; }


        /// <summary>
        /// 排序类型
        /// </summary>
        public OrderByType OrderByType { get; set; } = OrderByType.Asc;


        /// <summary>
        /// 分表查询条件
        /// </summary>
        public Func<List<SplitTableInfo>, IEnumerable<SplitTableInfo>> SplitTable { get; set; }

    }


    /// <summary>
    /// 单查参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryOneParams<T> : QueryParams<T>
    {


    }

    /// <summary>
    /// 批量查询参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryListParams<T> : QueryParams<T>
    {
        /// <summary>
        /// 指定条数
        /// </summary>
        public int Take { get; set; }

        /// <summary>
        /// 跳过
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// 是否重复
        /// </summary>
        public bool Distinct { get; set; } = false;
    }

}
