var builder = WebApplication.CreateBuilder(args);

//进行配置注册 | 添加静态文件读取(优先级比较高)
AppConfig.AddConfigStartup(builder.Configuration);

//数据库注入
Func<IServiceProvider, IFreeSql> fsqlFactory = r =>
{
    IFreeSql fsql = new FreeSql.FreeSqlBuilder()
        .UseConnectionString(FreeSql.DataType.MySql, AppConfig.Database.ConnectionString)
        .UseMonitorCommand(cmd => Console.WriteLine($"Sql：{cmd.CommandText}"))
        .UseAutoSyncStructure(true) //自动同步实体结构到数据库，只有CRUD时才会生成表   谨慎、谨慎、谨慎在生产环境中使用 UseAutoSyncStructure
        .Build();
    return fsql;
};
builder.Services.AddSingleton(fsqlFactory);
builder.Services.AddFreeRepository();//仓储注入

//动态API
builder.Services.AddDynamicApi(options =>
{
    options.NamingConvention = NamingConventionEnum.CamelCase;// 接口以小驼峰方式命名
    options.DefaultApiPrefix = "api"; // 指定全局默认的 api 前缀
    options.RemoveActionPostfixes.Clear();//清空API结尾，不删除API结尾;若不清空 CreatUserAsync 将变为 CreateUser
    options.GetRestFulActionName = (actionName) => actionName; // 自定义 ActionName 处理函数;
});

//API文档
//builder.Services.AddSwaggerGen();
//

//

//

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}


app.UseHttpsRedirection();


app.Run();
