using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoClaseXamarin.Models
{
    public class ResponseModel
    {
        public int total { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }

        public ResponseModel()
        {
        }

        public ResponseModel(int total, int page, int limit, int offset)
        {
            this.total = total;
            this.page = page;
            this.limit = limit;
            this.offset = offset;
        }
    }
}
