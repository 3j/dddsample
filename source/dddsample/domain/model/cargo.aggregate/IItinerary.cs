using System.Collections.Generic;
using dddsample.domain.model.location.aggregate;
using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface IItinerary : IValueObject<IItinerary>
    {
        ILocation initial_departure_location();
        ILocation final_arrival_location();
        IDate final_arrival_date();
        IList<ILeg> legs();
        int GetHashCode();
    }

    
}