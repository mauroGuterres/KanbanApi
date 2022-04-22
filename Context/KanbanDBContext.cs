using KanbanAPI.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanAPI.Context
{
    public class KanbanDBContext : DbContext
    {
        public KanbanDBContext(DbContextOptions<KanbanDBContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projeto>().HasMany(p => p.Card).WithOne(c => c.Projeto);
            modelBuilder.Entity<Coluna>().HasMany(p => p.Card).WithOne(c => c.Coluna);
            modelBuilder.Entity<Colaborador_Card>().HasOne(p => p.Card).WithMany(e => e.Colaborador_Card).HasForeignKey(c => c.CardId);
            modelBuilder.Entity<Colaborador_Card>().HasOne(p => p.Colaborador).WithMany(e => e.Colaborador_Card).HasForeignKey(c => c.ColaboradorId);                      
            modelBuilder.Entity<Coluna>()
            .HasKey(p => new { p.Id });
            modelBuilder.Entity<Coluna>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Projeto>()
           .HasKey(p => new { p.Id });
            modelBuilder.Entity<Projeto>().Property(p => p.Id).ValueGeneratedOnAdd();


            modelBuilder.Entity<Colaborador>().HasData(
                    new Colaborador
                    {
                        Id = 1,
                        Nome = "Mauro Guterres",
                    },
                    new Colaborador
                    {
                        Id = 2,
                        Nome = "Afonso Solano",
                    },
                    new Colaborador
                    {
                        Id = 3,
                        Nome = "Anderson Gaveta",
                    }
                );

            modelBuilder.Entity<Projeto>().HasData(
                new Projeto
                {
                    Id = 1,
                    Nome = "Some Company"                    
                },
                new Projeto
                {
                    Id = 2,
                    Nome = "Some Group"
                },
                new Projeto
                {
                    Id = 3,
                    Nome = "Some Corp"
                }
            );
            modelBuilder.Entity<Card>().HasData(
                new Card { Id = 1,  ProjetoId = 1,Titulo = "Criar Relatório", Descricao= "Criação de relatórios para asdrubal company", TempoPrevisto = 120,TempoCorrido = 0, DataPrevista = DateTime.Now.AddDays(3), Codigo = "XYB-12345", ColunaId = 1, Posicao = 1 },
                new Card { Id = 2, ProjetoId = 1, Titulo = "Criar Sorteador", Descricao = "Criação de sofware sorteador de números para asdrubal company", TempoPrevisto = 60, TempoCorrido = 0, DataPrevista = DateTime.Now.AddDays(2), Codigo = "XYA-12345", ColunaId = 1, Posicao = 2 },
                new Card { Id = 3, ProjetoId = 2, Titulo = "Criar Listagem", Descricao = "Criação de listagem para asdrubal group", TempoPrevisto = 60, TempoCorrido = 0,  DataPrevista = DateTime.Now.AddDays(5), Codigo = "XYC-12345", ColunaId = 2, Posicao = 1 },
                new Card { Id = 4,  ProjetoId = 3, Titulo = "Criar Paginação", Descricao = "Criação de paginação para asdrubal corp", TempoPrevisto = 90, TempoCorrido = 0, DataPrevista = DateTime.Now.AddDays(7), Codigo = "XYP-12345", ColunaId = 2, Posicao = 2 }
            );

            modelBuilder.Entity<Colaborador_Card>().HasData(
               new Colaborador_Card { Id = 1, ColaboradorId = 1, CardId = 1},
               new Colaborador_Card { Id = 2, ColaboradorId = 1, CardId = 2 },
               new Colaborador_Card { Id = 3, ColaboradorId = 2, CardId = 3 },
               new Colaborador_Card { Id = 4, ColaboradorId = 3, CardId = 4 }
           );

            modelBuilder.Entity<Coluna>().HasData(
              new Coluna { Id = 1, Nome = "Aguardando" },
              new Coluna { Id = 2, Nome = "Em Andamento" },
              new Coluna { Id = 3, Nome = "Pendência" },
              new Coluna { Id = 4, Nome = "Finalizado" },
              new Coluna { Id = 5, Nome = "Outros" }
          );

            
        }

        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Coluna> Coluna { get; set; }
        public DbSet<Colaborador_Card> Colaborador_Card { get; set; }
        

    }
}
