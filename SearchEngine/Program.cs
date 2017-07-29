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
                    Console.Write("\nPlease provide email password: ");
                    var password = Console.ReadLine();
                    Console.Write("\n What Type of Account: ");
                    var typeOfAccount = Console.ReadLine();
                    var account1 = Engine.CreateAccount(emailAddress, password, AccountTypes.Jobseeker );
                    break;
            }
        }


    }
}
