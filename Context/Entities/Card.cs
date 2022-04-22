using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI.Context.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }        
        public int TempoPrevisto { get; set; }
        public int TempoCorrido { get; set; }
        public DateTime DataPrevista { get; set; }
        public int ProjetoId { get; set; }        
        public Projeto Projeto { get; set; }
        public List<Colaborador_Card> Colaborador_Card { get; set; }  
        public int ColunaId { get; set; }
        public Coluna Coluna { get; set; }

        public int Posicao { get; set; }
        public Status Status { get; set; }
    }
}
