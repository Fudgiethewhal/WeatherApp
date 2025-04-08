using System;
using System.Globalization;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp;

class Program
{
    static void Main(string[] args)
    {
        string apiKey = "973db427debb88e41756d8f9de4f4487"; 
        string weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip=97527,us&units=imperial&appid={apiKey}";

        using var client = new HttpClient();
        var response = client.GetStringAsync(weatherURL).Result;

        var weather = JsonDocument.Parse(response);
        var temp = weather.RootElement.GetProperty("main").GetProperty("temp").GetDouble();
        var description = weather.RootElement.GetProperty("weather")[0].GetProperty("description").GetString();

        Console.WriteLine($"Grants Pass, OR Weather"); 
        Console.WriteLine($"Temperature: {temp}°F");
        Console.WriteLine($"Condition: {description}");

        if (temp < 50)
            Console.ForegroundColor = ConsoleColor.Cyan;
        else if (temp < 80) 
            Console.ForegroundColor = ConsoleColor.Yellow;
        else if (temp > 80)
            Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine($"It's currently {temp}°F in Grants Pass.");
        Console.ResetColor();

    }
}