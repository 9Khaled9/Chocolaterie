using Chocolaterie.Entities;
using Chocolaterie.Maps.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace Chocolaterie.Maps
{
    public class DiscountMap : EntityMapBase<Discount>
    {
        public override void Configure(EntityTypeBuilder<Discount> builder)
        {
            base.Configure(builder);
        }
    }
}
