using Chocolaterie.Entities;
using Chocolaterie.Maps.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolaterie.Maps
{
    public class WholeSalerMap : EntityMapBase<WholeSaler>
    {
        public override void Configure(EntityTypeBuilder<WholeSaler> builder)
        {
            base.Configure(builder);
        }
    }
}
