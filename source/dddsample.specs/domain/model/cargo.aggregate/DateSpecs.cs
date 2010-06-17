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

    public class when_asked_if_the_same_date_has_the_same_value : concern_for_date
    {
        Establish context = () =>
        {
            the_same_date = new Date(DateTime.MaxValue);

            create_sut_using(() => new Date(DateTime.MaxValue));
        };

        Because of = () => result = sut.has_the_same_value_as(the_same_date);

        It should_confirm_that_both_have_the_same_value = () => result.ShouldBeTrue();

        static bool result;
        static IDate the_same_date;
    }

    public class when_asked_if_a_different_date_has_the_same_value : concern_for_date
    {
        Establish context = () =>
        {
            a_different_date = new Date(DateTime.Now);

            create_sut_using(() => new Date(DateTime.MaxValue));
        };

        Because of = () => result = sut.has_the_same_value_as(a_different_date);

        It should_prove_as_otherwise = () => result.ShouldBeFalse();

        static bool result;
        static IDate a_different_date;
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
}