using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_girafales.Dominio.Entidades
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectId { get; set; } = string.Empty; // código único da matéria

        public int Code { get; set; }

        public string Name { get; set; } = string.Empty;

        // 🔹 Muitos professores podem ensinar uma mesma matéria
        public ICollection<Professor> Professors { get; set; } = new List<Professor>();

        public ICollection<Class> Classes { get; set; } = new List<Class>();
        public ICollection<SubjectPrerequisite> Prerequisites { get; set; } = new List<SubjectPrerequisite>();

    }
}