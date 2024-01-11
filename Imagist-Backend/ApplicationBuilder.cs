using System.Text;
using System.Text.Json;
using Imagist_Backend.Data;
using Imagist_Backend.Service;
using Imagist_Backend.Service.Interface;
using Imagist_Library.Apis;
using Imagist_Library.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Minio;
using Snowflake.Core;
using Swashbuckle.AspNetCore.Filters;

namespace Imagist_Backend;

public static class ApplicationBuilder
{
  public static void ConfigServer(this WebApplicationBuilder builder)
  {
    //Basic
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    //Swagger
    builder.Services.AddSwaggerGen(options =>
    {
      options.AddSecurityDefinition("oauth2",new OpenApiSecurityScheme()
      {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
      });
      options.OperationFilter<SecurityRequirementsOperationFilter>();
    });
    //DataBase
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
    builder.Services.AddDbContext<DataContext>(
      options =>
        options.UseMySql(builder.Configuration.GetSection("APP:DBConnectingString").Value, serverVersion)
          .LogTo(Console.WriteLine, LogLevel.Information)
          .EnableSensitiveDataLogging()
          .EnableDetailedErrors());
    //Object-Server
    builder.Services.AddMinio(configureClient=>
      configureClient
        .WithEndpoint(builder.Configuration.GetSection("APP:MinIO:Url").Value)
        .WithCredentials(
          builder.Configuration.GetSection("APP:MinIO:accessKey").Value,
          builder.Configuration.GetSection("APP:MinIO:secretKey").Value)
        .WithSSL(false));
    
    //Authorization
    builder.Services.AddAuthentication().AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters()
      {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
          builder.Configuration.GetSection("APP:JwtSecret").Value!))
      };
      //Handle the UnAuthorize Request 自定义返回内容
      options.Events = new JwtBearerEvents()
      {
        OnChallenge = context =>
        {

          //此处代码为终止.Net Core默认的返回类型和数据结果
          context.HandleResponse();
 
          //自定义自己想要返回的数据结果，这里要返回的是Json对象
          var payload = 
            JsonSerializer.Serialize(
              Api<Object>.Failed(ApiCode.NotLogin, "用户未登录")
              );
          //自定义返回的数据类型
          context.Response.ContentType = "application/json";
          //自定义返回状态码，默认为401 这里改成 200
          context.Response.StatusCode = StatusCodes.Status200OK;
          //输出Json数据结果
          context.Response.WriteAsync(payload);
          return Task.FromResult(0);
        },
        OnAuthenticationFailed = context => {
 
          //自定义自己想要返回的数据结果，我这里要返回的是Json对象
          var payload = 
            JsonSerializer.Serialize(
              Api<Object>.Failed(ApiCode.TokenExpired, "Token过期")
            );
          //自定义返回的数据类型
          context.Response.ContentType = "application/json";
          //自定义返回状态码，默认为401 这里改成 200
          context.Response.StatusCode = StatusCodes.Status200OK;
          //输出Json数据结果
          context.Response.WriteAsync(payload);
          return Task.FromResult(0);
        
      }
      };
    });
  }

  public static void RegisterServices(this WebApplicationBuilder builder)
  {
    builder.Services.AddScoped<DataContext>();
    builder.Services.AddScoped<IAccountService, AccountService>();
    builder.Services.AddScoped<IObjectStorageService, ObjectStorageService>();
    builder.Services.AddScoped<IAlbumService, AlbumService>();
    builder.Services.AddScoped<IPhotoService, PhotoService>();
  }

  public static void RegisterComponents(this WebApplicationBuilder builder)
  {
    builder.Services.AddScoped<IdWorker>(provider => new IdWorker(1, 1));
    builder.Services.AddScoped<JwtHelper>();
  }
}