using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.location.aggregate.interfaces;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace dddsample.specs.domain.model.location.aggregate
{
    public abstract class concern_for_location : Observes<ILocation, Location>
    {
        Establish context = () =>
        {
            the_injected_united_nations_location_code = an<IUnitedNationsLocationCode>();
            the_injected_location_name = an<ILocationName>();
            the_location_factory = new LocationAggregateFactory();

            create_sut_using(() => the_location_factory.create_location_using(the_injected_united_nations_location_code, the_injected_location_name));
        };

        static protected IUnitedNationsLocationCode the_injected_united_nations_location_code;
        static protected ILocationName the_injected_location_name;
        static ILocationFactory the_location_factory;
    }

    public class when_returning_the_associated_united_nations_location_code : concern_for_location
    {

        Because of = () => result = sut.associated_united_nations_location_code();
        
        It should_return_the_underlying_united_nations_location_code =
            () => result.ShouldEqual(the_injected_united_nations_location_code);
        
        static IUnitedNationsLocationCode result;
    }

    public class when_returning_the_actual_location_name : concern_for_location
    {
        Establish context = () =>
        {
            the_injected_location_name
                .Stub(x => x.name())
                .Return("boo");
        };

        Because of = () => result = sut.actual_location_name();

        It should_leverage_the_underlying_location_name_representation =
            () => the_injected_location_name.received(x=>x.name());

        static string result;
    }

    public class when_comparing_two_locations_with_the_same_identity : concern_for_location
    {
        Establish context = () =>
        {
            the_other_location = an<ILocation>();
            the_other_location
                .Stub(x => x.associated_united_nations_location_code())
                .Return(the_injected_united_nations_location_code);

            the_injected_united_nations_location_code
                .Stub(x => x.has_the_same_value_as(the_injected_united_nations_location_code))
                .Return(true);
        };

        Because of = () => result = sut.has_the_same_identity_as(the_other_location);
        
        It should_leverage_the_underlying_united_nations_location_code_value_comparer =
            () => the_injected_united_nations_location_code.received(x => x.has_the_same_value_as(the_injected_united_nations_location_code));

        It should_confirm_they_have_the_same_identity = () => result.ShouldBeTrue();

        static bool result;
        static ILocation the_other_location;
    }

    public class when_comparing_two_locations_with_different_identity : concern_for_location
    {
        Establish context = () =>
        {
            the_other_location = an<ILocation>();
            the_other_location
                .Stub(x => x.associated_united_nations_location_code())
                .Return(the_injected_united_nations_location_code);

            the_injected_united_nations_location_code
                .Stub(x => x.has_the_same_value_as(the_injected_united_nations_location_code))
                .Return(false);
        };

        Because of = () => result = sut.has_the_same_identity_as(the_other_location);

        It should_leverage_the_underlying_united_nations_location_code_value_comparer =
            () => the_injected_united_nations_location_code.received(x => x.has_the_same_value_as(the_injected_united_nations_location_code));

        It should_confirm_they_have_different_identity = () => result.ShouldBeFalse();

        static bool result;
        static ILocation the_other_location;
    }

    public class when_comparing_any_location_with_a_null_location : concern_for_location
    {
        Establish context = () =>
        {
            the_other_location = null;
        };

        Because of = () => result = sut.has_the_same_identity_as(the_other_location);
        
        It should_confirm_they_have_different_identity = () => result.ShouldBeFalse();

        static bool result;
        static ILocation the_other_location;
    }

    //public class when_calculating_the_location_hash_code_v1 : concern_for_location
    //{
    //    Establish context = () =>
    //    {
    //        the_injected_united_nations_location_code
    //            .Stub(x => x.GetHashCode())
    //            .Return(1);
    //    };

    //    Because of = () => result = sut.GetHashCode();

    //    It should_leverage_the_underlying_united_nations_location_code_hash_code =
    //        () => the_injected_united_nations_location_code.received(x => x.GetHashCode());

    //    It should_leverage_the_underlying_location_name_hash_code = () =>
    //       result.ShouldEqual(the_injected_location_name.GetHashCode() + 13376);

    //    It should_return_the_hash_code = () => result.ShouldEqual(341586293);

    //    static int result;
    //}

    public class when_calculating_the_location_hash_code_v2 : concern_for_location
    {
        Establish context = () =>
        {
            the_injected_united_nations_location_code
                .Stub(x => x.GetHashCode())
                .Return(1);

            the_injected_location_name
                .Stub(x => x.GetHashCode())
                .Return(2);
        };

        Because of = () => result = sut.GetHashCode();

        It should_leverage_the_underlying_united_nations_location_code_hash_code =
            () => the_injected_united_nations_location_code.received(x => x.GetHashCode());

        It should_leverage_the_underlying_location_name_hash_code = () =>
            the_injected_location_name.received(x => x.GetHashCode());

        It should_return_the_hash_code = () => result.ShouldEqual(13378);

        static int result;
    }

    public class when_comparing_two_locations_with_the_same_identity_using_equals : concern_for_location
    {
        Establish context = () =>
        {
            the_other_location = an<ILocation>();
            the_other_location
                .Stub(x => x.associated_united_nations_location_code())
                .Return(the_injected_united_nations_location_code);

            the_injected_united_nations_location_code
                .Stub(x => x.has_the_same_value_as(the_injected_united_nations_location_code))
                .Return(true);
        };

        Because of = () => result = sut.Equals(the_other_location);

        It should_leverage_the_location_identity_comparer =
            () => the_injected_united_nations_location_code.received(x => x.has_the_same_value_as(the_injected_united_nations_location_code));

        It should_confirm_they_have_are_equal = () => result.ShouldBeTrue();

        static bool result;
        static ILocation the_other_location;
    }

    public class when_comparing_two_locations_with_different_identity_using_equals : concern_for_location
    {
        Establish context = () =>
        {
            the_other_location = an<ILocation>();
            the_other_location
                .Stub(x => x.associated_united_nations_location_code())
                .Return(the_injected_united_nations_location_code);

            the_injected_united_nations_location_code
                .Stub(x => x.has_the_same_value_as(the_injected_united_nations_location_code))
                .Return(false);
        };

        Because of = () => result = sut.Equals(the_other_location);

        It should_leverage_the_location_identity_comparer =
            () => the_injected_united_nations_location_code.received(x => x.has_the_same_value_as(the_injected_united_nations_location_code));

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static ILocation the_other_location;
    }

    public class when_comparing_any_location_with_a_null_location_using_equals : concern_for_location
    {
        Establish context = () =>
        {
            the_other_location = null;
        };

        Because of = () => result = sut.Equals(the_other_location);

        It should_leverage_the_location_identity_comparer =
            () => the_injected_united_nations_location_code.never_received(x => x.has_the_same_value_as(the_injected_united_nations_location_code));

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static ILocation the_other_location;
    }

    public class when_comparing_any_location_with_a_different_type_object_using_equals : concern_for_location
    {
        Establish context = () =>
        {
            not_a_location = an<ILocationName>();
        };

        Because of = () => result = sut.Equals(not_a_location);

        It should_leverage_the_leg_value_object_comparer =
            () =>
                the_injected_united_nations_location_code.never_received(
                    x => x.has_the_same_value_as(the_injected_united_nations_location_code));

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static ILocationName not_a_location;
    }
}