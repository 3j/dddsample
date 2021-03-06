﻿using System;
using dddsample.domain.model.cargo.aggregate.interfaces;
using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.location.aggregate.interfaces;

namespace dddsample.domain.model.cargo.aggregate
{
    public class RouteSpecification : IRouteSpecification
    {
        readonly ILocation underlying_origin_location;
        readonly ILocation underlying_destination_location;
        readonly IDate underlying_arrival_deadline;

        internal RouteSpecification(ILocation the_origin_location, ILocation the_destination_location, IDate the_arrival_deadline)
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

        public IDate arrival_dealine()
        {
            return this.underlying_arrival_deadline;
        }

        public bool has_the_same_value_as(IRouteSpecification the_other)
        {
            return the_other != null &&
                   this.underlying_origin_location.has_the_same_identity_as(the_other.origin()) &&
                   this.underlying_destination_location.has_the_same_identity_as(the_other.destination()) &&
                   this.underlying_arrival_deadline.has_the_same_value_as(the_other.arrival_dealine());
        }

        public bool is_satisfied_by(IItinerary the_itinerary)
        {
            return the_itinerary != null &&
                   underlying_origin_location.has_the_same_identity_as(
                       the_itinerary.initial_departure_load_location()) &&
                   underlying_destination_location.has_the_same_identity_as(
                       the_itinerary.final_arrival_unload_location()) &&
                   underlying_arrival_deadline.is_posterior_to(
                       the_itinerary.final_arrival_date());
        }

        public override int GetHashCode()
        {
            var result =  this.underlying_origin_location.GetHashCode();
            result = result * 397 + this.underlying_destination_location.GetHashCode();
            result = result * 397 + this.underlying_arrival_deadline.GetHashCode();
            return result;
        }

        public override bool Equals(object the_to_compare_object)
        {
            return this.has_the_same_value_as(the_to_compare_object as IRouteSpecification);
        }
    }
}