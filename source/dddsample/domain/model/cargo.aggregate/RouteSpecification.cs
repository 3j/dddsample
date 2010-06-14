using System;

namespace dddsample.domain.model.cargo.aggregate
{
    public class RouteSpecification : IRouteSpecification
    {
        readonly ILocation underlying_origin_location;
        readonly ILocation underlying_destination_location;
        readonly DateTime underlying_arrival_deadline;

        public RouteSpecification(ILocation the_origin_location, ILocation the_destination_location, DateTime the_arrival_deadline)
        {
            this.underlying_origin_location = the_origin_location;
            this.underlying_destination_location = the_destination_location;
            this.underlying_arrival_deadline = the_arrival_deadline;

        }

        public ILocation origin()
        {
            return this.underlying_origin_location;
        }

        public ILocation destination()
        {
            return this.underlying_destination_location;
        }

        public DateTime arrival_dealine()
        {
            return this.underlying_arrival_deadline;
        }

        public bool has_the_same_value_as(IRouteSpecification the_other_value_object)
        {
            throw new NotImplementedException();
        }

        public IRouteSpecification copy_into_this()
        {
            throw new NotImplementedException();
        }

        public bool is_satisfied_by(IItinerary this_itinerary)
        {
            throw new NotImplementedException();
        }
    }
}