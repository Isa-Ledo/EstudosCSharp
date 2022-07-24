using Estudo.Entidades;
using Estudo.Repositorio;
using System;

namespace Estudo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();
                var placaDigitada = DigiteNaTelaEObtemResposta("Digite a placa do seu carro");

                var carroRepositorio = new CarroRepositorio();
                var carroBuscado = carroRepositorio.BuscarCarroPorPlaca(placaDigitada);
                
                if (carroBuscado == null)
                {
                    Console.WriteLine($"Carro não encontrado para a placa informada: {placaDigitada}");
                }
                else
                {
                    var executaMenu = "1";
                    while (executaMenu == "1")
                    {
                        Console.WriteLine($"Carro encontrado, marca: {carroBuscado.Marca} e cor {carroBuscado.Cor}");
                        MenuPrincipal(carroBuscado);
                        executaMenu = DigiteNaTelaEObtemResposta("Digite 1 para voltar para o menu anterior ou 2 para sair");
                    }
                }
            }
        }

        private static void MenuPrincipal(Carro carroBuscado)
        {
            var respostaMenu = DigiteNaTelaEObtemResposta("Menu: Digite 1 para colocar insulfilme, 2 para trocar a cor ou 3 para trocar a cor do teto");

            if (respostaMenu == "1")
                AdicionaInsulfilmeNoCarro(carroBuscado);
            else if (respostaMenu == "2")
                TrocaCorNoCarro(carroBuscado);
            else if (respostaMenu == "3")
                TrocaCorDoTeto(carroBuscado);
            else
                Console.WriteLine("Opção inválida");
        }

        private static void TrocaCorNoCarro(Carro carroBuscado)
        {
            var novaCor = DigiteNaTelaEObtemResposta("Qual a Cor do seu carro");
            carroBuscado.MudaCorCarro(novaCor);
        }

        private static void TrocaCorDoTeto(Carro carroBuscado) 
        {
            var corTeto = DigiteNaTelaEObtemResposta("Qual a Cor do teto?");
            carroBuscado.MudaCorTeto(corTeto);
            Console.WriteLine($"A nova cor do teto é {carroBuscado.CorTeto}");
        }

        private static void AdicionaInsulfilmeNoCarro(Carro carroBuscado)
        {
            var insulfimeEscolhido = int.Parse(DigiteNaTelaEObtemResposta("Qual insulfilme você quer, digite 1 para 3M 50% ou 2 para 3M 100%"));
            var insulfilmeRepositorio = new InsulfimeRepositorio();
            var insulfilmeEncontrado = insulfilmeRepositorio.BuscarInsulfilmePorId(insulfimeEscolhido);
            carroBuscado.AdicionaInsulfilme(insulfilmeEncontrado);
        }

        private static string DigiteNaTelaEObtemResposta(string mensagem)
        {
            Console.WriteLine(mensagem);
            string placaDigitada = Console.ReadLine();
            return placaDigitada;
        }
    }
}
