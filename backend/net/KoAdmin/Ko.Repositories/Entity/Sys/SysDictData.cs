namespace Ko.Repositories.Entity.Sys;

/// <summary>
/// 系统字典数据表
/// </summary>
[SugarTable("sys_dict_data", "系统字典数据表")]
[SugarIndex("index_{table}_n", nameof(Name), OrderByType.Asc)]
[SugarIndex("index_{table}_c", nameof(Code), OrderByType.Asc)]
[SugarIndex("index_{table}_s", nameof(Sort), OrderByType.Asc)]
public partial class SysDictData : BaseEntity
{
    /// <summary>
    /// 名称
    /// </summary>
    [SugarColumn(ColumnDescription = "名称", Length = 256)]
    public virtual string? Name { get; set; }
    
    /// <summary>
    /// 值
    /// </summary>
    [SugarColumn(ColumnDescription = "值", Length = 128)]
    public virtual string Value { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    [SugarColumn(ColumnDescription = "编码", Length = 256)]
    public virtual string Code { get; set; }

    /// <summary>
    /// 显示样式-标签颜色
    /// </summary>
    [SugarColumn(ColumnDescription = "显示样式-标签颜色", Length = 16)]
    public string? TagType { get; set; }

    /// <summary>
    /// 显示样式-Style(控制显示样式)
    /// </summary>
    [SugarColumn(ColumnDescription = "显示样式-Style", Length = 512)]
    public string? StyleSetting { get; set; }

    /// <summary>
    /// 显示样式-Class(控制显示样式)
    /// </summary>
    [SugarColumn(ColumnDescription = "显示样式-Class", Length = 512)]
    public string? ClassSetting { get; set; }

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