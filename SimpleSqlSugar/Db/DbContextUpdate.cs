using SqlSugar;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSqlSugar
{
    /// <summary>
    /// 数据库上下文更新方法
    /// </summary>
    public partial class DbContext
    {

        #region 更新单条

        #region 获取实例
        /// <summary>
        /// 获取修改实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updateOneParams"></param>
        /// <returns></returns>
        public static IUpdateable<T> GetUpdateable<T>(UpdateOneParams<T> updateOneParams) where T : class, new()
        {
            IUpdateable<T> updateable;
            if (updateOneParams.Entity != null)//有实体
            {
                updateable = Db.UpdateableWithAttr(updateOneParams.Entity).IgnoreColumns(updateOneParams.IgnoreNullColumns);
                if (updateOneParams.IgnoreColumns != null)
                {
                    updateable.IgnoreColumns(updateOneParams.IgnoreColumns);
                }
                if (updateOneParams.UpdateColumns != null)
                {
                    updateable.UpdateColumns(updateOneParams.UpdateColumns);
                }
                if (updateOneParams.WhereColumns != null)
                {
                    updateable.WhereColumns(updateOneParams.WhereColumns);
                }
            }
            else//无实体
            {
                updateable = Db.UpdateableWithAttr<T>().SetColumns(updateOneParams.SetsColumns);
            }
            if (!string.IsNullOrEmpty(updateOneParams.As))
            {
                updateable.AS(updateOneParams.As);
            }
            if (updateOneParams.Where != null)
            {
                updateable.Where(updateOneParams.Where);
            }
            return updateable;
        }

        /// <summary>
        /// 获取插入分表实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updateOneParams"></param>
        /// <returns></returns>
        public static SplitTableUpdateByObjectProvider<T> GetSplitUpdateable<T>(UpdateOneParams<T> updateOneParams) where T : class, new()
        {
            var updateable = GetUpdateable(updateOneParams);

            return updateable.SplitTable();
        }
        #endregion


        /// <summary>
        /// 根据实体更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updateOneParams"></param>
        /// <returns></returns>
        public static int Update<T>(UpdateOneParams<T> updateOneParams) where T : class, new()
        {
            if (updateOneParams.IsSpliteTable)
            {
                return GetSplitUpdateable(updateOneParams).ExecuteCommand();
            }
            else
            {
                return GetUpdateable(updateOneParams).ExecuteCommand();
            }

        }

        /// <summary>
        /// 根据实体更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updateOneParams"></param>
        /// <returns></returns>
        public static async Task<int> UpdateAsync<T>(UpdateOneParams<T> updateOneParams) where T : class, new()
        {
            if (updateOneParams.IsSpliteTable)
            {
                return await GetSplitUpdateable(updateOneParams).ExecuteCommandAsync();
            }
            else
            {
                return await GetUpdateable(updateOneParams).ExecuteCommandAsync();
            }
        }
        #endregion


        #region 批量更新

        #region 获取实例
        /// <summary>
        /// 获取批量插入实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updateListParams"></param>
        /// <returns></returns>
        public static IUpdateable<T> GetUpdateable<T>(UpdateListParams<T> updateListParams) where T : class, new()
        {
            IUpdateable<T> updateable;
            if (updateListParams.Entities != null)//有实体
            {
                updateable = Db.UpdateableWithAttr(updateListParams.Entities);

                if (updateListParams.IgnoreColumns != null)
                {
                    updateable.IgnoreColumns(updateListParams.IgnoreColumns);
                }
                if (updateListParams.UpdateColumns != null)
                {
                    updateable.UpdateColumns(updateListParams.UpdateColumns);
                }
                if (updateListParams.WhereColumns != null)
                {
                    updateable.WhereColumns(updateListParams.WhereColumns);
                }
            }
            else//无实体
            {
                updateable = Db.UpdateableWithAttr<T>().SetColumns(updateListParams.SetsColumns);
            }
            if (!string.IsNullOrEmpty(updateListParams.As))
            {
                updateable.AS(updateListParams.As);
            }
            if (updateListParams.Where != null)
            {
                updateable.Where(updateListParams.Where);
            }
            return updateable;
        }

        /// <summary>
        /// 获取批量插入分表实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updateListParams"></param>
        /// <returns></returns>
        public static SplitTableUpdateByObjectProvider<T> GetSplitUpdateable<T>(UpdateListParams<T> updateListParams) where T : class, new()
        {

            var updateable = GetUpdateable(updateListParams);
            return updateable.SplitTable();
        }
        #endregion

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updateListParams"></param>
        /// <returns></returns>
        public static int UpdateList<T>(UpdateListParams<T> updateListParams) where T : class, new()
        {

            if (updateListParams.IsSpliteTable)
            {
                return GetSplitUpdateable(updateListParams).ExecuteCommand();
            }
            else
            {
                return GetUpdateable(updateListParams).ExecuteCommand();
            }
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updateListParams"></param>
        /// <returns></returns>
        public static async Task<int> UpdateListAsync<T>(UpdateListParams<T> updateListParams) where T : class, new()
        {
            if (updateListParams.IsSpliteTable)
            {
                return await GetSplitUpdateable(updateListParams).ExecuteCommandAsync();
            }
            else
            {
                return await GetUpdateable(updateListParams).ExecuteCommandAsync();
            }
        }

        #endregion


        #region
        #endregion
    }
}
