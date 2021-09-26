using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiRequestXamarin.Services
{
    class AlertService : IAlertService
    {
        public Task Alert(string title, string description, string ok)
        {
            return App.Current.MainPage.DisplayAlert(title, description, ok);
        }
        
    }
}
