using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder) 
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(p => p.TotalCost)
                .HasColumnType("decimal(18,2)");

            builder
                .HasOne(t => t.Freelancer)
                .WithMany(f => f.FreelanceProjects)
                .HasForeignKey(t => t.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Client)
                .WithMany(f => f.OwnedProjects)
                .HasForeignKey(t => t.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(p => p.TotalCost)
                .HasColumnType("decimal(18,2)");
        }
    }
}
