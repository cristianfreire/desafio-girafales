using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio_girafales.Dominio.DTO;
using desafio_girafales.Dominio.Entidades;
using desafio_girafales.Dominio.Interfaces;
using desafio_girafales.Infraestrutura;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace desafio_girafales.Dominio.Servicos
{

    public class SalaServico : ISalaServico
    {

        private readonly DbContexto _context;



        public SalaServico(DbContexto context)
        {
            _context = context;
        }

        public IEnumerable<Class> ObterStatusSalas(int? page = 1, int pageSize = 10)
        {
            var salas = _context.Classes.AsQueryable();
            int itensPorPage = 10;
            if (page != null)
                salas = salas.Skip(((int)page - 1) * itensPorPage).Take(itensPorPage);
            return salas.ToList();
        }
    }
}