using Microsoft.AspNetCore.Mvc;
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
    public class UsersController : ControllerBase
    {
        public IUserService<UserDetail> userService;
        public UsersController(IUserService<UserDetail> service)
        {
            userService = service;
        }
        [HttpPost]
        public void AddUser([FromBody] UserDetail ud)
        {
            bool status = userService.AddUser(ud);
            //return status;
        }


        //Login
        [HttpGet("{email}/{password}")]
        //[Route("api/[controller]/Login")]
        public UserDetail GetUser(string email, string password)
        {
            //UserDetail user = userService.GetUser(l);
            UserDetail user = userService.GetUser(email, password);
            return user;
            //if(user != null)
            //{
            //    return true;
            //}
            //return false;
        }

        [HttpPut]
        public int EditUser(UserDetail ud)
        {
            return userService.EditUser(ud);
        }
    }
}
