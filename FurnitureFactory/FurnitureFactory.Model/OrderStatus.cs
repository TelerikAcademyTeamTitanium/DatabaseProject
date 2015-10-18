namespace FurnitureFactory.Model
{
    using System;

    public enum OrderStatus
    {
        InProgress = 1,
        Completed = 2,
        PartiallyShipped = 3,
        Cancelled = 4,
        OnHold = 5,
    }
}
