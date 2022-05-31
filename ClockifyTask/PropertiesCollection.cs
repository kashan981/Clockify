using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClockifyTask
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName
    }
    class PropertiesCollection
    {
        public static IWebDriver driver { get; set; }
    }
}
