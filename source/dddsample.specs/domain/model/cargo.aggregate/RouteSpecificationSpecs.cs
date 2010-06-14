using System;
using dddsample.domain.model.cargo.aggregate;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;

namespace dddsample.specs.domain.model.cargo.aggregate
{
    public abstract class concern_for_route_specification : Observes<IRouteSpecification, RouteSpecification>{}

    public class when_asked_for_its_origin_location : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_origin_location = an<ILocation>();
            the_destination_location = an<ILocation>();
            the_arrival_deadline = new DateTime();
            
            create_sut_using(
                () => new RouteSpecification(the_origin_location, the_destination_location, the_arrival_deadline));
        };

        Because of = () => result = sut.origin();
        
        It should_give_back_the_origin_location = () => result.ShouldEqual(the_origin_location);

        static ILocation result;
        static ILocation the_origin_location;
        static ILocation the_destination_location;
        static DateTime the_arrival_deadline;
    }

    public class when_asked_for_its_destination_location : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_origin_location = an<ILocation>();
            the_destination_location = an<ILocation>();
            the_arrival_deadline = new DateTime();

            create_sut_using(
                () => new RouteSpecification(the_origin_location, the_destination_location, the_arrival_deadline));
        };

        Because of = () => result = sut.destination();

        It should_give_back_the_destination_location = () => result.ShouldEqual(the_destination_location);

        static ILocation result;
        static ILocation the_origin_location;
        static ILocation the_destination_location;
        static DateTime the_arrival_deadline;
    }

    public class when_asked_for_its_arrival_deadline : concern_for_route_specification
    {
        Establish context = () =>
        {
            the_origin_location = an<ILocation>();
            the_destination_location = an<ILocation>();
            the_arrival_deadline = new DateTime();
            
            create_sut_using(
                () => new RouteSpecification(the_origin_location, the_destination_location, the_arrival_deadline));
        };

        Because of = () => result = sut.arrival_dealine();

        It should_give_back_the_arrival_deadline = () => result.ShouldEqual(the_arrival_deadline);

       // It should_leverage_the_arrival_deadline_property = () => the_arrival_deadline.received(x => x.MyMethod());

        static DateTime result;
        static ILocation the_origin_location;
        static ILocation the_destination_location;
        static DateTime the_arrival_deadline;
    }
}