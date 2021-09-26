using ApiRequestXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiRequestXamarin.Services
{
    interface ILogInApiService
    {
        Task<LogInApiResponse> Authenticate(Credentials userCredentials);
    }
}
