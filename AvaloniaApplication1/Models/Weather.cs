using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Styling;

namespace AvaloniaApplication1;

public class Weather{
    public Condition condition{ get; private set; }
    public Current current{ get; private set; }
    public Location location{ get; private set; }

    public Weather(){
    }

    public async Task getWeatherFor(string cityName){
        string apiCall = "https://api.weatherapi.com/v1/current.json?key=2e5e0a5608d248fe99d114032242502&q="+cityName;
        HttpClient client = new HttpClient();
        string responseBody="" ;
        try{
            
            responseBody = await client.GetStringAsync(apiCall);
            
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