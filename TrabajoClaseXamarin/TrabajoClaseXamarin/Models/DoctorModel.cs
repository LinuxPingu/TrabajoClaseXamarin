using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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



        public async static Task GetAllDoctors()
        {
            using (HttpClient client = new HttpClient())
            {

                var uri = new Uri("https://dummyapi.io/data/api/user");

                client.DefaultRequestHeaders.Add("app-id", "5fad867bca750f4fc7508473");

                HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);

                string ans = await response.Content.ReadAsStringAsync();

                ResponseDoctorModel responseObject = JsonConvert.DeserializeObject<ResponseDoctorModel>(ans);

               
            }
        }

        public async static Task<DoctorModel> GetDoctorDetail(string doctorId)
        {
            using (HttpClient client = new HttpClient())
            {

                var uri = new Uri("https://dummyapi.io/data/api/user/" + doctorId);

                client.DefaultRequestHeaders.Add("app-id", "5fad867bca750f4fc7508473");

                HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);

                string ans = await response.Content.ReadAsStringAsync();

                DoctorModel responseObject = JsonConvert.DeserializeObject<DoctorModel>(ans);

                return responseObject;
            }
        }


    }
}
