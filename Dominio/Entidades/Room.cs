using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_girafales.Dominio.Entidades
{
    public class Room
    {
        public int Id { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; } = null!;
        public ICollection<ClassSchedule> Schedules { get; set; } = new List<ClassSchedule>();



    }
}