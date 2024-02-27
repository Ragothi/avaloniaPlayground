using System;
using System.Threading;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using WeatherApp.Views;

namespace WeatherApp;

public partial class App : Application{
    public override void Initialize(){
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted(){
        base.OnFrameworkInitializationCompleted();
        var service = new WeatherService();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop){
            desktop.MainWindow = new MainWindow{
                DataContext = new MainWindowViewModel(service),
            };
        }
        
    }
}