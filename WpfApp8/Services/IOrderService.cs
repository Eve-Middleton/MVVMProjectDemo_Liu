using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApp8.Services
{
    internal interface IOrderService
    {
        void PlaceOrder(List<string> dishes);
    }
}
