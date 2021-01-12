using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoClaseXamarin.Models
{
    public class DoctorModel
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Phone { get; set; }

        public DoctorModel()
        {
        }

        public DoctorModel(string id, string title, string firstName, string lastName, string gender, string email, string picture, DateTime dateOfBirth, DateTime registerDate, string phone)
        {
            Id = id;
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            Picture = picture;
            DateOfBirth = dateOfBirth;
            RegisterDate = registerDate;
            Phone = phone;
        }
    }
}
