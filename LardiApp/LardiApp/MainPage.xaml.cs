using LardiApp.CustomViewElements;
using LardiApp.Data;
using LardiApp.DependencyServices;
using LardiApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LardiApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<OrderInfo> ordersCollection = new ObservableCollection<OrderInfo>();

        public MainPage()
        {
            InitializeComponent();
          
            lwOrdersList.ItemTemplate = new DataTemplate(typeof(OrderCell));
            lwOrdersList.ItemsSource = ordersCollection;
        }

        private async void switchStartSearch_Toggled(object sender, ToggledEventArgs e)
        {
            
            if (e.Value)
            {
                Device.StartTimer(ApplicationTimer.Instance.GetInterval(), () =>
                {
                    Task.Factory.StartNew(async () =>
                    {
                        await SendOrdersRequestAsync();
                    });
                    return true;
                });

                await SendOrdersRequestAsync();
            }
            else
            {
                Device.StartTimer(TimeSpan.FromSeconds(0), () => false);
            }
        }

        private async Task<bool> SendOrdersRequestAsync()
        {
            List<OrderInfo> orders = new List<OrderInfo>();
            try
            {
                orders = await OrderRequest.Instance.SendRequestAsync();
            }
            catch
            {
                await DisplayAlert("Error", "try to check internet connection", "Ok");
                return false;
            }

            OrdersLocalStorage.Instance.AddOrders(orders);

            foreach (var item in OrdersLocalStorage.Instance.GetLatestOrders())
            {
                ordersCollection.Insert(0, item);
            }

            int latestOrdersCount = OrdersLocalStorage.Instance.GetLatestOrders().Count();

            if (latestOrdersCount > 0)
            {
                DependencyService.Get<IOrderNotification>().NotifyUser("New orders", $"{latestOrdersCount} new orders !");
            }
            
            return true;
        }

        private void lwOrdersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                string orderUri = ((OrderInfo)lwOrdersList.SelectedItem).ContactInfoLink;
                try
                {
                    var uri = new Uri(orderUri);
                    Device.OpenUri(uri);
                }
                catch (Exception)
                {
                    DisplayAlert("Error", "Error", "Ok");
                }

                lwOrdersList.SelectedItem = null;
            }
            catch
            {

            }

        }

    }
}
