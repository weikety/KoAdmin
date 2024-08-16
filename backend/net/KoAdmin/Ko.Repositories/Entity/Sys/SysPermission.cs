namespace Ko.Repositories.Entity.Sysp;

/// <summary>
/// 系统权限表
/// </summary>
[Table(Name = "sys_permission")]
[Index("index_{tablename}_n", "Name")]
[Index("index_{tablename}_c", "Code")]
[Index("index_{tablename}_s", "Sort")]
public partial class SysPermission : BaseEntity
{

}

