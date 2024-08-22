namespace Ko.Services.Sys.SysConfigService;
/// <summary>
/// 系统参数配置
/// </summary>
[Order(80)]
[DynamicApi(Area = Consts.AreaName)]
public class SysConfigService : BaseService, ISysConfigService, IDynamicApi
{
    private readonly IBaseRepository<SysConfig> _sysConfigRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sysConfigRepository"></param>
    public SysConfigService(IBaseRepository<SysConfig> sysConfigRepository)
    {
        _sysConfigRepository = sysConfigRepository;
    }
    
    /// <summary>
    /// 列表
    /// </summary>
    /// <returns></returns>
    public async Task<List<SysConfig>> GetAsync()
    {
        var list = await _sysConfigRepository.Select.ToListAsync();
        return list;
    }
    
}