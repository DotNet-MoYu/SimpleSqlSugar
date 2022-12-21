using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSqlSugar
{
    /// <summary>
    /// 仓储模式
    /// </summary>
    public partial class DbRepository<T> : SimpleClient<T> where T : class, new()
    {
        protected ITenant itenant = null;//多租户事务、GetConnection、IsAnyConnection等功能
        public DbRepository(ISqlSugarClient context = null) : base(context)//注意这里要有默认值等于null
        {
            base.Context = DbContext.Db.GetConnectionScopeWithAttr<T>();//ioc注入的对象
            itenant = DbContext.Db;
        }
    }
}
