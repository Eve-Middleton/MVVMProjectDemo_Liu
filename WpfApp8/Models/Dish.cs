using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApp8.Models
{
    internal class Dish
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string MyProperty { get; set; }
        public double Score { get; set; } = 0;
        public string Comment { get; set; }
    }
}
