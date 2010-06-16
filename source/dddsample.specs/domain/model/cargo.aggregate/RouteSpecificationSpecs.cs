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
            the_arrival_deadline = an<IDate>();
            the_route_specification_factory = new RouteSpecificationFactory();

            create_sut_using(() =>
                the_route_specification_factory
                   .create_route_specification_using(the_origin_location, the_destination_location, the_arrival_deadline));
        };

        protected static ILocation the_origin_location;
        protected static ILocation the_destination_location;
        protected static IDate the_arrival_deadline;
        protected static RouteSpecificationFactory the_route_specification_factory;
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

        static IDate result;
    }

    public class when_asked_if_the_specification_is_satisfied_by_an_itinerary_that_satisfies_the_route_specification : concern_for_route_specification
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
                .Return(an<IDate>());

            the_origin_location
                .Stub(x => x.has_the_same_value_as(
                    the_itinerary_that_satisfies_the_route_specification.initial_departure_location()))
                .Return(true);
            the_destination_location
                .Stub(x => x.has_the_same_value_as(
                    the_itinerary_that_satisfies_the_route_specification.final_arrival_location()))
                .Return(true);
            the_arrival_deadline
                .Stub(x => x.is_posterior_to(
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
               .received(x => x.is_posterior_to(
                   the_itinerary_that_satisfies_the_route_specification.final_arrival_date()));

        static bool result;
        static IItinerary the_itinerary_that_satisfies_the_route_specification;
    }

    public class when_asked_if_the_specification_is_satisfied_by_an_itinerary_with_an_invalid_initial_departure_location : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_itinerary_with_an_invalid_initial_departure_location = an<IItinerary>();

            the_itinerary_with_an_invalid_initial_departure_location
                .Stub(x => x.initial_departure_location())
                .Return(an<ILocation>());

            the_origin_location
                .Stub(x => x.has_the_same_value_as(
                    the_itinerary_with_an_invalid_initial_departure_location.initial_departure_location()))
                .Return(false);
        };

        Because of = () => result = sut.is_satisfied_by(the_itinerary_with_an_invalid_initial_departure_location);

        It should_confirm_that_the_itinerary_does_not_satisfy_the_route_specification = () => result.ShouldBeFalse();

        It should_leverage_the_itinerary_initial_departure_location = () =>
            the_itinerary_with_an_invalid_initial_departure_location.received(x => x.initial_departure_location());

        It should_leverage_the_origin_location_identity_comparer = () =>
            the_origin_location
               .received(x => x.has_the_same_value_as(
                  the_itinerary_with_an_invalid_initial_departure_location.initial_departure_location()));

        It should_not_leverage_the_itinerary_final_arrival_location = () =>
            the_itinerary_with_an_invalid_initial_departure_location.never_received(x => x.final_arrival_location());

        It should_not_leverage_the_destination_location_identity_comparer = () =>
            the_destination_location
                .never_received(x => x.has_the_same_value_as(
                    the_itinerary_with_an_invalid_initial_departure_location.final_arrival_location()));

        It should_not_leverage_the_itinerary_final_arrival_date = () =>
            the_itinerary_with_an_invalid_initial_departure_location.never_received(x => x.final_arrival_date());

        It should_not_leverage_the_arrival_deadline_time_check = () =>
            the_arrival_deadline
               .never_received(x => x.is_posterior_to(
                   the_itinerary_with_an_invalid_initial_departure_location.final_arrival_date()));

        static bool result;
        static IItinerary the_itinerary_with_an_invalid_initial_departure_location;
    }

    public class when_asked_if_the_specification_is_satisfied_by_an_itinerary_with_an_invalid_final_arrival_location : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_itinerary_with_an_invalid_final_arrival_location = an<IItinerary>();

            the_itinerary_with_an_invalid_final_arrival_location
                .Stub(x => x.initial_departure_location())
                .Return(an<ILocation>());
            the_itinerary_with_an_invalid_final_arrival_location
                .Stub(x => x.final_arrival_location())
                .Return(an<ILocation>());

            the_origin_location
                .Stub(x => x.has_the_same_value_as(
                    the_itinerary_with_an_invalid_final_arrival_location.initial_departure_location()))
                .Return(true);
            the_destination_location
                .Stub(x => x.has_the_same_value_as(
                    the_itinerary_with_an_invalid_final_arrival_location.final_arrival_location()))
                .Return(false);
        };

        Because of = () => result = sut.is_satisfied_by(the_itinerary_with_an_invalid_final_arrival_location);

        It should_confirm_that_the_itinerary_does_not_satisfy_the_route_specification = () => result.ShouldBeFalse();

        It should_leverage_the_itinerary_initial_departure_location = () =>
            the_itinerary_with_an_invalid_final_arrival_location.received(x => x.initial_departure_location());

        It should_leverage_the_origin_location_identity_comparer = () =>
            the_origin_location
               .received(x => x.has_the_same_value_as(
                  the_itinerary_with_an_invalid_final_arrival_location.initial_departure_location()));

        It should_leverage_the_itinerary_final_arrival_location = () =>
            the_itinerary_with_an_invalid_final_arrival_location.received(x => x.final_arrival_location());

        It should_leverage_the_destination_location_identity_comparer = () =>
            the_destination_location
                .received(x => x.has_the_same_value_as(
                    the_itinerary_with_an_invalid_final_arrival_location.final_arrival_location()));

        It should_not_leverage_the_itinerary_final_arrival_date = () =>
            the_itinerary_with_an_invalid_final_arrival_location.never_received(x => x.final_arrival_date());

        It should_not_leverage_the_arrival_deadline_time_check = () =>
            the_arrival_deadline
               .never_received(x => x.is_posterior_to(
                   the_itinerary_with_an_invalid_final_arrival_location.final_arrival_date()));

        static bool result;
        static IItinerary the_itinerary_with_an_invalid_final_arrival_location;
    }

    public class when_asked_if_the_specification_is_satisfied_by_an_itinerary_with_an_invalid_final_arrival_date : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_itinerary_with_an_invalid_final_arrival_date = an<IItinerary>();

            the_itinerary_with_an_invalid_final_arrival_date
                .Stub(x => x.initial_departure_location())
                .Return(an<ILocation>());
            the_itinerary_with_an_invalid_final_arrival_date
                .Stub(x => x.final_arrival_location())
                .Return(an<ILocation>());
            the_itinerary_with_an_invalid_final_arrival_date
                .Stub(x => x.final_arrival_date())
                .Return(an<IDate>());

            the_origin_location
                .Stub(x => x.has_the_same_value_as(
                    the_itinerary_with_an_invalid_final_arrival_date.initial_departure_location()))
                .Return(true);
            the_destination_location
                .Stub(x => x.has_the_same_value_as(
                    the_itinerary_with_an_invalid_final_arrival_date.final_arrival_location()))
                .Return(true);
            the_arrival_deadline
                .Stub(x => x.is_posterior_to(
                    the_itinerary_with_an_invalid_final_arrival_date.final_arrival_date()))
                .Return(false);
        };

        Because of = () => result = sut.is_satisfied_by(the_itinerary_with_an_invalid_final_arrival_date);

        It should_confirm_that_the_itinerary_does_not_satisfy_the_route_specification = () => result.ShouldBeFalse();

        It should_leverage_the_itinerary_initial_departure_location = () =>
            the_itinerary_with_an_invalid_final_arrival_date.received(x => x.initial_departure_location());

        It should_leverage_the_origin_location_identity_comparer = () =>
            the_origin_location
               .received(x => x.has_the_same_value_as(
                  the_itinerary_with_an_invalid_final_arrival_date.initial_departure_location()));

        It should_leverage_the_itinerary_final_arrival_location = () =>
            the_itinerary_with_an_invalid_final_arrival_date.received(x => x.final_arrival_location());

        It should_leverage_the_destination_location_identity_comparer = () =>
            the_destination_location
                .received(x => x.has_the_same_value_as(
                    the_itinerary_with_an_invalid_final_arrival_date.final_arrival_location()));

        It should_leverage_the_itinerary_final_arrival_date = () =>
            the_itinerary_with_an_invalid_final_arrival_date.received(x => x.final_arrival_date());

        It should_leverage_the_arrival_deadline_time_check = () =>
            the_arrival_deadline
               .received(x => x.is_posterior_to(
                   the_itinerary_with_an_invalid_final_arrival_date.final_arrival_date()));

        static bool result;
        static IItinerary the_itinerary_with_an_invalid_final_arrival_date;
    }

    public class when_asked_if_the_specification_is_satisfied_by_a_null_itinerary : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_null_itinerary = null;
        };

        Because of = () => result = sut.is_satisfied_by(the_null_itinerary);

        It should_confirm_that_the_itinerary_does_not_satisfy_the_route_specification = () => result.ShouldBeFalse();

        It should_not_leverage_the_origin_location_identity_comparer = () =>
            the_origin_location
                .never_received(x => x.has_the_same_value_as(an<ILocation>()));

        It should_not_leverage_the_destination_location_identity_comparer = () =>
            the_destination_location
                .never_received(x => x.has_the_same_value_as(an<ILocation>()));

        It should_not_leverage_the_arrival_deadline_time_check = () =>
            the_arrival_deadline
               .never_received(x => x.is_posterior_to(an<IDate>()));

        static bool result;
        static IItinerary the_null_itinerary;
    }

    public class when_asked_if_two_similar_route_specifications_have_the_same_value : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_other_route_specification = an<IRouteSpecification>();

            the_other_route_specification
                .Stub(x => x.origin())
                .Return(the_origin_location);
            the_origin_location
                .Stub(x => x.has_the_same_value_as(the_origin_location))
                .Return(true);

            the_other_route_specification
                .Stub(x => x.destination())
                .Return(the_destination_location);
            the_destination_location
                .Stub(x => x.has_the_same_value_as(the_destination_location))
                .Return(true);

            the_other_route_specification
                .Stub(x => x.arrival_dealine())
                .Return(the_arrival_deadline);
            the_arrival_deadline
                .Stub(x => x.has_the_same_value_as(the_arrival_deadline))
                .Return(true);
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_route_specification);

        It should_confirm_that_they_have_the_same_value = () => result.ShouldBeTrue();

        It should_leverage_the_origin_location_value_comparer =
            () => the_origin_location.received(x => x.has_the_same_value_as(the_origin_location));

        It should_leverage_the_destination_location_value_comparer =
            () => the_destination_location.received(x => x.has_the_same_value_as(the_destination_location));

        It should_leverage_the_arrival_deadline_value_comparer =
            () => the_arrival_deadline.received(x => x.has_the_same_value_as(the_arrival_deadline));

        static bool result;
        static IRouteSpecification the_other_route_specification;
    }

    public class when_asked_if_two_route_specifications_with_different_origin_location_have_the_same_value : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_other_route_specification = an<IRouteSpecification>();

            the_other_route_specification
                .Stub(x => x.origin())
                .Return(the_origin_location);
            the_origin_location
                .Stub(x => x.has_the_same_value_as(the_origin_location))
                .Return(false);
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_route_specification);

        It should_confirm_that_they_have_different_value = () => result.ShouldBeFalse();

        It should_leverage_the_origin_location_value_comparer =
            () => the_origin_location.received(x => x.has_the_same_value_as(the_origin_location));

        It should_not_leverage_the_destination_location_value_comparer =
            () => the_destination_location.never_received(x => x.has_the_same_value_as(the_destination_location));

        It should_not_leverage_the_arrival_deadline_value_comparer =
            () => the_arrival_deadline.never_received(x => x.has_the_same_value_as(the_arrival_deadline));

        static bool result;
        static IRouteSpecification the_other_route_specification;
    }

    public class when_asked_if_two_route_specifications_with_different_destination_location_have_the_same_value : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_other_route_specification = an<IRouteSpecification>();

            the_other_route_specification
                .Stub(x => x.origin())
                .Return(the_origin_location);
            the_origin_location
                .Stub(x => x.has_the_same_value_as(the_origin_location))
                .Return(true);

            the_other_route_specification
                .Stub(x => x.destination())
                .Return(the_destination_location);
            the_destination_location
                .Stub(x => x.has_the_same_value_as(the_destination_location))
                .Return(false);
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_route_specification);

        It should_confirm_that_they_have_different_value = () => result.ShouldBeFalse();

        It should_leverage_the_origin_location_value_comparer =
            () => the_origin_location.received(x => x.has_the_same_value_as(the_origin_location));

        It should_leverage_the_destination_location_value_comparer =
            () => the_destination_location.received(x => x.has_the_same_value_as(the_destination_location));

        It should_not_leverage_the_arrival_deadline_value_comparer =
            () => the_arrival_deadline.never_received(x => x.has_the_same_value_as(the_arrival_deadline));

        static bool result;
        static IRouteSpecification the_other_route_specification;
    }

    public class when_asked_if_two_route_specifications_with_different_arrival_deadline_have_the_same_value : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_other_route_specification = an<IRouteSpecification>();

            the_other_route_specification
                .Stub(x => x.origin())
                .Return(the_origin_location);
            the_origin_location
                .Stub(x => x.has_the_same_value_as(the_origin_location))
                .Return(true);

            the_other_route_specification
                .Stub(x => x.destination())
                .Return(the_destination_location);
            the_destination_location
                .Stub(x => x.has_the_same_value_as(the_destination_location))
                .Return(true);

            the_other_route_specification
                .Stub(x => x.arrival_dealine())
                .Return(the_arrival_deadline);
            the_arrival_deadline
                .Stub(x => x.has_the_same_value_as(the_arrival_deadline))
                .Return(false);
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_route_specification);

        It should_confirm_that_they_have_different_value = () => result.ShouldBeFalse();

        It should_leverage_the_origin_location_value_comparer =
            () => the_origin_location.received(x => x.has_the_same_value_as(the_origin_location));

        It should_leverage_the_destination_location_value_comparer =
            () => the_destination_location.received(x => x.has_the_same_value_as(the_destination_location));

        It should_leverage_the_arrival_deadline_value_comparer =
            () => the_arrival_deadline.received(x => x.has_the_same_value_as(the_arrival_deadline));

        static bool result;
        static IRouteSpecification the_other_route_specification;
    }

    public class when_asked_if_a_null_route_specification_has_the_same_value_as_the_current_specification : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_other_route_specification = null;
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_route_specification);

        It should_confirm_that_they_have_different_value = () => result.ShouldBeFalse();

        It should_not_leverage_the_origin_location_value_comparer =
            () => the_origin_location.never_received(x => x.has_the_same_value_as(the_origin_location));

        It should_not_leverage_the_destination_location_value_comparer =
            () => the_destination_location.never_received(x => x.has_the_same_value_as(the_destination_location));

        It should_not_leverage_the_arrival_deadline_value_comparer =
            () => the_arrival_deadline.never_received(x => x.has_the_same_value_as(the_arrival_deadline));

        static bool result;
        static IRouteSpecification the_other_route_specification;
    }

    public class when_asked_about_the_route_specification_hash_code : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_origin_location
                .Stub(x => x.GetHashCode())
                .Return(2);

            the_destination_location
                .Stub(x => x.GetHashCode())
                .Return(4);

            the_arrival_deadline
                .Stub(x => x.GetHashCode())
                .Return(6);
        };

        Because of = () => result = sut.GetHashCode();

        It should_calculate_the_hash_code_according_to_a_given_algorithm = () => result.ShouldEqual(316812);

        It should_leverage_the_origin_location_hash_code =
            () => the_origin_location.received(x => x.GetHashCode());

        It should_leverage_the_destination_location_hash_code =
            () => the_destination_location.received(x => x.GetHashCode());

        It should_leverage_the_arrival_deadline_hash_code =
            () => the_arrival_deadline.received(x => x.GetHashCode());

        static int result;
    }
}