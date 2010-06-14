using System;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface IItinerary
    {
        ILocation initial_departure_location();
        ILocation final_arrival_location();
        IArrivalDeadline final_arrival_date();
    }
}