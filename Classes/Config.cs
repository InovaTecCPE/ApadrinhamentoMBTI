using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoApadrinhamento.Classes
{
    class Config
    {
        string csvAlunos = @"Path";
        string csvPadrinhos = @"Path";
        string saida = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public string CsvAlunos { get => csvAlunos; }
        public string CsvPadrinhos { get => csvPadrinhos; }
        public string Saida { get => saida; }
    }
}
