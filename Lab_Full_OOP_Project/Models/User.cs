using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Full_OOP_Project.Models
{
    public abstract class User
    {
        public int Id { get; protected set; }
        public string Username { get; protected set; }
        public string Email { get; protected set; }

        public User(int id, string username,string email)
        {
            Id = id;
            Username = username;
            Email = email;
        }

        public abstract void DisplayInfo();

    }
}
