using System;
using System.Threading.Tasks;

namespace BlazorServerSide.Core.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);        
    }
}
