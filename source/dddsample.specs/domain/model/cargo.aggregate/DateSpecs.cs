using System;
using dddsample.domain.model.cargo.aggregate;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;

namespace dddsample.specs.domain.model.cargo.aggregate
{
    public abstract class concern_for_date : Observes<IDate, Date>{}

    public class when_asked_if_a_past_date_is_posterior_to_the_current_date : concern_for_date
    {
        Establish context = () =>
        {
            a_past_date = new Date(DateTime.MinValue);
            
            create_sut_using(() => new Date(DateTime.Now));
        };

        Because of = () => result = sut.is_posterior_to(a_past_date);

        It should_confirm_that_it_is_posterior = () => result.ShouldBeTrue();

        static bool result;
        static IDate a_past_date;
    }

    public class when_asked_if_a_future_date_is_posterior_to_the_current_date : concern_for_date
    {
        Establish context = () =>
        {
            a_future_date = new Date(DateTime.MaxValue);

            create_sut_using(() => new Date(DateTime.Now));
        };

        Because of = () => result = sut.is_posterior_to(a_future_date);

        It should_confirm_that_it_is_previous_instead = () => result.ShouldBeFalse();

        static bool result;
        static IDate a_future_date;
    }

    public class when_asked_if_the_current_date_is_posterior_to_the_current_date : concern_for_date
    {
        Establish context = () =>
        {
            the_current_date = new Date(DateTime.MaxValue);

            create_sut_using(() => new Date(DateTime.MaxValue));
        };

        Because of = () => result = sut.is_posterior_to(the_current_date);

        It should_confirm_that_it_is_not_posterior = () => result.ShouldBeFalse();

        static bool result;
        static IDate the_current_date;
    }

    public class when_comparing_two_dates_with_the_same_attribute : concern_for_date
    {
        Establish context = () =>
        {
            the_other_date = new Date(DateTime.MaxValue);
            create_sut_using(() => new Date(DateTime.MaxValue));
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_date);

        It should_confirm_they_have_the_same_value = () => result.ShouldBeTrue();

        static bool result;
        static IDate the_other_date;
    }

    public class when_comparing_two_dates_with_different_attribute : concern_for_date
    {
        Establish context = () =>
        {
            the_other_date = new Date(DateTime.Now);
            create_sut_using(() => new Date(DateTime.MaxValue));
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_date);

        It should_confirm_they_have_not_the_same_value = () => result.ShouldBeFalse();

        static bool result;
        static IDate the_other_date;
    }

    public class when_comparing_any_date_with_a_null_date : concern_for_date
    {
        Establish context = () =>
        {
            the_other_date = null;
            create_sut_using(() => new Date(DateTime.MaxValue));
        };

        Because of = () => result = sut.has_the_same_value_as(the_other_date);

        It should_confirm_they_have_not_the_same_value = () => result.ShouldBeFalse();

        static bool result;
        static IDate the_other_date;
    }

    public class when_returning_the_datetime : concern_for_date
    {
        Establish context = () =>
        {
            the_datetime = DateTime.Now;

            create_sut_using(() => new Date(the_datetime));
        };

        Because of = () => result = sut.datetime_value();

        It should_be_the_same_used_in_construction = () => result.ShouldEqual(the_datetime);

        static DateTime result;
        static DateTime the_datetime;
    }

    public class when_asked_for_the_hash_code : concern_for_date
    {
        Establish context = () =>
        {
            the_datetime = DateTime.Now;

            create_sut_using(() => new Date(the_datetime));
        };

        Because of = () => result = sut.GetHashCode();

        It should_return_the_hash_code_based_on_the_construction_datetime_hash_code = () => 
            result.ShouldEqual(the_datetime.GetHashCode());

        static int result;
        static DateTime the_datetime;
    }

    public class when_comparing_two_dates_with_the_same_attribute_using_equals : concern_for_date
    {
        Establish context = () =>
        {
            the_datetime = DateTime.Now;

            create_sut_using(() => new Date(the_datetime));
            the_other_date = new Date(the_datetime);
        };

        Because of = () => result = sut.Equals(the_other_date);

        It should_confirm_they_are_equal = () => result.ShouldBeTrue();

        static bool result;
        static DateTime the_datetime;
        static IDate the_other_date;
    }

    public class when_comparing_two_dates_with_different_attribute_using_equals : concern_for_date
    {
        Establish context = () =>
        {
            the_datetime = DateTime.Now;
            create_sut_using(() => new Date(the_datetime));

            the_other_datetime = DateTime.MaxValue;
            the_other_date = new Date(the_other_datetime);
        };

        Because of = () => result = sut.Equals(the_other_date);

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static DateTime the_datetime;
        static IDate the_other_date;
        static DateTime the_other_datetime;
    }

    public class when_comparing_any_date_with_null_date_using_equals : concern_for_date
    {
        Establish context = () =>
        {
            the_datetime = DateTime.Now;
            create_sut_using(() => new Date(the_datetime));

            the_other_date = null;
        };

        Because of = () => result = sut.Equals(the_other_date);

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static DateTime the_datetime;
        static IDate the_other_date;
    }

    public class when_comparing_any_date_with_a_different_type_object_using_equals : concern_for_date
    {
        Establish context = () =>
        {
            the_datetime = DateTime.Now;
            create_sut_using(() => new Date(the_datetime));

            not_a_date = null;
        };

        Because of = () => result = sut.Equals(not_a_date);

        It should_confirm_they_are_different = () => result.ShouldBeFalse();

        static bool result;
        static DateTime the_datetime;
        static IItinerary not_a_date;
    }
}