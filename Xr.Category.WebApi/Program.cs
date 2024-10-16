using Aspros.Base.Framework.Infrastructure;
using Aspros.Project.User.Infrastructure.Repository;
using Xr.System.Domain.DomainEvent;
using Xr.System.Domain.DomainEvent.EventHandler;
using Xr.System.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Nacos.AspNetCore.V2;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net;
using System.Text;
using IdentityServer4.AccessTokenValidation;
using Nacos.V2.Naming.Dtos;
using Nacos.V2;


var listener = new TcpListener(IPAddress.Loopback, 0);
listener.Start();
int port = ((IPEndPoint)listener.LocalEndpoint).Port;
listener.Stop();
listener.Server.Dispose();



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
//builder.WebHost.UseUrls($"http://*:{port}");
//读取nacos配置文件
builder.Host.UseNacosConfig("Nacos");
//注册服务到nacos
builder.Services.AddNacosAspNet(builder.Configuration, "Nacos");

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Description = "在下框中输入请求头中需要添加Jwt授权Token：Bearer Token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var _namingService = builder.Services.BuildServiceProvider().GetService<INacosNamingService>();
var instance = await _namingService.SelectOneHealthyInstance("auth", "DEFAULT_GROUP");
var host = $"{instance.Ip}:{instance.Port}";

var baseUrl = instance.Metadata.TryGetValue("secure", out _)
    ? $"https://{host}"
    : $"http://{host}";

//Authentication
builder.Services
    .AddAuthentication("Bearer")
    //.AddIdentityServerAuthentication(options =>
    //{
    //    options.Authority = "https://localhost:7241";
    //    //options.ApiName = "discovery";
    //    options.RequireHttpsMetadata = false;
    //})
    .AddJwtBearer("Bearer", options =>
    {
        //options.Authority = "https://localhost:7241";
        options.Authority = baseUrl;
        //options.Audience = "discovery";
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    })
    ;
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "category_brand");
    });
});

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



//工作单元组
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
//获取token中当前操作人,租户等信息
//builder.Services.AddTransient<IWorkContext, WorkContext>();
//dbContext
//builder.Services.AddTransient<IDbContext, SystemDbContext>();

//http context 上下文
builder.Services.AddHttpContextAccessor();

//自动注入
builder.Services.AutoInject();

//仓储
//builder.Services.AddTransient<ITenantPackageRepository, TenantPackageRepository>();
//builder.Services.AddTransient<IUserReporistory, UserReporistory>();
//builder.Services.AddTransient<IRoleReporistory, RoleReporistory>();
//builder.Services.AddTransient<IMenuReporistory, MenuReporistory>();

//事件总线
builder.Services.AddTransient<IEventBus, EventBus>();


//cqrs cmd query
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TenantPackageCreateCommand).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TenantPackageModifyCommand).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TenantPackageDelCommand).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TenantPackageListQuery).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TenantCreateCommand).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UserRoleConferCommand).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UserLoginCommand).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UserPermissionQuery).Assembly));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//重写参数
//app.UseRewriteQueryString();

//获取服务
ServiceLocator.Instance = app.Services;

app.UseHttpsRedirection();

//app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
//{
//    Authority = "https://localhost:7241",
//    ApiName = "discovery",
//    RequireHttpsMetadata = false
//});

app.UseAuthentication();

app.UseAuthorization();

//权限校验
//app.UsePermissionValid();

app.MapControllers().RequireAuthorization("ApiScope");

app.Run();

public partial class Program { }