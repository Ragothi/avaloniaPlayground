using System.Collections.ObjectModel;
using System.Reactive.Linq;
using ReactiveUI;
using WeatherApp.Services;

namespace WeatherApp.ViewModels;

public class MainWindowViewModel : ViewModelBase{
    ViewModelBase _context;
    
    public MainWindowViewModel(WeatherService service)
    {
        Context = WeatherList = new WeatherViewModel(service.GetItems());
    }
    
    public ViewModelBase Context
    {
        get => _context;
        private set => this.RaiseAndSetIfChanged(ref _context, value);
    }

    public WeatherViewModel WeatherList { get; }
    
   
    
}