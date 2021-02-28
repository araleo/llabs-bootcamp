using System;

namespace Bank
{
    public class Conta
    {
        private string Nome { get; set; }
        private double Credito { get; set; }
        private double Saldo { get; set; }
        private TipoConta TipoConta { get; set; }

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        public bool Sacar(double valor) 
        {

            if (this.Saldo - valor < this.Credito * -1) {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            this.Saldo -= valor;
            Console.WriteLine("Saque realizado, {0}. Seu saldo atual é: {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valor) 
        {
            this.Saldo += valor;
            Console.WriteLine("Depósito realizado, {0}. Seu saldo atual é: {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valor, Conta contaDestino) 
        {
            if (this.Sacar(valor)) {
                contaDestino.Depositar(valor);
            }
        }

        public override string ToString()
        {
            string output = "";
            output += "TipoConta " + this.TipoConta + " | ";
            output += "Nome " + this.Nome + " | ";
            output += "Saldo " + this.Saldo + " | ";
            output += "Credito " + this.Credito;
            return output;
        }

    }
}