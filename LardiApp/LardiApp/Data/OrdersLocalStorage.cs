using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LardiApp.Models;
using System.Collections.ObjectModel;

namespace LardiApp.Data
{
    class OrdersLocalStorage : IOrdersRepository
    {
        private List<OrderInfo> ordersCollection;
        private List<OrderInfo> latestOrders;

        private OrdersLocalStorage()
        {
            ordersCollection = new List<OrderInfo>();
            latestOrders = new List<OrderInfo>();
        }

        private static OrdersLocalStorage localStorage;
        public static OrdersLocalStorage Instance
        {
            get
            {
                if (localStorage == null)
                {
                    localStorage = new OrdersLocalStorage();
                }
                return localStorage;
            }
        }

        public void AddOrders(IEnumerable<OrderInfo> orders)
        {
            var uniqueOrders = orders.Where(
                no => ordersCollection.Select(
                    ol => ol.OrderIdFromSite)
                    .Contains(no.OrderIdFromSite) == false).ToList();

            foreach (var item in uniqueOrders)
            {
                ordersCollection.Add(item);
            }

            latestOrders.Clear();
            latestOrders.AddRange(uniqueOrders);
        }

        public IEnumerable<OrderInfo> GetAllOrders()
        {
            return ordersCollection;
        }

        public IEnumerable<OrderInfo> GetLatestOrders()
        {
            return latestOrders;
        }
    }
}
