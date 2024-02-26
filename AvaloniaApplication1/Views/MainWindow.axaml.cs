using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Controls;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window{
    private static string responseBody;
    private static Current conditionWarsaw;
    public MainWindow(){
        InitializeComponent();

        // List<User> users = deserializeJson("E:\\c#\\AvaloniaApplication1\\AvaloniaApplication1\\Assets\\list.json");
        // printUsers(users);

        String apiCall = "https://api.weatherapi.com/v1/current.json?key=2e5e0a5608d248fe99d114032242502&q=Warsaw";
        Main(apiCall);

       

    }
    
    static readonly HttpClient client = new HttpClient();

    static async Task Main(String apiCall)
    {
        // Call asynchronous network methods in a try/catch block to handle exceptions.
        try{
            using HttpResponseMessage response = await client.GetAsync(apiCall);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);
        }
        catch (HttpRequestException e){
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        finally{
            // Console.WriteLine(responseBody);
            conditionWarsaw = JsonSerializer.Deserialize<Current>(responseBody);
            Console.WriteLine(conditionWarsaw.ToString());
        }
    }
    
    public static void printUsers(List<User> list){
        foreach (User user in list){
            Console.WriteLine(user.id+": "+user.username+"\tis adult?: " + user.adult);
        }
    }
    
    public static List<User> deserializeJson(string fileName){
        try{
            string jsonString = File.ReadAllText(fileName);
            jsonString = jsonString.Substring(2, jsonString.Length - 4);
            List<User> l = new List<User>();

               
            foreach (string s in jsonString.Split("},{")){
                User? user2 = JsonSerializer.Deserialize<User>("{"+s+"}");
                l.Add(user2);
            }
            return l;
        }
        catch (Exception e){
            Console.WriteLine(e);
            throw;
        }
    }
}