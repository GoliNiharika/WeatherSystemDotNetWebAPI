using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherManagementSystem.Service
{
    public interface IWeatherService<WeatherDetail>
    {
        public bool AddWeather(WeatherDetail wd);
        public List<WeatherDetail> GetWeatherByCity(string city);
        public List<WeatherDetail> GetWeatherAllWeathers();
        public int EditWeather(WeatherDetail wd);
        public int DeleteWeather(int wid);
    }
}
