using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClockifyTask
{
    class SeleniumGetMethods
    {
        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");
        }
        /*public static string GetTextfromDDL(IWebElement element)
        {
            //if (elementtype == PropertyType.Id)
                return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
            //if (elementtype == PropertyType.Name)
                //return new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
            //else return String.Empty;
        }*/
    }
}
