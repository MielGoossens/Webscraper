using System;
using System.environment;
System.Environment.variable;
//System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using CsvHelper;
//using System.Collections.Generic;

namespace Webscraper_Goossens_Miel
{
    public class Program
    {
        public static void Main()
        {
            //public 
            Console.WriteLine("Project Goossens Miel Webscraper");
            Console.WriteLine("--------------------------------\n");
            Console.WriteLine("Choose between A, B or C\n");
            Console.WriteLine("A: Scrape: Youtube");
            Console.WriteLine("B: Scrape: Indeed");
            Console.WriteLine("C: Scrape: Binance\n");
            Console.Write("Your choice: ");
            string Choice = Console.ReadLine();
            switch(Choice)
            {
                case "A":
                    Console.WriteLine("Enter what you want to look for on youtube");
                    string searchYoutube = (Console.ReadLine());
                    Youtube.ProgramYoutube(searchYoutube);
                    break;
                case "B":
                    Console.WriteLine("Enter the job you want to look for on LinkedIn");
                    string searchIndeed = (Console.ReadLine());
                    Indeed.ProgramIndeed(searchIndeed);
                    break;
                case "C":
                    Console.WriteLine("Enter coin in like: DOGE_EUR");
                    string searchBinance = (Console.ReadLine());
                    Crypto.ProgramBinance(searchBinance);
                    break;
                default: 
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}