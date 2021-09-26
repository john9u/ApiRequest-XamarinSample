using ApiRequestXamarin.Models;
using ApiRequestXamarin.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ApiRequestXamarin.ViewModels
{
    class LogInViewModel : INotifyPropertyChanged
    {
        public Credentials Credentials { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private AlertService _alertService;
        private LogInApiService _LogInService;

        public ICommand LogInCommand { get; set; }
        public LogInViewModel()
        {
            Credentials = new Credentials();
            LogInCommand = new Command(OnLogIn);
            _alertService = new AlertService();
            _LogInService = new LogInApiService();
        }
        private async void OnLogIn()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var response = await _LogInService.Authenticate(Credentials);
                if (response.Status == "success")
                {
                    await _alertService.Alert("Success!", $"Tu usuario fue autenticado satisfactoriamente!", "Ok");
                }
                else if (response.Status == "fail")
                {
                    await _alertService.Alert("Error", $"Usuario o Contraseña Incorrectos", "Ok");
                }
                else
                {
                    await _alertService.Alert("Error", $"Algo ocurrio: {response.ErrorMessage}", "Ok");
                }
            }
            else
            {
                await _alertService.Alert("Error", "Compruebe su conexion a Internet", "Ok");
            }
        }

    }
}
