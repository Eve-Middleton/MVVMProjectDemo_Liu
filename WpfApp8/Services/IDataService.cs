using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApp8.Models;

namespace WpfApp8.Services
{
    internal interface IDataService
    {
        List<Dish> GetAllDishes();
    }
}
