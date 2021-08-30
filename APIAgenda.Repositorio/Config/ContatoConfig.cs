using APIAgenda.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAgenda.Repositorio.Config
{
    public class ContatoConfig : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(u => u.Id);

            builder
            .Property(u => u.Nome)
            .IsRequired()
            .HasMaxLength(50);

            builder
                .Property(u => u.Telefone)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(u => u.UserId)
                .IsRequired();

            builder.HasOne(p => p.User);
        }
    }
}
