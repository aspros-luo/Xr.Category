using Aspros.Base.Framework.Infrastructure;
using Aspros.Base.Framework.Infrastructure.Event;
using Aspros.Base.Framework.Infrastructure.Interface;
using Aspros.Base.Framework.Infrastructure.Ioc;
using Aspros.Project.User.Infrastructure.Repository;
using Aspros.SaaS.System.Application.Command;
using Aspros.SaaS.System.Application.Query;
using Aspros.SaaS.System.Domain.DomainEvent;
using Aspros.SaaS.System.Domain.DomainEvent.EventHandler;
using Aspros.SaaS.System.Domain.Repository;
using Aspros.SaaS.System.Infrastructure.Repostory;
using Microsoft.EntityFrameworkCore;
using Nacos.AspNetCore.V2;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services
    .AddMvc()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
    });
//手动设置url 后续由apisix转发
builder.WebHost.UseUrls($"http://*:5033");
//读取nacos配置文件
builder.Host.UseNacosConfig("Nacos");
//设置db连接
builder.Services.AddDbContext<SystemDbContext>(op =>
        op.UseMySql(builder.Configuration.GetSection("data")["ConnectionString"], new MySqlServerVersion(new Version(8, 2, 0))));
//CAP
builder.Services.AddCap(x =>
{
    x.UseMySql(builder.Configuration.GetSection("data")["ConnectionString"]);
    x.UseRedis(builder.Configuration.GetSection("data")["RedisServer"]);
    x.UseRabbitMQ(builder.Configuration.GetSection("data")["RabbitMqServer"]);
});
//设置redis连接
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.InstanceName = "";
    options.Configuration = builder.Configuration.GetSection("data")["RedisServer"];
});
//注册服务到nacos
builder.Services.AddNacosAspNet(builder.Configuration, "Nacos");
//工作单元组
builder.Services.AddTransient<IUnitOfWork, Aspros.SaaS.System.Infrastructure.UnitOfWork>();
//获取token中当前操作人,租户等信息
builder.Services.AddTransient<IWorkContext, WorkContext>();
//dbContext
builder.Services.AddTransient<IDbContext, SystemDbContext>();
//http context 上下文
builder.Services.AddHttpContextAccessor();
//仓储
builder.Services.AddTransient<ITenantPackageRepository, TenantPackageRepository>();
builder.Services.AddTransient<IUserReporistory, UserReporistory>();
//事件总线
builder.Services.AddTransient<IEventBus, EventBus>();
builder.Services.AddTransient<IEventHandler<TenentUserAddEvent>, TenentUserAddEventHandler>();
//cqrs cmd query
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TenantPackageCreateCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TenantPackageModifyCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TenantPackageDelCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TenantPackageListQuery).Assembly));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TenantCreateCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UserRoleAddCommand).Assembly));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//重写参数
//app.UseRewriteQueryString();

//获取服务IOC
ServiceLocator.Instance = app.Services;

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
