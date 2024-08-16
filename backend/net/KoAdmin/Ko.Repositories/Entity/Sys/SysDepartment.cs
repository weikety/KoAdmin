namespace Ko.Repositories.Entity.Sys;

/// <summary>
/// 系统部门表
/// </summary>
[Table(Name ="sys_department")]
[Index("index_{tablename}_n", "Name")]
[Index("index_{tablename}_c", "Code")]
public partial class SysDepartment : BaseEntity
{
    /// <summary>
    /// 父Id
    /// </summary>
    public long ParentId { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [Column(StringLength = 64)]
    public string Name { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    [Column(StringLength = 64)]
    public string? Code { get; set; }

    /// <summary>
    /// 级别
    /// </summary>
    public int? Level { get; set; }
    
    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; set; } = 100;

    /// <summary>
    /// 状态
    /// </summary>
    public bool Enable { get; set; } = true;

    /// <summary>
    /// 描述
    /// </summary>
    [Column(StringLength = 128)]
    public string? Description { get; set; }

    /// <summary>
    /// 部门子级列表
    /// </summary>
    [Navigate(nameof(ParentId))]
    public List<SysDepartment>? Children { get; set; }

    /// <summary>
    /// 是否禁止选中
    /// </summary>
    [Column(IsIgnore = true)]
    public bool Disabled { get; set; } = false;
}