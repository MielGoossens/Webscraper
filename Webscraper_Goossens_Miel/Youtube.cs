using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CsvHelper;
using System.Collections.Generic;

namespace Webscraper_Goossens_Miel
{
    internal class Youtube
    {
        public static void ProgramYoutube(string searchYoutube)
        {
            IWebDriver driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Navigate().GoToUrl("https://www.youtube.com/results?search_query="+searchYoutube+"&sp=CAI%253D");
            string pad = Directory.GetCurrentDirectory()+"/Youtube.csv";
            File.Delete(pad);
            addData("Link to video", "Title of video", "Uploaded by:", "Viewers/Total views", pad);
            for (int i = 1; i < 6; i++)
            {
                var link = driver.FindElement(By.XPath("/html/body/ytd-app/div/ytd-page-manager/ytd-search/div[1]/ytd-two-column-search-results-renderer/div/ytd-section-list-renderer/div[2]/ytd-item-section-renderer/div[3]/ytd-video-renderer[" + i + "]/div[1]/div/div[1]/div/h3/a")).GetAttribute("href");
                var title = driver.FindElement(By.XPath("/html/body/ytd-app/div/ytd-page-manager/ytd-search/div[1]/ytd-two-column-search-results-renderer/div/ytd-section-list-renderer/div[2]/ytd-item-section-renderer/div[3]/ytd-video-renderer[" + i + "]/div[1]/div/div[1]/div/h3/a"));
                var uploader = driver.FindElement(By.XPath("/html/body/ytd-app/div/ytd-page-manager/ytd-search/div[1]/ytd-two-column-search-results-renderer/div/ytd-section-list-renderer/div[2]/ytd-item-section-renderer/div[3]/ytd-video-renderer[" + i + "]/div[1]/div/div[2]/ytd-channel-name/div/div/yt-formatted-string/a"));
                var views = driver.FindElement(By.XPath("/html/body/ytd-app/div/ytd-page-manager/ytd-search/div[1]/ytd-two-column-search-results-renderer/div/ytd-section-list-renderer/div[2]/ytd-item-section-renderer/div[3]/ytd-video-renderer[" + i + "]/div[1]/div/div[1]/ytd-video-meta-block/div[1]/div[2]/span[1]"));
                addData(link, title.Text.Replace(";", " "), uploader.Text.Replace(";", " "), views.Text.Replace(";", " "), pad);
            }
            driver.Quit();
        }
        public static void addData(string link, string titel, string uploader, string views, string filepath)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
            {
                file.WriteLine(link + ";" + titel + ";" + uploader + ";" + views);
            }
        }

    }
}
