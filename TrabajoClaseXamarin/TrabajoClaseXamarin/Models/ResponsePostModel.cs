using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TrabajoClaseXamarin.Models
{
    public class ResponsePostModel:ResponseModel
    {

        public ObservableCollection<PostModel> data { get; set; }

        public ResponsePostModel()
        {
        }

        public ResponsePostModel(ObservableCollection<PostModel> data)
        {
            this.data = data;
        }
    }
}
