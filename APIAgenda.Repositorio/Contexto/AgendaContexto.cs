using APIAgenda.Dominio.Entidades;
using APIAgenda.Repositorio.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAgenda.Repositorio.Contexto
{
    public class AgendaContexto : DbContext
    {


        public AgendaContexto(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<User> User { get; set; }

        public DbSet<Contato> Contato { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new ContatoConfig());

            base.OnModelCreating(modelBuilder);
        }

        private string GetStringConectionConfig()
        {
            string strCon = "Server=DESKTOP-QSCPMAU\\SQL;Database=Agenda;User Id=sa;Password=12345";
            return strCon;
        }

    }
}
