using System;
using System.Collections.Generic;
using System.Linq;

namespace VendaDeCarroEstudo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var insulfilmRepositorio = new InsulfilmRepositorio();
            var carroRepositorio = new CarroRepositorio();

            while (true)
            {
                Console.Clear();
                var nomeDigitado = DigiteNaTelaEObtemResposta("Digite seu nome: ");
                var carros = carroRepositorio.BuscarTodosOsCarros();

                Carro carroEscolhido = null;
                carroEscolhido = MenuEscolheCarro(nomeDigitado, carros, carroEscolhido);
                MenuAcessorios(insulfilmRepositorio, nomeDigitado, carroEscolhido);
            }
        }

        private static void MenuAcessorios(InsulfilmRepositorio insulfilmRepositorio, string nomeDigitado, Carro carroEscolhido)
        {
            var insulfilms = insulfilmRepositorio.BuscarTodosOsInsulfilm();
            var resposta = DigiteNaTelaEObtemResposta($"{nomeDigitado}, deseja adicionar insulfilm? 1 para SIM e 2 para NÃO!");
           
            if (resposta == "1")
            {
                Insulfilm insulfilmEscolhido = null;
                while (insulfilmEscolhido == null)
                {
                    Console.WriteLine("As opções de insulfilm são: ");
                    foreach (var insulfilm in insulfilms)
                    {
                        Console.WriteLine($"Codigo: {insulfilm.Id}, Marca: {insulfilm.Marca}, Transparência: {insulfilm.TransparenciaPorcentagem}");
                    }

                    var opcaoInsulfilmEscolhido = int.Parse(DigiteNaTelaEObtemResposta("Digite o código do insulfilm escolhido: "));
                    insulfilmEscolhido = insulfilms.Where(insulfilmDaLista => insulfilmDaLista.Id == opcaoInsulfilmEscolhido).FirstOrDefault();

                    if (insulfilmEscolhido == null)
                    {
                        Console.WriteLine("Codigo inválido.");
                    }
                    else
                    {
                        carroEscolhido.Insulfilm = insulfilmEscolhido;
                        Console.WriteLine($"Voce escolheu o carro:\r\nCodigo: {carroEscolhido.Id}, Marca: {carroEscolhido.Marca}, Cor: {carroEscolhido.Cor}, Cor do teto: {carroEscolhido.CorTeto},\r\nInsulfilm: Id {carroEscolhido.Insulfilm.Id}, Marca {carroEscolhido.Insulfilm.Marca}, Transparencia {carroEscolhido.Insulfilm.TransparenciaPorcentagem}");
                        Console.ReadLine();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Voce escolheu o carro:\r\nCodigo: {carroEscolhido.Id}, Marca: {carroEscolhido.Marca}, Cor: {carroEscolhido.Cor}, Cor do teto: {carroEscolhido.CorTeto}, sem insulfilm");
                Console.ReadLine();
            }
        }

        private static Carro MenuEscolheCarro(string nomeDigitado, List<Carro> carros, Carro carroEscolhido)
        {
            while (carroEscolhido == null)
            {
                Console.WriteLine($"{nomeDigitado}, as opções de carro são: ");
                foreach (var carro in carros)
                {
                    Console.WriteLine($"Codigo: {carro.Id}, Marca: {carro.Marca}, Cor: {carro.Cor}, Cor do teto: {carro.CorTeto}");
                }

                var codigoDigitado = int.Parse(DigiteNaTelaEObtemResposta("Digite o código do carro escolhido: "));
                carroEscolhido = carros.Where(carroDaLista => carroDaLista.Id == codigoDigitado).FirstOrDefault();
               
                if (carroEscolhido == null)
                    Console.WriteLine("Codigo inválido.");
                else
                    Console.WriteLine($"Voce escolheu o carro:\r\nCodigo: {carroEscolhido.Id}, Marca: {carroEscolhido.Marca}, Cor: {carroEscolhido.Cor}, Cor do teto: {carroEscolhido.CorTeto}");
            }

            return carroEscolhido;
        }

        private static string DigiteNaTelaEObtemResposta(string mensagem)
        {
            Console.WriteLine(mensagem);
            string informacaoDigitada = Console.ReadLine();
            return informacaoDigitada;
        }

    }
}
