namespace WeatherApp;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Condition
{
    public string text { get; set; }
    public string icon { get; set; }
    public int code { get; set; }

   
}