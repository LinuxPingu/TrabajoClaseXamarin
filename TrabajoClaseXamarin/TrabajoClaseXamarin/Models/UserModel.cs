using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoClaseXamarin.Models
{
    public class UserModel : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }


        public UserModel()
        {
        }

        public UserModel(int id, string name, string lastName, string email, string password, string phone)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Phone = phone;
        }
    }





}
