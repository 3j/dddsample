using System;
using System.Collections.Generic;
using System.Data;
using dddsample.domain.model.cargo.aggregate;
using dddsample.domain.model.location.aggregate;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace dddsample.specs.domain.model.cargo.aggregate
{
    public abstract class concern_for_itinerary : Observes<IItinerary,Itinerary> {}

    public class when_asked_for_the_itinerary_legs_collection : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_collection_of_legs = new List<ILeg>();
            the_first_leg = an<ILeg>();
            the_collection_of_legs.Add(the_first_leg);

            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.legs();
        
        It should_return_its_collection_of_legs = () => result.ShouldEqual(the_collection_of_legs);

        static IList<ILeg> result;
        static IList<ILeg> the_collection_of_legs;
        static ILeg the_first_leg;
    }

    public class when_asked_for_the_initial_departure_load_location : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_initial_departure_load_location = an<ILocation>();

            the_collection_of_legs = new List<ILeg>();
            the_first_leg = an<ILeg>();
            the_last_leg = an<ILeg>();
            the_collection_of_legs.Add(the_first_leg);
            the_collection_of_legs.Add(the_last_leg);

            the_first_leg
                .Stub(x => x.load_location())
                .Return(the_initial_departure_load_location);

            create_sut_using(()=> new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.initial_departure_load_location();

        It should_leverage_the_first_leg_load_location = () =>
            the_first_leg.received(x => x.load_location());

        It should_return_the_legs_collection_first_element_load_location =
            () => result.ShouldEqual(the_initial_departure_load_location);
        
        static ILocation result;
        static ILocation the_initial_departure_load_location;
        static ILeg the_first_leg;
        static ILeg the_last_leg;
        static IList<ILeg> the_collection_of_legs;
    }

    //public class when_asked_for_the_initial_departure_load_location_with_an_empty_leg_collection : concern_for_itinerary
    //{
    //    Establish context = () =>
    //    {
    //        the_collection_of_legs = new List<ILeg>();
    //        create_sut_using(() => new Itinerary(the_collection_of_legs));
    //    };

    //    Because of = () => result = sut.initial_departure_load_location();

    //    It should_return_a_location_UNKNWON =
    //        () => result.ShouldEqual(LocationImplementationExample.UNKNOWN);

    //    static ILocation result;
    //    static IList<ILeg> the_collection_of_legs;
    //}

    public class when_asked_for_the_final_arrival_unload_location : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_final_arrival_unload_location = an<ILocation>();

            the_collection_of_legs = new List<ILeg>();
            the_first_leg = an<ILeg>();
            the_last_leg = an<ILeg>();
            the_collection_of_legs.Add(the_first_leg);
            the_collection_of_legs.Add(the_last_leg);

            the_last_leg
                .Stub(x => x.unload_location())
                .Return(the_final_arrival_unload_location);

            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.final_arrival_unload_location();

        It should_leverage_the_last_leg_unload_location = () =>
            the_last_leg.received(x => x.unload_location());

        It should_return_the_legs_collection_last_element_unload_location =
            () => result.ShouldEqual(the_final_arrival_unload_location);

        static ILeg the_first_leg;
        static ILocation result;
        static ILocation the_final_arrival_unload_location;
        static IList<ILeg> the_collection_of_legs;
        static ILeg the_last_leg;
    }

    //public class when_asked_for_the_final_arrival_unload_location_with_an_empty_leg_collection : concern_for_itinerary
    //{
    //    Establish context = () =>
    //    {
    //        the_collection_of_legs = new List<ILeg>();
    //        create_sut_using(() => new Itinerary(the_collection_of_legs));
    //    };

    //    Because of = () => result = sut.final_arrival_unload_location();

    //    It should_return_a_location_UNKNWON =
    //        () => result.ShouldEqual(LocationImplementationExample.UNKNOWN);

    //    static ILocation result;
    //    static IList<ILeg> the_collection_of_legs;
    //}

    public class when_asked_for_the_final_arrival_date : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_final_arrival_date = an<IDate>();

            the_collection_of_legs = new List<ILeg>();
            the_first_leg = an<ILeg>();
            the_last_leg = an<ILeg>();
            the_collection_of_legs.Add(the_first_leg);
            the_collection_of_legs.Add(the_last_leg);

            the_last_leg
                .Stub(x => x.unload_time())
                .Return(the_final_arrival_date);

            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.final_arrival_date();

        It should_leverage_the_last_leg_unload_time = () =>
            the_last_leg.received(x => x.unload_time());

        It should_return_the_legs_collection_last_element_unload_date =
            () => result.ShouldEqual(the_final_arrival_date);
        
        static IDate result;
        static IList<ILeg> the_collection_of_legs;
        static ILeg the_first_leg;
        static IDate the_final_arrival_date;
        static ILeg the_last_leg;
    }

    //public class when_asked_for_the_final_arrival_date_with_a_non_empty_leg_collection_and_a_null_last_leg : concern_for_itinerary
    //{
    //    Establish context = () =>
    //    {
    //        the_final_arrival_date = an<IDate>();

    //        the_collection_of_legs = new List<ILeg>();
    //        the_first_leg = an<ILeg>();
    //        the_last_leg = null;
    //        the_collection_of_legs.Add(the_first_leg);
    //        the_collection_of_legs.Add(the_last_leg);

    //        create_sut_using(() => new Itinerary(the_collection_of_legs));
    //    };

    //    Because of = () => result = sut.final_arrival_date();

    //    It should_assert_true = () => true.ShouldBeTrue();

    //    static IDate result;
    //    static IList<ILeg> the_collection_of_legs;
    //    static ILeg the_first_leg;
    //    static IDate the_final_arrival_date;
    //    static ILeg the_last_leg;
    //}

    public class when_trying_to_construct_the_itinerary_with_an_empty_leg_collection
    {
        // "CLASSIC" MSpec
        Because of = () => exception = Catch.Exception(() => new Itinerary(new List<ILeg>()));

        It should_throw_a_null_argument_exception = () => exception.ShouldBeAn<ArgumentNullException>();

        It should_contain_a_custom_error_message = () =>
            exception.ShouldContainErrorMessage("The injected leg collection cannot be empty.");

        static Exception exception;
    }

    public class when_trying_to_construct_the_itinerary_with_a_leg_collection_which_contains_null_legs
    {
        // CLASSIC MSpec
        Establish context = () =>
        {
            the_collection_of_legs = new List<ILeg>();
            the_first_leg = null; 
            the_last_leg = null;
            the_collection_of_legs.Add(the_first_leg);
            the_collection_of_legs.Add(the_last_leg);
        };

        Because of = () => exception = Catch.Exception(() => new Itinerary(the_collection_of_legs));

        It should_throw_a_null_argument_exception = () => exception.ShouldBeAn<NoNullAllowedException>();

        It should_contain_a_custom_error_message = () =>
            exception.ShouldContainErrorMessage("The injected leg collection cannot contain null Leg elements.");

        static IList<ILeg> the_collection_of_legs;
        static ILeg the_first_leg;
        static ILeg the_last_leg;
        static Exception exception;
    }

    public class when_asked_if_two_itineraries_with_the_same_leg_collection_have_the_same_value : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_collection_of_legs = new List<ILeg>();
            the_first_leg = an<ILeg>();
            the_last_leg = an<ILeg>();
            the_collection_of_legs.Add(the_first_leg);
            the_collection_of_legs.Add(the_last_leg);

            the_itinerary_with_same_leg_collection = new Itinerary(the_collection_of_legs);
            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.has_the_same_value_as(the_itinerary_with_same_leg_collection);

        It should_confirm_they_have_the_same_value = () => result.ShouldBeTrue();
        
        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IItinerary the_itinerary_with_same_leg_collection;
        static ILeg the_first_leg;
        static ILeg the_last_leg;
    }

    public class when_asked_if_two_itineraries_with_different_leg_collection_have_the_same_value : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_collection_of_legs = new List<ILeg>();
            the_first_leg = an<ILeg>();
            the_last_leg = an<ILeg>();
            the_collection_of_legs.Add(the_first_leg);
            the_collection_of_legs.Add(the_last_leg);

            create_sut_using(() => new Itinerary(the_collection_of_legs));

            the_alternative_collection_of_legs = new List<ILeg>();
            the_alternative_first_leg = an<ILeg>();
            the_alternative_last_leg = an<ILeg>();
            the_alternative_collection_of_legs.Add(the_alternative_first_leg);
            the_alternative_collection_of_legs.Add(the_alternative_last_leg);

            the_itinerary_with_different_leg_collection = new Itinerary(the_alternative_collection_of_legs);
            
        };

        Because of = () => result = sut.has_the_same_value_as(the_itinerary_with_different_leg_collection);

        It should_confirm_they_have_different_value = () => result.ShouldBeFalse();

        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static ILeg the_first_leg;
        static ILeg the_last_leg;
        static IItinerary the_itinerary_with_different_leg_collection;
        static IList<ILeg> the_alternative_collection_of_legs;
        static ILeg the_alternative_first_leg;
        static ILeg the_alternative_last_leg;
    }

    public class when_asked_if_a_null_itinerary_has_the_same_value_as_any_other_itinerary : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_collection_of_legs = new List<ILeg>();
            the_first_leg = an<ILeg>();
            the_last_leg = an<ILeg>();
            the_collection_of_legs.Add(the_first_leg);
            the_collection_of_legs.Add(the_last_leg);

            a_null_itinerary = null;
            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.has_the_same_value_as(a_null_itinerary);

        It should_confirm_they_have_different_value = () => result.ShouldBeFalse();

        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IItinerary a_null_itinerary;
        static ILeg the_first_leg;
        static ILeg the_last_leg;
    }

    public class when_asked_for_the_itinerary_hash_code : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_collection_of_legs = new List<ILeg>();
            the_first_leg = an<ILeg>();
            the_last_leg = an<ILeg>();
            the_collection_of_legs.Add(the_first_leg);
            the_collection_of_legs.Add(the_last_leg);

            the_collection_of_legs_hash_code = the_collection_of_legs.GetHashCode();
            
            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.GetHashCode();

        It should_return_a_hash_code = () => result.ShouldBeOfType(typeof(int));

        It should_calculate_the_hash_code = () => result.ShouldEqual(the_collection_of_legs_hash_code);
        
        static int result;
        static IList<ILeg> the_collection_of_legs;
        static ILeg the_first_leg;
        static ILeg the_last_leg;
        static int the_collection_of_legs_hash_code;
    }
}