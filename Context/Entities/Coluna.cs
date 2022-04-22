using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI.Context.Entities
{
    public class Coluna
    {
       
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Card> Card { get; set; }


    }
}
