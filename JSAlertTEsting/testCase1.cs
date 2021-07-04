using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

namespace JSAlertTEsting
{
    class testCase1
    {
        //declare variabel using IWebDriver Interface
        IWebDriver driver;

        //initiate to use ChromeDriver Class
        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }


        [Test]
        public void JSAlert()
        {
            //launch Website
            driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

            //get website title
            String Title = driver.Title;

            //Print Title name on Console
            Console.WriteLine("Title of the page is : " + Title);
            Console.WriteLine("");

            #region JSAlert
            //This step produce an alert on screen
            driver.FindElement(By.XPath("//button[contains(text(),'Click for JS Alert')]")).Click();

            // Switch the control of 'driver' to the Alert from main Window
            IAlert simpleAlert = driver.SwitchTo().Alert();

            // '.Text' is used to get the text from the Alert
            String alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is " + alertText);
            Console.WriteLine("");

            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            simpleAlert.Accept();

            String result = driver.FindElement(By.XPath("//p[@id='result']")).Text;

            if (result== "You successfully clicked an alert")
            {
                Console.WriteLine(result);
                Console.WriteLine("Result value: OK");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine("Result value: Not OK");
                Console.WriteLine("");
            }

            #endregion JSAlert

            

        }

        [Test]
        public void JSConfirm()
        {
            //launch Website
            driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

            #region JSConfirm
            //This step produce an alert on screen
            IWebElement element = driver.FindElement(By.XPath("//button[contains(text(),'Click for JS Confirm')]"));

            // 'IJavaScriptExecutor' is an interface which is used to run the 'JavaScript code' into the webdriver (Browser)
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);

            // Switch the control of 'driver' to the Alert from main window
            IAlert confirmationAlert = driver.SwitchTo().Alert();

            // Get the Text of Alert
            String alertText2 = confirmationAlert.Text;

            Console.WriteLine("Alert text is " + alertText2);
            Console.WriteLine("");


            //'.Accept()' is used to accept the alert '(click on the OK button)'
            confirmationAlert.Accept();
            String result = driver.FindElement(By.XPath("//p[@id='result']")).Text;
            if (result == "You clicked: Ok")
            {
                Console.WriteLine(result);
                Console.WriteLine("Result accept value: OK");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Result accept value: Not OK");
                Console.WriteLine("");
            }

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
            //'.Dismiss()' is used to cancel the alert '(click on the Cancel button)'
            confirmationAlert.Dismiss();
            String result2 = driver.FindElement(By.XPath("//p[@id='result']")).Text;
            if (result2 == "You clicked: Cancel")
            {
                Console.WriteLine(result);
                Console.WriteLine("Result dismiss value: OK");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Result dismiss value: Not OK");
                Console.WriteLine("");
            }

            #endregion JSConfirm
        }

        [Test]
        public void JSPrompt()
        {
            //launch Website
            driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

            //This step produce an alert on screen
            IWebElement element = driver.FindElement(By.XPath("//button[contains(text(),'Click for JS Prompt')]"));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);

            // Switch the control of 'driver' to the Alert from main window
            IAlert promptAlert = driver.SwitchTo().Alert();

            // Get the Text of Alert
            String alertText = promptAlert.Text;
            Console.WriteLine("Alert text is " + alertText);

            //'.SendKeys()' to enter the text in to the textbox of alert 
            String promptMsg = "Stay Healthy";
            promptAlert.SendKeys(promptMsg);

            Thread.Sleep(4000); //This sleep is not necessary, just for testing

            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            promptAlert.Accept();

            String result = driver.FindElement(By.XPath("//p[@id='result']")).Text;
            if (result == "You entered: "+promptMsg)
            {
                Console.WriteLine(result);
                Console.WriteLine("Result accept value: OK");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Result accept value: Not OK");
                Console.WriteLine("");
            }
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}
