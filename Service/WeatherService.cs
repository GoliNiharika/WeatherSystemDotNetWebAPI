using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherManagementSystem.WeatherModel;

namespace WeatherManagementSystem.Service
{
    public class WeatherService : IWeatherService<WeatherDetail>
    {
        public bool AddWeather(WeatherDetail wd)
        {
            bool status = false;
            try
            {
                using (var weatherDBContext = new WeatherDBContext())
                {
                    weatherDBContext.WeatherDetails.Add(wd);
                    weatherDBContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                status = false;
            }
            return status;
        }

        public int DeleteWeather(WeatherDetail wd)
        {
            int status = 0;
            try
            {
                using (var weatherDBContext = new WeatherDBContext())
                {
                    //WeatherDetail detail = weatherDBContext.WeatherDetails.Find(wid);
                    weatherDBContext.WeatherDetails.Remove(wd);
                    weatherDBContext.SaveChanges();
                    status = 1;
                }
            }
            catch (Exception e)
            {
                status = 0;
            }
            return status;
        }

        public int EditWeather(WeatherDetail newWeather)
        {
            int status = 0;
            try
            {
                using (var weatherDBContext = new WeatherDBContext())
                {
                    WeatherDetail oldWeather = weatherDBContext.WeatherDetails.Find(newWeather.Wid);
                    oldWeather.Wid = oldWeather.Wid;
                    oldWeather.City = newWeather.City;
                    oldWeather.Temperature = newWeather.Temperature;
                    oldWeather.Visibility = newWeather.Visibility;
                    oldWeather.Humidity = newWeather.Humidity;
                    weatherDBContext.SaveChanges();
                    status = 1;
                }
            }
            catch (Exception e)
            {
                status = 0;
            }
            return status;
        }

        public List<WeatherDetail> GetWeatherAllWeathers()
        {
            List<WeatherDetail> weatherList = new List<WeatherDetail>();
            WeatherDBContext weatherDBContext = new WeatherDBContext();
            foreach (var row in weatherDBContext.WeatherDetails)
                weatherList.Add(row);
            //weatherList = WeatherModel.WeatherDetail.ToList();
            return weatherList;
        }

        public List<WeatherDetail> GetWeatherByCity(string city)
        {
            List<WeatherDetail> wd = new List<WeatherDetail>();
            try
            {
                using (var weatherDBContext = new WeatherDBContext())
                {
                    wd = weatherDBContext.WeatherDetails.Where(x => x.City == city).ToList();
                    //wd= weatherDBContext.WeatherDetails.Find(city);
                }
            }
            catch(Exception e)
            {
                wd = null;
            }
            return wd;
        }
    }
}
