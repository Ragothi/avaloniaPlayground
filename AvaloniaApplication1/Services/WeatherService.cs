using System.Collections.Generic;

namespace WeatherApp.Services;

public class WeatherService{
    public IEnumerable<Weather> GetItems() => new[]
    {
        new Weather("Warsaw") { },
        new Weather("London") {  },
        new Weather("Paris") {  },
    };
    
}