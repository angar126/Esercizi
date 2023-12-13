using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService:IUserService
    {

        readonly IRepository<User, User, User> _Repository;

        //static UserService instance;
        public UserService(IRepository<User, User, User> configuration)
        {
            _Repository = configuration;
        }
        //public static UserService GetInstance(String path)
        //{
        //    if (instance is null)
        //    {
        //        instance = new UserService(path);
        //    }
        //    return instance;
        //}
        public List<User> GetAll()
        {

            return _Repository.GetAll().ToList();

        }
        public User Get(int Id)
        {
            List<User> items = GetAll();
            return items.FirstOrDefault(s => s.Id == Id);
        }
        public User GetByName(string Name)
        {
            List<User> items = GetAll();
            return items.FirstOrDefault(s => s.Name == Name);
        }
        public Product Update() { return null; }
        public Product Delete(int Id) { return null; }
    }
}
