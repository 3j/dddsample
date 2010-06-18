using System;
using dddsample.domain.model.location.aggregate;

namespace dddsample.domain.model.cargo.aggregate
{
    public class RouteSpecificationFactory
    {
        public IRouteSpecification create_route_specification_using(ILocation the_origin_location, ILocation the_destination_location, IDate the_arrival_deadline)
        {
            if (the_origin_location == null)
                throw new ArgumentNullException("the_origin_location",
                                                "Invariant Violated: origin location is required.");

            if (the_destination_location == null)
                throw new ArgumentNullException("the_destination_location",
                                                "Invariant Violated: destination location is required.");

            if (the_arrival_deadline == null)
                throw new ArgumentNullException("the_arrival_deadline",
                                                "Invariant Violated: arrival deadline is required.");

            if (the_origin_location.has_the_same_identity_as(the_destination_location))
                throw new ArgumentException("Invariant Violated: origin and destination locations can't be the same.");

            return new RouteSpecification(the_origin_location, the_destination_location, the_arrival_deadline);
        }
    }
}