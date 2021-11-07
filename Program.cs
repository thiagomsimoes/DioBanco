using System;
using System.Collections.Generic;

namespace Dio.Banco
{
    class Program
    {
        static List<Conta> listcontas  = new List<Conta>();
        //Armazenamento em memória das contas    
        static void Main(string[] args)
        {
        
        string opcaousuario = Obteropcaousuario();
        
        while (opcaousuario!="X")
        {
            switch (opcaousuario)
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
                    throw new ArgumentOutOfRangeException();

              }

            opcaousuario = Obteropcaousuario();
             

        }
        Console.WriteLine("Obrigado por usar os serviços do banco DIO! Volte Sempre!");
        Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o Código da Conta:");
            int conta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Valor de Depósito:");
            double valor_deposito = double.Parse(Console.ReadLine());

            listcontas[conta].Depositar(valor_deposito);

        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o Código da Conta:");
            int conta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor de saque:");
            double valor_saque = double.Parse(Console.ReadLine());

            listcontas[conta].Sacar(valor_saque);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o Código da Conta Origem:");
            int conta_origem = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Código da Conta Destino:");
            int conta_destino = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Valor da Transferência:");
            double valor_transferencia = double.Parse(Console.ReadLine());
            
            listcontas[conta_origem].Transferir(valor_transferencia,listcontas[conta_destino]);
                    

        }

        private static void ListarContas()
        {
            
            if(listcontas.Count==0)
                {
                    Console.WriteLine("======= Nenhuma conta cadastrada! =======");
                    return;
                }
            
           
                
            for (int i=0; i<listcontas.Count; i++)
                 {
                    Console.Write("#{0} -",i);
                    Conta contas = listcontas[i];
                    Console.WriteLine(contas);

                }

                
        }

        private static void InserirConta()
        {
            Console.WriteLine("Para contas Pessoa Física, digite 1 \nPara Contas Pessoa Jurídica digite 2");
            int entradatipoconta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Nome do Cliente:");
            string entradanome = Console.ReadLine();
            Console.WriteLine("Digite o Saldo:");
            double entradasaldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Crédito disponível:");
            double entradacredito = double.Parse(Console.ReadLine());

            Conta novaconta = new Conta(tipoConta:(TipoConta) entradatipoconta,
                                        nome:entradanome,
                                        saldo:entradasaldo,
                                        credito:entradacredito);

            // Conversão explícita para o tipo TipoConta (ENUM)

            listcontas.Add(novaconta);
        }

        public static string Obteropcaousuario()
        {
            Console.WriteLine ("\nSeja bem-vindo ao Dio Banco!");
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1-Listar Contas");
            Console.WriteLine("2-Inserir nova conta");
            Console.WriteLine("3-Transferir");
            Console.WriteLine("4-Sacar");
            Console.WriteLine("5-Depositar");
            Console.WriteLine("C-Limpar Tela");
            Console.WriteLine("X-Sair");
            Console.WriteLine();

            string opcaousuario = Console.ReadLine().ToUpper();
            
            return opcaousuario;

        }     

    }
}
