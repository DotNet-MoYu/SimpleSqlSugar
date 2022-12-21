using SqlSugar;
using System.Threading.Tasks;

namespace SimpleSqlSugar
{
    /// <summary>
    /// 数据库上下文删除方法
    /// </summary>
    public partial class DbContext
    {
        #region 根据实体删除
        #region 删除单个
        #region 获取删除实例

        /// <summary>
        /// 获取插入实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deleteOneParams"></param>
        /// <returns></returns>
        public static IDeleteable<T> GetDeleteable<T>(DeleteOneParams<T> deleteOneParams) where T : class, new()
        {
            var deleteable = deleteOneParams.Entity == null ? Db.DeleteableWithAttr<T>() : Db.DeleteableWithAttr(deleteOneParams.Entity);
            if (!string.IsNullOrEmpty(deleteOneParams.As))
            {
                deleteable.AS(deleteOneParams.As);
            }
            if (deleteOneParams.WhereExp != null)
            {
                deleteable.Where(deleteOneParams.WhereExp);
            }
            return deleteable;

        }
        #endregion
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deleteOneParams"></param>
        /// <returns></returns>
        public static async Task<int> DeleteOneAsync<T>(DeleteOneParams<T> deleteOneParams) where T : class, new()
        {

            if (deleteOneParams.IsSpliteTable)//分表
            {
                if (deleteOneParams.SplitTable == null)//判断是否有分表条件
                {
                    return await GetDeleteable(deleteOneParams).SplitTable().ExecuteCommandAsync();
                }
                else
                {
                    return await GetDeleteable(deleteOneParams).SplitTable(deleteOneParams.SplitTable).ExecuteCommandAsync();
                }

            }
            else
            {
                return await GetDeleteable(deleteOneParams).ExecuteCommandAsync();
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deleteOneParams"></param>
        /// <returns></returns>
        public static int DeleteOne<T>(DeleteOneParams<T> deleteOneParams) where T : class, new()
        {

            if (deleteOneParams.IsSpliteTable)//分表
            {
                if (deleteOneParams.SplitTable == null)//判断是否有分表条件
                {
                    return GetDeleteable(deleteOneParams).SplitTable().ExecuteCommand();
                }
                else
                {
                    return GetDeleteable(deleteOneParams).SplitTable(deleteOneParams.SplitTable).ExecuteCommand();
                }

            }
            else
            {
                return GetDeleteable(deleteOneParams).ExecuteCommand();
            }
        }

        #endregion

        #region 批量删除
        #region  获取删除实例
        /// <summary>
        /// 获取插入实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deleteListParams"></param>
        /// <returns></returns>
        public static IDeleteable<T> GetDeleteable<T>(DeleteListParams<T> deleteListParams) where T : class, new()
        {
            var deleteable = deleteListParams.Entities == null ? Db.DeleteableWithAttr<T>() : Db.DeleteableWithAttr(deleteListParams.Entities);
            if (!string.IsNullOrEmpty(deleteListParams.As))
            {
                deleteable.AS(deleteListParams.As);
            }
            if (deleteListParams.WhereExp != null)
            {
                deleteable.Where(deleteListParams.WhereExp);
            }
            return deleteable;
        }
        #endregion
        #endregion

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deleteListParams"></param>
        /// <returns></returns>
        public static async Task<int> DeleteListAsync<T>(DeleteListParams<T> deleteListParams) where T : class, new()
        {

            if (deleteListParams.IsSpliteTable)//分表
            {
                if (deleteListParams.SplitTable == null)//判断是否有分表条件
                {
                    return await GetDeleteable(deleteListParams).SplitTable().ExecuteCommandAsync();
                }
                else
                {
                    return await GetDeleteable(deleteListParams).SplitTable(deleteListParams.SplitTable).ExecuteCommandAsync();
                }

            }
            else
            {
                return await GetDeleteable(deleteListParams).ExecuteCommandAsync();
            }
        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deleteListParams"></param>
        /// <returns></returns>
        public static int DeleteList<T>(DeleteListParams<T> deleteListParams) where T : class, new()
        {

            if (deleteListParams.IsSpliteTable)//分表
            {
                if (deleteListParams.SplitTable == null)//判断是否有分表条件
                {
                    return GetDeleteable(deleteListParams).SplitTable().ExecuteCommand();
                }
                else
                {
                    return GetDeleteable(deleteListParams).SplitTable(deleteListParams.SplitTable).ExecuteCommand();
                }
            }
            else
            {
                return GetDeleteable(deleteListParams).ExecuteCommand();
            }
        }

        #endregion
        #region
        #endregion

    }
}
