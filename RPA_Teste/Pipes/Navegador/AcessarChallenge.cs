using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using RPA_Teste.Models;


namespace RPA_Teste.Pipes.Navegador
{
    public class AcessarChallenge
    {
        public static void Challenge(ChromeDriver driver, List<Funcionarios> funcionarios)
        {
            //indo pra url
            driver.Navigate().GoToUrl("https://www.rpachallenge.com");
            Thread.Sleep(1000);

            //startando
            driver.FindElement(By.XPath(".//button[contains(text(),'Start')]")).Click();

            foreach (var funcionario in funcionarios)
            {
                IReadOnlyCollection<IWebElement> elementosInput = driver.FindElements(By.XPath("//input[contains(text(), '')]"));

                foreach (IWebElement element in elementosInput)
                { 
                    if(element.GetAttribute("ng-reflect-name") != null) 
                    {
                        switch (element.GetAttribute("ng-reflect-name").Replace("label", "").Trim()) 
                        {
                            case "Address":
                                element.SendKeys(funcionario.Endereco);
                                break;
                            case "Role":
                                element.SendKeys(funcionario.Cargo);
                                break;
                            case "Phone":
                                element.SendKeys(funcionario.Telefone);
                                break;
                            case "CompanyName":
                                element.SendKeys(funcionario.Empresa);
                                break;
                            case "FirstName":
                                element.SendKeys(funcionario.Nome);
                                break;
                            case "LastName":
                                element.SendKeys(funcionario.Sobrenome);
                                break;
                            case "Email":
                                element.SendKeys(funcionario.Email);
                                break;
                            default:
                                Console.WriteLine("not found");
                                break;
                        }
                    }

                    Thread.Sleep(500);
                }

                driver.FindElement(By.XPath("/html/body/app-root/div[2]/app-rpa1/div/div[2]/form/input")).Click();
                Console.WriteLine("\nproximo funcionario\n");
            }

            Console.WriteLine("\nFINALIZOU\n");
            Console.ReadLine();
            // Fechando o navegador
        }
    }
}