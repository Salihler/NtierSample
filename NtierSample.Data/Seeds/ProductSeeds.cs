using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NtierSample.Core.Models;

namespace NtierSample.Data.Seeds
{
    public class ProductSeeds : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;

        public ProductSeeds(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
            (
                new Product {Id = 1, Name = "Pilot Kalem", Price = 12.50m, Stock = 100, CategoryId=_ids[0]},
                new Product {Id = 2, Name = "Kurşun Kalem", Price = 40.50m, Stock = 300, CategoryId=_ids[0]},
                new Product {Id = 3, Name = "Tükenmez Kalem", Price = 500m, Stock = 200, CategoryId=_ids[0]},
                new Product {Id = 4, Name = "Küçük Boy Defter", Price = 12.50m, Stock = 100, CategoryId=_ids[1]},
                new Product {Id = 5, Name = "Orta Boy Defter", Price = 12.50m, Stock = 100, CategoryId=_ids[1]},
                new Product {Id = 6, Name = "Büyük Boy Defter", Price = 12.50m, Stock = 100, CategoryId=_ids[1]}
            );
        }
    }
}