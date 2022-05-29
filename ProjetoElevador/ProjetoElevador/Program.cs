using ProjetoElevador.Model;
using System;
using System.Threading;

namespace ProjetoElevador
{
    public class Program
    {
        private const string SAIR = "s"; //criação da costante de controle de loop.

        public static void Main(string[] args)

        {

            Cabecalho();  //apresentação do Ed.
            Thread.Sleep(2000);

            //inicialização do elevador

            Linha();
            Elevador elevador1 = new Elevador();
            elevador1.Inicializar();
            Linha();
            Thread.Sleep(2000);

            //Console menu.

            bool continuar = true;

            do
            {
                Console.WriteLine(@"Escolha uma opção no menu: 
                    1- Entrar
                    2- Sair
                    3- Finalizar o programa
                ");

                string opcao = Console.ReadLine();

                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        Startar();
                        break;

                    case "2":
                        Elevador elevador = new Elevador();
                       elevador.Sair();

                        break;

                    case "3":
                        Console.WriteLine("Finalizando o programa...", continuar = false);
                        break;

                    default:
                        Console.WriteLine("Opçaõ inválida, tenta novamente.");
                        break;
                }

            } while (continuar);
        }

        public static void Startar()
        {
        Start:   // criação do elevador com 14 andares.
            Console.WriteLine("Ditar 14 para startar o elevador: ");

            int andar; string andarInput; Elevador elevador; //inicialização de variaveis.

            andarInput = Console.ReadLine();
            Console.Clear();

            //validação de dados.
            if (int.TryParse(andarInput, out andar))
            {
                if (andar == 14)
                    elevador = new Elevador(andar);

                else
                {
                    Console.WriteLine("Para startar, digite somente 14");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto Start;
                }

            }

            else
            {
                Console.WriteLine("Para startar, digite somente 14");
                Thread.Sleep(2000);
                Console.Clear();
                goto Start;
            }
            elevador.Entrar();
        }

        //função para o cabeçalho
        public static void Cabecalho()
        {
            Linha();
            Console.WriteLine("*****               SEJA BENVIDO AO ED. OKAPI!               *****");
            Linha();
        }
        //função para criação de linha
        public static void Linha()
        {
            Console.WriteLine("******************************************************************");
        }
        public static void LinhaP()
        {
            Console.WriteLine("**************************");
        }
    }
}
