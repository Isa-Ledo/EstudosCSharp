using Estudo.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estudo.Repositorio
{
    public class InsulfimeRepositorio
    {
        private List<Insulfilme> Insulfimes = new List<Insulfilme>()
        {
            new Insulfilme(){Id = 1, Marca = "3M", TransparenciaPorcentagem = 50},
            new Insulfilme(){Id = 2, Marca = "3M", TransparenciaPorcentagem = 100}
        };

        public Insulfilme BuscarInsulfilmePorId(int id)
        {
            return Insulfimes.Where(insulfilme => insulfilme.Id == id).FirstOrDefault();
        }

    }
}
