using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_girafales.Dominio.Entidades
{
    public class Professor
    {
        public int Id { get; set; }

        public int TitleId { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public Title Title { get; set; } = null!;
        // 🔹 Professor pode ensinar várias Subjects
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}