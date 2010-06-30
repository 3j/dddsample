using dddsample.domain.model.cargo.aggregate;
using Machine.Specifications;

namespace dddsample.specs.domain.model.cargo.aggregate
{
    public class when_asked_about_the_misrouted_value
    {
        Because of = () => result = RouteStatus.MISROUTED.display_name();

        It should_return_the_misrouted_display_name = () => result.ShouldEqual("MISROUTED");

        static string result;
    }

    public class when_asked_about_the_routed_value
    {
        Because of = () => result = RouteStatus.ROUTED.display_name();

        It should_return_the_routed_display_name = () => result.ShouldEqual("ROUTED");

        static string result;
    }

    public class when_asked_about_the_not_routed_value
    {
        Because of = () => result = RouteStatus.NOT_ROUTED.display_name();

        It should_return_the_routed_display_name = () => result.ShouldEqual("NOT_ROUTED");

        static string result;
    }

    public class when_comparing_two_equal_route_status
    {
        Because of = () => result = RouteStatus.MISROUTED.has_the_same_value_as(RouteStatus.MISROUTED);

        It should_confirm_that_both_have_the_same_value = () => result.ShouldBeTrue();
        
        static bool result;
    }

    public class when_comparing_two_different_route_status
    {
        Because of = () => result = RouteStatus.ROUTED.has_the_same_value_as(RouteStatus.NOT_ROUTED);

        It should_confirm_they_have_differennt_value = () => result.ShouldBeFalse();

        static bool result;
    }
}