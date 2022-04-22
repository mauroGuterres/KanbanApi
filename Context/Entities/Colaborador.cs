using KanbanAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI.Context.Entities
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }         
        public List<Colaborador_Card> Colaborador_Card { get; set; }

       
    }
}
