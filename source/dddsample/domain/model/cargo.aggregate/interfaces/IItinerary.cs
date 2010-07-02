using System.Collections.Generic;
using dddsample.domain.model.handling.aggregate;
using dddsample.domain.model.handling.aggregate.interfaces;
using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.location.aggregate.interfaces;
using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate.interfaces
{
    public interface IItinerary : IValueObject<IItinerary>
    {
        ILocation initial_departure_load_location();
        ILocation final_arrival_unload_location();
        IDate final_arrival_date();
        IList<ILeg> associated_legs();
        bool was_expecting(IHandlingEvent the_handling_event);
        int GetHashCode();
    }
}