using Avalonia;
using Avalonia.ReactiveUI;

namespace RegistryApp
{
    internal class Program
    {
        // App entry point
        public static void Main(string[] args) =>
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

        // Avalonia app builder
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                         .UsePlatformDetect()
                         .LogToTrace()
                         .UseReactiveUI();
    }
}
