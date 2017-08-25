using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("******** Welcome to Job search Engine*******");
            while(true)
            { 
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Employer Post a Job");
            Console.WriteLine("3. Jobseeker Upload a resume");
            Console.WriteLine("4. Print All Accounts");
            Console.WriteLine("5. Print All Jobs");
            Console.WriteLine("Please select option");
            var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("\n Thank you!");
                        return;
                    case "1":
                        try
                        {
                            Console.Write("\nPlease provide email address: ");
                            var emailAddress = Console.ReadLine();
                            Console.Write("\nPlease provide password:");
                            // var password = Console.ReadLine();

                            string password = null;
                            while (true)
                            {
                                var key = Console.ReadKey(true);
                                if (key.Key == ConsoleKey.Enter)
                                    break;
                                password += key.KeyChar;
                                Console.Write("*");
                            }

                            var typeOfAccounts = Enum.GetNames(typeof(AccountTypes));
                            for (int i = 0; i < typeOfAccounts.Length; i++)
                            {
                                Console.WriteLine($"\n {i}: {typeOfAccounts[i]}");
                            }
                            Console.Write("\n Please select the type of account: ");
                            var typeOfAccount = Convert.ToInt32(Console.ReadLine());
                            var accountType = (AccountTypes)Enum.Parse(typeof(AccountTypes),
                               typeOfAccounts[typeOfAccount]);
                            var account1 = Engine.CreateAccount(emailAddress, password, accountType);
                            Console.WriteLine($"AN Account: {account1.AccountNumber}, Email: {account1.EmailAddress} Password: {account1.Password} TA: {account1.TypeOfAccount} has been created");
                            Console.ReadLine();
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"Something went wrong. {ax.Message} ");
                        }
                        break;
                    case "2":
                        try
                        {
                            PrintAllAccounts();
                            Console.WriteLine("\n Please provide you Account Number to post job:");
                            int anumber = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\n Please provide Job Title:");
                            var title = Console.ReadLine();
                            Console.Write("\n Please provide Job Description:\n");
                            var description = Console.ReadLine();
                            Console.WriteLine("\n Please provide your Company name:\n");
                            var company = Console.ReadLine();
                            Console.Write("\n Please provide location:\n");
                            var location = Console.ReadLine();
                            var job = Engine.PostJob(title, description, company, location, anumber);
                            Console.WriteLine($"A Job with Id: {job.JobNumber}, Company: {job.Company}, for Account: {job.AccountNumber} has been posted ");
                            Console.ReadLine();
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"Something went wrong. {ax.Message} ");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Something went wrong. Either account number is invalid.");
                        }
                        break;
                    case "3":
                        try
                        {
                            PrintAllAccounts();
                            Console.WriteLine("\n Please provide you Account Number to Post Resume:");
                            int accnumber = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\n Please provide your name:");
                            var resumeName = Console.ReadLine();
                            Console.Write("\n Please provide Description:\n");
                            var resumeDescription = Console.ReadLine();
                            Console.WriteLine("\n Please provide your education:\n");
                            var education = Console.ReadLine();
                            Console.Write("\n Please provide Skills:\n");
                            var skills = Console.ReadLine();
                            var resume = Engine.UploadResume(resumeName, resumeDescription, education, skills, accnumber);
                            Console.WriteLine($"A Resume for: {resume.ResumeName}, With Description: {resume.Description}, for Account: {resume.AccountNumber} has been posted ");
                            Console.ReadLine();

                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"Something went wrong. {ax.Message} ");
                        }
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                        try
                        {
                            PrintAllAccounts();
                            Console.Write("Account number to view jobs? ");
                            var accountNumber = Convert.ToInt32(Console.ReadLine());

                            var Jobs = Engine.GetJobsByAccountNumber(accountNumber);
                            foreach (var Job in Jobs)
                            {
                                Console.WriteLine($"Job{Job.JobNumber}, JobTitle : {Job.JobTitle}, JobDescription: {Job.Description}, Company: {Job.Company}, JobLocation: {Job.Location}");
                            }
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"Something went wrong. {ax.Message} ");
                        }
                        break;
                    default:
                        break;

                }

            }

        }

        private static void PrintAllAccountsByEmail()
        {

            Console.WriteLine("Email Address");
            var emailAddress = Console.ReadLine();
            var myAccounts = Engine.GetAllAccountsByEmail(emailAddress);
            foreach (var account in myAccounts)
            {
                Console.WriteLine($"An: {account.AccountNumber}, AT: {account.TypeOfAccount}");
            }

        }

        private static void PrintAllAccounts()
        {
            var myAccounts = Engine.GetAllAccounts();
            foreach (var account in myAccounts)
            {
                Console.WriteLine($"An: {account.AccountNumber}, Email: {account.EmailAddress}, AT: {account.TypeOfAccount}");
            }

        }
    }
}
