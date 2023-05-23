using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    public class User : BaseEntity
    {
        public Role Role { get; set; }
        public int IdPerson { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public User(Role role, string username, string password)
        {
            Role = role;
            Username = username;
            Password = password;
        }
        public User()
        {
            
        }
    }
    public enum Role
    {
        Admin,
        Teacher,
        Student,
        ClassMaster
    }
}
