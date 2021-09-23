using System;
namespace Dio.Bank
{
    public class Conta
    {
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public double Credito { get; set; }
        public TipoConta TipoConta { get; set; }

        public Conta(TipoConta tipoconta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoconta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é: {1}", this.Nome, this.Saldo);
            return true;
        }
        public void Depositar(double valorDepositvo)
        {
            this.Saldo += valorDepositvo;
            Console.WriteLine("Saldo atual da conta de {0} é: {1}", this.Nome, this.Saldo);
        }
        public void Transferir(double valorTransferencia, Conta contadestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contadestino.Depositar(valorTransferencia);
            }
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito;
            return retorno;
        }
    }
}