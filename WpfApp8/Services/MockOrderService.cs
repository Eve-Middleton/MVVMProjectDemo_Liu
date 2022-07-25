using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WpfApp8.Services
{
    internal class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<string> dishes)
        {
            File.WriteAllLines(@"C:\order.txt",dishes.ToArray());
        }
    }
}
