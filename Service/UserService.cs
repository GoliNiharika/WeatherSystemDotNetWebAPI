using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherManagementSystem.WeatherModel;

namespace WeatherManagementSystem.Service
{
    public class UserService: IUserService<UserDetail>
    {
        //WeatherDBContext weatherDBContext = new WeatherDBContext();

        public bool AddUser(UserDetail ud)
        {
            bool status = false;
            try
            {
                using (var weatherDBContext = new WeatherDBContext())
                {
                    weatherDBContext.UserDetails.Add(ud);
                    weatherDBContext.SaveChanges();
                    status = true;
                }
            }
            catch(Exception e)
            {
                status = false;
            }
            return status;
        }

        public int EditUser(UserDetail newUser)
        {
            int status = 0;
            try
            {
                using (var weatherDBContext = new WeatherDBContext())
                {
                    UserDetail oldUser = weatherDBContext.UserDetails.Find(newUser.Uid);
                    oldUser.Uid = oldUser.Uid;
                    oldUser.Email= newUser.Email;
                    oldUser.Password = newUser.Password;
                    oldUser.Name = newUser.Name;
                    weatherDBContext.SaveChanges();
                    status = 1;
                }
            }
            catch(Exception e)
            {
                status = 0;
            }
            return status;
        }

        //public UserDetail GetUser(Login l)
        public UserDetail GetUser(string email, string password)
        {
            UserDetail ud = null;
            try
            {
                using (var db = new WeatherDBContext())
                {
                   // var user = db.UserDetails.Where(x => x.Email == l.Email && x.Password == l.Password).ToList();
                    var user = db.UserDetails.Where(x => x.Email == email && x.Password == password).ToList();
                    ud = user[0];
                }
            }
            catch (Exception e)
            {
                ud = null;
            }
            return ud;
        }
    }
}
