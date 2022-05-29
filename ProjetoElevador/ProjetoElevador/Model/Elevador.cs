using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoElevador.Model
{
    public class Elevador //construção do Elevador em si.
    {
        private const string SAIR = "s";
        //inicialização de parámetros.
        private bool[] terreo;
        public int andarAtual = 1;
        private int ultimoAndar;
        public int totAndar;
        public float capacitElevador;
        public int totPessoas;
        public EstadoElevador Estado = EstadoElevador.PARADO;

        //constructor da classe
        public Elevador (int totAndar = 14)
        {
            terreo = new bool[totAndar + 1];
            ultimoAndar = totAndar;
        }

        //métodos da classe.

        public void Inicializar(float capacitElevador = 450, int totPessoas = 5) //para inicializar
        {
            Console.WriteLine("A Capacidade Máxima deste Elevador é de {0} Kgs e Suporta {1} pessoas", capacitElevador, totPessoas);
        }
        public void Entrar(int andar = 14, int totPessoas = 5, int pessoNoElevador = 0) //para entrar no elevador.
        {
            string input = string.Empty;
            while (input != SAIR)
            {
                Console.WriteLine("Digite o andar que desaja ir ou s para voltar para o menu principal.");
                input = Console.ReadLine();
                Console.Clear();
                if (int.TryParse(input, out andar)) //validadação de dados.
                {
                    if (andar <= 14)
                    {
                        if (int.TryParse(input, out andar))
                        {
                            EscolhaAndar(andar);

                        }
                        else if (input == SAIR)
                        {
                            Console.WriteLine("Voltando para o menu principal");
                            Thread.Sleep(1000);
                        }
                        else
                            Console.WriteLine("Este andar não existe, digite novamente");
                        pessoNoElevador++;
                        if (pessoNoElevador <= totPessoas)
                            Console.WriteLine("Voce pode entrar");
                        else

                        {
                            Console.WriteLine("Infelizmente não tem mais espaço");
                            Console.WriteLine("Espere outro Elevador.");
                            Thread.Sleep(2000);
                            Console.Clear();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("O elevador só tem {0} andares", ultimoAndar);
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
            }

        }
        public void Sair(int andar = 14, int totPessoas = 5, int pessoNoElevador = 5) //para sair no elevador
        {
            string input = string.Empty;
            while (input != SAIR)
            {
                Console.WriteLine("Digite o andar que desaja ir ou s para voltar para o menu principal.");
                input = Console.ReadLine();
                Console.Clear();
                if (int.TryParse(input, out andar)) //validação de dados.
                {
                    if (andar <= 14)

                    {
                        if (int.TryParse(input, out andar))
                        {
                            EscolhaAndar(andar);

                        }
                        else if (input == SAIR)
                        {
                            Console.WriteLine("Voltando para o menu principal");
                            Thread.Sleep(1000);
                        }
                        else
                            Console.WriteLine("Este andar não existe, digite novamente");
                        pessoNoElevador--;
                        if (pessoNoElevador > 0)
                            Console.WriteLine("Voce pode sair");
                        else

                        {
                            Console.WriteLine(" Opa! O Elevador vazio!");
                            Thread.Sleep(2000);
                            Console.Clear();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("O elevador só tem {0} andares", ultimoAndar);
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
            }
        }
        private void Para(int andar) //para parar.
        {
            Estado = EstadoElevador.PARADO;
            andarAtual = andar;
            terreo[andar] = false;
        }
        private void Subir(int andar) //para subir.
        {
            for (int i = andarAtual; i <= ultimoAndar; i++)
            {
                if (terreo[i])
                    Para(andar);
                else
                    continue;
            }
            Estado = EstadoElevador.PARADO;
            Console.WriteLine("Subindo...");
        }
        private void Descer(int andar) //para descer.
        {
            for (int i = andarAtual; i >= 1; i--)
            {
                if (terreo[i])
                    Para(andar);
                else
                    continue;
            }
            Estado = EstadoElevador.PARADO;
            Console.WriteLine("Desendo...");
        }
        void Destino() //para o destino escolhido.
        {
            Console.WriteLine("Chegou no seu destino.");
        }
        public void EscolhaAndar(int andar) //contrala a ação de subir e descer.
        {
            if (andar > ultimoAndar)
            {
                Console.WriteLine("O elevador só tem {0} andares", ultimoAndar);
                return;
            }

            terreo[andar] = true;

            switch (Estado)
            {
                case EstadoElevador.ABAIXO:
                    Descer(andar);
                    break;

                case EstadoElevador.PARADO:
                    if (andarAtual < andar)
                        Subir(andar);
                    else if (andarAtual == andar)
                        Destino();
                    else
                        Descer(andar);
                    break;

                case EstadoElevador.ACIMA:
                    Subir(andar);
                    break;

                default:
                    break;
            }
        }
        public enum EstadoElevador
        {
            ACIMA,
            PARADO,
            ABAIXO
        }

        
    }
  
}
