using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio_girafales.Dominio.DTO;
using desafio_girafales.Dominio.Entidades;

namespace desafio_girafales.Dominio.Interfaces
{
    public interface IProfessorServico
    {
        IEnumerable<Professor> Todos(int? page = 1, int pageSize = 10);

        // 🔹 Regra de negócio: calcular carga horária
        IEnumerable<object> HorasComprometidas();
    }
}