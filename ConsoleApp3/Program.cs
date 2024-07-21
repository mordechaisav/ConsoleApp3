using System;
using System.Xml.Linq;

namespace ConsoleApp3
{
    internal class Program
    {

        static void Main(string[] args)
        {
            while (true) {
            Console.WriteLine("1. Create questions");
            Console.WriteLine("2. Answer Questions");
            string option = Console.ReadLine();
            Server server = new Server("XML1.xml");

                switch (option)
                {
                    case "1":
                        server.CreateQuestion();
                        break;
                    case "2":
                        server.read();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }


        



    }
}
