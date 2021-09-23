using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            string opcaoUsuario = ObterOpcaoUsuario();
            int indiceAluno = 0;
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    Console.WriteLine("Informe o nome do aluno:");
                    Aluno aluno = new Aluno();
                    aluno.Nome = Console.ReadLine();
                    Console.WriteLine("Informe a nota do aluno:");
                    if(decimal.TryParse(Console.ReadLine(), out decimal nota)){
                    aluno.Nota = nota;
                    }
                    else{
                        throw new ArgumentOutOfRangeException("Valor da nota deve ser decimal");
                    }
                    alunos[indiceAluno] = aluno;
                    indiceAluno++;
                        break;
                    case "2":
                    
                    foreach(var a in alunos){
                        if(!string.IsNullOrEmpty(a.Nome)){
                        Console.WriteLine($"Nome do aluno: {a.Nome} - Nota do aluno: {a.Nota}");}
                    }
                        break;
                    case "3":
                    decimal notaTotal = 0;
                    var nrAlunos = 0;
                    for(int i=0; i<alunos.Length;i++){
                            if(!string.IsNullOrEmpty(alunos[i].Nome)){
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                                }
                    }
                    var mediaGeral = notaTotal/nrAlunos;
                    Console.WriteLine($"Média geral: {mediaGeral}");
                    Conceito conceitoGeral;
                    if (mediaGeral<3)
                    {
                        conceitoGeral = Conceito.E;
                    }
                    else if (mediaGeral<4)
                    {
                        conceitoGeral = Conceito.D;
                    }
                    else if (mediaGeral<6)
                    {
                        conceitoGeral = Conceito.C;
                    }
                    else if (mediaGeral<8)
                    {
                        conceitoGeral = Conceito.B;
                    }
                    else {
                        conceitoGeral = Conceito.A;
                    }
                    Console.WriteLine($"Conceito:{conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\nInforme a opção desejada");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - para sair\n");
            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
