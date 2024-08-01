namespace Ko.Repositories.Core;

/// <summary>
/// 仓储接口
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TEntity> where TEntity : class, new()
{
    
     #region 查询

     /// <summary>
     /// 获取总数
     /// </summary>
     /// <param name="whereExpression"></param>
     /// <returns></returns>
     public int Count(Expression<Func<TEntity, bool>> whereExpression);

     /// <summary>
     /// 获取总数
     /// </summary>
     /// <param name="whereExpression"></param>
     /// <returns></returns>
     public Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression);
     
     /// <summary>
     /// 检查是否存在
     /// </summary>
     /// <param name="whereExpression"></param>
     /// <returns></returns>
     public bool Any(Expression<Func<TEntity, bool>> whereExpression);

     /// <summary>
     /// 检查是否存在
     /// </summary>
     /// <param name="whereExpression"></param>
     /// <returns></returns>
     public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> whereExpression);

     /// <summary>
     /// 通过主键获取实体
     /// </summary>
     /// <param name="Id"></param>
     /// <returns></returns>
     public TEntity Single(dynamic Id);

     /// <summary>
     /// 获取一个实体
     /// </summary>
     /// <param name="whereExpression"></param>
     /// <returns></returns>
     public TEntity Single(Expression<Func<TEntity, bool>> whereExpression);

     /// <summary>
     /// 获取一个实体
     /// </summary>
     /// <param name="whereExpression"></param>
     /// <returns></returns>
     public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> whereExpression);
     
     /// <summary>
     /// 获取一个实体
     /// </summary>
     /// <param name="id"></param>
     /// <returns></returns>
     public Task<TEntity> SingleAsync(dynamic id);
     
     /// <summary>
     /// 获取一个实体
     /// </summary>
     /// <param name="whereExpression"></param>
     /// <returns></returns>
     public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> whereExpression);

     /// <summary>
     /// 获取一个实体
     /// </summary>
     /// <param name="whereExpression"></param>
     /// <returns></returns>
     public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> whereExpression);

     /// <summary>
     /// 获取列表
     /// </summary>
     /// <returns></returns>
     public List<TEntity> ToList();

     /// <summary>
     /// 获取列表
     /// </summary>
     /// <param name="whereExpression"></param>
     /// <returns></returns>
     public List<TEntity> ToList(Expression<Func<TEntity, bool>> whereExpression);

     /// <summary>
     /// 获取列表
     /// </summary>
     /// <param name="whereExpression"></param>
     /// <param name="orderByExpression"></param>
     /// <param name="orderByType"></param>
     /// <returns></returns>
     public List<TEntity> ToList(Expression<Func<TEntity, bool>> whereExpression,
         Expression<Func<TEntity, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc);

     /// <summary>
     /// 获取列表
     /// </summary>
     /// <returns></returns>
     public Task<List<TEntity>> ToListAsync();

     /// <summary>
     /// 获取列表
     /// </summary>
     /// <param name="whereExpression"></param>
     /// <returns></returns>
     public Task<List<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> whereExpression);

     /// <summary>
     /// 获取列表
     /// </summary>
     /// <param name="whereExpression"></param>
     /// <param name="orderByExpression"></param>
     /// <param name="orderByType"></param>
     /// <returns></returns>
     public Task<List<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> whereExpression,
         Expression<Func<TEntity, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc);
     #endregion

     #region 新增

     public IInsertable<TEntity> AsInsertable(TEntity entity);

     public IInsertable<TEntity> AsInsertable(params TEntity[] entities);

     /// <summary>
     /// 新增一条记录
     /// </summary>
     /// <param name="entity"></param>
     /// <returns></returns>
     public int Insert(TEntity entity);

     /// <summary>
     /// 新增多条记录
     /// </summary>
     /// <param name="entities"></param>
     /// <returns></returns>
     public int Insert(params TEntity[] entities);

     /// <summary>
     /// 新增多条记录
     /// </summary>
     /// <param name="entities"></param>
     /// <returns></returns>
     public int Insert(IEnumerable<TEntity> entities);

     /// <summary>
     /// 新增一条记录返回自增Id
     /// </summary>
     /// <param name="insertObj"></param>
     /// <returns></returns>
     public int InsertReturnIdentity(TEntity insertObj);

     /// <summary>
     /// 新增一条记录返回雪花Id
     /// </summary>
     /// <param name="entity"></param>
     /// <returns></returns>
     public long InsertReturnSnowflakeId(TEntity entity);

     /// <summary>
     /// 新增一条记录返回实体
     /// </summary>
     /// <param name="entity"></param>
     /// <returns></returns>
     public TEntity InsertReturnEntity(TEntity entity);
     
     /// <summary>
     /// 新增一条记录
     /// </summary>
     /// <param name="entity"></param>
     /// <returns></returns>
     public Task<int> InsertAsync(TEntity entity);

     /// <summary>
     /// 新增多条记录
     /// </summary>
     /// <param name="entities"></param>
     /// <returns></returns>
     public Task<int> InsertAsync(params TEntity[] entities);

     /// <summary>
     /// 新增多条记录
     /// </summary>
     /// <param name="entities"></param>
     /// <returns></returns>
     public Task<int> InsertAsync(IEnumerable<TEntity> entities);

     /// <summary>
     /// 新增一条记录返回自增Id
     /// </summary>
     /// <param name="entity"></param>
     /// <returns></returns>
     public Task<long> InsertReturnIdentityAsync(TEntity entity);

     /// <summary>
     /// 新增一条记录返回雪花Id
     /// </summary>
     /// <param name="entity"></param>
     /// <returns></returns>
     public Task<long> InsertReturnSnowflakeIdAsync(TEntity entity);

     /// <summary>
     /// 新增一条记录返回实体
     /// </summary>
     /// <param name="entity"></param>
     /// <returns></returns>
     public Task<TEntity> InsertReturnEntityAsync(TEntity entity);
     #endregion

     #region 更新

     /// <summary>
     /// 更新一条记录
     /// </summary>
     /// <param name="entity"></param>
     /// <returns></returns>
     public int Update(TEntity entity);

     /// <summary>
     /// 更新多条记录
     /// </summary>
     /// <param name="entities"></param>
     /// <returns></returns>
     public int Update(params TEntity[] entities);

     /// <summary>
     /// 更新多条记录
     /// </summary>
     /// <param name="entities"></param>
     /// <returns></returns>
     public int Update(IEnumerable<TEntity> entities);

     /// <summary>
     /// 更新一条记录
     /// </summary>
     /// <param name="entity"></param>
     /// <returns></returns>
     public Task<int> UpdateAsync(TEntity entity);

     /// <summary>
     /// 更新记录
     /// </summary>
     /// <param name="predicate">更新的条件</param>
     /// <param name="content">更新的内容</param>
     /// <returns></returns>
     public int Update(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> content);

     /// <summary>
     /// 更新记录
     /// </summary>
     /// <param name="predicate">更新的条件</param>
     /// <param name="content">更新的内容</param>
     /// <returns></returns>
     public Task<int> UpdateAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> content);

     /// <summary>
     /// 更新多条记录
     /// </summary>
     /// <param name="entities"></param>
     /// <returns></returns>
     public Task<int> UpdateAsync(params TEntity[] entities);

     /// <summary>
     /// 更新多条记录
     /// </summary>
     /// <param name="entities"></param>
     /// <returns></returns>
     public Task<int> UpdateAsync(IEnumerable<TEntity> entities);

     public IUpdateable<TEntity> AsUpdateable(TEntity entity);

     public IUpdateable<TEntity> AsUpdateable(IEnumerable<TEntity> entities);
     #endregion

     #region 删除

     /// <summary>
     /// 删除一条记录
     /// </summary>
     /// <param name="entity"></param>
     /// <returns></returns>
     public int Delete(TEntity entity);

     /// <summary>
     /// 删除一条记录
     /// </summary>
     /// <param name="key"></param>
     /// <returns></returns>
     public int Delete(object key);

     /// <summary>
     /// 删除多条记录
     /// </summary>
     /// <param name="keys"></param>
     /// <returns></returns>
     public int Delete(params object[] keys);

     /// <summary>
     /// 自定义条件删除记录
     /// </summary>
     /// <param name="whereExpression"></param>
     /// <returns></returns>
     public int Delete(Expression<Func<TEntity, bool>> whereExpression);

     /// <summary>
     /// 删除一条记录
     /// </summary>
     /// <param name="entity"></param>
     /// <returns></returns>
     public Task<int> DeleteAsync(TEntity entity);

     /// <summary>
     /// 删除一条记录
     /// </summary>
     /// <param name="key"></param>
     /// <returns></returns>
     public Task<int> DeleteAsync(object key);

     /// <summary>
     /// 删除多条记录
     /// </summary>
     /// <param name="keys"></param>
     /// <returns></returns>
     public Task<int> DeleteAsync(params object[] keys);

     /// <summary>
     /// 自定义条件删除记录
     /// </summary>
     /// <param name="whereExpression"></param>
     /// <returns></returns>
     public Task<int> DeleteAsync(Expression<Func<TEntity, bool>> whereExpression);
     
     #endregion

     #region 其他

     /// <summary>
     /// 根据表达式查询多条记录
     /// </summary>
     /// <param name="predicate"></param>
     /// <returns></returns>
     public ISugarQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

     /// <summary>
     /// 根据表达式查询多条记录
     /// </summary>
     /// <param name="condition"></param>
     /// <param name="predicate"></param>
     /// <returns></returns>
     public ISugarQueryable<TEntity> Where(bool condition, Expression<Func<TEntity, bool>> predicate);

     /// <summary>
     /// 构建查询分析器
     /// </summary>
     /// <returns></returns>
     public ISugarQueryable<TEntity> AsQueryable();

     /// <summary>
     /// 构建查询分析器
     /// </summary>
     /// <param name="predicate"></param>
     /// <returns></returns>
     public ISugarQueryable<TEntity> AsQueryable(Expression<Func<TEntity, bool>> predicate);

     /// <summary>
     /// 直接返回数据库结果
     /// </summary>
     /// <returns></returns>
     public List<TEntity> AsEnumerable();
     
     /// <summary>
     /// 直接返回数据库结果
     /// </summary>
     /// <param name="predicate"></param>
     /// <returns></returns>
     public List<TEntity> AsEnumerable(Expression<Func<TEntity, bool>> predicate);
     /// <summary>
     /// 直接返回数据库结果
     /// </summary>
     /// <returns></returns>
     public  Task<List<TEntity>> AsAsyncEnumerable();
     /// <summary>
     /// 直接返回数据库结果
     /// </summary>
     /// <param name="predicate"></param>
     /// <returns></returns>
     public Task<List<TEntity>> AsAsyncEnumerable(Expression<Func<TEntity, bool>> predicate);

     public bool IsExists(Expression<Func<TEntity, bool>> whereExpression);

     public Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> whereExpression);
     #endregion

     #region 仓储事务

     /// <summary>
     /// 当前db
     /// </summary>
     public void CurrentBeginTran();

     /// <summary>
     /// 当前db
     /// </summary>
     public void CurrentCommitTran();

     /// <summary>
     /// 当前db
     /// </summary>
     public void CurrentRollbackTran();

     /// <summary>
     /// 所有db
     /// </summary>
     public void BeginTran();

     /// <summary>
     /// 所有db
     /// </summary>
     public void CommitTran();
     /// <summary>
     /// 所有db
     /// </summary>
     public void RollbackTran();

     #endregion

}