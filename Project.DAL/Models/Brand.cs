using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Models
{
    public class Brand
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Instock { get; set; }        
    }
}
