using Ilithenza.App.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ilithenza.App.DataAccess.ContextConfiguration
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Class");
            builder.HasData(
                new Class
                {
                    ClassId = 1,
                    Name = "Elementalist",
                    Description = "Can manipulate Earth, water, fire, air"
                });
        }
    }
}
