using SqlSugar;
using System.Threading.Tasks;

namespace SimpleSqlSugar
{
    /// <summary>
    /// 数据库上下文添加方法
    /// </summary>
    public partial class DbContext
    {

        #region 单条

        /// <summary>
        /// 获取插入实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="addOneParams"></param>
        /// <returns></returns>
        public static IInsertable<T> GetInsertable<T>(AddOneParams<T> addOneParams) where T : class, new()
        {

            var insertable = Db.InsertableWithAttr(addOneParams.Entity).IgnoreColumns(addOneParams.IgnoreColumns);
            if (!string.IsNullOrEmpty(addOneParams.As))
            {
                insertable.AS(addOneParams.As);
            }
            if (addOneParams.InsertColumns != null)
            {
                insertable.InsertColumns(addOneParams.InsertColumns);
            }
            if (addOneParams.IsSpliteTable)
            {
                insertable.SplitTable();
            }
            return insertable;
        }

        /// <summary>
        /// 获取分表插入实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="addOneParams"></param>
        /// <returns></returns>
        public static SplitInsertable<T> GetSplitInsertable<T>(AddOneParams<T> addOneParams) where T : class, new()
        {

            var insertable = GetInsertable(addOneParams);
            return insertable.SplitTable();
        }


        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="addOneParams"></param>
        /// <returns>添加成功数量</returns>
        public static async Task<int> AddOneAsync<T>(AddOneParams<T> addOneParams) where T : class, new()
        {

            if (addOneParams.IsSpliteTable)//分表
            {
                return await GetSplitInsertable(addOneParams).ExecuteCommandAsync();
            }
            else
            {
                return await GetInsertable(addOneParams).ExecuteCommandAsync();
            }
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="addOneParams"></param>
        /// <returns>添加成功数量</returns>
        public static int AddOne<T>(AddOneParams<T> addOneParams) where T : class, new()
        {

            if (addOneParams.IsSpliteTable)//分表
            {
                return GetSplitInsertable(addOneParams).ExecuteCommand();
            }
            else
            {
                return GetInsertable(addOneParams).ExecuteCommand();
            }
        }

        #endregion

        #region 批量



        /// <summary>
        /// 获取批量插入实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="addListParams"></param>
        /// <returns></returns>
        public static IInsertable<T> GetInsertable<T>(AddListParams<T> addListParams) where T : class, new()
        {

            var insertable = Db.InsertableWithAttr(addListParams.Entities);
            if (!string.IsNullOrEmpty(addListParams.As))
            {
                insertable.AS(addListParams.As);
            }
            if (addListParams.InsertColumns != null)
            {
                insertable = insertable.InsertColumns(addListParams.InsertColumns);
            }
            return insertable;
        }

        /// <summary>
        /// 获取分表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="addListParams"></param>
        /// <returns></returns>
        private static SplitInsertable<T> GetSplitInsertable<T>(AddListParams<T> addListParams) where T : class, new()
        {

            var insertable = GetInsertable(addListParams);
            return insertable.SplitTable();
        }


        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="addListParams"></param>
        /// <returns></returns>
        public static async Task<int> AddListAsync<T>(AddListParams<T> addListParams) where T : class, new()
        {
            if (addListParams.IsSpliteTable)//分表
            {
                return await GetSplitInsertable(addListParams).ExecuteCommandAsync();
            }
            else
            {
                return await GetInsertable(addListParams).ExecuteCommandAsync();
            }
        }

        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="addListParams"></param>
        /// <returns></returns>
        public static int AddList<T>(AddListParams<T> addListParams) where T : class, new()
        {
            if (addListParams.IsSpliteTable)//分表
            {
                return GetSplitInsertable(addListParams).ExecuteCommand();
            }
            else
            {
                return GetInsertable(addListParams).ExecuteCommand();
            }
        }
        #endregion

    }
}
