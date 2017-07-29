using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public static class Engine
    {
        public static Account CreateAccount(string emailAddress, string password, AccountTypes typeofAccount)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                TypeOfAccount = typeofAccount,
                Password = password
            };
            return account;
        }
    }
}
