using dddsample.domain.model.cargo.aggregate;
using dddsample.domain.model.cargo.aggregate.interfaces;
using dddsample.domain.model.location.aggregate.interfaces;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace dddsample.specs.domain.model.cargo.aggregate
{
    public abstract class concern_for_cargo : Observes<ICargo, Cargo>
    {
        Establish context = () =>
        {
            tracking_id = the_dependency<ITrackingId>();
            route_specification = the_dependency<IRouteSpecification>();
        };

        protected static ITrackingId tracking_id;
        protected static IRouteSpecification route_specification;
    }

    public class when_asked_about_its_tracking_identificator : concern_for_cargo
    {
        Because of = () => result = sut.tracking_id();

        It should_provide_the_cargo_id = () => result.ShouldEqual(tracking_id);

        static ITrackingId result;
    }

    public class when_asked_about_its_route_specification : concern_for_cargo
    {
        Because of = () => result = sut.route_specification();

        It should_provide_the_route_specification = () => result.ShouldEqual(route_specification);

        static IRouteSpecification result;
    }

    public class when_asked_about_its_origin_location : concern_for_cargo
    {
        Establish context = () =>
        {
            the_origin_location = an<ILocation>();
            route_specification
                .Stub(x => x.origin())
                .Return(the_origin_location);
        };

        Because of = () => result = sut.origin_location();

        It should_provide_the_origin_location = () =>
            result.ShouldEqual(the_origin_location);

        It should_leverage_the_route_specification_origin_location = () =>
            route_specification.received(x => x.origin());

        static ILocation the_origin_location;
        static ILocation result;
    }

    public class when_comparing_two_equal_cargoes : concern_for_cargo
    {
        Establish context = () =>
        {
            the_to_compare_cargo = an<ICargo>();
            tracking_id
                .Stub(x => x.has_the_same_value_as(the_to_compare_cargo.tracking_id()))
                .Return(true);
        };

        Because of = () => result = sut.has_the_same_identity_as(the_to_compare_cargo);

        It should_confirm_that_they_have_the_same_identity = () => result.ShouldBeTrue();

        It should_leverage_the_tracking_identity_collaborator = () =>
            tracking_id.received(
                x => x.has_the_same_value_as(the_to_compare_cargo.tracking_id()));

        static ICargo the_to_compare_cargo;
        static bool result;
    }

    public class when_comparing_two_diferent_cargoes : concern_for_cargo
    {
        Establish context = () =>
        {
            the_to_compare_cargo = an<ICargo>();
            tracking_id
                .Stub(x => x.has_the_same_value_as(the_to_compare_cargo.tracking_id()))
                .Return(false);
        };

        Because of = () => result = sut.has_the_same_identity_as(the_to_compare_cargo);

        It should_confirm_that_they_have_diferent_identity = () => result.ShouldBeFalse();

        It should_leverage_the_tracking_identity_collaborator = () =>
            tracking_id.received(
                x => x.has_the_same_value_as(the_to_compare_cargo.tracking_id()));

        static ICargo the_to_compare_cargo;
        static bool result;
    }

    public class when_comparing_to_a_null_cargo : concern_for_cargo
    {
        Establish context = () =>
        {
            a_null_to_compare_cargo = null;
            tracking_id
                .Stub(x => x.has_the_same_value_as(null));
        };

        Because of = () => result = sut.has_the_same_identity_as(a_null_to_compare_cargo);

        It should_confirm_that_they_have_diferent_identity = () => result.ShouldBeFalse();

        It should_not_leverage_the_tracking_identity_collaborator = () =>
            tracking_id.never_received(x => x.has_the_same_value_as(null));

        static bool result;
        static ICargo a_null_to_compare_cargo;
    }

    public class when_asked_about_its_hash_code : concern_for_cargo
    {
        Establish context = () =>
        {
            tracking_id
                .Stub(x => x.GetHashCode())
                .Return(new int());
        };

        Because of = () => sut.GetHashCode();

        It should_leverage_the_tracking_identity_hash_code = () =>
            tracking_id.received(x => x.GetHashCode());
    }

    public class when_asked_about_its_string_representation : concern_for_cargo
    {
        Establish context = () =>
        {
            tracking_id
                .Stub(x => x.id())
                .Return(string.Empty);
        };

        Because of = () => sut.ToString();

        It should_leverage_the_tracking_identity_string_representation = () =>
            tracking_id.received(x => x.id());
    }

    public class when_comparing_two_cargoes_with_the_same_identity_using_equals : concern_for_cargo
    {
        Establish context = () =>
        {
            the_other_cargo = an<ICargo>();
            the_other_cargo
                .Stub(x => x.tracking_id())
                .Return(tracking_id);

            tracking_id
                .Stub(x => x.has_the_same_value_as(tracking_id))
                .Return(true);
        };

        Because of = () => result = sut.Equals(the_other_cargo);

        It should_leverage_the_cargo_entity_comparer = () => tracking_id.received(x => x.has_the_same_value_as(tracking_id));
        
        It should_confirm_they_are_equal = () => result.ShouldBeTrue();

        static bool result;
        static ICargo the_other_cargo;
    }

    public class when_comparing_two_cargoes_with_different_identity_using_equals : concern_for_cargo
    {
        Establish context = () =>
        {
            the_other_cargo = an<ICargo>();
            the_other_cargo
                .Stub(x => x.tracking_id())
                .Return(tracking_id);

            tracking_id
                .Stub(x => x.has_the_same_value_as(tracking_id))
                .Return(false);
        };

        Because of = () => result = sut.Equals(the_other_cargo);

        It should_leverage_the_cargo_entity_comparer = () => tracking_id.received(x => x.has_the_same_value_as(tracking_id));

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static ICargo the_other_cargo;
    }

    public class when_comparing_any_cargo_with_a_null_cargo_using_equals : concern_for_cargo
    {
        Establish context = () =>
        {
            the_other_cargo = null;
        };

        Because of = () => result = sut.Equals(the_other_cargo);

        It should_leverage_the_cargo_entity_comparer = () => tracking_id.never_received(x => x.has_the_same_value_as(tracking_id));

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static ICargo the_other_cargo;
    }

    public class when_comparing_any_cargo_with_a_diferent_type_object_using_equals : concern_for_cargo
    {
        Establish context = () =>
        {
            not_a_cargo = an<ILeg>();
        };

        Because of = () => result = sut.Equals(not_a_cargo);

        It should_leverage_the_cargo_entity_comparer = () => tracking_id.never_received(x => x.has_the_same_value_as(tracking_id));

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static ILeg not_a_cargo;
    }
}