using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CsvHelper;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Web;

namespace Webscraper_Goossens_Miel
{
    internal class Crypto
    {
        public static void ProgramBinance(string searchBinance)
        {
            IWebDriver driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Navigate().GoToUrl("https://www.binance.com/en/trade/" + searchBinance);
            Thread.Sleep(5000);

            string pad = Directory.GetCurrentDirectory() + "/Binance.csv";
            File.Delete(pad);
            Console.WriteLine(pad);
            //add titles to csv file
            addData("Coin", "Price of 1 coin", "high 24h", "low 24h", "volume in (eur, usdt,...) 24h", pad);
            //get data
            var coin = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[4]/div/div[1]/div[1]/div/div[1]/div/div[1]/div/h1"));
            var price = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[4]/div/div[1]/div[1]/div/div[2]/div[1]"));
            var high24h = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[4]/div/div[1]/div[2]/div/div/div[2]/div[2]"));
            var low24h = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[4]/div/div[1]/div[2]/div/div/div[3]/div[2]"));
            var volume24h = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[4]/div/div[1]/div[2]/div/div/div[5]/div[2]"));
            //add data to csv file
            addData(coin.Text, price.Text, high24h.Text, low24h.Text, volume24h.Text, pad);
            driver.Quit();
        }
        public static void addData(string coin, string price, string high24h, string low24h, string volume24h, string filepath)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
            {
                file.WriteLine(coin + ";" + price + ";" + high24h + ";" + low24h + ";" + volume24h);
            }
        }
    }
}
