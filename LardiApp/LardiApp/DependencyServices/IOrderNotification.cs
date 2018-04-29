using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LardiApp.DependencyServices
{
    public interface IOrderNotification
    {
        void NotifyUser(string title, string content);
    }
}
