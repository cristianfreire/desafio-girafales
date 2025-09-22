using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio_girafales.Dominio.DTO;
using desafio_girafales.Dominio.Entidades;

namespace desafio_girafales.Dominio.Interfaces
{
    public interface ISalaServico
    {
        IEnumerable<Class> ObterStatusSalas(int? page = 1, int pageSize = 10);

    }
}