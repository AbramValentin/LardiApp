using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using LardiApp.DependencyServices;
using LardiApp.Droid.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(OrderNotification_Android))]

namespace LardiApp.Droid.DependencyServices
{

    public class OrderNotification_Android : IOrderNotification
    {
        public void NotifyUser(string title, string content)
        {

            // Instantiate the builder and set notification elements:
            Notification.Builder builder = new Notification.Builder(Forms.Context)
                .SetContentTitle(title)
                .SetContentText(content)
                .SetDefaults(NotificationDefaults.All)
                .SetSmallIcon(Resource.Drawable.abc_ab_share_pack_mtrl_alpha);

            // Build the notification:
            Notification notification = builder.Build();

            // Get the notification manager:
            NotificationManager notificationManager = Forms.Context.GetSystemService(Context.NotificationService) as NotificationManager;

            // Publish the notification:
            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);
        }
    }
}