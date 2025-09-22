using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_girafales.Dominio.Entidades
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Room> Rooms { get; set; } = new List<Room>();

    }
}