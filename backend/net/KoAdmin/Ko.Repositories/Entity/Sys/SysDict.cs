namespace Ko.Repositories.Entity.Sys;

/// <summary>
/// 系统字典表
/// </summary>
[Table(Name ="sys_dict")]
[Index("index_{tablename}_n", "Name")]
[Index("index_{tablename}_c", "Code")]
[Index("index_{tablename}_s", "Sort")]
public partial class SysDict : BaseEntity
{
    /// <summary>
    /// 名称
    /// </summary>
    [Column(StringLength = 256)]
    public string? Name { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    [Column(StringLength = 256)]
    public string Code { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; set; } = 100;

    /// <summary>
    /// 描述
    /// </summary>
    [Column(StringLength = 2048)]
    public string? Description { get; set; }

    /// <summary>
    /// 拓展数据
    /// </summary>
    [Column(StringLength = -1)]
    public string? ExtData { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enable { get; set; } = true;
}