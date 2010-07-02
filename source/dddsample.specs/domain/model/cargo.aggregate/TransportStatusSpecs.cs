using System;
using dddsample.domain.model.cargo.aggregate;
using Machine.Specifications;

namespace dddsample.specs.domain.model.cargo.aggregate
{
    public class when_asked_about_the_not_received_value
    {
        Because of = () => result = TransportStatus.NON_RECEIVED.display_name();

        It should_return_the_non_received_display_name = () => result.ShouldEqual("NON_RECEIVED");

        static string result;
    }

    public class when_asked_about_the_in_port_value
    {
        Because of = () => result = TransportStatus.IN_PORT.display_name();

        It should_return_the_in_port_display_name = () => result.ShouldEqual("IN_PORT");

        static string result;
    }

    public class when_asked_about_the_onboard_carrier_value
    {
        Because of = () => result = TransportStatus.ONBOARD_CARRIER.display_name();

        It should_return_the_onboard_carrier_display_name = () => result.ShouldEqual("ONBOARD_CARRIER");

        static string result;
    }

    public class when_asked_about_the_claimed_value
    {
        Because of = () => result = TransportStatus.CLAIMED.display_name();

        It should_return_the_claimed_display_name = () => result.ShouldEqual("CLAIMED");

        static string result;
    }

    public class when_asked_about_the_unknown_value
    {
        Because of = () => result = TransportStatus.UNKNOWN.display_name();

        It should_return_the_unknown_display_name = () => result.ShouldEqual("UNKNOWN");

        static string result;
    }

    public class when_comparing_two_equal_transport_status
    {
        Because of = () => result = TransportStatus.NON_RECEIVED.has_the_same_value_as(TransportStatus.NON_RECEIVED);

        It should_confirm_that_both_have_the_same_value = () => result.ShouldBeTrue();

        static bool result;
    }

    public class when_comparing_two_different_transport_status
    {
        Because of = () => result = TransportStatus.ONBOARD_CARRIER.has_the_same_value_as(TransportStatus.IN_PORT);

        It should_confirm_they_have_different_value = () => result.ShouldBeFalse();

        static bool result;
    }
}