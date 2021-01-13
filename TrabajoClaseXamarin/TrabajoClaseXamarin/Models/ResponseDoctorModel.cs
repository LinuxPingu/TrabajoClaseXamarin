using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TrabajoClaseXamarin.Models
{
   public class ResponseDoctorModel:ResponseModel
    {

        public ObservableCollection<PostModel> data { get; set; }

        public ResponseDoctorModel()
        {
        }

        public ResponseDoctorModel(ObservableCollection<PostModel> data)
        {
            this.data = data;
        }
    }
}
