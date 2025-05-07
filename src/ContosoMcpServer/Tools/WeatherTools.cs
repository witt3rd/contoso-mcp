using System.ComponentModel;
using System.Globalization;
using System.Text.Json.Nodes;
using ModelContextProtocol.Server; // Added for McpServerToolType and McpServerTool

namespace ContosoMcpServer.Tools
{
    [McpServerToolType] // Added attribute
    public class WeatherTools
    {
        [McpServerTool] // Added attribute
        [Description("Gets the current weather for a specified location.")]
        public static async Task<string> GetCurrentWeatherAsync(
            [Description("The city and state, e.g., San Francisco, CA")] string location,
            [Description("The temperature unit (celsius or fahrenheit)")] string unit = "fahrenheit"
        )
        {
            // Simulate API call
            await Task.Delay(100);

            var temperature = Random.Shared.Next(-20, 35);
            if (unit == "fahrenheit")
            {
                temperature = (int)(temperature * 9 / 5.0) + 32;
            }

            var weatherData = new JsonObject
            {
                ["location"] = location,
                ["temperature"] = temperature,
                ["unit"] = unit,
                ["description"] = "Sunny",
            };

            return weatherData.ToJsonString();
        }

        [McpServerTool] // Added attribute
        [Description("Gets the weather forecast for a specified location.")]
        public static async Task<string> GetWeatherForecastAsync(
            [Description("The city and state, e.g., San Francisco, CA")] string location
        )
        {
            // Simulate API call
            await Task.Delay(100);

            var forecastData = new JsonArray();
            for (int i = 0; i < 5; i++)
            {
                forecastData.Add(
                    new JsonObject
                    {
                        ["date"] = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                        ["temperature"] = Random.Shared.Next(-10, 30),
                        ["description"] = "Partly cloudy",
                    }
                );
            }
            return forecastData.ToJsonString();
        }
    }
}
