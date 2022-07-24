using System.Collections.Generic;
using System.Linq;

namespace VendaDeCarroEstudo
{
    public class InsulfilmRepositorio
    {
        private List<Insulfilm> Insulfilms= new List<Insulfilm>()
        {
            new Insulfilm(){Id = 1, Marca = "3M", TransparenciaPorcentagem = 50},
            new Insulfilm(){Id = 2, Marca = "3M", TransparenciaPorcentagem = 100}
        };

        public List<Insulfilm> BuscarTodosOsInsulfilm()
        {
            return Insulfilms;
        }

        public Insulfilm BuscarInsulfilmPorId(int id)
        {
            return Insulfilms.Where(insulfilm => insulfilm.Id == id).FirstOrDefault();
        }
    }
}
