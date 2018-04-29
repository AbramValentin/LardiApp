using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LardiApp.Models
{
    class OrderRequest 
    {
        private static OrderRequest orderRequest;

        public OrderParameters OrderParameters { get; private set; }

        public void SetRequestParemeters(OrderParameters orderParameters)
        {
            OrderParameters = orderParameters;
        }

        public static OrderRequest Instance
        {
            get
            {
                if (orderRequest == null)
                {
                    orderRequest = new OrderRequest();
                }
                return orderRequest;
            }
        }

        public async Task<List<OrderInfo>> SendRequestAsync()
        {
            var json = JsonConvert.SerializeObject(OrderParameters);
            var login = "valentin.abram@ukr.net";
            var password = "password";
            var httpClient = new HttpClient();

            string requestResult = "";

            try
            {
                requestResult = await httpClient
                    .GetStringAsync($"http://lardiapiservice.azurewebsites.net/api/orders?orderParameters={json}&userLogin={login}&userPassword={password}&ordersToReturn=25");
                    //.GetStringAsync($"http://lardiapiservice.azurewebsites.net/api/orders?orderParameters={"AreaIdFrom":"7","AreaIdTo":"0","MassTonMin":"0","MassTonMax":"4","VolumeMin":"","VolumeMax":"21"}//&userLogin="valentin"&userPassword=password&ordersToReturn=25 ");
            }
            catch
            {
                throw new Exception();
            }


            var result = JsonConvert.DeserializeObject<List<OrderInfo>>(requestResult);

            return result;
            //return GetFakeOrders();
        }


        public IEnumerable<OrderInfo> GetFakeOrders()
        {
            List<OrderInfo> fakeList = new List<OrderInfo>();
            var fakeOrder = new OrderInfo
                (
                orderIdFromSite : "Fake-fakeOrderId",
                shippingDate : "Fake-shiping date",
                carBodyType : "Fake-carBodyType",
                cityFrom : "Fake-CityFrom",
                cityTo : "Fake-CityTo",
                distance : "Fake-Distance",
                cargoInfo : "Fake-cargoInfo",
                paymentInfo : "Fake-paymentInfo",
                contactInfoLink : "Fake-contactInfoLink"
                );

            for (int i = 0; i < 10; i++)
            {
                fakeList.Add(fakeOrder);
            }

            return fakeList;
        }
    }
}
