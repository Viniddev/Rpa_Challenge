using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using DocumentFormat.OpenXml.Bibliography;

namespace RPA_Teste.Pipes.Navegador
{
    public class Launch
    {
       
        public static dynamic LaunchNavegador() 
        {
            try
            {
                IWebDriver Driver;

                string version = null;
                var path = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

                string pathDownload = $@"C:\RPA\RPA_Teste\exec\Chrome\120.0.6099.109\X64";

                ChromeOptions opt = new ChromeOptions();

                if (!Directory.Exists(pathDownload))
                    Directory.CreateDirectory(pathDownload);

                if (!Directory.Exists(@"C:\ScopeDir\ScopeDir"))
                    Directory.CreateDirectory(@"C:\Selenium\Scope");


                opt.AcceptInsecureCertificates = true;
                string scopeDirPath = @"C:\Selenium\Scope\ScopeDir";
                opt.AddArgument($"--user-data-dir={scopeDirPath}");

                opt.AddArgument("--start-maximized");
                opt.AddArgument("--aways-authorize-plugins");
                opt.AddArgument("--disable-notifications");
                opt.AddArgument("--no-sandbox");
                opt.AddArgument("--ignore-certificate-errors");
                opt.AddArgument("--ignore-ssl-errors");
                opt.AddUserProfilePreference("download.default_directory", pathDownload);
                opt.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
                opt.AddUserProfilePreference("download.prompt_for_download", false);
                opt.AddUserProfilePreference("download.directory_upgrade", true);
                opt.AddUserProfilePreference("plugins.plugins_disabled", "Chrome PDF Viewer");
                //opt.AddArgument("--proxy-server=" + "192.168.239.14" + ":" + "8080");                
                //opt.AddArgument("--headless");

                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                chromeDriverService.HideCommandPromptWindow = true;
                Driver = new ChromeDriver(chromeDriverService, opt, TimeSpan.FromSeconds(300));

                return Driver;
            }
            catch (Exception e) 
            {
                Console.WriteLine("Erro: " + e.Message);
                Console.ReadLine();
                Aplication.KillChromeDriver();
            }
            return null;
        }
    }
}
