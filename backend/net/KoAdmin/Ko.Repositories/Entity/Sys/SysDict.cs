namespace Ko.Repositories.Entity.Sys;

/// <summary>
/// 系统字典表
/// </summary>
[SugarTable("sys_dict", "系统字典表")]
[SugarIndex("index_{table}_n", nameof(Name), OrderByType.Asc)]
[SugarIndex("index_{table}_c", nameof(Code), OrderByType.Asc)]
[SugarIndex("index_{table}_s", nameof(Sort), OrderByType.Asc)]
public partial class SysDict : BaseEntity
{
    /// <summary>
    /// 名称
    /// </summary>
    [SugarColumn(ColumnDescription = "名称", Length = 256)]
    public virtual string? Name { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    [SugarColumn(ColumnDescription = "编码", Length = 256)]
    public virtual string Code { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnDescription = "排序")]
    public int Sort { get; set; } = 100;

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "备注", Length = 2048)]
    public string? Remark { get; set; }

    /// <summary>
    /// 拓展数据
    /// </summary>
    [SugarColumn(ColumnDescription = "拓展数据", ColumnDataType = StaticConfig.CodeFirst_BigString)]
    public string? ExtData { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnDescription = "是否启用")]
    public bool Enable { get; set; } = true;
}