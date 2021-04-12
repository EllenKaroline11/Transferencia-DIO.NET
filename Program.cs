using System;
using System.Collections.Generic;

namespace Dio.Bank
{
    class Program
    {
         static List<conta> listContas = new List<conta>();

        
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
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

                default:
                      throw new ArgumentException();

                }
                 opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utlizar nosso serviço");
            Console.ReadLine();
        }
         private static void Transferir()
         {
            Console.Write("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTrasferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTrasferencia, listContas[indiceContaDestino]);
         }

        private static void Sacar()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

           listContas[indiceConta].Sacar(valorSaque);
        }
         
        
        private static void Depositar()
        {
        Console.Write("Digite o numero da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        Console.Write("Digite o valor a ser depositado: ");
        double ValorDeposito = double.Parse(Console.ReadLine());

        listContas[indiceConta].Depositar(ValorDeposito);
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o credito:");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(TipoConta : (TipoConta) entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listContas.Add(novaConta);                                                        
        }
         private static void ListarContas()
         {
            Console.WriteLine("Listar contas");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            for(int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("# {0} -" , i);
                Console.WriteLine(conta);
            }
         }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO BANK a seu dispor!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair ");
            Console.WriteLine();
 
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
