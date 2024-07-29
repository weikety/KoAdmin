namespace Ko.Repositories.Entity.Sys;

/// <summary>
/// 系统机构表
/// </summary>
[SugarTable("sys_department", "系统部门表")]
[SugarIndex("index_{table}_n", nameof(Name), OrderByType.Asc)]
[SugarIndex("index_{table}_c", nameof(Code), OrderByType.Asc)]
public partial class SysDepartment : BaseEntity
{
    /// <summary>
    /// 父Id
    /// </summary>
    [SugarColumn(ColumnDescription = "父Id")]
    public long Pid { get; set; }

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
    /// 级别
    /// </summary>
    [SugarColumn(ColumnDescription = "级别")]
    public int? Level { get; set; }
    
    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnDescription = "排序")]
    public int Sort { get; set; } = 100;

    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态")]
    public bool Enable { get; set; } = true;

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "备注", Length = 128)]
    public string? Remark { get; set; }

    /// <summary>
    /// 部门子项
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public List<SysDepartment>? Children { get; set; }

    /// <summary>
    /// 是否禁止选中
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool Disabled { get; set; } = false;
}