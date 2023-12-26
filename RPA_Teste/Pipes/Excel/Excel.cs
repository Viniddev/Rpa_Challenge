using ClosedXML.Excel;
using RPA_Teste.Models;

namespace RPA_Teste.Pipes.Excel
{
    public class Excel
    {
        public static List<Models.Funcionarios> LerExcel() 
        {

            string caminhoDoArquivo = @"C:\RPA\challenge.xlsx";
            List<Funcionarios> listaDeDados = new List<Funcionarios>();

            using (var workbook = new XLWorkbook(caminhoDoArquivo))
            {
                var ws = workbook.Worksheet("Sheet1");

                for (int rowNum = 2; rowNum <= ws.LastRowUsed().RowNumber(); rowNum++)
                {
                    var nome = ws.Cell(rowNum, 1).Value.ToString().Trim();
                    var sobrenome = ws.Cell(rowNum, 2).Value.ToString().Trim();
                    var empresa = ws.Cell(rowNum, 3).Value.ToString().Trim();
                    var cargo = ws.Cell(rowNum, 4).Value.ToString().Trim();
                    var endereco = ws.Cell(rowNum, 5).Value.ToString().Trim();
                    var email = ws.Cell(rowNum, 6).Value.ToString().Trim();
                    var telefone = ws.Cell(rowNum, 7).Value.ToString().Trim();


                    listaDeDados.Add(new Funcionarios{
                        Nome = nome,
                        Sobrenome = sobrenome,
                        Empresa = empresa,
                        Cargo = cargo,
                        Endereco = endereco,
                        Email = email,
                        Telefone = telefone
                    });
                }
            }

            foreach (var dado in listaDeDados)
            {
                Console.WriteLine($"Nome: {dado.Nome}, {dado.Sobrenome}, {dado.Cargo} ...");
            }

            return listaDeDados;
        }
    }
}
