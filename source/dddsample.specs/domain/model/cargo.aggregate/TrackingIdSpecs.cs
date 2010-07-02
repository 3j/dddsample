using System;
using dddsample.domain.model.cargo.aggregate;
using dddsample.domain.model.cargo.aggregate.interfaces;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;

namespace dddsample.specs.domain.model.cargo.aggregate
{
    public abstract class concern_for_tracking_id : Observes<ITrackingId, TrackingId>
    {
        Establish context = () =>
        {
            the_tracking_id_factory = new CargoAggregateFactory();
            the_injected_id = "1234";

            create_sut_using(() => the_tracking_id_factory.create_tracking_id_using(the_injected_id));
        };

        protected static ITrackingIdFactory the_tracking_id_factory;
        protected static string the_injected_id;
    }
    
    public class when_returning_the_tracking_id_value : concern_for_tracking_id
    {
        Because of = () => result = sut.id();

        It should_return_the_underlying_id = () => result.ShouldEqual(the_injected_id);

        static string result;
    }

    public class when_comparing_two_tracking_ids_with_the_same_attributes : concern_for_tracking_id
    {
        Establish context = () =>
        {
            the_other_tracking_id = the_tracking_id_factory.create_tracking_id_using(the_injected_id);
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_tracking_id);
        
        It should_confirm_they_have_the_same_value = () => result.ShouldBeTrue();
        
        static bool result;
        static ITrackingId the_other_tracking_id;
    }

    public class when_comparing_two_tracking_ids_with_the_different_attributes : concern_for_tracking_id
    {
        Establish context = () =>
        {
            the_other_injected_id = "5678";
            the_other_tracking_id = the_tracking_id_factory.create_tracking_id_using(the_other_injected_id);
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_tracking_id);

        It should_confirm_they_have_not_the_same_value = () => result.ShouldBeFalse();

        static bool result;
        static ITrackingId the_other_tracking_id;
        static string the_other_injected_id;
    }

    public class when_comparing_any_tracking_id_with_a_null_tracking_id : concern_for_tracking_id
    {
        Establish context = () =>
        {
            the_other_tracking_id = null;
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_tracking_id);

        It should_confirm_they_have_not_the_same_value = () => result.ShouldBeFalse();

        static bool result;
        static ITrackingId the_other_tracking_id;
    }

    public class when_calculating_the_tracking_id_hash_code : concern_for_tracking_id
    {
        Because of = () => result = sut.GetHashCode();

        It should_return_the_constructor_injected_id_hash_code = () => result.ShouldEqual(the_injected_id.GetHashCode());

        static int result;
    }

    public class when_comparing_two_tracking_ids_with_the_same_attributes_using_equals : concern_for_tracking_id
    {
        Establish context = () =>
        {
            the_other_tracking_id = the_tracking_id_factory.create_tracking_id_using(the_injected_id);
        };

        Because of = () => result = sut.Equals(the_other_tracking_id);

        It should_confirm_they_are_equal = () => result.ShouldBeTrue();
        
        static bool result;
        static ITrackingId the_other_tracking_id;
    }

    public class when_comparing_two_tracking_ids_with_different_attributes_using_equals : concern_for_tracking_id
    {
        Establish context = () =>
        {
            the_other_injected_id = "9876";
            the_other_tracking_id = the_tracking_id_factory.create_tracking_id_using(the_other_injected_id);
        };

        Because of = () => result = sut.Equals(the_other_tracking_id);

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static ITrackingId the_other_tracking_id;
        static string the_other_injected_id;
    }

    public class when_comparing_any_tracking_id_with_a_null_tracking_id_using_equals : concern_for_tracking_id
    {
        Establish context = () =>
        {   
            the_other_tracking_id = null;
        };

        Because of = () => result = sut.Equals(the_other_tracking_id);

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static ITrackingId the_other_tracking_id;
    }

    public class when_comparing_any_tracking_id_with_a_different_type_object_using_equals : concern_for_tracking_id
    {
        Establish context = () =>
        {
            not_a_tracking_id = an<IItinerary>();
        };

        Because of = () => result = sut.Equals(not_a_tracking_id);

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static IItinerary not_a_tracking_id;
    }
}