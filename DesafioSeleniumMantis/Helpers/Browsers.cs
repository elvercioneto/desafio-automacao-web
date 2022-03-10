using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioSeleniumMantis.Helpers
{
    public class Browsers
    {
        private static string seleniumHub = BuilderJson.ReturnParameterAppSettings("SELENIUM_HUB");

        #region Chrome
        public static IWebDriver GetLocalChrome()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            chromeOptions.AddArgument("enable-automation");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-infobars");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("--disable-browser-side-navigation");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;

            return new ChromeDriver(GeneralHelpers.GetProjectBinDebugPath(), chromeOptions);

        }

        public static IWebDriver GetRemoteChrome()
        {
            ChromeOptions chromeOptions = new ChromeOptions();

            chromeOptions.AddArgument("no-sandbox");
            //chromeOptions.AddArgument("--allow-running-insecure-content");
            //chromeOptions.AddArgument("start-maximized");
            //chromeOptions.AddArgument("enable-automation");
            chromeOptions.AddArgument("no-sandbox");
            chromeOptions.AddArgument("--disable-infobars");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("--disable-browser-side-navigation");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;

            return new RemoteWebDriver(new Uri(seleniumHub), chromeOptions); 

        }
        public static IWebDriver GetLocalChromeHeadless()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");

            return new ChromeDriver(GeneralHelpers.GetProjectBinDebugPath(), chromeOptions);
        }

        public static IWebDriver GetRemoteChromeHeadless()
        {
            ChromeOptions chromeOptions = new ChromeOptions();

            chromeOptions.AddArgument("no-sandbox");
            chromeOptions.AddArgument("--allow-running-insecure-content");
            chromeOptions.AddArgument("--lang=pt-BR");
            chromeOptions.AddArgument("--headless");

            return new RemoteWebDriver(new Uri(seleniumHub), chromeOptions); ;
        }
        #endregion

        #region Firefox
        public static IWebDriver GetLocalFirefox()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.SetPreference("intl.accept_languages", "pt-BR");
            //alteração no método que carrega o firefox para trazer o firefox pra português
            return new FirefoxDriver(GeneralHelpers.GetProjectBinDebugPath(), firefoxOptions);
        }

        public static IWebDriver GetRemoteFirefox()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.SetPreference("intl.accept_languages", "pt-BR");

            return new RemoteWebDriver(new Uri(seleniumHub), firefoxOptions);
        }
        #endregion

        #region Internet Explorer
        public static IWebDriver GetLocalInternetExplorer()
        {
            return new InternetExplorerDriver(GeneralHelpers.GetProjectBinDebugPath());
        }

        public static IWebDriver GetRemoteInternetExplorer()
        {
            InternetExplorerOptions ieOptions = new InternetExplorerOptions();

            return new RemoteWebDriver(new Uri(seleniumHub), ieOptions.ToCapabilities()); ;
        }
        #endregion

        #region Edge
        public static IWebDriver GetLocalEdge()
        {
            
            
            
            
            //edgeoptions edgeoptions = new edgeoptions(); //implementar o arquivo de metadados EdgeOptions assim como no FirefoxOptions
            //edgedriver edgedriver = new edgedriver();
            //edgedriver.manage().window.maximize();
            //edgeoptions.addargument("start-maximized");
            //edgeoptions.addargument("enable-automation");
            //edgeoptions.addargument("--no-sandbox");
            //edgeoptions.addargument("--disable-infobars");
            //edgeoptions.addargument("--disable-dev-shm-usage");
            //edgeoptions.addargument("--disable-browser-side-navigation");
            //edgeoptions.addargument("--disable-gpu");
            
           
            //edgeoptions.pageloadstrategy = pageloadstrategy.normal;



            return new EdgeDriver(GeneralHelpers.GetProjectBinDebugPath());

        }

        public static IWebDriver GetRemoteEdge()
        {
            EdgeOptions edgeOptions = new EdgeOptions();


            return new RemoteWebDriver(new Uri(seleniumHub), edgeOptions.ToCapabilities());
        }
        #endregion
        
    }
}