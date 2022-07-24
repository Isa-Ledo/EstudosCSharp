using System.Collections.Generic;

namespace VendaDeCarroEstudo
{
    public class CarroRepositorio
    {
        private static List<Carro> carros = new List<Carro>()
        {
            new Carro{Id = 23, Marca = "Toyota", Cor = "Vermelho", CorTeto = "Preto"},
            new Carro{Id = 12, Marca = "Honda", Cor = "Preto", CorTeto = "Rosa"},
            new Carro{Id = 50, Marca = "Tesla", Cor = "Azul", CorTeto = "Verde"}
        };

        public List<Carro> BuscarTodosOsCarros()
        {
            return carros;
        }
    }
}
