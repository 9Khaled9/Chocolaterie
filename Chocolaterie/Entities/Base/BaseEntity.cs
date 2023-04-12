namespace Chocolaterie.Entities.Base
{
    public abstract class EntityBase : IEntityBase
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
