using System;
using System.Collections.Generic;
using System.Data;
using dddsample.domain.model.cargo.aggregate;
using dddsample.domain.model.cargo.aggregate.interfaces;
using dddsample.domain.model.handling.aggregate;
using dddsample.domain.model.handling.aggregate.interfaces;
using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.location.aggregate.interfaces;
using dddsample.domain.model.voyage.aggregate;
using dddsample.domain.model.voyage.aggregate.interfaces;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
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

        Because of = () => result = sut.associated_legs();
        
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

    public class when_receiving_an_expected_handling_event_of_type_RECEIVE : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_expected_location = an<ILocation>();
            a_receive_type_handling_event = an<IHandlingEvent>();

            a_receive_type_handling_event
                .Stub(x => x.type())
                .Return(HandlingEventType.RECEIVE);

            the_collection_of_legs = new List<ILeg>();
            the_first_leg = an<ILeg>();
            the_collection_of_legs.Add(the_first_leg);

            the_first_leg
                .Stub(x => x.load_location())
                .Return(the_expected_location);
            the_first_leg.load_location()
                .Stub(x => x.has_the_same_identity_as(a_receive_type_handling_event.location()))
                .Return(true);

            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.was_expecting(a_receive_type_handling_event);

        It should_check_that_the_event_is_a_RECEIVE_type_event = () =>
        {
            a_receive_type_handling_event.was_told_to(x => x.type().Equals(HandlingEventType.RECEIVE));
            a_receive_type_handling_event.type().ShouldEqual(HandlingEventType.RECEIVE);
        };

        It should_compare_the_initial_departure_location_with_the_handling_event_location = () =>
            the_first_leg.load_location()
                .received(x => x.has_the_same_identity_as(a_receive_type_handling_event.location()));

        It should_confirm_that_the_locations_associated_to_the_handling_event_and_the_initial_departure_are_the_same =
            () => result.ShouldBeTrue();

        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IHandlingEvent a_receive_type_handling_event;
        static ILeg the_first_leg;
        static ILocation the_expected_location;
    }

    public class when_receiving_an_unexpected_handling_event_of_type_RECEIVE : concern_for_itinerary
    {
        Establish context = () =>
        {
            a_receive_type_handling_event = an<IHandlingEvent>();

            a_receive_type_handling_event
                .Stub(x => x.type())
                .Return(HandlingEventType.RECEIVE);

            the_collection_of_legs = new List<ILeg>();
            the_first_leg = an<ILeg>();
            the_collection_of_legs.Add(the_first_leg);

            the_first_leg
                .Stub(x => x.load_location())
                .Return(an<ILocation>());
            the_first_leg.load_location()
                .Stub(x => x.has_the_same_identity_as(a_receive_type_handling_event.location()))
                .Return(false);

            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.was_expecting(a_receive_type_handling_event);

        It should_check_that_the_event_is_a_RECEIVE_type_event = () =>
        {
            a_receive_type_handling_event.was_told_to(x => x.type().Equals(HandlingEventType.RECEIVE));
            a_receive_type_handling_event.type().ShouldEqual(HandlingEventType.RECEIVE);
        };

        It should_compare_the_initial_departure_location_with_the_handling_event_location = () =>
            the_first_leg.load_location()
                .received(x => x.has_the_same_identity_as(a_receive_type_handling_event.location()));

        It should_confirm_that_the_locations_associated_to_the_handling_event_and_the_initial_departure_are_different =
            () => result.ShouldBeFalse();

        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IHandlingEvent a_receive_type_handling_event;
        static ILeg the_first_leg;
    }

    public class when_receiving_an_expected_handling_event_of_type_LOAD : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_expected_location = an<ILocation>();
            a_not_matching_location = an<ILocation>();
            the_expected_voyage = an<IVoyage>();
            a_load_type_handling_event = an<IHandlingEvent>();

            a_load_type_handling_event
                .Stub(x => x.type())
                .Return(HandlingEventType.LOAD);

            the_collection_of_legs = new List<ILeg>();
            the_first_leg = an<ILeg>();
            the_middle_leg = an<ILeg>();
            the_last_leg = an<ILeg>();

            the_collection_of_legs.Add(the_first_leg);
            the_collection_of_legs.Add(the_middle_leg);
            the_collection_of_legs.Add(the_last_leg);

            the_first_leg
                .Stub(x => x.load_location())
                .Return(a_not_matching_location);
            the_first_leg.load_location()
                .Stub(x => x.has_the_same_identity_as(a_load_type_handling_event.location()))
                .Return(false);
            the_first_leg
                .Stub(x => x.voyage())
                .Return(an<IVoyage>());
            the_middle_leg
                .Stub(x => x.load_location())
                .Return(the_expected_location);
            the_middle_leg.load_location()
                .Stub(x => x.has_the_same_identity_as(a_load_type_handling_event.location()))
                .Return(true);
            the_middle_leg
                .Stub(x => x.voyage())
                .Return(the_expected_voyage);
            the_middle_leg.voyage()
                .Stub(x => x.has_the_same_identity_as(a_load_type_handling_event.voyage()))
                .Return(true);

            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.was_expecting(a_load_type_handling_event);

        It should_check_that_the_event_is_a_LOAD_type_event = () =>
        {
            a_load_type_handling_event.was_told_to(x => x.type().Equals(HandlingEventType.LOAD));
            a_load_type_handling_event.type().ShouldEqual(HandlingEventType.LOAD);
        };

        It should_compare_the_handling_event_location_with_every_leg_load_location_until_it_finds_a_match = () =>
        {
            the_first_leg.load_location()
                .received(x => x.has_the_same_identity_as(a_load_type_handling_event.location()));
            the_middle_leg.load_location()
                .received(x => x.has_the_same_identity_as(a_load_type_handling_event.location()));
        };

        It should_compare_the_handling_event_voyage_with_the_leg_voyage_if_theres_a_previous_location_match = () =>
        {
            the_first_leg.voyage()
                .never_received(x => x.has_the_same_identity_as(a_load_type_handling_event.voyage()));
            the_middle_leg.voyage()
                .received(x => x.has_the_same_identity_as(a_load_type_handling_event.voyage()));
        };

        It should_confirm_that_there_is_one_leg_with_the_same_load_location_and_voyage_as_the_ones_from_the_handling_event = () => 
            result.ShouldBeTrue();

        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IHandlingEvent a_load_type_handling_event;
        static ILeg the_last_leg;
        static ILocation the_expected_location;
        static ILeg the_first_leg;
        static ILeg the_middle_leg;
        static ILocation a_not_matching_location;
        static IVoyage the_expected_voyage;
    }

    public class when_receiving_an_unexpected_handling_event_of_type_LOAD : concern_for_itinerary
    {
        Establish context = () =>
        {
            a_load_type_handling_event = an<IHandlingEvent>();
            a_load_type_handling_event
                .Stub(x => x.type())
                .Return(HandlingEventType.LOAD);

            the_collection_of_legs = new List<ILeg>();
            for (var i = 0; i < 3; i++)
                the_collection_of_legs.Add(an<ILeg>());

            the_collection_of_legs.each(leg => leg
               .Stub(x => x.load_location())
               .Return(an<ILocation>()));
            the_collection_of_legs.each(leg =>leg.load_location()
               .Stub(x => x.has_the_same_identity_as(a_load_type_handling_event.location()))
               .Return(false));
            
            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.was_expecting(a_load_type_handling_event);

        It should_check_that_the_event_is_a_LOAD_type_event = () =>
        {
            a_load_type_handling_event.was_told_to(x => x.type().Equals(HandlingEventType.LOAD));
            a_load_type_handling_event.type().ShouldEqual(HandlingEventType.LOAD);
        };

        It should_compare_the_handling_event_location_with_every_leg_load_location = () =>
            the_collection_of_legs
                .each(leg => leg.load_location()
                                   .received(x => x.has_the_same_identity_as(a_load_type_handling_event.location())));

        It should_confirm_that_the_event_was_unexpected = () =>
            result.ShouldBeFalse();

        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IHandlingEvent a_load_type_handling_event;
    }

    public class when_receiving_an_expected_handling_event_of_type_UNLOAD : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_expected_location = an<ILocation>();
            a_not_matching_location = an<ILocation>();
            the_expected_voyage = an<IVoyage>();
            an_unload_type_handling_event = an<IHandlingEvent>();

            an_unload_type_handling_event
                .Stub(x => x.type())
                .Return(HandlingEventType.UNLOAD);

            the_collection_of_legs = new List<ILeg>();
            the_first_leg = an<ILeg>();
            the_middle_leg = an<ILeg>();
            the_last_leg = an<ILeg>();

            the_collection_of_legs.Add(the_first_leg);
            the_collection_of_legs.Add(the_middle_leg);
            the_collection_of_legs.Add(the_last_leg);

            the_first_leg
                .Stub(x => x.unload_location())
                .Return(a_not_matching_location);
            the_first_leg.unload_location()
                .Stub(x => x.has_the_same_identity_as(an_unload_type_handling_event.location()))
                .Return(false);
            the_first_leg
                .Stub(x => x.voyage())
                .Return(an<IVoyage>());
            the_middle_leg
                .Stub(x => x.unload_location())
                .Return(the_expected_location);
            the_middle_leg.unload_location()
                .Stub(x => x.has_the_same_identity_as(an_unload_type_handling_event.location()))
                .Return(true);
            the_middle_leg
                .Stub(x => x.voyage())
                .Return(the_expected_voyage);
            the_middle_leg.voyage()
                .Stub(x => x.has_the_same_identity_as(an_unload_type_handling_event.voyage()))
                .Return(true);

            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.was_expecting(an_unload_type_handling_event);

        It should_check_that_the_event_is_an_UNLOAD_type_event = () =>
        {
            an_unload_type_handling_event.was_told_to(x => x.type().Equals(HandlingEventType.UNLOAD));
            an_unload_type_handling_event.type().ShouldEqual(HandlingEventType.UNLOAD);
        };

        It should_compare_the_handling_event_location_with_every_leg_unload_location_until_it_finds_a_match = () =>
        {
            the_first_leg.unload_location()
                .received(x => x.has_the_same_identity_as(an_unload_type_handling_event.location()));
            the_middle_leg.unload_location()
                .received(x => x.has_the_same_identity_as(an_unload_type_handling_event.location()));
        };

        It should_compare_the_handling_event_voyage_with_the_leg_voyage_if_theres_a_previous_location_match = () =>
        {
            the_first_leg.voyage()
                .never_received(x => x.has_the_same_identity_as(an_unload_type_handling_event.voyage()));
            the_middle_leg.voyage()
                .received(x => x.has_the_same_identity_as(an_unload_type_handling_event.voyage()));
        };

        It should_confirm_that_there_is_one_leg_with_the_same_unload_location_and_voyage_as_the_ones_from_the_handling_event = () =>
            result.ShouldBeTrue();

        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IHandlingEvent an_unload_type_handling_event;
        static ILeg the_last_leg;
        static ILocation the_expected_location;
        static ILeg the_first_leg;
        static ILeg the_middle_leg;
        static ILocation a_not_matching_location;
        static IVoyage the_expected_voyage;
    }

    public class when_receiving_an_unexpected_handling_event_of_type_UNLOAD : concern_for_itinerary
    {
        Establish context = () =>
        {
            an_unload_type_handling_event = an<IHandlingEvent>();
            an_unload_type_handling_event
                .Stub(x => x.type())
                .Return(HandlingEventType.UNLOAD);

            the_collection_of_legs = new List<ILeg>();
            for (var i = 0; i < 3; i++)
                the_collection_of_legs.Add(an<ILeg>());

            the_collection_of_legs.each(leg => leg
               .Stub(x => x.unload_location())
               .Return(an<ILocation>()));
            the_collection_of_legs.each(leg => leg.unload_location()
               .Stub(x => x.has_the_same_identity_as(an_unload_type_handling_event.location()))
               .Return(false));

            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.was_expecting(an_unload_type_handling_event);

        It should_check_that_the_event_is_an_UNLOAD_type_event = () =>
        {
            an_unload_type_handling_event.was_told_to(x => x.type().Equals(HandlingEventType.UNLOAD));
            an_unload_type_handling_event.type().ShouldEqual(HandlingEventType.UNLOAD);
        };

        It should_compare_the_handling_event_location_with_every_leg_unload_location = () =>
            the_collection_of_legs
                .each(leg => leg.unload_location()
                                   .received(x => x.has_the_same_identity_as(an_unload_type_handling_event.location())));

        It should_confirm_that_the_event_was_unexpected = () =>
            result.ShouldBeFalse();

        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IHandlingEvent an_unload_type_handling_event;
    }

    public class when_receiving_an_expected_handling_event_of_type_CLAIM : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_expected_location = an<ILocation>();
            a_claim_type_handling_event = an<IHandlingEvent>();

            a_claim_type_handling_event
                .Stub(x => x.type())
                .Return(HandlingEventType.CLAIM);

            the_collection_of_legs = new List<ILeg>();
            the_first_leg = an<ILeg>();
            the_last_leg = an<ILeg>();
            the_collection_of_legs.Add(the_first_leg);
            the_collection_of_legs.Add(the_last_leg);

            the_last_leg
                .Stub(x => x.unload_location())
                .Return(the_expected_location);
            the_last_leg.unload_location()
                .Stub(x => x.has_the_same_identity_as(a_claim_type_handling_event.location()))
                .Return(true);

            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.was_expecting(a_claim_type_handling_event);

        It should_check_that_the_event_is_a_CLAIM_type_event = () =>
        {
            a_claim_type_handling_event.was_told_to(x => x.type().Equals(HandlingEventType.CLAIM));
            a_claim_type_handling_event.type().ShouldEqual(HandlingEventType.CLAIM);
        };

        It should_compare_the_final_arrival_unload_location_with_the_handling_event_location = () =>
            the_last_leg.unload_location()
                        .received(x => x.has_the_same_identity_as(a_claim_type_handling_event.location()));

        It should_confirm_that_the_locations_associated_to_the_handling_event_and_the_final_arrival_are_the_same =
            () => result.ShouldBeTrue();

        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IHandlingEvent a_claim_type_handling_event;
        static ILeg the_first_leg;
        static ILocation the_expected_location;
        static ILeg the_last_leg;
    }

    public class when_receiving_an_unexpected_handling_event_of_type_CLAIM : concern_for_itinerary
    {
        Establish context = () =>
        {
            a_claim_type_handling_event = an<IHandlingEvent>();

            a_claim_type_handling_event
                .Stub(x => x.type())
                .Return(HandlingEventType.CLAIM);

            the_collection_of_legs = new List<ILeg>();
            the_first_leg = an<ILeg>();
            the_last_leg = an<ILeg>();
            the_collection_of_legs.Add(the_first_leg);
            the_collection_of_legs.Add(the_last_leg);

            the_last_leg
                .Stub(x => x.unload_location())
                .Return(an<ILocation>());
            the_last_leg.unload_location()
                .Stub(x => x.has_the_same_identity_as(a_claim_type_handling_event.location()))
                .Return(false);

            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.was_expecting(a_claim_type_handling_event);

        It should_check_that_the_event_is_a_CLAIM_type_event = () =>
        {
            a_claim_type_handling_event.was_told_to(x => x.type().Equals(HandlingEventType.CLAIM));
            a_claim_type_handling_event.type().ShouldEqual(HandlingEventType.CLAIM);
        };

        It should_compare_the_final_arrival_unload_location_with_the_handling_event_location = () =>
            the_last_leg.unload_location()
                        .received(x => x.has_the_same_identity_as(a_claim_type_handling_event.location()));

        It should_confirm_that_the_locations_associated_to_the_handling_event_and_the_final_arrival_are_different =
            () => result.ShouldBeFalse();

        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IHandlingEvent a_claim_type_handling_event;
        static ILeg the_first_leg;
        static ILeg the_last_leg;
    }

    public class when_receiving_an_expected_handling_event_of_type_CUSTOMS : concern_for_itinerary
    {
        Establish context = () =>
        {
            a_customs_type_handling_event = an<IHandlingEvent>();
            a_customs_type_handling_event
                .Stub(x => x.type())
                .Return(HandlingEventType.CUSTOMS);

            the_collection_of_legs = new List<ILeg>();
            a_leg = an<ILeg>();
            the_collection_of_legs.Add(a_leg);
            
            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.was_expecting(a_customs_type_handling_event);

        It should_check_that_the_event_is_a_CUSTOMS_type_event = () =>
        {
            a_customs_type_handling_event.was_told_to(x => x.type().Equals(HandlingEventType.CUSTOMS));
            a_customs_type_handling_event.type().ShouldEqual(HandlingEventType.CUSTOMS);
        };

        It should_confirm_it_was_expected = () => result.ShouldBeTrue();

        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IHandlingEvent a_customs_type_handling_event;
        static ILeg a_leg;
    }

    public class when_receiving_an_unexpected_handling_event_of_type_unknown : concern_for_itinerary
    {
        Establish context = () =>
        {
            an_unknown_type_handling_event = an<IHandlingEvent>();
            an_unknown_type_handling_event
                .Stub(x => x.type())
                .Return(an<IHandlingEventType>());

            the_collection_of_legs = new List<ILeg>();
            a_leg = an<ILeg>();
            the_collection_of_legs.Add(a_leg);

            create_sut_using(() => new Itinerary(the_collection_of_legs));
        };

        Because of = () => result = sut.was_expecting(an_unknown_type_handling_event);

        It should_check_that_the_event_is_an_unknown_type_event = () =>
        {
            an_unknown_type_handling_event.was_told_to(x => x.type().Equals(HandlingEventType.RECEIVE));
            an_unknown_type_handling_event.was_told_to(x => x.type().Equals(HandlingEventType.LOAD));
            an_unknown_type_handling_event.was_told_to(x => x.type().Equals(HandlingEventType.UNLOAD));
            an_unknown_type_handling_event.was_told_to(x => x.type().Equals(HandlingEventType.CLAIM));
            an_unknown_type_handling_event.was_told_to(x => x.type().Equals(HandlingEventType.CUSTOMS));
            an_unknown_type_handling_event.type().ShouldNotEqual(HandlingEventType.RECEIVE);
            an_unknown_type_handling_event.type().ShouldNotEqual(HandlingEventType.LOAD);
            an_unknown_type_handling_event.type().ShouldNotEqual(HandlingEventType.UNLOAD);
            an_unknown_type_handling_event.type().ShouldNotEqual(HandlingEventType.CLAIM);
            an_unknown_type_handling_event.type().ShouldNotEqual(HandlingEventType.CUSTOMS);
        };

        It should_confirm_it_was_not_expected = () => result.ShouldBeFalse();

        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IHandlingEvent an_unknown_type_handling_event;
        static ILeg a_leg;
    }
}