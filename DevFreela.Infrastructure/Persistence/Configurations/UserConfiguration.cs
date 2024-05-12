using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DevFreela.Infrastructure.Persistence.Configurations
{

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasMany(t => t.Skills)
                .WithOne()
                .HasForeignKey(t => t.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
