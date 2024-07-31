namespace Ko.Api.Admin.Core.Startups;

/// <summary>
/// SqlSugar启动注册
/// </summary>
public static class SqlSugarSetup
{
    /// <summary>
    /// 主方法
    /// </summary>
    /// <param name="services"></param>
    public static void AddSqlSugarSetup(this IServiceCollection services)
    {
        var configConnection = new ConnectionConfig
        {
            DbType = (DbType)AppSettings.SqlSugarDatabase.DbType,
            ConnectionString = AppSettings.SqlSugarDatabase.Connection,
            IsAutoCloseConnection = true,
            ConfigId = AppSettings.SqlSugarDatabase.ConnId.ToLower(),
            InitKeyType = InitKeyType.Attribute,
            MoreSettings = new ConnMoreSettings()
            {
                IsAutoRemoveDataCache = true,//自动清理缓存
                IsAutoDeleteQueryFilter = true, // 启用删除查询过滤器
                IsAutoUpdateQueryFilter = true, // 启用更新查询过滤器
                SqlServerCodeFirstNvarchar = true // 采用Nvarchar
            },
        };

        // 文档地址：https://www.donet5.com/Home/Doc?typeId=1204
        Action<SqlSugarClient> sqlclient = db =>
        {
            // 设置超时时间
            db.Ado.CommandTimeOut = AppSettings.SqlSugarDatabase.CommandTimeOut;
            
            // 打印SQL语句
            if (AppSettings.SqlSugarDatabase.EnableConsoleSql)
            {
                db.Aop.OnLogExecuting = (sql, parameters) =>
                {
                    var originColor = Console.ForegroundColor;
                    if (sql.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    if (sql.StartsWith("UPDATE", StringComparison.OrdinalIgnoreCase) || sql.StartsWith("INSERT", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    if (sql.StartsWith("DELETE", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine("【" + DateTime.Now + "... 执行SQL】\r\n" + UtilMethods.GetSqlString(db.CurrentConnectionConfig.DbType, sql, parameters) + "\r\n");
                    Console.ForegroundColor = originColor;
                };
                
                //监控所有超过5秒的Sql 
                db.Aop.OnLogExecuted = (sql, p) =>
                {
                    if (db.Ado.SqlExecutionTime.TotalSeconds > AppSettings.SqlSugarDatabase.SqlExecutionTime)
                    {
                        // var fileName = db.Ado.SqlStackTrace.FirstFileName; // 文件名
                        // var fileLine = db.Ado.SqlStackTrace.FirstLine; // 行号
                        // var firstMethodName = db.Ado.SqlStackTrace.FirstMethodName; // 方法名
                        // var log = $"【{DateTime.Now}——超时SQL】\r\n【所在文件名】：{fileName}\r\n【代码行数】：{fileLine}\r\n【方法名】：{firstMethodName}\r\n" + $"【SQL语句】：{UtilMethods.GetNativeSql(sql, pars)}";
                        // Log.Warning(log);
                        // App.PrintToMiniProfiler("SqlSugar", "Slow", log);
                    }
                };
            }
            
            // 数据审计
            db.Aop.DataExecuting = (oldValue, entityInfo) =>
            {
                // 新增/插入
                if (entityInfo.OperationType == DataFilterType.InsertByObject)
                {
                    
                }
                // 编辑/更新
                else if (entityInfo.OperationType == DataFilterType.UpdateByObject)
                {
                    
                }
            };

            //查询事件 
            db.Aop.DataExecuted = (value, entity) => { };
            
            //异常事件
            db.Aop.OnError = ex =>
            {
                if (ex.Parametres == null) return;
                var originColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                var pars = db.Utilities.SerializeObject(((SugarParameter[])ex.Parametres).ToDictionary(it => it.ParameterName, it => it.Value));
                Console.ForegroundColor = originColor;
                Console.WriteLine("【" + DateTime.Now + "... 执行SQL异常】\r\n" + pars + " \r\n");
            };
    
            // 超管排除其他过滤器
            //if (App.User?.FindFirst(ClaimConst.AccountType)?.Value == ((int)AccountTypeEnum.SuperAdmin).ToString()) return;
           
            // 配置假删除过滤器
            db.QueryFilter.AddTableFilter<IDeletedFilter>(u => u.IsDelete == false);
            
            
            
        };
        
       
        

        //SqlSugarScope线程是安全的
        var sqlSugar = new SqlSugarScope(configConnection, sqlclient);
        //这边是SqlSugarScope用AddSingleton
        services.AddSingleton<ISqlSugarClient>(sqlSugar);
        // 注册 SqlSugar 仓储
        services.AddScoped(typeof(SqlSugarRepository<>));
    }
}