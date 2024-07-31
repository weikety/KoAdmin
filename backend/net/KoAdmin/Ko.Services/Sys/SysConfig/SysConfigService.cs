using Ko.Common.Components.SqlSugar;
using Ko.Repositories.Entity;

public class SysConfigService
{
    private readonly SqlSugarRepository<SysConfig> _sysConfigRepostory;

    public SysConfigService(SqlSugarRepository<SysConfig> sysConfigRepostory)
    {
        _sysConfigRepostory = sysConfigRepostory;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public async Task<List<SysConfig>> GetList()
    {
        return await _sysConfigRepostory.ToListAsync();
    }



}