using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Registry.Data;

namespace RegistryApp
{
    public class App : Application
    {
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
                var context = provider.GetRequiredService<RegistryDbContext>();
                // Optional: context.Database.EnsureCreated();

                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
