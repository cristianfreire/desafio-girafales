using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_girafales.Dominio.Entidades
{
    public class Class
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public string Code { get; set; } = string.Empty;
        public Subject Subject { get; set; } = null!;


        public ICollection<ClassSchedule> Schedules { get; set; } = new List<ClassSchedule>();

    }
}