using System;
using dddsample.domain.model.cargo.aggregate;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace dddsample.specs.domain.model.cargo.aggregate
{
    public abstract class concern_for_route_specification_factory : Observes<RouteSpecificationFactory> { }

    public class when_attempting_to_inject_a_null_origin_location_into_the_route_specification_factory : concern_for_route_specification_factory
    {
        Establish context = () =>
        {
            the_origin_location = null;
            the_destination_location = an<ILocation>();
            the_arrival_deadline = an<IArrivalDeadline>();
        };

        Because of = () => catch_exception(() => sut.create_route_specification_using(the_origin_location, the_destination_location, the_arrival_deadline));

        It should_throw_a_null_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentNullException>();

        It should_throw_an_invariant_violated_exception_message = () => exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: origin location is required.");

        static ILocation the_origin_location;
        static ILocation the_destination_location;
        static IArrivalDeadline the_arrival_deadline;
    }

    public class when_attempting_to_inject_a_null_destination_location_into_the_route_specification_factory : concern_for_route_specification_factory
    {
        Establish context = () =>
        {
            the_origin_location = an<ILocation>();
            the_destination_location = null;
            the_arrival_deadline = an<IArrivalDeadline>();
        };

        Because of = () => catch_exception(() => sut.create_route_specification_using(the_origin_location, the_destination_location, the_arrival_deadline));

        It should_throw_a_null_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentNullException>();

        It should_throw_an_invariant_violated_exception_message = () => exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: destination location is required.");

        static ILocation the_origin_location;
        static ILocation the_destination_location;
        static IArrivalDeadline the_arrival_deadline;
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
        static IArrivalDeadline the_arrival_deadline;
    }

    public class when_attempting_to_inject_the_same_origin_and_destination_locations_into_the_route_specification_factory : concern_for_route_specification_factory
    {
        Establish context = () =>
        {
            the_origin_location = an<ILocation>();
            the_destination_location = an<ILocation>();
            the_arrival_deadline = an<IArrivalDeadline>();

            the_origin_location
                .Stub(x => x.has_the_same_value_as(the_destination_location))
                .Return(true);
        };

        Because of = () => catch_exception(() => sut.create_route_specification_using(the_origin_location, the_destination_location, the_arrival_deadline));

        It should_throw_an_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentException>();

        It should_throw_an_invariant_violated_exception_message = () => 
            exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: origin and destination locations can't be the same.");

        static ILocation the_origin_location;
        static ILocation the_destination_location;
        static IArrivalDeadline the_arrival_deadline;
    }
}