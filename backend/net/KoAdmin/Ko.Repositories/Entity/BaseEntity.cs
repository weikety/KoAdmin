
namespace Ko.Repositories.Entity;

/// <summary>
/// 基类Id
/// </summary>
public class EntityBaseId
{
    /// <summary>
    /// Id
    /// 主键
    /// 雪花ID var newId = YitIdHelper.NextId();
    /// </summary>
    [Column(IsPrimary = true,Position = 1)]
    [Description("主键Id")]
    public long Id { get; set; }
}

/// <summary>
/// 基类
/// </summary>
[Index("index_{tablename}_ct", "CreateTime desc")]
[Index("index_{tablename}_ut", "UpdateTime desc")]
public class BaseEntity : EntityBaseId
{
    /// <summary>
    /// 创建时间
    /// </summary>
    [Column(ServerTime = DateTimeKind.Utc, CanUpdate = false,Position = -20)]
    [Description("创建时间")]
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    [Column(ServerTime = DateTimeKind.Utc,Position = -20)]
    [Description("更新时间")]
    public DateTime? UpdateTime { get; set; }
    
    /// <summary>
    /// 删除时间
    /// </summary>
    [Column(CanInsert = false,Position = -20)]
    [Description("删除时间")]
    public DateTime? DeleteTime { get; set; }

    /// <summary>
    /// 创建者Id
    /// </summary>
    [Column(CanUpdate = false,Position = -20)]
    [Description("创建者Id")]
    public long? CreateUserId { get; set; }

    /// <summary>
    /// 创建者姓名
    /// </summary>
    [Column(CanUpdate = false,Position = -20)]
    [Description("创建者姓名")]
    public string? CreateUserName { get; set; }

    /// <summary>
    /// 修改者Id
    /// </summary>
    [Column(CanInsert = false,Position = -20)]
    [Description("修改者Id")]
    public long? UpdateUserId { get; set; }

    /// <summary>
    /// 修改者姓名
    /// </summary>
    [Column(CanInsert = false,Position = -20)]
    [Description("修改者姓名")]
    public string? UpdateUserName { get; set; }

    /// <summary>
    /// 删除者Id
    /// </summary>
    [Column(CanInsert = false,Position = -20)]
    [Description("删除者Id")]
    public long? DeleteUserId { get; set; }

    /// <summary>
    /// 删除者姓名
    /// </summary>
    [Column(CanInsert = false,Position = -20)]
    [Description("删除者姓名")]
    public string? DeleteUserName { get; set; }

    /// <summary>
    /// 软删除
    /// </summary>
    [Column(Position = -20)]
    [Description("软删除")]
    public bool IsDelete { get; set; } = false;

}

/// <summary>
/// 业务数据基类（数据权限）
/// </summary>
public abstract class BaseEntityData : BaseEntity
{
    /// <summary>
    /// 创建者部门Id
    /// </summary>
    [Column(CanUpdate = false,Position = -30)]
    [Description("创建者部门Id")]
    public long? CreateOrgId { get; set; }

    // /// <summary>
    // /// 创建者部门
    // /// </summary>
    // [Newtonsoft.Json.JsonIgnore]
    // [System.Text.Json.Serialization.JsonIgnore]
    // [Navigate(NavigateType.OneToOne, nameof(CreateOrgId))]
    // public SysOrg CreateOrg { get; set; }

    /// <summary>
    /// 创建者部门名称
    /// </summary>
    [Column(CanUpdate = false,Position = -30)]
    [Description("创建者部门名称")]
    public string? CreateOrgName { get; set; }
}

