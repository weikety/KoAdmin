using System.Text.RegularExpressions;

namespace Ko.Repositories.Entity.Sys;

/// <summary>
/// 系统字典数据表
/// </summary>
[Table(Name = "sys_dict_data")]
[Index("index_{tablename}_n", "Name")]
[Index("index_{tablename}_c", "Code", true)]
[Index("index_{tablename}_s", "Sort")]
public class SysDictData : BaseEntity
{
    /// <summary>
    /// 所属字典ID
    /// </summary>
    public long SysDictId { get; set; }

    /// <summary>
    /// 所属字典
    /// </summary>
    [Navigate(nameof(SysDictId))]
    public SysDict? SysDict { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [Column(StringLength = 256)]
    public string? Name { get; set; }
    
    /// <summary>
    /// 值
    /// </summary>
    [Column(StringLength = 128)]
    public string Value { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    [Column(StringLength = 256)]
    public string Code { get; set; }

    /// <summary>
    /// 显示样式-标签颜色
    /// </summary>
    [Column(StringLength = 16)]
    public string? TagType { get; set; }

    /// <summary>
    /// 显示样式-Style(控制显示样式)
    /// </summary>
    [Column(StringLength = 512)]
    public string? StyleSetting { get; set; }

    /// <summary>
    /// 显示样式-Class(控制显示样式)
    /// </summary>
    [Column(StringLength = 512)]
    public string? ClassSetting { get; set; }

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