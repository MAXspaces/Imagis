using Imagist_Frontend.Controls;
using Imagist_Frontend.Froms;
using Imagist_Library.Connectivity.Account;
using Imagist_Library.Connectivity.Albumn;
using Imagist_Library.Connectivity.HTTP.Account;
using Imagist_Library.Connectivity.Photo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Imagist_Frontend;

public static class ApplicationBuilder
{
    public static void ConfigService(this ServiceCollection service)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        var configuration = builder.Build();
        service.AddSingleton<IConfiguration>(configuration);
    }

    public static void RegisterComponents(this ServiceCollection service)
    {
        service.AddSingleton<AuthenticationManager>();//账号信息采用单实例存储
        service.AddScoped<AccountClient>();
        service.AddScoped<AlbumClient>();
        service.AddScoped<PhotoClient>();
    }
    public static void RegisterForm(this ServiceCollection services) {
        services.AddScoped<LoginForm>();
        services.AddScoped<MainForm>();
        services.AddScoped<ImagePanel>();
        services.AddScoped<UploadPanel>();
        services.AddScoped<Form1>();
    }
}