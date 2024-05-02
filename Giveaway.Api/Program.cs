using Giveaway.Api.Authentication;
using Giveaway.Api.Filters;
using Giveaway.Infrastructure.Context;
using Giveaway.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opts =>
{
    opts.Filters.Add(typeof(AppExceptionFilterAttribute));
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "Ingrese API Key",
        Type = SecuritySchemeType.ApiKey,
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });
    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
    {
        {
            scheme,
            new List<string>()
        }
    };

    swagger.AddSecurityRequirement(requirement);
});

builder.Services.AddMediatR(Assembly.Load("Giveaway.Application"), typeof(Program).Assembly);

builder.Services
    .AddPersistence(builder.Configuration)
    .AddDomainServices();

builder.Services.AddDbContext<PersistenceContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DevConnection")
    )
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
