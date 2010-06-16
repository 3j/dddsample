using System;

namespace dddsample.domain.model.cargo.aggregate
{
    public class RouteSpecification : IRouteSpecification
    {
        readonly ILocation underlying_origin_location;
        readonly ILocation underlying_destination_location;
        readonly IArrivalDeadline underlying_arrival_deadline;

        internal RouteSpecification(ILocation the_origin_location, ILocation the_destination_location, IArrivalDeadline the_arrival_deadline)
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

        public IArrivalDeadline arrival_dealine()
        {
            return this.underlying_arrival_deadline;
        }

        public bool has_the_same_value_as(IRouteSpecification the_other)
        {
            return the_other != null &&
                   this.underlying_origin_location.has_the_same_value_as(the_other.origin()) &&
                   this.underlying_destination_location.has_the_same_value_as(the_other.destination()) &&
                   this.underlying_arrival_deadline.has_the_same_value_as(the_other.arrival_dealine());
        }

        public bool is_satisfied_by(IItinerary the_itinerary)
        {
            return the_itinerary != null &&
                   underlying_origin_location.has_the_same_value_as(
                       the_itinerary.initial_departure_location()) &&
                   underlying_destination_location.has_the_same_value_as(
                       the_itinerary.final_arrival_location()) &&
                   underlying_arrival_deadline.is_afterwards_than(
                       the_itinerary.final_arrival_date());
        }

        public override int GetHashCode()
        {
            var result =  this.underlying_origin_location.GetHashCode();
            result = result * 397 + this.underlying_destination_location.GetHashCode();
            result = result * 397 + this.underlying_arrival_deadline.GetHashCode();
            return result;
        }
    }
}