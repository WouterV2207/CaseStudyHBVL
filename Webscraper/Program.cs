using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    class Program
    {

        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.hbvl.be/");
            Thread.Sleep(2000);

            var cookiebutton = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/button[2]"));
            cookiebutton.Click();
            Thread.Sleep(2000);

            var searchbutton = driver.FindElement(By.XPath("/html/body/header/div[2]/div/nav/ul[2]/li[2]/a"));
            searchbutton.Click();

            var element = driver.FindElement(By.XPath("/html/body/header/div[2]/div/nav/div[1]/div/div/input[1]"));

            Thread.Sleep(2000);

            element.SendKeys("rode duivels");

            var submitbutton = driver.FindElement(By.XPath("/html/body/header/div[2]/div/nav/div[1]/div/div/input[2]"));
            submitbutton.Click();
            Thread.Sleep(2000);

            var datebutton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/main/div[2]/div/div/div[1]/div/section/aside/form/fieldset[1]/div[3]/label/input"));
            datebutton.Click();

            Thread.Sleep(2000);

            var datesubmitbutton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/main/div[2]/div/div/div[1]/div/section/aside/form/button"));
            datesubmitbutton.Click();
            Thread.Sleep(2000);

            By elem_article_link = By.ClassName("hbvl-a7f01eee_displayflex");
            ReadOnlyCollection<IWebElement> articles = driver.FindElements(elem_article_link);

            /* Go through the Videos List and scrap the same to get the attributes of the videos in the channel */
            foreach (IWebElement article in articles)
            {
                string str_title, str_time;
                IWebElement elem_article_title = article.FindElement(By.ClassName("hbvl-721a2946_root"));
                str_title = elem_article_title.Text;
                IWebElement elem_article_time = article.FindElement(By.ClassName("hbvl-721a2946_caption2"));
                str_time = elem_article_time.Text;

                Console.WriteLine("Article Title: " + str_title);
                Console.WriteLine("Article Upload: " + str_time);
                Console.WriteLine("\n");

                StringBuilder csvcontent = new StringBuilder();
                csvcontent.AppendLine("Article title: " + str_title + "\n" + "Article uploaded: " + str_time + "\n");
                string csvpath = "D:\\School\\AI\\hbvl\\Webscraper\\hbvl.csv";
                File.AppendAllText(csvpath, csvcontent.ToString());



            }
        }
    }
}
