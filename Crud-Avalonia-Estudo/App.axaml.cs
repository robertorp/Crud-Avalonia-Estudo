using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Crud_Avalonia_Estudo.ViewModels;
using Crud_Avalonia_Estudo.Views;

namespace Crud_Avalonia_Estudo
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
                desktop.MainWindow = new MainWindow(new MainWindowViewModel());
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
