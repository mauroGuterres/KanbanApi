

using System.Collections.Generic;

namespace KanbanAPI.Context.Entities
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Card> Card { get; set; }
    }
}
