using Cinema.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Models
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Volume { get; set; }
        public int Quantity { get; set; }
        public float Weight { get; set; }
    }
}
