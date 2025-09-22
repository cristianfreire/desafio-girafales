using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio_girafales.Dominio.DTO;
using desafio_girafales.Dominio.Interfaces;
using desafio_girafales.Infraestrutura;

namespace desafio_girafales.Dominio.Servicos
{
    using desafio_girafales.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;

    public class ProfessorServico : IProfessorServico
    {
        private readonly DbContexto _context;

        public ProfessorServico(DbContexto context)
        {
            _context = context;
        }


        public IEnumerable<Professor> Todos(int? page = 1, int pageSize = 10)
        {
            var professores = _context.Professors.AsQueryable();
            int itensPorPage = 10;
            if (page != null)
                professores = professores.Skip(((int)page - 1) * itensPorPage).Take(itensPorPage);
            return professores.ToList();

        }

        /// <summary>
        /// 🔹 Regra de negócio: retorna a quantidade de horas que cada professor tem comprometida em aulas
        /// </summary>
        public IEnumerable<object> HorasComprometidas()
        {
            var query = from professor in _context.Professors
                        join subject in _context.Subjects on professor.Id equals subject.Id into subjGroup
                        from subject in subjGroup.DefaultIfEmpty()
                        join classe in _context.Classes on subject.Id equals classe.SubjectId into classGroup
                        from classe in classGroup.DefaultIfEmpty()
                        join schedule in _context.ClassSchedules on classe.Id equals schedule.ClassId into scheduleGroup
                        from schedule in scheduleGroup.DefaultIfEmpty()
                        group schedule by new { professor.Id, professor.TitleId } into g
                        select new
                        {
                            ProfessorId = g.Key.Id,
                            TitleId = g.Key.TitleId,
                            HorasTotais = g.Sum(s => (s.EndTime - s.StartTime).TotalMinutes) / 60.0
                        };

            return query.ToList();
        }
    }
}