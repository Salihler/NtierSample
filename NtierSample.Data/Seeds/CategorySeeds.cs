using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NtierSample.Core.Models;

namespace NtierSample.Data.Seeds
{
    public class CategorySeeds : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _ids;

        public CategorySeeds(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
            (
                new Category{Id = _ids[0], Name = "Kalemler"},
                new Category{Id = _ids[1], Name = "Defterler"}
            );
        }
    }
}