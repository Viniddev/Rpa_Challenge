using OpenQA.Selenium.Chrome;
using RPA_Teste;
using RPA_Teste.Models;
using RPA_Teste.Pipes.Excel;
using RPA_Teste.Pipes.Navegador;

/*
    Espaço para estudar sobre automação
    criado em 23/12/2023 por Vinícius Dias

*/

namespace RPA_Teste
{
    public class Program 
    {
        static void Main(string[] args) 
        {

            List<Models.Funcionarios> funcionarios = Excel.LerExcel();
            ChromeDriver driver = Launch.LaunchNavegador();
            AcessarChallenge.Challenge(driver, funcionarios);
            Console.ReadLine();

            Aplication.KillChromeDriver();
        }
    }
}