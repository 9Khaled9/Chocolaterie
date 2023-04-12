﻿namespace Chocolaterie.Entities.Base
{
    public interface IEntityBase
    {
        int Id { get; set; }

        bool IsDeleted { get; set; }
    }
}
