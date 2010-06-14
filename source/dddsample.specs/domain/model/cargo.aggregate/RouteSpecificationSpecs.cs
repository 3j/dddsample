using System;
using dddsample.domain.model.cargo.aggregate;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace dddsample.specs.domain.model.cargo.aggregate
{
    public abstract class concern_for_route_specification : Observes<IRouteSpecification, RouteSpecification>
    {
        Establish context = () =>
        {
            the_origin_location = an<ILocation>();
            the_destination_location = an<ILocation>();
            the_arrival_deadline = an<IArrivalDeadline>();

            create_sut_using(
                () => new RouteSpecification(the_origin_location, the_destination_location, the_arrival_deadline));
        };

        protected static ILocation the_origin_location;
        protected static ILocation the_destination_location;
        protected static IArrivalDeadline the_arrival_deadline;
    }

    public class when_asked_for_its_origin_location : concern_for_route_specification
    {
        Because of = () => result = sut.origin();
        
        It should_give_back_the_origin_location = () => result.ShouldEqual(the_origin_location);

        static ILocation result;
    }

    public class when_asked_for_its_destination_location : concern_for_route_specification
    {
        Because of = () => result = sut.destination();

        It should_give_back_the_destination_location = () => result.ShouldEqual(the_destination_location);

        static ILocation result;
    }

    public class when_asked_for_its_arrival_deadline : concern_for_route_specification
    {
        Because of = () => result = sut.arrival_dealine();

        It should_give_back_the_arrival_deadline = () => result.ShouldEqual(the_arrival_deadline);

        static IArrivalDeadline result;
    }

    public class when_asked_if_the_specification_is_satified_by_an_itinerary_that_satisfies_the_route_specification : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_itinerary_that_satisfies_the_route_specification = an<IItinerary>();

            the_itinerary_that_satisfies_the_route_specification
                .Stub(x => x.initial_departure_location())
                .Return(an<ILocation>());
            the_itinerary_that_satisfies_the_route_specification
                .Stub(x => x.final_arrival_location())
                .Return(an<ILocation>());
            the_itinerary_that_satisfies_the_route_specification
                .Stub(x => x.final_arrival_date())
                .Return(an<IArrivalDeadline>());

            the_origin_location
                .Stub(x => x.has_the_same_value_as(
                    the_itinerary_that_satisfies_the_route_specification.initial_departure_location()))
                .Return(true);
            the_destination_location
                .Stub(x => x.has_the_same_value_as(
                    the_itinerary_that_satisfies_the_route_specification.final_arrival_location()))
                .Return(true);
            the_arrival_deadline
                .Stub(x => x.is_afterwards_than(
                    the_itinerary_that_satisfies_the_route_specification.final_arrival_date()))
                .Return(true);
        };

        Because of = () => result = sut.is_satisfied_by(the_itinerary_that_satisfies_the_route_specification);

        It should_confirm_that_the_itinerary_satisfies_the_route_specification = () => result.ShouldBeTrue();

        It should_leverage_the_itinerary_initial_departure_location = () => 
            the_itinerary_that_satisfies_the_route_specification.received(x => x.initial_departure_location());

        It should_leverage_the_origin_location_identity_comparer = () =>
            the_origin_location
               .received(x => x.has_the_same_value_as(
                  the_itinerary_that_satisfies_the_route_specification.initial_departure_location()));

        It should_leverage_the_itinerary_final_arrival_location = () =>
            the_itinerary_that_satisfies_the_route_specification.received(x => x.final_arrival_location());

        It should_leverage_the_destination_location_identity_comparer = () =>
            the_destination_location
                .received(x => x.has_the_same_value_as(
                    the_itinerary_that_satisfies_the_route_specification.final_arrival_location()));

        It should_leverage_the_itinerary_final_arrival_date = () => 
            the_itinerary_that_satisfies_the_route_specification.received(x => x.final_arrival_date());

        It should_leverage_the_arrival_deadline_time_check = () => 
            the_arrival_deadline
               .received(x => x.is_afterwards_than(
                   the_itinerary_that_satisfies_the_route_specification.final_arrival_date()));
        
        static bool result;
        static IItinerary the_itinerary_that_satisfies_the_route_specification;
    }

    public class when_asked_if_the_specification_is_satified_by_an_itinerary_that_does_not_satisfy_the_route_specification : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_itinerary_that_does_not_satisfy_the_route_specification = an<IItinerary>();
        };

        Because of = () => result = sut.is_satisfied_by(the_itinerary_that_does_not_satisfy_the_route_specification);

        It should_confirm_that_the_itinerary_does_not_satisfy_the_route_specification = () => result.ShouldBeFalse();
        
        static bool result;
        static IItinerary the_itinerary_that_does_not_satisfy_the_route_specification;
    }

    public class when_asked_if_the_specification_is_satified_by_a_null_itinerary : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_null_itinerary = null;
        };

        Because of = () => result = sut.is_satisfied_by(the_null_itinerary);

        It should_confirm_that_the_itinerary_does_not_satisfy_the_route_specification = () => result.ShouldBeFalse();

        static bool result;
        static IItinerary the_null_itinerary;
    }
}