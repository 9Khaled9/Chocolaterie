using Chocolaterie.Entities;
using Chocolaterie.Maps.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolaterie.Maps
{
    public class OrderMap : EntityMapBase<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);
        }
    }
}
