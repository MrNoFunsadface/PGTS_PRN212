using AutoMapper;
using BLL;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using DAL.Data;
using DAL.Entities;
using DAL.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PGTS_WPF.AuthenticationWindows;
using PGTS_WPF.Helper;
using PGTS_WPF.Helpers;
using PGTS_WPF.UserWindows;
using System.IO;
using System.Windows;

namespace PGTS_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();

            var windowManager = _serviceProvider.GetRequiredService<IWindowManager>();
            windowManager.ShowWindow<LoginWindow>();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Add configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            services.AddSingleton<IConfiguration>(configuration);

            // Register DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Register Repositories
            services.AddSingleton<IGenericRepo<User>, GenericRepo<User>>();
            services.AddSingleton<IGenericRepo<Pregnancy>, GenericRepo<Pregnancy>>();
            services.AddSingleton<IGenericRepo<FetusData>, GenericRepo<FetusData>>();
            services.AddSingleton<IGenericRepo<Milestone>, GenericRepo<Milestone>>();

            // Register Services
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IPregnancyService, PregnancyService>();
            services.AddSingleton<IFetusDataService, FetusDataService>();
            services.AddSingleton<IMilestoneService, MilestoneService>();

            // Register Helpers
            services.AddSingleton<UserSession>();
            services.AddSingleton<IWindowManager, WindowManager>();

            // Register Windows
            services.AddTransient<LoginWindow>();
            services.AddTransient<UserMainWindow>();


        }
    }
}
