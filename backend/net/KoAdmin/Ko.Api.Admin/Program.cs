using Ko.Common.Components.ApiUi;
using Ko.Common.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//进行配置注册 | 添加静态文件读取(优先级比较高)
AppConfig.AddConfigStartup(builder.Configuration);
// 注入HTTPClient
builder.Services.AddHttpClient();
//数据库注入
Func<IServiceProvider, IFreeSql> fsqlFactory = r =>
{
    var sql = new FreeSql.FreeSqlBuilder()
        .UseConnectionString(FreeSql.DataType.MySql, AppConfig.Database.ConnectionString)
        .UseMonitorCommand(cmd => Console.WriteLine($"Sql：{cmd.CommandText}"))
        .UseAutoSyncStructure(true) //自动同步实体结构到数据库，只有CRUD时才会生成表   谨慎、谨慎、谨慎在生产环境中使用 UseAutoSyncStructure
        .Build();
    return sql;
};
builder.Services.AddSingleton(fsqlFactory);
builder.Services.AddFreeRepository();//仓储注入


//提供了访问当前HTTP上下文（HttpContext）的方法
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers(options =>
{
    //在具有较高的 Order 值的筛选器之前运行 before 代码
    //在具有较高的 Order 值的筛选器之后运行 after 代码
    options.Filters.Add<FormatResultFilter>(20);
    options.Conventions.Add(new ApiGroupConvention());//API分组约定
}).AddJsonOptions(options =>
{
    //命名规则，该值指定用于将对象上的属性名称转换为另一种格式(例如驼峰大小写)或为空以保持属性名称不变的策略[前端想要使用与后端模型本身命名格式输出]。
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    //自定义输出的时间格式
    options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
});
builder.Services.AddEndpointsApiExplorer();
//

//

//


//动态API
builder.Services.AddDynamicApi(options =>
{
    options.FormatResult = true;
    options.FormatResultType = typeof(ResultOutput<>);
    options.AddAssemblyOptions(Assembly.GetCallingAssembly());
    
    options.NamingConvention = NamingConventionEnum.CamelCase;// 接口以小驼峰方式命名
    options.DefaultApiPrefix = "api"; // 指定全局默认的 api 前缀
    options.RemoveActionPostfixes.Clear();//清空API结尾，不删除API结尾;若不清空 CreatUserAsync 将变为 CreateUser
    options.GetRestFulActionName = (actionName) => actionName; // 自定义 ActionName 处理函数;
});
//Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("admin", new OpenApiInfo() { Title = "后台管理接口", Version = "v1" });
    
    // TODO:一定要返回true！
    options.DocInclusionPredicate((docName, description) => true);

    // 增加项目xml注释显示
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Ko.Services.xml"), true);
    // 增加Model xml显示
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Ko.Repositories.xml"), true);
});

//雪花ID
YitIdHelper.SetIdGenerator(new IdGeneratorOptions(1));



builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseApiUI(c =>
    {
        c.SwaggerEndpoint("/swagger/admin/swagger.json", "admin","v1");
    });
}

//异常处理
app.UseMiddleware<ExceptionMiddleware>();

//静态文件
app.UseDefaultFiles();
app.UseStaticFiles();

//路由
app.UseRouting();

//跨域
app.UseCors();

//配置端点
app.MapControllers();
app.UseHttpsRedirection();


app.Run();
