
using SqlSugar;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleSqlSugar
{

    /// <summary>
    /// 数据库上下文对象
    /// </summary>
    public partial class DbContext
    {

        /// <summary>
        /// SqlSugar 数据库实例
        /// </summary>
        public static readonly SqlSugarScope Db = new SqlSugarScope(
           DbConfig.ConnectionConfigs
            , db =>
            {
                DbConfig.ConnectionConfigs.ForEach(it =>
                {
                    string configId = it.ConfigId;
                    var filter = DbConfig.Filters.Where(it => it.ConfigId == configId).FirstOrDefault();//获取表过滤器
                    if (filter != null)//如果有个表过滤器
                    {
                        filter.SqlFilterItems.ForEach(item =>
                        {
                            db.GetConnection(configId).QueryFilter.Add(item);//添加过滤器
                        });
                    }
                    db.GetConnection(configId).Aop.OnLogExecuting = (sql, pars) =>
                    {
                        if (DbConfig.OutputSql)
                        {
                            if (sql.StartsWith("SELECT"))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"==============查询{configId}库操作==============");
                            }
                            if (sql.StartsWith("UPDATE") || sql.StartsWith("INSERT"))
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"==============修改{configId}库操作==============");
                            }
                            if (sql.StartsWith("DELETE"))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"==============删除{configId}库操作==============");
                            }
                            Console.WriteLine(UtilMethods.GetSqlString(it.DbType, sql, pars));
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    };
                });
            });

        /// <summary>
        /// 添加表过滤器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configId">数据库标识</param>
        /// <param name="expression">过滤表达式</param>
        /// <param name="isJoinOn">是否连表</param>
        public static void AddTableFilter<T>(string configId, Expression<Func<T, bool>> expression, bool isJoinOn = true) where T : class, new()
        {
            Db.GetConnection(configId).QueryFilter.Add(new TableFilterItem<T>(expression, isJoinOn));
        }

    }
}