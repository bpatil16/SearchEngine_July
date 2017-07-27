using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public enum AccountTypes
    {
        Jobseeker,
        Employer
    }

    public class Account
    {
        #region Variables

        private static int lastAccountNumber = 0;

        #endregion

        #region Properties

            public int AccountNumber { get; private set;}
            public string EmailAddress { get; set; }
            public string Password { get; set; }
            public AccountTypes TypeOfAccount { get; set; }


        #endregion

        #region Constructor

        public Account()
        {
            AccountNumber = ++lastAccountNumber;
        }

        #endregion
    }
}
