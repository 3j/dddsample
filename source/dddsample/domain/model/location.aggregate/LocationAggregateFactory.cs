using System;
using dddsample.domain.model.location.aggregate.interfaces;

namespace dddsample.domain.model.location.aggregate
{
    public class LocationAggregateFactory : ILocationFactory
    {
        public ILocation create_location_using(IUnitedNationsLocationCode the_united_nations_location_code, ILocationName the_location_name)
        {
            if (the_united_nations_location_code == null)
                throw new ArgumentNullException("the_united_nations_location_code", "Invariant Violated: a valid United Nations location code is required in order to construct a location.");
            
            if (the_location_name == null)
                throw new ArgumentNullException("the_location_name", "Invariant Violated: a valid location name is required in order to construct a location.");

            return new Location(the_united_nations_location_code, the_location_name);
        }

    }
}