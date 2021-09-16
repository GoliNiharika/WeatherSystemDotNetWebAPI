using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherManagementSystem.WeatherModel;

namespace WeatherManagementSystem.Service
{
    public interface IUserService<UserDetail>
    {
        public bool AddUser(UserDetail ud);
        public UserDetail GetUser(string email, string password);
        public int EditUser(UserDetail ud);

    }
}
