﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoClaseXamarin.Models
{
    public class UserModel
    {

        public string Email { get; set; }
        public string Password { get; set; }

        public UserModel()
        {
        }
        public UserModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
