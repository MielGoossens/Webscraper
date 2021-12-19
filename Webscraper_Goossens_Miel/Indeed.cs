using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CsvHelper;
using System.Collections.Generic;

namespace Webscraper_Goossens_Miel
{
    internal class Indeed
    {
        public static void ProgramIndeed(string searchIndeed)
        {
            IWebDriver driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Navigate().GoToUrl("https://be.indeed.com/");
            Thread.Sleep(4000);                 
            IWebElement job = driver.FindElement(By.CssSelector("#text-input-what"));
            job.SendKeys(searchIndeed);
            job.SendKeys(Keys.Enter);

            IWebElement date = driver.FindElement(By.CssSelector("#filter-dateposted"));
            date.Click();
            IWebElement last3days = driver.FindElement(By.XPath("/html/body/table[1]/tbody/tr/td/div/div[2]/div/div[1]/ul/li[2]/a"));
            last3days.Click();
            string pad = Directory.GetCurrentDirectory()+"/Indeed.csv";
            File.Delete(pad);
            addData("Link to the ad", "Title to the ad", "Company of ad", "Location of ad", pad);
            for (int i = 1; i < 16; i++)
            {
                var link = driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr/td/table/tbody/tr/td[1]/div[5]/div/a[" + i + "]")).GetAttribute("href");
                var title = driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr/td/table/tbody/tr/td[1]/div[5]/div/a[" + i + "]/div[1]/div/div[1]/div/table[1]/tbody/tr/td/div[1]/h2/span"));
                var company = driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr/td/table/tbody/tr/td[1]/div[5]/div/a[" + i + "]/div[1]/div/div[1]/div/table[1]/tbody/tr/td/div[2]/pre/span"));
                var location = driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr/td/table/tbody/tr/td[1]/div[5]/div/a[" + i + "]/div[1]/div/div[1]/div/table[1]/tbody/tr/td/div[2]/pre/div"));
                addData(link, title.Text, company.Text, location.Text, pad);
            }
            driver.Quit();
        }
        public static void addData(string link, string title, string company, string location, string filepath)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
            {
                file.WriteLine(link + ";" + title + ";" + company + ";" + location);
            }
        }
    }
}
