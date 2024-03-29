using Imagist_Frontend.Froms;
using Imagist_Library.Apis.UserApi.Register;
using Imagist_Library.Connectivity.Account;
using Imagist_Library.Connectivity.HTTP.Account;
using Microsoft.Extensions.DependencyInjection;

namespace Imagist_Frontend
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Using dependency Injection 使用依赖注入
            var services = new ServiceCollection();
            services.ConfigService();
            services.RegisterComponents();
            services.RegisterForm();

            var serviceProvider = services.BuildServiceProvider();
            var loginFrom = serviceProvider.GetService<LoginForm>();
            
            Application.Run(loginFrom);
        }
    }
}