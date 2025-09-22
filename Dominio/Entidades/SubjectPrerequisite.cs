using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_girafales.Dominio.Entidades
{
    public class SubjectPrerequisite
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }
        public int PrerequisiteId { get; set; }
        public Subject Subject { get; set; } = null!;

        public Subject Prerequisite { get; set; } = null!;
    }
}