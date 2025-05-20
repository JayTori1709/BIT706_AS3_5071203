using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Registry.Data;
using RegistryApp.ViewModels;
using RegistryApp.Views;
using Registry.Data.Services;
using System.Linq;
using Registry.Data.Models;

namespace RegistryApp
{
    public class App : Application
    {
        public static RegistryDbContext DbContext { get; private set; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var services = new ServiceCollection();
                var connStr = "server=localhost;database=RegistryDB;user=root;password=l3nardw12";

                services.AddDbContext<RegistryDbContext>(options =>
                    options.UseMySql(connStr, ServerVersion.AutoDetect(connStr)));

                var provider = services.BuildServiceProvider();
                DbContext = provider.GetRequiredService<RegistryDbContext>();

                var clinicService = new ClinicService(DbContext);
                if (!DbContext.Clinics.Any())
                {
                    clinicService.AddClinic(new Clinic { Name = "CityVet" });
                    clinicService.AddClinic(new Clinic { Name = "PawsCare" });
                }



                desktop.MainWindow = new MainWindow
                {
                    DataContext = MainWindowViewModel.Instance
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

    }
}
