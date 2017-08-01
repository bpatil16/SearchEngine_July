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
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Change Password");
            Console.WriteLine("Please select option");
            var option = Console.ReadLine();
            switch(option)
            {
                case "0":
                    Console.WriteLine("\n Thank you!");
                    return;
                case "1":
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
                    for(int i =0; i<typeOfAccounts.Length; i++ )
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
                    break;
                case "2":
                    Console.WriteLine("\n Please enter new password");
                    var newPass = Console.ReadLine();
                    break;
                case "3":

                    break;
                default:
                    break;



            }
        }


    }
}
