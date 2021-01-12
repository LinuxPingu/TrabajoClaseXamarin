using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoClaseXamarin.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }


        public UserModel()
        {
        }

        public UserModel(string name, string lastName, string email, string password, string phone)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Phone = phone;
        }
    }
}
