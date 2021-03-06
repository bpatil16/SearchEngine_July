﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

            [Key, Column(Order = 0)]
            public int AccountNumber { get; private set;}
            [Required]
            [StringLength(50, ErrorMessage = "Email address should be 50 character or less")]
            [Index ("TitleIndex", IsUnique = true)]
            [Key, Column(Order = 1)]
            public string EmailAddress { get; set; }

            public string Password { get; set; }
            public AccountTypes TypeOfAccount { get; set; }

            public string JobOrResumeDescription { get; private set; }

            public virtual ICollection<Resume> Resumes { get; set; }

            public virtual ICollection<Job> Jobs { get; set; }



        #endregion

        #region Constructor

        public Account()
        {
            AccountNumber = ++lastAccountNumber;
        }

        #endregion

        #region Methods

        public void CreateResumeAccountType()
        {
            TypeOfAccount = AccountTypes.Jobseeker;
           // JobOrResumeDescription = description;
        }

        public void CreateJobAccountType()
        {
           // JobOrResumeDescription = description;
            TypeOfAccount = AccountTypes.Employer;
        }

        #endregion

    }
}
