namespace Ko.Repositories.Entity;

/// <summary>
/// 软删除 过滤器
/// </summary>
public interface IDeletedFilter
{
    /// <summary>
    /// 软删除
    /// </summary>
    bool IsDelete { get; set; }
}

/// <summary>
/// 部门Id 过滤器
/// </summary>
internal interface IOrgIdFilter
{
    /// <summary>
    /// 创建者部门Id
    /// </summary>
    long? CreateOrgId { get; set; }
}