using System;
using System.Collections.Generic;
using System.Text;

namespace Estudo.Entidades
{
    public class Carro
    {
        public string Placa { get; set; }

        public int QuantidadePortas { get; set; }

        public int QuantidadeBancos { get; set; }

        public int QuantidadePneus { get; set; }

        public string Cor { get; set; }

        public string CorTeto { get; set; }

        public string Marca { get; set; }

        public Insulfilme Insulfilme { get; set; }

        public void MudaCorCarro(string novaCor)
        {
            Cor = novaCor;
        }

        public void MudaCorTeto(string corTeto)
        {
            CorTeto = corTeto;
        }

        public void AdicionaInsulfilme(Insulfilme novoInsulfilme)
        {
            Insulfilme = novoInsulfilme;
        }

    }
}
