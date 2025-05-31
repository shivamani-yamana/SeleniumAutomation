using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using System;
using System.Threading;

namespace Selenium_Automation
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver("C:\\Users\\Kavya\\Downloads\\chromedriver-win32");

            try
            {
                driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
                driver.Manage().Window.Maximize();

                Thread.Sleep(4000);

                IWebElement form = driver.FindElement(By.Id("automationtestform"));

                IWebElement firstname = form.FindElement(By.Id("fname"));
                firstname.Clear();
                firstname.SendKeys("Shivamani");

                IWebElement gender = form.FindElement(By.Id("male"));
                gender.Click();

                IWebElement dateElement = form.FindElement(By.Id("dob"));
                dateElement.Clear();
                dateElement.SendKeys("2000-01-01");

                IWebElement dropdown = form.FindElement(By.Id("state"));

                SelectElement selectElement = new SelectElement(dropdown);
                selectElement.SelectByText("India");

                IWebElement agreebox = form.FindElement(By.Id("Agree"));
                agreebox.Click();


                IWebElement submitBtn = form.FindElement(By.CssSelector("button[Type='submit']"));

                submitBtn.Click();
                

                Console.WriteLine("✅ Automation test for first form completed successfully.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed with error message: " + ex.Message);
            }
            finally
            {
                Thread.Sleep(3000);
                driver.Quit();
            }
        }
    }
}