namespace Ko.Api.Admin.Core;

/// <summary>
/// 系统参数配置
/// </summary>
public static class AppConfig
{
    private static IConfiguration? _configuration;

    /// <summary>
    /// 
    /// </summary>
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
    public static class Database
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public static string Type => Configuration["Database:Type"] ?? "";
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string ConnectionString => Configuration["Database:ConnectionString"] ?? "";
        /// <summary>
        /// 程序集
        /// </summary>
        public static string ProviderType => Configuration["Database:ProviderType"] ?? "";

    }



}