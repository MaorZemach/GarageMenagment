using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Threading;
//using Threads;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            // Console.WriteLine("Welcome To The Garage System!");

            UIManagement garageManager = new UIManagement();
            garageManager.Run();

            Console.ReadLine();
        }
    }
}