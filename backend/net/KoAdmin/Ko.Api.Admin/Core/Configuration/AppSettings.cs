namespace Ko.Api.Admin.Core.Configuration;
using Microsoft.Extensions.Configuration;

public static class AppSettings
{
    private static IConfiguration? _configuration;

    public static IConfiguration Configuration
    {
        get
        {
            if (_configuration == null) throw new NullReferenceException(nameof(Configuration));
            return _configuration;
        }
    }

    /// <summary>
    /// 设置 Configuration 的实例
    /// </summary>
    /// <param name="configuration"></param>
    /// <exception cref="Exception"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public static void AddConfigStartup(IConfiguration? configuration)
    {
        if (_configuration != null)
        {
            throw new Exception($"{nameof(Configuration)}不可修改！");
        }
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }
    
    /// <summary>
    /// 获取数据库配置
    /// </summary>
    public static class SqlSugarDatabase
    {
        public static string ConnId => Configuration["SqlSugarDatabase:ConnId"] ?? "";
        public static int DbType => Configuration.GetValue<int>("SqlSugarDatabase:DbType");
        public static string Connection => Configuration["SqlSugarDatabase:Connection"] ?? "";
        public static int CommandTimeOut => Configuration.GetValue<int>("SqlSugarDatabase:CommandTimeOut");

        public static bool EnableConsoleSql => Configuration.GetValue<bool>("SqlSugarDatabase:EnableConsoleSql");
        public static int SqlExecutionTime => Configuration.GetValue<int>("SqlSugarDatabase:SqlExecutionTime");
        
    }
    
}