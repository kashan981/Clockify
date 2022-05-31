using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Threading;
using ExcelDataReader;
using System.Data;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;
using System.Reflection;

namespace ClockifyTask
{
    class Program
    {
        public static string datetime = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
        IWebDriver driver = new ChromeDriver();
        public static ExtentReports extent;
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to start Execution");
            Console.ReadLine();
            Initialize();
            Execution();
            Extentclose();
            Console.WriteLine("Execution Completed");
            Console.ReadLine();
            
        }
        public static void Initialize()
        {
            string pth = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+"\\";//Reflection.Assembly.GetCallingAssembly().CodeBase;

                //string actualPath = pth.Substring(0, pth.LastIndexOf("netcoreapp3.1"));

               // string projectPath = new Uri(actuaPath).LocalPath;
                string reportPath = pth + "Reports"+datetime+"\\Report.html";

                extent = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter(""+reportPath);
                extent.AttachReporter(htmlReporter);

                PropertiesCollection.driver = new ChromeDriver();
                PropertiesCollection.driver.Navigate().GoToUrl("https://app.clockify.me/en/login");
                PropertiesCollection.driver.Manage().Window.Maximize();
                Thread.Sleep(2000);
        }

        public static void Execution()
        {
                ExtentTest test;
                test = extent.CreateTest("SOKIN TASK ADDITION").Info("Test Started");

                DataTable table = ExcelLib.PopulateInCollection(ConfigurationManager.AppSettings["data"]);

                LoginPageObject obj1 = new LoginPageObject();
                obj1.Login(ExcelLib.ReadData(1, "email"), ExcelLib.ReadData(1, "password"));
                obj1.btnLoginn.Submit();

                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    bool success = obj1.Login1(ExcelLib.ReadData(i, "Description"), ExcelLib.ReadData(i, "strttime"), ExcelLib.ReadData(i, "endtime"), ExcelLib.ReadData(i, "projectmenu"), ExcelLib.ReadData(i, "tags"), ExcelLib.ReadData(i, "task"), ExcelLib.ReadData(i, "date"));
                
                PropertiesCollection.driver.Navigate().Refresh();
                if (success == true)
                {
                   
                    test.Log(Status.Pass, "Project <b>" + ExcelLib.ReadData(i, "projectmenu") + "</b> , task <b>" + ExcelLib.ReadData(i, "task") + "</b> added SUCCESSFULLY with description <b>-" +
                    ExcelLib.ReadData(i, "Description") + "-</b> on tag <b>" + ExcelLib.ReadData(i, "tags")+ "</b> \n Dated : " + ExcelLib.ReadData(i,"date"));
                }
                else
                    test.Log(Status.Error, "Entry not added SUCCESFULLY");
                }
                PropertiesCollection.driver.Close();
                PropertiesCollection.driver.Quit();

        }
        public static void Extentclose()
        {
            extent.Flush();
        }

    }
}
