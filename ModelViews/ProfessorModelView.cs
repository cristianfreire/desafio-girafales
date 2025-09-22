using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_girafales.ModelViews
{
    public class ProfessorModelView
    {
        public int Id { get; set; }
        public string Department { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}