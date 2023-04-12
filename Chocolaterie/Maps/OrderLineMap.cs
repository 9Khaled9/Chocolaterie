using Chocolaterie.Entities;
using Chocolaterie.Maps.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolaterie.Maps
{
    public class OrderLineMap : EntityMapBase<OrderLine>
    {
        public override void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            base.Configure(builder);
        }
    }
}
