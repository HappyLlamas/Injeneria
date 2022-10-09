using LlamaRider_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataImport.Models
{
    public class User
    {

        public int ID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public byte[]? Avatar { get; set; } = null;
        public DateTime UpdatedAt { get; set; }

        public User()
            : this(id: 0, email: "", username: "", password: "")
        {
            return;
        }

        public User(
            int id,
            string email,
            string username,
            string password,
            Role Role = 0)
        {
            this.ID = id;
            this.Email = email;
            this.Password = password;
            this.Username = username;
            this.Role = Role;
            this.Avatar = new byte[1];
            this.UpdatedAt = DateTime.Now;
            return;
        }

        public override string ToString()
        {
            string res = "";
            PropertyInfo[] propeties = this.GetType().GetProperties()!.ToArray();
            res += propeties[0].GetValue(obj: this)?.ToString();

            for (int i = 1; i < propeties.Count(); ++i)
            {
                res += (' ' + propeties[i].GetValue(obj: this)?.ToString());
            }

            return (res);
        }



    }
}
