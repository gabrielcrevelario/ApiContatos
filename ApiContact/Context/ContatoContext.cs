using ApiContact.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace ApiContact.Context
{


    public class ContatoContext : DbContext
    {
        public ContatoContext() : base(@"Server=(localdb)\mssqllocaldb;Database=ContatosDb;Trusted_Connection=True;")
        {
           Database.SetInitializer<ContatoContext>(new CreateDatabaseIfNotExists<ContatoContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>().HasKey(t => t.Id)
                 .Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Contato>().Property(x => x.Nome).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Contato>().Property(x => x.Valor).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Contato>().Property(x => x.Canal).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Contato>().Property(x => x.Obs).HasMaxLength(150);
        }

        public DbSet<Contato> Contatos { get; set; }
    }
}