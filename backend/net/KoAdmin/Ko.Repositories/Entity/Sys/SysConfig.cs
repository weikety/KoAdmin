namespace Ko.Repositories.Entity;

/// <summary>
/// 系统参数配置表
/// </summary>
[SugarTable("sys_config", "系统参数配置表")]
[SugarIndex("index_{table}_n", nameof(Name), OrderByType.Asc)]
[SugarIndex("index_{table}_c", nameof(Code), OrderByType.Asc, IsUnique = true)]
[SugarIndex("index_{table}_s", nameof(Sort), OrderByType.Asc)]
public partial class SysConfig : BaseEntity
{
    /// <summary>
    /// 名称
    /// </summary>
    [SugarColumn(ColumnDescription = "名称", Length = 64)]
    public virtual string Name { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    [SugarColumn(ColumnDescription = "编码", Length = 64)]
    public string? Code { get; set; }

    /// <summary>
    /// 值
    /// </summary>
    [SugarColumn(ColumnDescription = "属性值", Length = 64)]
    public string? Value { get; set; }

    /// <summary>
    /// 拓展数据
    /// </summary>
    [SugarColumn(ColumnDescription = "拓展数据", ColumnDataType = StaticConfig.CodeFirst_BigString)]
    public string? ExtData { get; set; }
    
    /// <summary>
    /// 是否是内置参数
    /// </summary>
    [SugarColumn(ColumnDescription = "是否是内置参数")]
    public bool IsSysOwn { get; set; }

    /// <summary>
    /// 分组编码
    /// </summary>
    [SugarColumn(ColumnDescription = "分组编码", Length = 64)]
    public string? GroupCode { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnDescription = "排序")]
    public int Sort { get; set; } = 100;

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "备注", Length = 256)]
    public string? Remark { get; set; }
    
    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnDescription = "是否启用")]
    public bool Enable { get; set; } = true;
}