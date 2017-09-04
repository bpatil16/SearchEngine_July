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

        public static Job PostJob(string jobTitle, string jobDescription, string company, string location, int accountNumber, string employerEmail)
        {
            var account = GetAccount(accountNumber, employerEmail);
            if (account.TypeOfAccount == 0)
            {
                
                return null;
            }
            
                account.CreateJobAccountType();
                db.Entry(account).CurrentValues.SetValues(account);
                db.SaveChanges();
                var job = new Job
                {
                    JobTitle = jobTitle,
                    Description = jobDescription,
                    Company = company,
                    Location = location,
                    AccountNumber = accountNumber,
                    EmployerEmail = employerEmail
                };
                db.Jobs.Add(job);
                db.SaveChanges();
                return job;
            
            
        }

        public static Resume UploadResume(string userName, string emailAddress, string resumeDescription, string education, string skills, int accountNumber)
        {
            var account = GetAccount(accountNumber, emailAddress);
            account.CreateResumeAccountType();
            db.Entry(account).CurrentValues.SetValues(account);
            db.SaveChanges();
            var resume = new Resume
            {
                ResumeName = userName,
                Description = resumeDescription,
                Education = education,
                Skills = skills,
                AccountNumber = accountNumber,
                EmailAddress= emailAddress

            };
            db.Resumes.Add(resume);
            db.SaveChanges();
            return resume;
        }

        public static Application CreateApplication(string emailAddress, int jobNumber)
        {
            var account1 = GetAccountByEmail(emailAddress);
            var resume1 = GetResumeByEmail(emailAddress);
            var application = new Application
            {
                AccountDetails = account1,
                ResumeDetails = resume1,
                JobNumber = jobNumber

            };
            db.Applications.Add(application);
            db.SaveChanges();
            return application;
        }


        public static Account[] GetAllAccountsByEmail(string email)
        {

            return db.Accounts.Where(a => a.EmailAddress == email).ToArray();

        }

        public static Resume GetResumeByEmail(string email)
        {

            var resume = db.Resumes.Where(a => a.EmailAddress == email).FirstOrDefault();
            if (resume == null)
            {
                throw new ArgumentException("Resume is not present");
            }

            return resume;

        }

        public static Account GetAccountByEmail(string email)
        {

            var account = db.Accounts.Where(a => a.EmailAddress == email).FirstOrDefault();
            if (account == null)
            {
                throw new ArgumentException("Account with that email is not present");
            }

            return account;

        }

        public static Job GetJobByEmail(string email)
        {

            var job = db.Jobs.Where(a => a.EmployerEmail == email).FirstOrDefault();
            if (job == null)
            {
                throw new ArgumentException("Account with that email is not present");
            }

            return job;

        }

        public static Account[] GetAllAccounts()
        {

            return db.Accounts.Where(a => a.AccountNumber != 0).ToArray();

        }

        public static Job[] GetAllJobs()
        {

            return db.Jobs.Where(a => a.JobNumber != 0).ToArray();

        }

        public static Account GetAccount(int accountNumber, string emailAddress)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber && a.EmailAddress == emailAddress).FirstOrDefault();
            if (account == null && emailAddress == null)
            {
                throw new ArgumentException("Invalid Account Number or email is invalid");
            }

            return account;
        }

        public static Job[] GetJobsByAccountNumber(int accountNumber)
        {
            return db.Jobs
                .Where(j =>j.AccountNumber == accountNumber)
                .ToArray();
        }

        public static Job[] GetJobsByJobTitle(string title)
        {
            return db.Jobs
                .Where(j => j.JobTitle == title)
                .ToArray();
        }

    }
}
