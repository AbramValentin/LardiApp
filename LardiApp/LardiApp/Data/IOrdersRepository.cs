
using LardiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LardiApp.Data
{
    interface IOrdersRepository
    {
        void AddOrders(IEnumerable<OrderInfo> orders);
        IEnumerable<OrderInfo> GetAllOrders();
        IEnumerable<OrderInfo> GetLatestOrders();
    }
}
