using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LardiApp.CustomViewElements
{
    public class OrderCell : ViewCell
    {
        public OrderCell()
        {
            var shippingDate = new Label();
            shippingDate.SetBinding(Label.TextProperty, new Binding("ShippingDate"));
            shippingDate.HorizontalOptions = LayoutOptions.FillAndExpand;

            var carBodyType = new Label();
            carBodyType.SetBinding(Label.TextProperty, new Binding("CarBodyType"));
            carBodyType.HorizontalOptions = LayoutOptions.FillAndExpand;

            var header = new StackLayout();
            header.Orientation = StackOrientation.Horizontal;
            header.HorizontalOptions = LayoutOptions.FillAndExpand;
            header.Children.Add(shippingDate);
            header.Children.Add(carBodyType);


            var cityFrom = new Label();
            cityFrom.SetBinding(Label.TextProperty, new Binding("CityFrom"));
            cityFrom.HorizontalOptions = LayoutOptions.FillAndExpand;

            var cityTo = new Label();
            cityTo.SetBinding(Label.TextProperty, new Binding("CityTo"));
            cityTo.HorizontalOptions = LayoutOptions.FillAndExpand;


            var distance = new Label();
            distance.SetBinding(Label.TextProperty, new Binding("Distance"));
            distance.HorizontalOptions = LayoutOptions.FillAndExpand;

            var payment = new Label();
            payment.SetBinding(Label.TextProperty, new Binding("PaymentInfo"));
            payment.HorizontalOptions = LayoutOptions.FillAndExpand;

            var cargoDescription = new Label();
            cargoDescription.SetBinding(Label.TextProperty, new Binding("CargoInfo"));
            cargoDescription.HorizontalOptions = LayoutOptions.FillAndExpand;

            var itemStack = new StackLayout();

            itemStack.Children.Add(header);
            itemStack.Children.Add(cityFrom);
            itemStack.Children.Add(cityTo);
            itemStack.Children.Add(distance);
            itemStack.Children.Add(payment);
            itemStack.Children.Add(cargoDescription);

            var content = new ContentView();

            content.Content = itemStack;
            
            View = content;
        }
    }
}
