using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService
    {

        readonly Repository<User, User, User> _Repository;

        static UserService instance;
        UserService(String path)
        {
            _Repository = new Repository<User, User, User>(path);
        }
        public static UserService GetInstance(String path)
        {
            if (instance is null)
            {
                instance = new UserService(path);
            }
            return instance;
        }
        public List<User> GetAll()
        {

            return _Repository.GetAll().ToList();

        }
        public User Get(int Id)
        {
            List<User> items = GetAll();
            return items.FirstOrDefault(s => s.Id == Id);
        }
        public Product Update() { return null; }
        public Product Delete(int Id) { return null; }
    }
}
