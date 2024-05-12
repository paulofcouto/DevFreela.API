using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{

    public class ProjectCommentConfiguration : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder
            .HasKey(t => t.Id);

            builder
                .HasOne(t => t.Project)
                .WithMany(t => t.Comments)
                .HasForeignKey(t => t.IdProject);

            builder
                .HasOne(t => t.User)
                .WithMany(t => t.Comments)
                .HasForeignKey(t => t.IdUser);
        }
    }
}
