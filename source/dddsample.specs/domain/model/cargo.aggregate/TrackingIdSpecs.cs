using System;
using System.Collections.Generic;
using System.Data;
using dddsample.domain.model.cargo.aggregate;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;

namespace dddsample.specs.domain.model.cargo.aggregate
{
    public abstract class concern_for_tracking_id : Observes<ITrackingId, TrackingId> {}
    
    // DEBERIA IR A LA FACTORIA
    public class when_trying_to_construct_the_tracking_id_with_a_null_id
    {
        Establish context = () =>
        {
            the_id = null;
        };

        Because of = () => exception = Catch.Exception(() => new TrackingId(the_id));
        
        It should_should_throw_a_null_argument_exception = () => exception.ShouldBeAn<ArgumentNullException>();
        It should_contain_a_custom_error_message = () => exception.ShouldContainErrorMessage("The injected id cannot be null.");

        static Exception exception;
        static string the_id;
    }

    public class when_returning_the_tracking_id_value : concern_for_tracking_id
    {
        Establish context = () =>
        {
            the_injected_id = "1234";
            provide_a_basic_sut_constructor_argument(the_injected_id);
        };

        Because of = () => result = sut.id();

        It should_return_the_underlying_id = () => result.ShouldEqual(the_injected_id);

        static string result;
        static string the_injected_id;
    }

    public class when_comparing_two_tracking_ids_with_the_same_attributes : concern_for_tracking_id
    {
        Establish context = () =>
        {
            the_injected_id = "1234";
            the_other_tracking_id = new TrackingId(the_injected_id);
            provide_a_basic_sut_constructor_argument(the_injected_id);
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_tracking_id);
        
        It should_confirm_they_have_the_same_value = () => result.ShouldBeTrue();
        
        static bool result;
        static ITrackingId the_other_tracking_id;
        static string the_injected_id;
    }

    public class when_comparing_two_tracking_ids_with_the_different_attributes : concern_for_tracking_id
    {
        Establish context = () =>
        {
            a_injected_id = "1234";
            another_injected_id = "5678";
            the_other_tracking_id = new TrackingId(a_injected_id);
            provide_a_basic_sut_constructor_argument(another_injected_id);
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_tracking_id);

        It should_confirm_they_have_not_the_same_value = () => result.ShouldBeFalse();

        static bool result;
        static ITrackingId the_other_tracking_id;
        static string a_injected_id;
        static string another_injected_id;
    }

    public class when_comparing_any_tracking_id_with_a_null_tracking_id : concern_for_tracking_id
    {
        Establish context = () =>
        {
            the_injected_id = "1234";
            the_other_tracking_id = null;
            provide_a_basic_sut_constructor_argument(the_injected_id);
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_tracking_id);

        It should_confirm_they_have_not_the_same_value = () => result.ShouldBeFalse();

        static bool result;
        static ITrackingId the_other_tracking_id;
        static string the_injected_id;
    }

    public class when_calculating_the_tracking_id_hash_code : concern_for_tracking_id
    {
        Establish context = () =>
        {
            the_injected_id = "1234";
            provide_a_basic_sut_constructor_argument(the_injected_id);
        };

        Because of = () => result = sut.GetHashCode();

        It should_return_the_constructor_injected_id_hash_code = () => result.ShouldEqual(the_injected_id.GetHashCode());

        static int result;
        static string the_injected_id;
    }

    public class when_comparing_two_tracking_ids_with_the_same_attributes_using_equals : concern_for_tracking_id
    {
        Establish context = () =>
        {
            the_injected_id = "1234";
            provide_a_basic_sut_constructor_argument(the_injected_id);

            the_other_tracking_id = new TrackingId(the_injected_id);
        };

        Because of = () => result = sut.Equals(the_other_tracking_id);

        It should_confirm_they_are_equal = () => result.ShouldBeTrue();
        
        static bool result;
        static string the_injected_id;
        static ITrackingId the_other_tracking_id;
    }

    public class when_comparing_two_tracking_ids_with_different_attributes_using_equals : concern_for_tracking_id
    {
        Establish context = () =>
        {
            the_injected_id = "1234";
            provide_a_basic_sut_constructor_argument(the_injected_id);

            the_other_injected_id = "9876";
            the_other_tracking_id = new TrackingId(the_other_injected_id);
        };

        Because of = () => result = sut.Equals(the_other_tracking_id);

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static string the_injected_id;
        static ITrackingId the_other_tracking_id;
        static string the_other_injected_id;
    }

    public class when_comparing_any_tracking_id_with_a_null_tracking_id_using_equals : concern_for_tracking_id
    {
        Establish context = () =>
        {
            the_injected_id = "1234";
            provide_a_basic_sut_constructor_argument(the_injected_id);
            
            the_other_tracking_id = null;
        };

        Because of = () => result = sut.Equals(the_other_tracking_id);

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static string the_injected_id;
        static ITrackingId the_other_tracking_id;
    }

    public class when_comparing_any_tracking_id_with_a_different_type_object_using_equals : concern_for_tracking_id
    {
        Establish context = () =>
        {
            the_injected_id = "1234";
            provide_a_basic_sut_constructor_argument(the_injected_id);

            not_a_tracking_id = an<IItinerary>();
        };

        Because of = () => result = sut.Equals(not_a_tracking_id);

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static string the_injected_id;
        static IItinerary not_a_tracking_id;
    }
}