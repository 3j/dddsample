using System;
using dddsample.domain.model.cargo.aggregate;
using dddsample.domain.model.handling.aggregate;
using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.voyage.aggregate;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace dddsample.specs.domain.model.cargo.aggregate
{
    public abstract class concern_for_route_specification_factory : Observes<CargoAggregateFactory> { }

    public class when_attempting_to_inject_a_null_origin_location_into_the_route_specification_factory : concern_for_route_specification_factory
    {
        Establish context = () =>
        {
            the_origin_location = null;
            the_destination_location = an<ILocation>();
            the_arrival_deadline = an<IDate>();
        };

        Because of = () => catch_exception(() => sut.create_route_specification_using(the_origin_location, the_destination_location, the_arrival_deadline));

        It should_throw_a_null_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentNullException>();

        It should_throw_an_invariant_violated_exception_message = () => exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: origin location is required.");

        static ILocation the_origin_location;
        static ILocation the_destination_location;
        static IDate the_arrival_deadline;
    }

    public class when_attempting_to_inject_a_null_destination_location_into_the_route_specification_factory : concern_for_route_specification_factory
    {
        Establish context = () =>
        {
            the_origin_location = an<ILocation>();
            the_destination_location = null;
            the_arrival_deadline = an<IDate>();
        };

        Because of = () => catch_exception(() => sut.create_route_specification_using(the_origin_location, the_destination_location, the_arrival_deadline));

        It should_throw_a_null_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentNullException>();

        It should_throw_an_invariant_violated_exception_message = () => exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: destination location is required.");

        static ILocation the_origin_location;
        static ILocation the_destination_location;
        static IDate the_arrival_deadline;
    }

    public class when_attempting_to_inject_a_null_arrival_deadline_into_the_route_specification_factory : concern_for_route_specification_factory
    {
        Establish context = () =>
        {
            the_origin_location = an<ILocation>();
            the_destination_location = an<ILocation>();
            the_arrival_deadline = null;
        };

        Because of = () => catch_exception(() => sut.create_route_specification_using(the_origin_location, the_destination_location, the_arrival_deadline));

        It should_throw_a_null_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentNullException>();

        It should_throw_an_invariant_violated_exception_message = () => exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: arrival deadline is required.");

        static ILocation the_origin_location;
        static ILocation the_destination_location;
        static IDate the_arrival_deadline;
    }

    public class when_attempting_to_inject_the_same_origin_and_destination_locations_into_the_route_specification_factory : concern_for_route_specification_factory
    {
        Establish context = () =>
        {
            the_origin_location = an<ILocation>();
            the_destination_location = an<ILocation>();
            the_arrival_deadline = an<IDate>();

            the_origin_location
                .Stub(x => x.has_the_same_identity_as(the_destination_location))
                .Return(true);
        };

        Because of = () => catch_exception(() => sut.create_route_specification_using(the_origin_location, the_destination_location, the_arrival_deadline));

        It should_throw_an_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentException>();

        It should_throw_an_invariant_violated_exception_message = () => 
            exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: origin and destination locations can't be the same.");

        static ILocation the_origin_location;
        static ILocation the_destination_location;
        static IDate the_arrival_deadline;
    }

    public class when_creating_a_route_specification_through_the_factory : concern_for_leg_factory
    {
        Establish context = () =>
        {
            the_origin_location = an<ILocation>();
            the_destination_location = an<ILocation>();
            the_arrival_deadline = an<IDate>();
        };

        Because of = () => result = sut.create_route_specification_using(the_origin_location, the_destination_location, the_arrival_deadline);

        It should_return_an_object_that_conforms_the_route_specification_interface = () => result.ShouldBeAn<IRouteSpecification>();

        static ILocation the_origin_location;
        static ILocation the_destination_location;
        static IDate the_arrival_deadline;
        static IRouteSpecification result;
    }

    public abstract class concern_for_leg_factory : Observes<CargoAggregateFactory> { }

    public class when_attempting_to_inject_a_null_voyage_into_the_leg_factory : concern_for_leg_factory
    {
        Establish context = () =>
        {
            an_empty_voyage = null;
            the_injected_load_location = an<ILocation>();
            the_injected_unload_location = an<ILocation>();
            the_injected_load_time = an<IDate>();
            the_injected_unload_time = an<IDate>();
        };

        Because of = () => catch_exception(() => sut.create_leg_using(an_empty_voyage, the_injected_load_location, the_injected_unload_location,
                                                                     the_injected_load_time, the_injected_unload_time));

        It should_throw_a_null_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentNullException>();

        It should_throw_an_invariant_violated_exception_message = () => exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: a valid voyage is required in order to construct a leg.");

        static IVoyage an_empty_voyage;
        static ILocation the_injected_load_location;
        static ILocation the_injected_unload_location;
        static IDate the_injected_load_time;
        static IDate the_injected_unload_time;
    }

    public class when_attempting_to_inject_a_null_load_location_into_the_leg_factory : concern_for_leg_factory
    {
        Establish context = () =>
        {
            the_injected_voyage = an<IVoyage>();
            an_empty_load_location = null;
            the_injected_unload_location = an<ILocation>();
            the_injected_load_time = an<IDate>();
            the_injected_unload_time = an<IDate>();
        };

        Because of = () => catch_exception(() => sut.create_leg_using(the_injected_voyage, an_empty_load_location, the_injected_unload_location,
                                                                     the_injected_load_time, the_injected_unload_time));

        It should_throw_a_null_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentNullException>();

        It should_throw_an_invariant_violated_exception_message = () => exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: a valid load location is required in order to construct a leg.");

        static IVoyage the_injected_voyage;
        static ILocation an_empty_load_location;
        static ILocation the_injected_unload_location;
        static IDate the_injected_load_time;
        static IDate the_injected_unload_time;
    }

    public class when_attempting_to_inject_a_null_unload_location_into_the_leg_factory : concern_for_leg_factory
    {
        Establish context = () =>
        {
            the_injected_voyage = an<IVoyage>();
            the_injected_load_location = an<ILocation>();
            an_empty_unload_location = null;
            the_injected_load_time = an<IDate>();
            the_injected_unload_time = an<IDate>();
        };

        Because of = () => catch_exception(() => sut.create_leg_using(the_injected_voyage, the_injected_load_location, an_empty_unload_location,
                                                                     the_injected_load_time, the_injected_unload_time));

        It should_throw_a_null_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentNullException>();

        It should_throw_an_invariant_violated_exception_message = () => exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: a valid unload location is required in order to construct a leg.");

        static IVoyage the_injected_voyage;
        static ILocation the_injected_load_location;
        static ILocation an_empty_unload_location;
        static IDate the_injected_load_time;
        static IDate the_injected_unload_time;
    }

    public class when_attempting_to_inject_a_null_load_time_into_the_leg_factory : concern_for_leg_factory
    {
        Establish context = () =>
        {
            the_injected_voyage = an<IVoyage>();
            the_injected_load_location = an<ILocation>();
            the_injected_unload_location = an<ILocation>();
            an_empty_load_time = null;
            the_injected_unload_time = an<IDate>();
        };

        Because of = () => catch_exception(() => sut.create_leg_using(the_injected_voyage, the_injected_load_location, the_injected_unload_location,
                                                                     an_empty_load_time, the_injected_unload_time));

        It should_throw_a_null_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentNullException>();

        It should_throw_an_invariant_violated_exception_message = () => exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: a valid load time is required in order to construct a leg.");

        static IVoyage the_injected_voyage;
        static ILocation the_injected_load_location;
        static ILocation the_injected_unload_location;
        static IDate an_empty_load_time;
        static IDate the_injected_unload_time;
    }

    public class when_attempting_to_inject_a_null_unload_time_into_the_leg_factory : concern_for_leg_factory
    {
        Establish context = () =>
        {
            the_injected_voyage = an<IVoyage>();
            the_injected_load_location = an<ILocation>();
            the_injected_unload_location = an<ILocation>();
            the_injected_load_time = an<IDate>();
            an_empty_unload_time = null;
        };

        Because of = () => catch_exception(() => sut.create_leg_using(the_injected_voyage, the_injected_load_location, the_injected_unload_location,
                                                                     the_injected_load_time, an_empty_unload_time));

        It should_throw_a_null_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentNullException>();

        It should_throw_an_invariant_violated_exception_message = () => exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: a valid unload time is required in order to construct a leg.");

        static IVoyage the_injected_voyage;
        static ILocation the_injected_load_location;
        static ILocation the_injected_unload_location;
        static IDate the_injected_load_time;
        static IDate an_empty_unload_time;
    }

    public class when_creating_a_leg_through_the_factory : concern_for_leg_factory
    {
        Establish context = () =>
        {
            the_injected_voyage = an<IVoyage>();
            the_injected_load_location = an<ILocation>();
            the_injected_unload_location = an<ILocation>();
            the_injected_load_time = an<IDate>();
            the_injected_unload_time = an<IDate>();
        };

        Because of = () => result = sut.create_leg_using(the_injected_voyage, the_injected_load_location, the_injected_unload_location,
                                                         the_injected_load_time, the_injected_unload_time);

        It should_return_an_object_that_conforms_the_leg_interface = () => result.ShouldBeAn<ILeg>();

        static IVoyage the_injected_voyage;
        static ILocation the_injected_load_location;
        static ILocation the_injected_unload_location;
        static IDate the_injected_load_time;
        static IDate the_injected_unload_time;
        static ILeg result;
    }

    public abstract class concern_for_handling_activity_factory : Observes<CargoAggregateFactory> { }

    public class when_attempting_to_inject_a_null_location_into_the_handling_activity_factory : concern_for_handling_activity_factory
    {
        Establish context = () =>
        {
            an_empty_location = null;
            the_injected_handling_event_type = an<IHandlingEventType>();
        };

        Because of = () => catch_exception(() => sut.create_handling_activity_using(an_empty_location, the_injected_handling_event_type));

        It should_throw_a_null_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentNullException>();

        It should_throw_an_invariant_violated_exception_message = () => exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: a valid location is required in order to construct a handling activity.");

        static ILocation an_empty_location;
        static IHandlingEventType the_injected_handling_event_type;
    }

    public class when_attempting_to_inject_a_null_handling_event_type_into_the_handling_activity_factory : concern_for_handling_activity_factory
    {
        Establish context = () =>
        {
            the_injected_location = an<ILocation>();
            an_empty_handling_event_type = null;
        };

        Because of = () => catch_exception(() => sut.create_handling_activity_using(the_injected_location, an_empty_handling_event_type));

        It should_throw_a_null_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentNullException>();

        It should_throw_an_invariant_violated_exception_message = () => exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: a valid handling event type is required in order to construct a handling activity.");

        static ILocation the_injected_location;
        static IHandlingEventType an_empty_handling_event_type;
    }
}