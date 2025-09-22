using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_girafales.Dominio.Entidades
{
    public class ClassSchedule
    {
        public int Id { get; set; }

        public int ClassId { get; set; }
        public int RoomId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        
        public Class Class { get; set; } = null!;
        public Room Room { get; set; } = null!;

  
    }
}