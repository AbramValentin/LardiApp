using LardiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LardiApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParametersPage : ContentPage
    {
        public ParametersPage()
        {
            InitializeComponent();
        }

        private async void btnSubmitOrderParameters_Clicked(object sender, EventArgs e)
        {
            // TODO : read parameters from controls, and set to OrderRequest
            OrderParameters orderParameters = new OrderParameters
                (
                    areaIdFrom:edtAreaIdFrom.Text,
                    areaIdTo:edtAreaIdTo.Text,
                    massTonMin:edtMassTonMin.Text,
                    massTonMax:edtMassTonMax.Text,
                    volumeMin:edtVolumeMin.Text,
                    volumeMax:edtVolumeMax.Text
                );
            OrderRequest.Instance.SetRequestParemeters(orderParameters);

            ApplicationTimer.Instance.SetInterval(Convert.ToInt32(edtTimerSeconds.Text));

            await Navigation.PushAsync(new MainPage());
        }
    }
}