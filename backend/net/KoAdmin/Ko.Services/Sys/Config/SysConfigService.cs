

namespace Ko.Services.Sys.SysConfig;

public class SysConfigService
{
    private readonly SqlSugarRepository<SysConfig> repository;

    public SysConfigService(SqlSugarRepository<SysConfig> repository)
    {
        this.repository = repository;
    }
}