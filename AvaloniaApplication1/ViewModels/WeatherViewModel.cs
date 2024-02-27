using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reactive;
using DynamicData.Binding;
using WeatherApp.Services;
using ReactiveUI;

namespace WeatherApp.ViewModels;

public class WeatherViewModel : ViewModelBase {

    /**Fields*/
    private string _newCityName = string.Empty;
    private Avalonia.Media.Imaging.Bitmap _weatherIcon = null;
    private string _weatherIconUrl = "//cdn.weatherapi.com/weather/64x64/day/116.png";
    
    /**Constructors*/
    public WeatherViewModel(IEnumerable<Weather> items){
        Weathers = new ObservableCollection<Weather>(items);
        DownloadImage(WeatherIconUrl);
        
        var isValidObservable = this.WhenAnyValue(
            x => x.NewCityName,
            x => !string.IsNullOrWhiteSpace(x));

        AddNewCityCommand = ReactiveCommand.Create((() => {
            Weathers[0].location.country = "Trolololo";
            
            Weather item = new Weather(NewCityName);
            item.location.name = NewCityName;
            Weathers.Add(item);
            NewCityName = string.Empty;
        }),isValidObservable);
        
    }
    
    
    /**Properties*/
    public ObservableCollection<Weather> Weathers { get; }
    
    public ReactiveCommand<Unit, Unit> AddNewCityCommand { get; }
    
    public string NewCityName
    {
        get => _newCityName;
        set => this.RaiseAndSetIfChanged(ref _newCityName, value);
    }
    
    
    public string WeatherIconUrl
    {
        get => _weatherIconUrl;
        set {
            this.RaiseAndSetIfChanged(ref _weatherIconUrl, value);
            DownloadImage(WeatherIconUrl);
        }
    }
    
    
    public Avalonia.Media.Imaging.Bitmap WeatherIcon
    {
        get => _weatherIcon;
        set => this.RaiseAndSetIfChanged(ref _weatherIcon, value);
    }
    
    /**Other*/
    public void DownloadImage(string url)
    {
        using (WebClient client = new WebClient())
        {
            client.DownloadDataAsync(new Uri(url));
            client.DownloadDataCompleted += DownloadComplete;
        }
    }

    private void DownloadComplete(object sender, DownloadDataCompletedEventArgs e)
    {
        try
        {
            byte[] bytes = e.Result;

            Stream stream = new MemoryStream(bytes);

            var image = new Avalonia.Media.Imaging.Bitmap(stream);
            WeatherIcon = image;
            Weathers[0].WeatherIcon = image;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            WeatherIcon = null; // Could not download...
        }
            
    }
}
