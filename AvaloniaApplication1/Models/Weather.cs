using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Styling;

namespace WeatherApp;

public class Weather{
    /**Fields*/
    
    /**Constructors*/
    public Weather(string city){
        getWeatherFor(city);
        
        WeatherIcon = new Bitmap(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        .Split("\\bin\\Debug\\")[0]+"/Assets/113.png");
        
    }
    
    /**Properties*/
    public Condition condition{ get; private set; }
    public Current current{ get; private set; }
    public Location location{ get; private set; }
    public Avalonia.Media.Imaging.Bitmap WeatherIcon {get; set;}
    
    /**Other*/
    public async Task getWeatherFor(string cityName){
        string apiCall = "https://api.weatherapi.com/v1/current.json?key=2e5e0a5608d248fe99d114032242502&q="+cityName;
        HttpClient client = new HttpClient();
        string responseBody="{\"location\":{\"name\":\"Warsaw\",\"region\":\"\",\"country\":\"Poland\",\"lat\":52.25,\"lon\":21.0,\"tz_id\":\"Europe/Warsaw\",\"localtime_epoch\":1709063824,\"localtime\":\"2024-02-27 20:57\"},\"current\":{\"last_updated_epoch\":1709063100,\"last_updated\":\"2024-02-27 20:45\",\"temp_c\":11.0,\"temp_f\":51.8,\"is_day\":0,\"condition\":{\"text\":\"Clear\",\"icon\":\"//cdn.weatherapi.com/weather/64x64/night/113.png\",\"code\":1000},\"wind_mph\":3.8,\"wind_kph\":6.1,\"wind_degree\":120,\"wind_dir\":\"ESE\",\"pressure_mb\":1014.0,\"pressure_in\":29.94,\"precip_mm\":0.0,\"precip_in\":0.0,\"humidity\":82,\"cloud\":0,\"feelslike_c\":10.4,\"feelslike_f\":50.8,\"vis_km\":10.0,\"vis_miles\":6.0,\"uv\":1.0,\"gust_mph\":8.6,\"gust_kph\":13.9}}" ;
        try{
            
            // string responseBody = await client.GetStringAsync(apiCall);
            
            string curr = responseBody.Split("current\":")[1];
            curr = curr.Substring(0, curr.Length - 1);
            string loc =  responseBody.Split("current\":")[0].Split("location\":")[1];
            loc = loc.Substring(0, loc.Length - 2);
            string con = responseBody.Split("condition\":")[1].Split(",\"wind_mph")[0];
            current = JsonSerializer.Deserialize<Current>(curr);
            location = JsonSerializer.Deserialize<Location>(loc);
            condition = JsonSerializer.Deserialize<Condition>(con);
            current.condition = condition;
            
        }
        catch (HttpRequestException e){
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
    }
    
    
}