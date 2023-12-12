using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
        public string Host {  get; set; }
        public int Port { get; set; }

        //poi DTO
        public User(User user)
        {
            Id= user.Id;
            Name= user.Name;
            Email= user.Email;
            Password= user.Password;
            Type = user.Type;
            Host = user.Host;
            Port = user.Port;
        }
        public User() { }
    }
    
}
