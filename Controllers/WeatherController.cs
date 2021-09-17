﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherManagementSystem.WeatherModel;
using WeatherManagementSystem.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class WeatherController : ControllerBase
    {
        public IWeatherService<WeatherDetail> weatherService;

        public WeatherController(IWeatherService<WeatherDetail> service)
        {
            weatherService = service;
        }

        [HttpPost]
        public void AddWeather([FromBody] WeatherDetail wd)
        {
            weatherService.AddWeather(wd);
        }
        [HttpPost]
        [Route("DeleteCity")]
        public int DeleteWeather(WeatherDetail wd)
        {
            return weatherService.DeleteWeather(wd);
        }
        [HttpPost]
        [Route("EditCity")]
        public int EditWeather(WeatherDetail wd)
        {
            return weatherService.EditWeather(wd);
        }

        [HttpPost]
        [Route("ListByCity")]
        public List<WeatherDetail> GetWeatherByCity(string city)
        {
            List<WeatherDetail> weatherList = new List<WeatherDetail>();
            weatherList = weatherService.GetWeatherByCity(city);
            return weatherList;
           
        }

        [HttpGet]
        public List<WeatherDetail> GetWeatherAllWeathers()
        {
            List<WeatherDetail> weatherList = new List<WeatherDetail>();
            weatherList = weatherService.GetWeatherAllWeathers();
            return weatherList;
        }
    }
}
