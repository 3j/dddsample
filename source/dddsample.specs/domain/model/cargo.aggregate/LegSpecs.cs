using dddsample.domain.model.cargo.aggregate;
using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.voyage.aggregate;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace dddsample.specs.domain.model.cargo.aggregate
{
    public abstract class concern_for_leg : Observes<ILeg, Leg>
    {
        Establish context = () =>
        {
            the_injected_voyage = an<IVoyage>();
            the_injected_load_location = an<ILocation>();
            the_injected_unload_location = an<ILocation>();
            the_injected_load_time = an<IDate>();
            the_injected_unload_time = an<IDate>();
            the_leg_factory = new CargoAggregateFactory();

            create_sut_using(() => the_leg_factory.create_leg_using(
                         the_injected_voyage, the_injected_load_location, the_injected_unload_location,
                         the_injected_load_time, the_injected_unload_time));
        };

        protected static IVoyage the_injected_voyage;
        protected static ILocation the_injected_load_location;
        protected static ILocation the_injected_unload_location;
        protected static IDate the_injected_load_time;
        protected static IDate the_injected_unload_time;
        protected static ILegFactory the_leg_factory;
    }

    public class when_returning_the_voyage : concern_for_leg
    {
        Because of = () => result = sut.voyage();

        It should_return_the_underlying_voyage = () => result.ShouldEqual(the_injected_voyage);

        static IVoyage result;
    }

    public class when_returning_the_load_location : concern_for_leg
    {
        Because of = () => result = sut.load_location();

        It should_return_the_underlying_load_location = () => result.ShouldEqual(the_injected_load_location);

        static ILocation result;
    }

    public class when_returning_the_unload_location : concern_for_leg
    {
        Because of = () => result = sut.unload_location();

        It should_return_the_underlying_unload_location = () => result.ShouldEqual(the_injected_unload_location);

        static ILocation result;
    }

    public class when_returning_the_load_time : concern_for_leg
    {
        Because of = () => result = sut.load_time();

        It should_return_the_underlying_load_time = () => result.ShouldEqual(the_injected_load_time);

        static IDate result;
    }

    public class when_returning_the_unload_time : concern_for_leg
    {
        Because of = () => result = sut.unload_time();

        It should_return_the_underlying_unload_time = () => result.ShouldEqual(the_injected_unload_time);

        static IDate result;
    }

    public class when_comparing_two_legs_with_the_same_attributes : concern_for_leg
    {
        Establish context = () =>
        {
            the_other_leg = the_leg_factory.create_leg_using(the_injected_voyage, the_injected_load_location, the_injected_unload_location,
                                                             the_injected_load_time, the_injected_unload_time);
            
            the_injected_voyage
                .Stub(x => x.has_the_same_identity_as(the_injected_voyage))
                .Return(true);
            the_injected_load_location
                .Stub(x => x.has_the_same_identity_as(the_injected_load_location))
                .Return(true);
            the_injected_unload_location
                .Stub(x => x.has_the_same_identity_as(the_injected_unload_location))
                .Return(true);
            the_injected_load_time
                .Stub(x => x.has_the_same_value_as(the_injected_load_time))
                .Return(true);
            the_injected_unload_time
                .Stub(x => x.has_the_same_value_as(the_injected_unload_time))
                .Return(true);
            
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_leg);

        It should_leverage_the_underlying_voyage_identity_comparer =
            () => the_injected_voyage.received(x => x.has_the_same_identity_as(the_injected_voyage));

        It should_leverage_the_underlying_load_location_identity_comparer =
            () => the_injected_load_location.received(x => x.has_the_same_identity_as(the_injected_load_location));

        It should_leverage_the_underlying_unload_location_identity_comparer =
            () => the_injected_unload_location.received(x => x.has_the_same_identity_as(the_injected_unload_location));

        It should_leverage_the_underlying_load_time_value_comparer =
            () => the_injected_load_time.received(x => x.has_the_same_value_as(the_injected_load_time));

        It should_leverage_the_underlying_unload_time_value_comparer =
            () => the_injected_unload_time.received(x => x.has_the_same_value_as(the_injected_unload_time));

        It should_confirm_they_have_the_same_value = () => result.ShouldBeTrue();

        static bool result;
        static ILeg the_other_leg;
    }

    public class when_comparing_two_legs_with_different_attributes : concern_for_leg
    {
        Establish context = () =>
        {
            the_new_unload_location = an<ILocation>();
            the_other_leg = the_leg_factory.create_leg_using(the_injected_voyage, the_injected_load_location, the_new_unload_location,
                                                             the_injected_load_time, the_injected_unload_time);

            the_injected_voyage
                .Stub(x => x.has_the_same_identity_as(the_injected_voyage))
                .Return(true);
            the_injected_load_location
                .Stub(x => x.has_the_same_identity_as(the_injected_load_location))
                .Return(true);
            the_injected_unload_location
                .Stub(x => x.has_the_same_identity_as(the_new_unload_location))
                .Return(false);

        };

        Because of = () => result = sut.has_the_same_value_as(the_other_leg);

        It should_leverage_the_different_attribute_identity_or_value_comparer =
            () => the_injected_unload_location.received(x => x.has_the_same_identity_as(the_new_unload_location));

        It should_confirm_they_have_not_the_same_value = () => result.ShouldBeFalse();

        static bool result;
        static ILeg the_other_leg;
        static ILocation the_new_unload_location;
    }

    public class when_comparing_any_leg_with_a_null_leg : concern_for_leg
    {
        Establish context = () =>
        {
            the_other_leg = null;
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_leg);
        
        It should_confirm_they_have_not_the_same_value = () => result.ShouldBeFalse();

        static bool result;
        static ILeg the_other_leg;
    }

    public class when_calculating_the_leg_hash_code : concern_for_leg
    {
        Establish context = () =>
        {
            the_injected_voyage
                .Stub(x => x.GetHashCode())
                .Return(2);
            the_injected_load_location
                .Stub(x => x.GetHashCode())
                .Return(4);
            the_injected_unload_location
                .Stub(x => x.GetHashCode())
                .Return(6);
            the_injected_load_time
                .Stub(x => x.GetHashCode())
                .Return(8);
            the_injected_unload_time
                .Stub(x => x.GetHashCode())
                .Return(10);
        };

        Because of = () => result = sut.GetHashCode();

        It should_leverage_the_underlying_voyage_hash_code =
            () => the_injected_voyage.received(x => x.GetHashCode());

        It should_leverage_the_underlying_load_location_hash_code =
            () => the_injected_load_location.received(x => x.GetHashCode());

        It should_leverage_the_underlying_unload_location_hash_code =
            () => the_injected_unload_location.received(x => x.GetHashCode());

        It should_leverage_the_underlying_load_time_hash_code =
            () => the_injected_load_time.received(x => x.GetHashCode());

        It should_leverage_the_underlying_unload_time_hash_code =
            () => the_injected_unload_time.received(x => x.GetHashCode());

        It should_return_the_hash_code = () => result.ShouldEqual(91906069);

        static int result;
    }

    public class when_comparing_two_legs_with_the_same_attributes_using_equals : concern_for_leg
    {
        Establish context = () =>
        {
            the_other_leg = the_leg_factory.create_leg_using(the_injected_voyage, the_injected_load_location, the_injected_unload_location,
                                                             the_injected_load_time, the_injected_unload_time);

            the_injected_voyage
                .Stub(x => x.has_the_same_identity_as(the_injected_voyage))
                .Return(true);
            the_injected_load_location
                .Stub(x => x.has_the_same_identity_as(the_injected_load_location))
                .Return(true);
            the_injected_unload_location
                .Stub(x => x.has_the_same_identity_as(the_injected_unload_location))
                .Return(true);
            the_injected_load_time
                .Stub(x => x.has_the_same_value_as(the_injected_load_time))
                .Return(true);
            the_injected_unload_time
                .Stub(x => x.has_the_same_value_as(the_injected_unload_time))
                .Return(true);
        };

        Because of = () => result = sut.Equals(the_other_leg);

        It should_leverage_the_leg_value_object_comparer = () =>
        {
            the_injected_voyage.received(x => x.has_the_same_identity_as(the_injected_voyage));
            the_injected_load_location.received(x => x.has_the_same_identity_as(the_injected_load_location));
            the_injected_unload_location.received(x => x.has_the_same_identity_as(the_injected_unload_location));
            the_injected_load_time.received(x => x.has_the_same_value_as(the_injected_load_time));
            the_injected_unload_time.received(x => x.has_the_same_value_as(the_injected_unload_time));
        };

        It should_confirm_they_are_equal = () => result.ShouldBeTrue();

        static bool result;
        static ILeg the_other_leg;
    }

    public class when_comparing_two_legs_with_different_attributes_using_equals : concern_for_leg
    {
        Establish context = () =>
        {
            the_other_leg = the_leg_factory.create_leg_using(the_injected_voyage, the_injected_load_location, the_injected_unload_location,
                                                             the_injected_load_time, the_injected_unload_time);
            the_injected_voyage
                .Stub(x => x.has_the_same_identity_as(the_injected_voyage))
                .Return(true);
            the_injected_load_location
                .Stub(x => x.has_the_same_identity_as(the_injected_load_location))
                .Return(true);
            the_injected_unload_location
                .Stub(x => x.has_the_same_identity_as(the_injected_unload_location))
                .Return(true);
            the_injected_load_time
                .Stub(x => x.has_the_same_value_as(the_injected_load_time))
                .Return(false);
        };

        Because of = () => result = sut.Equals(the_other_leg);

        It should_leverage_the_leg_value_object_comparer = () =>
        {
            the_injected_voyage.received(x => x.has_the_same_identity_as(the_injected_voyage));
            the_injected_load_location.received(x => x.has_the_same_identity_as(the_injected_load_location));
            the_injected_unload_location.received(x => x.has_the_same_identity_as(the_injected_unload_location));
            the_injected_load_time.received(x => x.has_the_same_value_as(the_injected_load_time));
            the_injected_unload_time.never_received(x => x.has_the_same_value_as(the_injected_unload_time));
        };

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static ILeg the_other_leg;
    }

    public class when_comparing_any_leg_with_a_null_leg_using_equals : concern_for_leg
    {
        Establish context = () =>
        {
            the_other_leg = null;   
        };

        Because of = () => result = sut.Equals(the_other_leg);

        It should_leverage_the_leg_value_object_comparer = () =>
        {
            the_injected_voyage.never_received(x => x.has_the_same_identity_as(the_injected_voyage));
            the_injected_load_location.never_received(x => x.has_the_same_identity_as(the_injected_load_location));
            the_injected_unload_location.never_received(x => x.has_the_same_identity_as(the_injected_unload_location));
            the_injected_load_time.never_received(x => x.has_the_same_value_as(the_injected_load_time));
            the_injected_unload_time.never_received(x => x.has_the_same_value_as(the_injected_unload_time));
        };

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static ILeg the_other_leg;
    }

    public class when_comparing_any_leg_with_a_different_type_object_using_equals : concern_for_leg
    {
        Establish context = () =>
        {
            not_a_leg = an<ILocation>();
        };

        Because of = () => result = sut.Equals(not_a_leg);

        It should_leverage_the_leg_value_object_comparer = () =>
        {
            the_injected_voyage.never_received(x => x.has_the_same_identity_as(the_injected_voyage));
            the_injected_load_location.never_received(x => x.has_the_same_identity_as(the_injected_load_location));
            the_injected_unload_location.never_received(x => x.has_the_same_identity_as(the_injected_unload_location));
            the_injected_load_time.never_received(x => x.has_the_same_value_as(the_injected_load_time));
            the_injected_unload_time.never_received(x => x.has_the_same_value_as(the_injected_unload_time));
        };

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static ILocation not_a_leg;
    }
}