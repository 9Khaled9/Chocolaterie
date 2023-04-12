using Chocolaterie.Entities;
using Chocolaterie.Maps.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace Chocolaterie.Maps
{
    public class ChocolateBarMap : EntityMapBase<ChocolateBar>
    {
        public override void Configure(EntityTypeBuilder<ChocolateBar> builder)
        {
            base.Configure(builder);
        }
    }
}
