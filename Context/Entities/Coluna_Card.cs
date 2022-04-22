using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI.Context.Entities
{
    public class Coluna_Card
    {
        public int Id { get; set; }

        public int ColunaId { get; set; }
        public Coluna Coluna { get; set; }

        public int CardId { get; set; }

        public Card Card { get; set; }

        public int Posicao { get; set; }
    }
}
