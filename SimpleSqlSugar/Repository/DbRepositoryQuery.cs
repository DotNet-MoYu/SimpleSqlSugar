using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSqlSugar
{
    /// <summary>
    /// 仓储模式
    /// </summary>
    public partial class DbRepository<T> : SimpleClient<T> where T : class, new()
    {

    }
}
