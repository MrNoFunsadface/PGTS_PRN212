using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BLL.Services.Interfaces;
using BLL.Services.Implementations;
using DAL.Repos.Interfaces;
using DAL.Repos.Implementations;
using DAL.Data;

namespace PGTS_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            base.OnStartup(e);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            services.AddSingleton<IUserRepo, UserRepo>();
            services.AddSingleton<IUserService, UserService>();
        }
    }
}
