using System;
using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface IRouteSpecification :  ISpecification<IItinerary>, IValueObject<IRouteSpecification>
    {
        ILocation origin();
        ILocation destination();
        IArrivalDeadline arrival_dealine();
    }
}