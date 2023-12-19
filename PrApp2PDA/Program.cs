//#1.8
//Write a console app, that accepsts name of the city as input and outputs wether for today. User should have ability to set city, without set city - wether should be from default city
//

using System.Net;
using System.Text.Json;

namespace PrApp1PDA;

public class Clouds
{
    public int all { get; set; }
}

public class Coord
{
    public double lon { get; set; }
    public double lat { get; set; }
}

public class Main
{
    public double temp { get; set; }
    public double feels_like { get; set; }
    public double temp_min { get; set; }
    public double temp_max { get; set; }
    public int pressure { get; set; }
    public int humidity { get; set; }
}

public class WetherReport
{
    public Coord coord { get; set; }
    public Weather[] weather { get; set; }
    public string Base { get; set; }
    public Main main { get; set; }
    public int visibility { get; set; }
    public Wind wind { get; set; }
    public Clouds clouds { get; set; }
    public int dt { get; set; }
    public Sys sys { get; set; }
    public int timezone { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public int cod { get; set; }
}

public class Sys
{
    public int type { get; set; }
    public int id { get; set; }
    public string country { get; set; }
    public int sunrise { get; set; }
    public int sunset { get; set; }
}

public class Weather
{
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
}

public class Wind
{
    public double speed { get; set; }
    public int deg { get; set; }
}
static class Program
{
    public static string GetJsonStringFromUrl(string url)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        Stream stream = response.GetResponseStream();
        StreamReader reader = new(stream);
        string jsonString = reader.ReadToEnd();

        response.Close();
        return jsonString;
    }

    static void Main()
    {
        string city = File.ReadAllText("def.txt");
        Console.WriteLine($"Введите город/Нажмите Enter чтобы выбрать город по умолчанию ({city}) или впишите edit чтобы редактировать город по умолчанию");
        string inputCity = Console.ReadLine();
        if (inputCity != "") 
        {
            if (inputCity == "edit") 
            {
                File.WriteAllText("def.txt", Console.ReadLine());
                city = File.ReadAllText("def.txt");
            } 
        }
        string key = "fbbba203f51172e21e58ec311cc4c9a3";
        string jsonString = GetJsonStringFromUrl($"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={key}");
        jsonString = '[' + jsonString + ']'; //figuring this out took severel hours of my life ;_;
        var report = JsonSerializer.Deserialize<List<WetherReport>>(jsonString);
        foreach(var wetherReport in report)
        {
            Console.WriteLine($"Прогноз погоды для {wetherReport.name}\n" +
                  $"Температура за окном {wetherReport.main.temp}, по ощущениям {wetherReport.main.feels_like}\n" +
                  $"Небо: {wetherReport.weather[0].description}\n" +
                  $"Влажность воздуха {wetherReport.main.humidity}%\n" +
                  $"Атмосферное давление {wetherReport.main.pressure}\n" +
                  $"Скорость ветра {wetherReport.wind.speed} метров в секунду, направление: {wetherReport.wind.deg} градусов\n" +
                  $"Код ошибки: {wetherReport.cod}\n");
        }
    }
}