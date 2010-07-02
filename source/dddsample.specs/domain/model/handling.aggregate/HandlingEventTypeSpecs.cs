using dddsample.domain.model.handling.aggregate;
using Machine.Specifications;

namespace dddsample.specs.domain.model.handling.aggregate
{
    public class when_asked_about_the_receive_handling_event_type_name
    {
        Because of = () => result = HandlingEventType.RECEIVE.display_name();

        It should_return_the_receive_display_name = () => result.ShouldEqual("RECEIVE");

        static string result;
    }

    public class when_asked_about_the_load_handling_event_type_name
    {
        Because of = () => result = HandlingEventType.LOAD.display_name();

        It should_return_the_load_display_name = () => result.ShouldEqual("LOAD");

        static string result;
    }

    public class when_asked_about_the_unload_handling_event_type_name
    {
        Because of = () => result = HandlingEventType.UNLOAD.display_name();

        It should_return_the_unload_display_name = () => result.ShouldEqual("UNLOAD");

        static string result;
    }

    public class when_asked_about_the_claim_handling_event_type_name
    {
        Because of = () => result = HandlingEventType.CLAIM.display_name();

        It should_return_the_claim_display_name = () => result.ShouldEqual("CLAIM");

        static string result;
    }

    public class when_asked_about_the_customs_handling_event_type_name
    {
        Because of = () => result = HandlingEventType.CUSTOMS.display_name();

        It should_return_the_customs_display_name = () => result.ShouldEqual("CUSTOMS");

        static string result;
    }

    public class when_comparing_two_equal_handling_event_types
    {
        Because of = () => result = HandlingEventType.LOAD.has_the_same_value_as(HandlingEventType.LOAD);

        It should_confirm_that_both_have_the_same_value = () => result.ShouldBeTrue();

        static bool result;
    }

    public class when_comparing_two_different_handling_event_types
    {
        Because of = () => result = HandlingEventType.CUSTOMS.has_the_same_value_as(HandlingEventType.RECEIVE);

        It should_confirm_that_they_have_different_value = () => result.ShouldBeFalse();

        static bool result;
    }

    public class when_calculating_the_handling_event_type_hash_code
    {
        Because of = () => result = HandlingEventType.RECEIVE.GetHashCode();

        It should_return_the_display_name_hash_code = () => result.ShouldEqual("RECEIVE".GetHashCode());
        
        static int result;
    }
}