using System;
using dddsample.domain.model.cargo.aggregate;
using dddsample.domain.model.handling.aggregate;
using dddsample.domain.model.location.aggregate;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace dddsample.specs.domain.model.cargo.aggregate
{
    public abstract class concern_for_handling_activity : Observes<IHandlingActivity, HandlingActivity>
    {
        Establish context = () =>
        {
            the_injected_handling_event_type = the_dependency<IHandlingEventType>();
            the_injected_location = the_dependency<ILocation>();
        };

        protected static IHandlingEventType the_injected_handling_event_type;
        protected static ILocation the_injected_location;
    }

    public class when_returning_the_location : concern_for_handling_activity
    {
        Because of = () => result = sut.location();

        It should_return_the_underlying_location = () => result.ShouldEqual(the_injected_location);

        static ILocation result;
    }

    public class when_returning_the_handling_event_type : concern_for_handling_activity
    {
        Because of = () => result = sut.handling_event_type();

        It should_return_the_underlying_handling_event_type = () => result.ShouldEqual(the_injected_handling_event_type);

        static IHandlingEventType result;
    }

    public class when_comparing_two_handling_activities_with_the_same_attributes : concern_for_handling_activity
    {
        Establish context = () =>
        {
            the_other_handling_activity = an<IHandlingActivity>();
            the_other_handling_activity
                .Stub(x => x.location())
                .Return(the_injected_location);
            the_other_handling_activity
                .Stub(x => x.handling_event_type())
                .Return(the_injected_handling_event_type);

            the_injected_location
                .Stub(x => x.has_the_same_identity_as(the_injected_location))
                .Return(true);
            the_injected_handling_event_type
                .Stub(x => x.has_the_same_value_as(the_injected_handling_event_type))
                .Return(true);
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_handling_activity);

        It should_leverage_the_location_identity_comparer =
            () => the_injected_location.received(x => x.has_the_same_identity_as(the_injected_location));

        It should_leverage_the_handling_event_type_value_comparer =
            () =>
                the_injected_handling_event_type.received(x => x.has_the_same_value_as(the_injected_handling_event_type));

        It should_confirm_they_have_the_same_value = () => result.ShouldBeTrue();

        static bool result;
        static IHandlingActivity the_other_handling_activity;
    }

    public class when_comparing_two_handling_activities_with_different_attributes : concern_for_handling_activity
    {
        Establish context = () =>
        {
            the_other_handling_activity = an<IHandlingActivity>();
            the_other_handling_activity
                .Stub(x => x.location())
                .Return(the_injected_location);
            the_other_handling_activity
                .Stub(x => x.handling_event_type())
                .Return(the_injected_handling_event_type);

            the_injected_location
                .Stub(x => x.has_the_same_identity_as(the_injected_location))
                .Return(true);
            the_injected_handling_event_type
                .Stub(x => x.has_the_same_value_as(the_injected_handling_event_type))
                .Return(false);
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_handling_activity);

        It should_leverage_the_different_attribute_identity_or_value_comparer =
            () => the_injected_handling_event_type.received(x => x.has_the_same_value_as(the_injected_handling_event_type));

        It should_confirm_they_have_not_the_same_value = () => result.ShouldBeFalse();

        static bool result;
        static IHandlingActivity the_other_handling_activity;
    }

    public class when_comparing_any_handling_activity_with_a_null_handling_activity : concern_for_handling_activity
    {
        Establish context = () =>
        {
            the_other_handling_activity = null;

            the_injected_location
                .Stub(x => x.has_the_same_identity_as(the_injected_location))
                .Return(false);
            the_injected_handling_event_type
                .Stub(x => x.has_the_same_value_as(the_injected_handling_event_type))
                .Return(false);
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_handling_activity);

        It should_not_leverage_the_location_identity_comparer =
            () => the_injected_location.never_received(x => x.has_the_same_identity_as(the_injected_location));

        It should_not_leverage_the_handling_event_type_value_comparer =
            () =>
                the_injected_handling_event_type.never_received(
                    x => x.has_the_same_value_as(the_injected_handling_event_type));

        It should_confirm_they_have_not_the_same_value = () => result.ShouldBeFalse();

        static bool result;
        static IHandlingActivity the_other_handling_activity;
    }

    public class when_calculating_the_handling_activity_hash_code : concern_for_handling_activity
    {
        Establish context = () =>
        {
            the_injected_location
                .Stub(x => x.GetHashCode())
                .Return(3);
            the_injected_handling_event_type
                .Stub(x => x.GetHashCode())
                .Return(5);
        };

        Because of = () => result = sut.GetHashCode();

        It should_leverage_the_location_hash_code = () => the_injected_location.received(x => x.GetHashCode());

        It should_leverage_the_handling_event_type_hash_code = () => the_injected_handling_event_type.received(x => x.GetHashCode());

        It should_return_the_hash_code = () => result.ShouldEqual(13419);

        static int result;
    }

    public class when_comparing_two_handling_activities_with_the_same_attributes_using_equals : concern_for_handling_activity
    {
        Establish context = () =>
        {
            the_other_handling_activity = new HandlingActivity(the_injected_location, the_injected_handling_event_type);

            the_injected_location
                .Stub(x => x.has_the_same_identity_as(the_injected_location))
                .Return(true);
            the_injected_handling_event_type
                .Stub(x => x.has_the_same_value_as(the_injected_handling_event_type))
                .Return(true);
        };

        Because of = () => result = sut.Equals(the_other_handling_activity);

        It should_leverage_the_handling_activity_value_object_comparer = () =>
        {
            the_injected_location.received(x => x.has_the_same_identity_as(the_injected_location));
            the_injected_handling_event_type.received(x => x.has_the_same_value_as(the_injected_handling_event_type));
        };
        
        It should_confirm_they_are_equal = () => result.ShouldBeTrue();

        static bool result;
        static IHandlingActivity the_other_handling_activity;
    }

    public class when_comparing_two_handling_activities_with_the_different_attributes_using_equals : concern_for_handling_activity
    {
        Establish context = () =>
        {
            the_other_handling_activity = new HandlingActivity(the_injected_location, the_injected_handling_event_type);

            the_injected_location
                .Stub(x => x.has_the_same_identity_as(the_injected_location))
                .Return(true);
            the_injected_handling_event_type
                .Stub(x => x.has_the_same_value_as(the_injected_handling_event_type))
                .Return(false);
        };

        Because of = () => result = sut.Equals(the_other_handling_activity);

        It should_leverage_the_handling_activity_value_object_comparer = () =>
        {
            the_injected_location.received(x => x.has_the_same_identity_as(the_injected_location));
            the_injected_handling_event_type.received(x => x.has_the_same_value_as(the_injected_handling_event_type));
        };

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static IHandlingActivity the_other_handling_activity;
    }

    public class when_comparing_any_handling_activity_with_a_null_handling_activity_using_equals : concern_for_handling_activity
    {
        Establish context = () =>
        {
            the_other_handling_activity = null;
        };

        Because of = () => result = sut.Equals(the_other_handling_activity);

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static IHandlingActivity the_other_handling_activity;
    }

    public class when_comparing_any_handling_activity_with_a_different_type_object_using_equals : concern_for_handling_activity
    {
        Establish context = () =>
        {
            not_a_handling_activity = an<ILocation>();
        };

        Because of = () => result = sut.Equals(not_a_handling_activity);

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static ILocation not_a_handling_activity;
    }
}