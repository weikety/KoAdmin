namespace Ko.Repositories.Entity;

/// <summary>
/// 基类Id
/// </summary>
public abstract class EntityBaseId
{
    /// <summary>
    /// Id
    /// 主键、自增
    /// </summary>
    [SugarColumn(ColumnDescription = "主键Id", IsPrimaryKey = true, IsIdentity = true)]
    public virtual long Id { get; set; }
}

/// <summary>
/// 基类
/// </summary>
[SugarIndex("index_{table}_ct", nameof(CreateTime), OrderByType.Asc)]
[SugarIndex("index_{table}_ut", nameof(UpdateTime), OrderByType.Asc)]
public class BaseEntity : EntityBaseId,IDeletedFilter
{
    /// <summary>
    /// 创建时间
    /// </summary>
    [SugarColumn(ColumnDescription = "创建时间", IsNullable = true, IsOnlyIgnoreUpdate = true, InsertServerTime = true)]
    public virtual DateTime CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    [SugarColumn(ColumnDescription = "更新时间", IsOnlyIgnoreInsert = true, UpdateServerTime = true)]
    public virtual DateTime? UpdateTime { get; set; }
    
    /// <summary>
    /// 删除时间
    /// </summary>
    [SugarColumn(ColumnDescription = "删除时间", IsOnlyIgnoreInsert = true)]
    public virtual DateTime? DeleteTime { get; set; }

    /// <summary>
    /// 创建者Id
    /// </summary>
    [SugarColumn(ColumnDescription = "创建者Id", IsOnlyIgnoreUpdate = true)]
    public virtual long? CreateUserId { get; set; }

    /// <summary>
    /// 创建者姓名
    /// </summary>
    [SugarColumn(ColumnDescription = "创建者姓名", Length = 64, IsOnlyIgnoreUpdate = true)]
    public virtual string? CreateUserName { get; set; }

    /// <summary>
    /// 修改者Id
    /// </summary>
    [SugarColumn(ColumnDescription = "修改者Id")]
    public virtual long? UpdateUserId { get; set; }

    /// <summary>
    /// 修改者姓名
    /// </summary>
    [SugarColumn(ColumnDescription = "修改者姓名", Length = 64)]
    public virtual string? UpdateUserName { get; set; }

    /// <summary>
    /// 删除者Id
    /// </summary>
    [SugarColumn(ColumnDescription = "删除者Id", IsOnlyIgnoreUpdate = true)]
    public virtual long? DeleteUserId { get; set; }

    /// <summary>
    /// 删除者姓名
    /// </summary>
    [SugarColumn(ColumnDescription = "删除者姓名", Length = 64, IsOnlyIgnoreUpdate = true)]
    public virtual string? DeleteUserName { get; set; }
    
    /// <summary>
    /// 软删除
    /// </summary>
    [SugarColumn(ColumnDescription = "软删除")]
    public virtual bool IsDelete { get; set; } = false;

}

/// <summary>
/// 业务数据基类（数据权限）
/// </summary>
public abstract class BaseEntityData : BaseEntity, IOrgIdFilter
{
    /// <summary>
    /// 创建者部门Id
    /// </summary>
    [SugarColumn(ColumnDescription = "创建者部门Id", IsOnlyIgnoreUpdate = true)]
    public virtual long? CreateOrgId { get; set; }

    // /// <summary>
    // /// 创建者部门
    // /// </summary>
    // [Newtonsoft.Json.JsonIgnore]
    // [System.Text.Json.Serialization.JsonIgnore]
    // [Navigate(NavigateType.OneToOne, nameof(CreateOrgId))]
    // public virtual SysOrg CreateOrg { get; set; }

    /// <summary>
    /// 创建者部门名称
    /// </summary>
    [SugarColumn(ColumnDescription = "创建者部门名称", Length = 64, IsOnlyIgnoreUpdate = true)]
    public virtual string? CreateOrgName { get; set; }
}

