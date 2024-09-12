namespace Ko.Services.Sys.SysConfigService;
/// <summary>
/// 系统配置接口
/// </summary>
public interface ISysConfigService
{
    /// <summary>
    /// 获取配置信息
    /// </summary>
    /// <returns></returns>
    public Task<List<SysConfig>> GetAsync();
}