using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace ClockifyTask
{
    class LoginPageObject
    {
        public LoginPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "cl-form-control")]
        public IWebElement txtemail { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement txtpassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()]")]
        public IWebElement btnLoginn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='cl-position-relative']/input")]
        public IWebElement txtDescription { get; set; }

        [FindsBy(How = How.ClassName, Using = "recorder-project-wrapper")]
        public IWebElement btnPro { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='cl-dropdown']")]
        public IWebElement btntag { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@class='tag-icon']/parent::div/parent::tag-names/parent::div/following-sibling::single-date-picker2/div/input-time-ampm[1]")]
        public IWebElement txtstrttime { get; set; }

        //[FindsBy(How = How.XPath, Using = "//span[@title="+tags+"]/parent::div/parent::tag-names/parent::div/following-sibling::single-date-picker2/div/input-time-ampm[2]")]
        //public IWebElement txtendtime { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class= 'cl-form-control cl-input-date-picker ng-untouched ng-pristine ng-valid']")]
        public IWebElement txtdate { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-cy='add-btn']")]
        public IWebElement btnAdd { get; set; }

        public void Login(string email, string password)
        {
            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //email
            txtemail.SendKeys(email);
            //password
            txtpassword.SendKeys(password);
            //submit
            btnLoginn.Submit();
                        
        }
        public bool Login1(string Description, string strttime, string endtime, string projectmenu, string tags, string task, string date)
        {
            bool success = false;
            try
            {               
                PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                txtDescription.Click();
                txtDescription.SendKeys(Description);
                btnPro.Click();
                PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                PropertiesCollection.driver.FindElement(By.XPath("//button[contains(text(), '" + projectmenu + "')]"));
                PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                PropertiesCollection.driver.FindElement(By.XPath("//button[contains(text(), '" + projectmenu + "')]/parent::div/child::div/a/select-arrow")).Click();
                PropertiesCollection.driver.FindElement(By.XPath("//div[contains(text(), '" + task + "')]")).Click();
                btnPro.Click();
                btntag.Click();
                PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                PropertiesCollection.driver.FindElement(By.XPath("//div[contains(text(), '" + tags + "')]")).Click();
                PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                
                Actions dClickAction = new Actions(PropertiesCollection.driver);
                dClickAction.DoubleClick(txtstrttime).Perform();
                Actions dClickAction1 = new Actions(PropertiesCollection.driver);
                dClickAction1.SendKeys(Keys.Backspace).Build().Perform();
                Actions dClickAction2 = new Actions(PropertiesCollection.driver);
                dClickAction2.SendKeys(strttime).Build().Perform();
                Thread.Sleep(1000);
                Actions dClickAction3 = new Actions(PropertiesCollection.driver);
                dClickAction3.DoubleClick(PropertiesCollection.driver.FindElement(By.XPath("//span[@title='"+tags+"']/parent::div/parent::tag-names/parent::div/following-sibling::single-date-picker2/div/input-time-ampm[2]"))).Perform();
                Actions dClickAction4 = new Actions(PropertiesCollection.driver);
                dClickAction4.SendKeys(Keys.Backspace).Build().Perform();
                Actions dClickAction5 = new Actions(PropertiesCollection.driver);
                dClickAction5.SendKeys(endtime).Build().Perform();

                PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
                txtdate.Click();
                PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                txtdate.SendKeys(date);
                PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
                btnAdd.Click();
                PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                success = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("*** Exception is : " + ex.Message + " ***");
            }
            return success;
        }       
    }
}
