using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoApadrinhamento.Classes
{
    class Aluno
    {
        public Aluno(string nome, string turno, string mbti, string horario)
        {
            this.nome = nome;
            this.turno = turno;
            this.mbti = mbti;
            this.horario = horario;
        }

        public string nome { get; set; }
        public string turno { get; set; }
        public string mbti { get; set; }
        public string horario { get; set; }

    }
}
