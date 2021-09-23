using System;
using System.Collections.Generic;


namespace Dio.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"dados.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] entrada = line.Split(";");
                Conta novaConta = new Conta(tipoconta: (TipoConta)Enum.Parse(typeof(TipoConta), entrada[0]), nome: entrada[1], saldo: double.Parse(entrada[2]), credito: double.Parse(entrada[3]));
                listContas.Add(novaConta);
            }
            file.Close();
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();

                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        break;

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Atualizar();
        }

        private static void Atualizar()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("dados.txt", append: false);
            for (int i = 0; i < listContas.Count; i++)
            {
                file.WriteLineAsync(listContas[i].TipoConta + ";" + listContas[i].Nome + ";" + listContas[i].Saldo + ";" + listContas[i].Credito);
            }
            file.Close();
        }

        private static void Transferir()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("\nNenhuma conta cadastrada!");
                return;
            }
            Console.Write("Digite a conta de origem da transferência:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite a conta de destino da transferência:");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor da transferência:");
            double valorTransferencia = double.Parse(Console.ReadLine());
            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("\nNenhuma conta cadastrada!");
                return;
            }
            Console.WriteLine("#Contas disponíveis: {0}.\nDigite o número da conta:", listContas.Count);
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser depositado");
            double valorDepositvo = double.Parse(Console.ReadLine());
            listContas[indiceConta].Depositar(valorDepositvo);
        }

        private static void Sacar()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("\nNenhuma conta cadastrada!");
                return;
            }
            Console.WriteLine("#Contas disponíveis: {0}.\nDigite o número da conta:", listContas.Count);
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser sacado");
            double valorSaque = double.Parse(Console.ReadLine());
            listContas[indiceConta].Sacar(valorSaque);

        }

        private static void ListarContas()
        {
            Console.WriteLine("\nListar contas");
            if (listContas.Count == 0)
            {
                Console.WriteLine("\nNenhuma conta cadastrada!");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta: ");
            Console.WriteLine("Digite 1 para Conta Física ou 2 para conta Jurídica");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();
            Console.WriteLine("Digite o saldo depositado inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoconta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);
            listContas.Add(novaConta);
            System.IO.StreamWriter file = new System.IO.StreamWriter("dados.txt", append: true);
            file.WriteLineAsync(entradaTipoConta + ";" + entradaNome + ";" + entradaSaldo + ";" + entradaCredito);
            file.Close();
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\nInforme a opção desejada:");
            Console.WriteLine("1 - Listar contas.");
            Console.WriteLine("2 - Inserir nova conta.");
            Console.WriteLine("3 - Transferir.");
            Console.WriteLine("4 - Sacar.");
            Console.WriteLine("5 - Depositar.");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair e atualizar banco e dados");
            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario.ToUpper();
        }
    }
}
