using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace AvaloniaApplication1.ViewModels;

public class WeatherViewModel : ReactiveObject{
    
    public WeatherViewModel(IEnumerable<Weather> items)
    {
        WeatherList = new ObservableCollection<Weather>(items);
    }
    
    public ObservableCollection<Weather> WeatherList { get; }
}