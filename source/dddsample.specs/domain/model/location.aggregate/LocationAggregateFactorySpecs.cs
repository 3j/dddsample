using System;
using System.Collections.Generic;
using dddsample.domain.model.cargo.aggregate.interfaces;
using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.location.aggregate.interfaces;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace dddsample.specs.domain.model.location.aggregate
{
    public abstract class concern_for_location_factory : Observes<LocationAggregateFactory> { }

    public class when_attempting_to_inject_a_null_united_nations_location_code_into_the_location_factory : concern_for_location_factory
    {
        Establish context = () =>
        {
            the_injected_united_nations_location_code = null;
            the_injected_location_name = an<ILocationName>();
        };

        Because of = () => catch_exception(() => sut.create_location_using(the_injected_united_nations_location_code, the_injected_location_name));

        It should_throw_a_null_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentNullException>();

        It should_throw_an_invariant_violated_exception_message = () => exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: a valid United Nations location code is required in order to construct a location.");

        static IUnitedNationsLocationCode the_injected_united_nations_location_code;
        static ILocationName the_injected_location_name;
    }

    public class when_attempting_to_inject_a_null_location_name_into_the_location_factory : concern_for_location_factory
    {
        Establish context = () =>
        {
            the_injected_united_nations_location_code = an<IUnitedNationsLocationCode>();
            the_injected_location_name = null;
        };

        Because of = () => catch_exception(() => sut.create_location_using(the_injected_united_nations_location_code, the_injected_location_name));

        It should_throw_a_null_argument_exception = () => exception_thrown_by_the_sut.ShouldBeAn<ArgumentNullException>();

        It should_throw_an_invariant_violated_exception_message = () => exception_thrown_by_the_sut.ShouldContainErrorMessage("Invariant Violated: a valid location name is required in order to construct a location.");

        static IUnitedNationsLocationCode the_injected_united_nations_location_code;
        static ILocationName the_injected_location_name;
    }

    public class when_creating_a_location_through_the_factory : concern_for_location_factory
    {
        Establish context = () =>
        {
            the_injected_united_nations_location_code = an<IUnitedNationsLocationCode>();
            the_injected_location_name = an<ILocationName>();
        };

        Because of =
            () => result = sut.create_location_using(the_injected_united_nations_location_code, the_injected_location_name);

        It should_return_an_object_that_conforms_the_location_interface = () => result.ShouldBeAn<ILocation>();

        static IUnitedNationsLocationCode the_injected_united_nations_location_code;
        static ILocationName the_injected_location_name;
        static ILocation result;
    }
}