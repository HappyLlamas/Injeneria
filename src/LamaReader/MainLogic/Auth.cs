
using LamaReader.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LamaReader.MainLogic
{
    public class Auth: IAuth
    {
        private readonly IAuthService _authService;
        public Auth(IAuthService authService)
        {
            _authService = authService;
        }

        public User1? CurrentAccount { get => _authService.CurrentAccount; set => _authService.CurrentAccount=value; }

        public bool IsLoggedIn()
        {
            return _authService.IsLoggedIn();
        }

        public User1 Login(string email, string password)
        {
            return _authService.Login(email, password);
        }

        public void Registration(string username, string email, string password)
        {
            _authService.Registration(username, email, password);
        }
    }
}
