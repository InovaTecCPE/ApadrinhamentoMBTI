using demoApadrinhamento.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoApadrinhamento
{
    class Program
    {
        static Config Config = new Config();

        static void Main(string[] args)
        {
            LinkedList<Aluno> alunos = new LinkedList<Aluno>();
            string csvAlunos = Config.CsvAlunos;
            using (StreamReader sr = new StreamReader(csvAlunos))
            {
                string currentLine;
                // currentLine will be null when the StreamReader reaches the end of file
                while ((currentLine = sr.ReadLine()) != null)
                {
                    string[] linha = currentLine.Split(';');
                    alunos.AddLast(new Aluno(linha[0], linha[1], linha[2], linha[3]));
                }
                alunos.RemoveFirst();
            }


            LinkedList<Padrinho> padrinhos = new LinkedList<Padrinho>();
            string csvADM = Config.CsvPadrinhos;
            using (StreamReader sr = new StreamReader(csvADM))
            {
                string currentLine;
                // currentLine will be null when the StreamReader reaches the end of file
                while ((currentLine = sr.ReadLine()) != null)
                {
                    string[] linha = currentLine.Split(';');
                    padrinhos.AddLast(new Padrinho(linha[0], linha[1], linha[2], linha[3], Convert.ToInt32(linha[4])));
                }
                padrinhos.RemoveFirst();
            }



            LinkedList<Match> matchesMBTI = new LinkedList<Match>();
            LinkedList<Match> matchesHorario = new LinkedList<Match>();

            Console.WriteLine(alunos.Count);


            /*
             * for(LinkedListNode<Object> node=list.First; node != null; node=node.Next){
             */

            {
                LinkedListNode<Padrinho> p = padrinhos.First;
                while (p != null)
                {
                    int afilhadosAtuais = 0;
                    LinkedListNode<Aluno> a = alunos.First;
                    while ((a != null) & (afilhadosAtuais < p.Value.maxAfilhado))
                    {
                        bool hasMatch = false;
                        if (validaHorario(p.Value.horario, a.Value.horario) && p.Value.mbti.Equals(a.Value.mbti))
                        {
                            matchesMBTI.AddLast(new Match(a.Value, p.Value));
                            hasMatch = true;
                            afilhadosAtuais++;
                        }

                        LinkedListNode<Aluno> nextAluno = a.Next;
                        if (hasMatch) alunos.Remove(a);

                        a = nextAluno;
                    }

                    LinkedListNode<Padrinho> nextPadrinho = p.Next;
                    if (afilhadosAtuais == p.Value.maxAfilhado) padrinhos.Remove(p);
                    p = nextPadrinho;
                }
            }

            if (alunos.Count > 0)
            {
                LinkedListNode<Padrinho> p = padrinhos.First;
                while (p != null)
                {
                    int afilhadosAtuais = 0;
                    LinkedListNode<Aluno> a = alunos.First;
                    while ((a != null) & (afilhadosAtuais < p.Value.maxAfilhado))
                    {
                        bool hasMatch = false;
                        if (validaHorario(p.Value.horario, a.Value.horario) )
                        {
                            matchesMBTI.AddLast(new Match(a.Value, p.Value));
                            hasMatch = true;
                            afilhadosAtuais++;
                        }

                        LinkedListNode<Aluno> nextAluno = a.Next;
                        if (hasMatch) alunos.Remove(a);

                        a = nextAluno;
                    }

                    LinkedListNode<Padrinho> nextPadrinho = p.Next;
                    if (afilhadosAtuais == p.Value.maxAfilhado) padrinhos.Remove(p);
                    p = nextPadrinho;
                }
            }
            
            //SalvaMatch(matchesHorario, "Horario");
            SalvaMatch(matchesMBTI, "Horario");
            SalvaAlunos(alunos, "Alunos");
            SalvaPadrinho(padrinhos, "Padrinhos");

            Console.WriteLine("Finalizado \n" +
                $"Alunos sem match {alunos.Count} e Padrinho sem Match {padrinhos.Count}");
            Console.ReadLine();
        }

        static bool validaHorario(string hPadrinho, string hAluno)
        {
            if (hPadrinho.Equals("Ambos"))
            {
                return true;
            }
            else if (hPadrinho.Equals("Vespertino"))
            {
                if (!hAluno.Contains("Noite"))
                    return true;
            }
            else if (hPadrinho.Equals("Noturno"))
            {
                if (hAluno.Contains("Noite"))
                    return true;
            }
            return false;
        }


        static void SalvaMatch(LinkedList<Match> list, string Name)
        {
            string path = Config.Saida;
            /*
             * (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")
             */
            using (StreamWriter sw = new StreamWriter(Path.Combine(path, $"Match{Name}.csv")))
            {
                string linha = $"NomeAluno;Turno;Horario;MBTI;NomePadrinho;Ocupacao;Horario;MBTI";
                sw.WriteLine(linha);
                foreach (Match m in list)
                {
                    linha = $"{m.afilhado.nome};{m.afilhado.turno};{m.afilhado.horario};{m.afilhado.mbti};";
                    linha += $"{m.padrinho.nome};{m.padrinho.ocupacao};{m.padrinho.horario};{m.padrinho.mbti};";
                    sw.WriteLine(linha);
                }
            }
        }

        static void SalvaAlunos(LinkedList<Aluno> list, string Name)
        {
            string path = Config.Saida;
            using (StreamWriter sw = new StreamWriter(Path.Combine(path, $"{Name}SemMatch.csv")))
            {
                string linha = $"Nome;Turno;Horario;MBTI;";
                sw.WriteLine(linha);
                foreach (Aluno m in list)
                {
                    linha = $"{m.nome};{m.turno};{m.horario};{m.mbti};";
                    sw.WriteLine(linha);
                }
            }
        }
        static void SalvaPadrinho(LinkedList<Padrinho> list, string Name)
        {
            string path = Config.Saida;
            using (StreamWriter sw = new StreamWriter(Path.Combine(path, $"{Name}SemMatch.csv")))
            {
                string linha = $"Nome;Ocupacao;Horario;MBTI;AfilhadosMax;";
                sw.WriteLine(linha);
                foreach (Padrinho m in list)
                {
                    linha = $"{m.nome};{m.ocupacao};{m.horario};{m.mbti};{m.maxAfilhado.ToString()};";
                    sw.WriteLine(linha);
                }

            }

        }



    }
}
