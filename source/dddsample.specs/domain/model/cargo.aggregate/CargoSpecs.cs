using dddsample.domain.model.cargo.aggregate;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;

namespace dddsample.specs.domain.model.cargo.aggregate
{
    public abstract class concern_for_cargo : Observes<ICargo, Cargo>
    {
    }

    public class when_asked_about_its_tracking_identificator : concern_for_cargo
    {
        Establish context = () =>
        {
            tracking_id = the_dependency<ITrackingId>();
            route_specification = the_dependency<IRouteSpecification>();
        };

        Because of = () => result = sut.tracking_id();

        It should_provide_the_cargo_id = () => result.ShouldEqual(tracking_id);

        static ITrackingId tracking_id;
        static ITrackingId result;
        static IRouteSpecification route_specification;
    }

    public class when_asked_about_its_route_specification : concern_for_cargo
    {
        Establish context = () =>
        {
            tracking_id = the_dependency<ITrackingId>();
            route_specification = the_dependency<IRouteSpecification>();
        };

        Because of = () => result = sut.route_specification();

        It should_provide_the_route_specification = () => result.ShouldEqual(route_specification);

        static IRouteSpecification result;
        static IRouteSpecification route_specification;
        static ITrackingId tracking_id;
    }
}   