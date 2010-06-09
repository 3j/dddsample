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
}

namespace dddsample.domain.model.cargo.aggregate
{
}
    

    //public class when_asked_about_its_tracking_identificator : concern_for_cargo
    //{
    //    Establish context = () =>
    //    {
    //        tracking_id = the_dependency<ITrackingId>();
    //        route_specification = the_dependency<IRouteSpecification>();
    //    };

    //    Because of = () => result = sut.tracking_id();

    //    It should_provide_the_cargo_id = () => result.ShouldEqual(tracking_id);

    //    static ITrackingId tracking_id;
    //    static IRouteSpecification route_specification;
    //    static ITrackingId result;
    //}

    //public class when_asked_about_its_route_specification : concern_for_cargo
    //{
    //    Establish context = () =>
    //    {
    //        tracking_id = the_dependency<ITrackingId>();
    //        route_specification = the_dependency<IRouteSpecification>();
    //    };

    //    Because of = () => result = sut.route_specification();

    //    It should_provide_the_route_specification = () => result.ShouldEqual(route_specification);

    //    static ITrackingId tracking_id;
    //    static IRouteSpecification route_specification;
    //    static IRouteSpecification result;
    //}

    //public class when_asked_about_its_origin_location : concern_for_cargo
    //{
    //    Establish context = () =>
    //    {
    //        tracking_id = the_dependency<ITrackingId>();
    //        route_specification = the_dependency<IRouteSpecification>();

    //        the_origin_location = an<ILocation>();
    //        route_specification.Stub(x => x.origin()).Return(the_origin_location);
    //    };

    //    Because of = () => result = sut.origin_location();

    //    It should_provide_the_origin_location = () => result.ShouldEqual(the_origin_location);
    //    It should_leverage_the_route_specification = () => route_specification.received(x => x.origin());

    //    static ITrackingId tracking_id;
    //    static IRouteSpecification route_specification;
    //    static ILocation result;
    //    static ILocation the_origin_location;
    //}


    //public interface ICargo
    //{
    //    //ITrackingId tracking_id();
    //    //IRouteSpecification route_specification();
    //    //ILocation origin_location();
    //}

    //public class Cargo : ICargo, IEntity<Cargo>
    //{
    //    //readonly ITrackingId underlying_tracking_id;
    //    //readonly IRouteSpecification underlying_route_specification;
    //    //readonly ILocation underlying_origin_location;

    //    //public Cargo(ITrackingId tracking_id, IRouteSpecification route_specification)
    //    //{
    //    //    this.underlying_tracking_id = tracking_id;
    //    //    this.underlying_route_specification = route_specification;
    //    //    this.underlying_origin_location = route_specification.origin();
    //    //}

    //    //public bool has_the_same_identity_as(Cargo the_other_entity)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}

    //    //public ITrackingId tracking_id()
    //    //{
    //    //    return underlying_tracking_id;
    //    //}

    //    //public IRouteSpecification route_specification()
    //    //{
    //    //    return underlying_route_specification;
    //    //}

    //    //public ILocation origin_location()
    //    //{
    //    //    return underlying_origin_location;
    //    //}
    //}

    //public interface ITrackingId
    //{
    //}

    //public interface IRouteSpecification : ISpecification<IItinerary>
    //{
    //    ILocation origin();
    //}

    //public interface ILocation
    //{
    //}

    //public interface IItinerary
    //{
    //}
