using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoApadrinhamento.Classes
{
    class Match
    {
        public Match(Aluno afilhado, Padrinho padrinho)
        {
            this.afilhado = afilhado;
            this.padrinho = padrinho;
        }

        public Aluno afilhado { get; set; }
        public Padrinho padrinho { get; set; }

    }
}
