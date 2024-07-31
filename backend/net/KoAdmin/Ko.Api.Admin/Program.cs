using Ko.Common.Components.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//进行配置注册 | 添加静态文件读取(优先级比较高)
AppSettings.AddConfigStartup(builder.Configuration);

// //进行选项注册
// builder.Services.AddConfigureSetup(builder.Configuration);
// // 注册redis缓存
// builder.Services.AddRedisSetup();
// //HttpContext
// builder.Services.AddHttpContextAccessor();
// // 添加过滤器
// builder.Services.AddControllers(options => 
//     {
//         // 全局异常过滤
//         options.Filters.Add<GlobalExceptionFilter>();
//         // 日志过滤器
//         options.Filters.Add<RequestActionFilter>();
//     })
// // 配置Api行为选项
//     .ConfigureApiBehaviorOptions(options =>
//     {
//         // 禁用默认模型验证过滤器
//         options.SuppressModelStateInvalidFilter = true;
//     });

// 添加SqlSugar
builder.Services.AddSqlSugarSetup();

// 自动添加服务层
builder.Services.AddAutoServices("Ko.Services");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
