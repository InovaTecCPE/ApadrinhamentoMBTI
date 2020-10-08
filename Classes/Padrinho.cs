using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoApadrinhamento.Classes
{
    class Padrinho
    {
        public string nome { get; set; }
        public string mbti { get; set; }
        public string ocupacao { get; set; }
        public string horario { get; set; }
        public int maxAfilhado { get; set; }

        public Padrinho(string nome, string mbti, string ocupacao, string horario, int maxAfilhado)
        {
            this.nome = nome;
            this.mbti = mbti;
            this.ocupacao = ocupacao;
            this.horario = horario;
            this.maxAfilhado = maxAfilhado;
        }

        public override string ToString()
        {
            return nome + ' ' + mbti + ' ' + ocupacao + ' ' + horario;
        }
    }
}
