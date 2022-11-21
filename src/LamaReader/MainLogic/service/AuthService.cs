using LamaReader.Data;
using LamaReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LamaReader.MainLogic
{
    public class AuthService : IAuthService
    {
        public User1? CurrentAccount { get; set; }
        public readonly LlamaReaderDbContext _dbContext;

        public AuthService(LlamaReaderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private int GetNextId()
        {
            return _dbContext.Users.Count() == 0 ? 1 : _dbContext.Users.Max(userLast => userLast.Id) + 1;
        }

        public bool IsLoggedIn() => CurrentAccount is null ? false : true;


        public void Registration(string username, string email, string password)
        {
            CreatePasswordHash(password, out string passwordHash);
            var a = _dbContext.Books.Local.ToList();
            var currentUser = new User1(GetNextId(), username, email, passwordHash);

            if (_dbContext.Users.Any(user => user.Email == currentUser.Email))
                throw new Exception("User exist");

            _dbContext.Users.Add(currentUser);
            _dbContext.SaveChanges();

        }

        public User1 Login(string email, string password)
        {
            CreatePasswordHash(password, out string passwordHash);
            var a = _dbContext.Books.Local.ToList();
            CurrentAccount = _dbContext.Users.Where(storeUser=>storeUser.Email == email && storeUser.Passwordhash == passwordHash).FirstOrDefault();

            if (CurrentAccount is null)
                throw new Exception("User doesn't exist");

            return CurrentAccount;
        }

        public void CreatePasswordHash(string password, out string passwordHash)
        {
            using(var hmac = new HMACSHA512())
            {
                var bytesPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                string newPasswordHash = String.Empty;
                foreach(var bytePasswordHash in bytesPasswordHash)
                {
                    newPasswordHash += bytePasswordHash.ToString();
                }
                passwordHash = newPasswordHash;
            }
        }
    }

}
