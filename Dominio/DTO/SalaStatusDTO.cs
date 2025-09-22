using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_girafales.Dominio.DTO
{
    public class SalaStatusDTO
    {
        public int SalaId { get; set; }
        public string Predio { get; set; } = string.Empty;
        public string DiaDaSemana { get; set; } = string.Empty;
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFim { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}