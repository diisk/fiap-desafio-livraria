using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasOne(l => l.Estoque)
                .WithOne(e => e.Livro).HasPrincipalKey<Estoque>(e => e.ID);

            builder.HasMany(l => l.ClientesAlugando)
                .WithMany(c => c.LivrosAlugados);
        }
    }
}
