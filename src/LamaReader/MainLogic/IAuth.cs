using LamaReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaReader.MainLogic
{
    public interface IAuth
    {
        User1 Login(string email, string password);
        User1? CurrentAccount { get; set; }
        bool IsLoggedIn();

        void Registration(string username, string email, string password);
    }
}
