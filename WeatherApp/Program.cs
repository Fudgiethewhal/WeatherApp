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
        var client = new HttpClient();
        
        var apiKey = "973db427debb88e41756d8f9de4f4487"; 
        var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip=97527,us&units=imperial&appid={apiKey}";

        var response = client.GetStringAsync(weatherURL).Result;
        Console.WriteLine(response);

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
        
        // //{
        //     "coord": {
        //         "lon": -123.3538,
        //         "lat": 42.3989
        //     },
        //     "weather": [
        //     {
        //         "id": 804,
        //         "main": "Clouds",
        //         "description": "overcast clouds",
        //         "icon": "04n"
        //     }
        //     ],
        //     "base": "stations",
        //     "main": {
        //         "temp": 44.62,
        //         "feels_like": 44.62,
        //         "temp_min": 44.62,
        //         "temp_max": 48.31,
        //         "pressure": 1021,
        //         "humidity": 84,
        //         "sea_level": 1021,
        //         "grnd_level": 957
        //     },
        //     "visibility": 10000,
        //     "wind": {
        //         "speed": 0,
        //         "deg": 0
        //     },
        //     "clouds": {
        //         "all": 100
        //     },
        //     "dt": 1744091366,
        //     "sys": {
        //         "type": 2,
        //         "id": 2002982,
        //         "country": "US",
        //         "sunrise": 1744033488,
        //         "sunset": 1744080337
        //     },
        //     "timezone": -25200,
        //     "id": 0,
        //     "name": "Grants Pass",
        //     "cod": 200
        // }

    }
}