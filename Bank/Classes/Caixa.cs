using System;
using System.Collections.Generic;

namespace Bank
{
    public class Caixa
    {

        private List<Conta> Contas { get; set; }

        public Caixa()
        {
            this.Contas = new List<Conta>();
        }

        private void ListarContas()
        {
            Console.WriteLine("Listar contas");
            
            if (this.Contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 0; i < this.Contas.Count; i++)
            {
                Conta conta = this.Contas[i];
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine("{0}", conta);
            }
        }
        
        private void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para PF ou 2 para PJ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente");
            string nome = Console.ReadLine();

            int saldo = 0;
            int credito = tipoConta == 1 ? 500 : 1000;

            Conta novaConta = new Conta((TipoConta) tipoConta, nome, saldo, credito);
           this.Contas.Add(novaConta);

        }

        private void Transferir()
        {
            int contaOrigem = GetNumConta();
            int contaDestino = GetNumConta();
            double valor = GetValor();
            this.Contas[contaOrigem].Transferir(valor, this.Contas[contaDestino]);
        }

        private void Sacar()
        {
            int numConta = GetNumConta();
            double valor = GetValor();
            this.Contas[numConta].Sacar(valor);
        }

        private void Depositar()
        {
            int numConta = GetNumConta();
            double valor = GetValor();
            this.Contas[numConta].Depositar(valor);
        }

        private int GetNumConta()
        {
            Console.WriteLine("Digite o número da conta");
            return int.Parse(Console.ReadLine());
        }

        private double GetValor()
        {
            Console.WriteLine("Digite o valor");
            return double.Parse(Console.ReadLine());
        }

        public void AtenderUsuario()
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        this.ListarContas();
                        break;
                    case "2":
                        this.InserirConta();
                        break;
                    case "3":
                        this.Transferir();
                        break;
                    case "4":
                        this.Sacar();
                        break;
                    case "5":
                        this.Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                                                                                                                                                                        
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar nossos serviços");

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1. Listar contas");
            Console.WriteLine("2. Nova conta");
            Console.WriteLine("3. Transferir");
            Console.WriteLine("4. Sacar");
            Console.WriteLine("5. Depositar");
            Console.WriteLine("C. Limpar tela");
            Console.WriteLine("X. Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }

    }
}