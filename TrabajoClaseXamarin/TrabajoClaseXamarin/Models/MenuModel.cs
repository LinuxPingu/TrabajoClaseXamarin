using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoClaseXamarin.Models
{
    public class MenuModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public MenuModel()
        {
        }

        public MenuModel(int id, string name, string icon)
        {
            Id = id;
            Name = name;
            Icon = icon;
        }
    }
}
