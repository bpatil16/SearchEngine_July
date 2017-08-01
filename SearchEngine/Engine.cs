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

        public static Job PostJob(string jobTitle, string jobDescription, string company, string location)
        {
            var job = new Job
            {
                JobTitle = jobTitle,
                Description = jobDescription,
                Company = company,
                Location = location
            };
            return job;
        }

        public static Resume UploadResume(string userName, string resumeDescription, string education, string skills)
        {
            var resume = new Resume
            {
                ResumeName = userName,
                Description = resumeDescription,
                Education = education,
                Skills = skills
        };
            return resume;
        }

    }
}
