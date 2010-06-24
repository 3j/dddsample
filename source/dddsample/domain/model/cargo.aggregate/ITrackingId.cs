﻿using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface ITrackingId : IValueObject<ITrackingId>
    {
        int GetHashCode();
        string id();
    }
}