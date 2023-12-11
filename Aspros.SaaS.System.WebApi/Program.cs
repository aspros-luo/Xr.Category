using Aspros.Base.Framework.Infrastructure;
using Aspros.Base.Framework.Infrastructure.Interface;
using Aspros.Project.User.Infrastructure.Repository;
using Aspros.SaaS.System.Application.Command;
using Aspros.SaaS.System.Application.Query;
using Aspros.SaaS.System.Domain.Repository;
using Aspros.SaaS.System.Infrastructure.Repostory;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nacos.AspNetCore.V2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Host.UseNacosConfig("Nacos");

builder.Services.AddDbContext<SystemDbContext>(op =>
        op.UseMySql(builder.Configuration.GetSection("data")["ConnectionString"], new MySqlServerVersion(new Version(8, 2, 0))));

builder.Services.AddNacosAspNet(builder.Configuration, "Nacos");

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IDbContext, SystemDbContext>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TenantPackageCreateCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TenantPackageListQuery).Assembly));

builder.Services.AddTransient<ITenantPackageRepository, TenantPackageRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
