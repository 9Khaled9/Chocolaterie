using Microsoft.EntityFrameworkCore;

namespace Chocolaterie.Maps.Base
{
    public interface IEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {

    }
}
