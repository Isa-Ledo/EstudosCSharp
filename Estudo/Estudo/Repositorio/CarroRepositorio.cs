using Estudo.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estudo.Repositorio
{
    public class CarroRepositorio
    {
        private static List<Carro> carros = new List<Carro>() {
            new Carro{Cor = "Vermelho", Marca = "Citroen", Placa = "GIG7C23" },
            new Carro{Cor = "Cinza", Marca = "Chevrolet", Placa = "KLP2D93"},
            new Carro{Cor = "Branco", Marca = "Toyota", Placa = "123test"}
        };
        public List<Carro> BuscarTodosOsCarros()
        {
            return carros;
        }

        public Carro BuscarCarroPorPlaca(string placa)
        {
            return carros.Where(carro => carro.Placa.ToUpper() == placa.ToUpper()).FirstOrDefault();
        }
    }
}
