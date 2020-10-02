using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoApadrinhamento.Classes
{
    class Config
    {
        string csvAlunos = @"C:\Users\natan\Desktop\CPE\Apadrinhamento 2020-2\csvAlunos.csv";
        string csvPadrinhos = @"C:\Users\natan\Desktop\CPE\Apadrinhamento 2020-2\csvPadrinhos.csv";
        string saida = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public string CsvAlunos { get => csvAlunos; }
        public string CsvPadrinhos { get => csvPadrinhos; }
        public string Saida { get => saida; }
    }
}
