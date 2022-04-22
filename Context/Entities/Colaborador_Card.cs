using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI.Context.Entities
{
    public class Colaborador_Card
    {
        public int Id { get; set; }

        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }

        public int CardId { get; set; }

        public Card Card { get; set; }
    }
}
