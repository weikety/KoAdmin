namespace Ko.Repositories.Entity;

/// <summary>
/// 系统参数配置表
/// </summary>
[Table(Name = "sys_config")]
[Index("index_{tablename}_n", "Name")]
[Index("index_{tablename}_c", "Code", true)]
[Index("index_{tablename}_s", "Sort")]
public partial class SysConfig : BaseEntity
{
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
    /// 值
    /// </summary>
    [Column(StringLength = 64)]
    public string? Value { get; set; }

    /// <summary>
    /// 拓展数据
    /// </summary>
    [Column(StringLength = -1)]
    public string? ExtData { get; set; }
    
    /// <summary>
    /// 是否是内置参数
    /// </summary>
    public bool IsSysOwn { get; set; }

    /// <summary>
    /// 分组编码
    /// </summary>
    [Column(StringLength = 64)]
    public string? GroupCode { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; set; } = 100;

    /// <summary>
    /// 描述
    /// </summary>
    [Column(StringLength = 256)]
    public string? Description { get; set; }
    
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enable { get; set; } = true;
}