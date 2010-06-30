using System;
using System.Collections.Generic;
using dddsample.domain.model.handling.aggregate;
using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.voyage.aggregate;

namespace dddsample.domain.model.cargo.aggregate
{
    public class CargoAggregateFactory : IRouteSpecificationFactory, ILegFactory, IHandlingActivityFactory
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

        public ILeg create_leg_using(IVoyage the_voyage, ILocation the_load_location, ILocation the_unload_location, IDate the_load_time, IDate the_unload_time)
        {
            if (the_voyage == null)
                throw new ArgumentNullException("the_voyage", "Invariant Violated: a valid voyage is required in order to construct a leg.");

            if (the_load_location == null)
                throw new ArgumentNullException("the_load_location", "Invariant Violated: a valid load location is required in order to construct a leg.");

            if (the_unload_location == null)
                throw new ArgumentNullException("the_unload_location", "Invariant Violated: a valid unload location is required in order to construct a leg.");

            if (the_load_time == null)
                throw new ArgumentNullException("the_load_time", "Invariant Violated: a valid load time is required in order to construct a leg.");

            if (the_unload_time == null)
                throw new ArgumentNullException("the_unload_time", "Invariant Violated: a valid unload time is required in order to construct a leg.");

            return new Leg(the_voyage, the_load_location, the_unload_location, the_load_time, the_unload_time);
        }

        public IHandlingActivity create_handling_activity_using(ILocation the_location, IHandlingEventType the_handling_event_type)
        {
            if (the_location == null)
                throw new ArgumentNullException("the_location", "Invariant Violated: a valid location is required in order to construct a handling activity.");

            if (the_handling_event_type == null)
                throw new ArgumentNullException("the_handling_event_type", "Invariant Violated: a valid handling event type is required in order to construct a handling activity.");

            return new HandlingActivity(the_location, the_handling_event_type);
        }
    }
}