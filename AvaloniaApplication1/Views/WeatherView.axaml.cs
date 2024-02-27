using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace WeatherApp.Views;

public partial class WeatherView : UserControl{
    public WeatherView(){
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}