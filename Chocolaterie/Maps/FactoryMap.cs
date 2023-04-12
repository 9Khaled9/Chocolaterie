using Chocolaterie.Entities;
using Chocolaterie.Maps.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace Chocolaterie.Maps
{
    public class FactoryMap : EntityMapBase<Factory>
    {
        public override void Configure(EntityTypeBuilder<Factory> builder)
        {
            base.Configure(builder);
        }
    }
}
