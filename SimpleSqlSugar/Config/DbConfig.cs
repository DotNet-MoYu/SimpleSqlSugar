using SqlSugar;
using System.Collections.Generic;

namespace SimpleSqlSugar
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    public class DbConfig
    {
        /// <summary>
        /// 数据库连接配置
        /// </summary>
        public static List<ConnectionConfig> ConnectionConfigs = new List<ConnectionConfig>();

        /// <summary>
        /// 动态表过滤器配置
        /// </summary>
        public static List<TableFilters> Filters = new List<TableFilters>();

        /// <summary>
        /// 是否输出SQL语句
        /// </summary>
        public static bool OutputSql = false;
    }

    /// <summary>
    /// 表过滤器
    /// </summary>
    public class TableFilters
    {
        /// <summary>
        /// 数据库ConfigId
        /// </summary>
        public string ConfigId { get; set; }

        /// <summary>
        /// 过滤器列表
        /// </summary>
        public List<SqlFilterItem> SqlFilterItems { get; set; }
    }
}
