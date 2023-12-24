using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace bug_Tracker.data.models
{
    public class User
    {
        public String Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(string Name , string Email , string Password) {
            Guid guid = Guid.NewGuid();

            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.Id = guid.ToString();

        }

    }
}
