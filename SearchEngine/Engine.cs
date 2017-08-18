using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    public static class Engine
    {
        private static Model1 db = new Model1(); 
        public static Account CreateAccount(string emailAddress, string password, AccountTypes typeofAccount)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                TypeOfAccount = typeofAccount,
                Password = password
            };
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public static Job PostJob(string jobTitle, string jobDescription, string company, string location, int accountNumber)
        {
            var job = new Job
            {
                JobTitle = jobTitle,
                Description = jobDescription,
                Company = company,
                Location = location,
                AccountNumber = accountNumber
            };
            db.Jobs.Add(job);
            db.SaveChanges();
            return job;
        }

        public static Resume UploadResume(string userName, string resumeDescription, string education, string skills, int accountNumber)
        {
            var resume = new Resume
            {
                ResumeName = userName,
                Description = resumeDescription,
                Education = education,
                Skills = skills,
                AccountNumber = accountNumber
        };
            db.Resumes.Add(resume);
            db.SaveChanges();
            return resume;
        }

        public static Account[] GetAllAccountsByEmail(string email)
        {

            return db.Accounts.Where(a => a.EmailAddress == email).ToArray();

        }

        public static Account[] GetAllAccounts()
        {

            return db.Accounts.Where(a => a.AccountNumber != 0).ToArray();

        }

    }
}
