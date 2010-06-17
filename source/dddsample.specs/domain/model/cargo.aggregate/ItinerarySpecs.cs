using System.Collections.Generic;
using dddsample.domain.model.cargo.aggregate;
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
            the_collection_of_legs = the_dependency<IList<ILeg>>();
        };

        Because of = () => result = sut.legs();

        It should_return_its_collection_of_legs = () => result.ShouldBeOfType(typeof(IList<ILeg>));

        static IList<ILeg> result;
        static IList<ILeg> the_collection_of_legs;
    }

    public class when_asked_for_the_initial_departure_location : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_collection_of_legs = the_dependency<IList<ILeg>>();
            the_first_leg = an<ILeg>();
            the_initial_departure_location = an<ILocation>();

            the_first_leg
                .Stub(x => x.load_location())
                .Return(the_initial_departure_location);
            
            the_collection_of_legs[0] = the_first_leg;
        };

        Because of = () => result = sut.initial_departure_location();

        It should_return_the_location_of_the_first_element_of_the_legs_collection =
            () => result.ShouldEqual(the_initial_departure_location);

        It should_leverage_the_load_location = () =>
            the_first_leg.received(x => x.load_location());
        
        static ILocation result;
        static IList<ILeg> the_collection_of_legs;
        static ILocation the_initial_departure_location;
        static ILeg the_first_leg;
    }

    public class when_asked_for_the_final_arrival_location : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_collection_of_legs = the_dependency<IList<ILeg>>();
            the_last_leg = an<ILeg>();
            the_final_arrival_location = an<ILocation>();

            the_last_leg
                .Stub(x => x.unload_location())
                .Return(the_final_arrival_location);

            the_collection_of_legs[the_collection_of_legs.Count - 1] = the_last_leg;
        };

        Because of = () => result = sut.final_arrival_location();

        It should_return_the_location_of_the_last_element_of_the_legs_collection =
            () => result.ShouldEqual(the_final_arrival_location);

        It should_leverage_the_unload_location = () =>
            the_last_leg.received(x => x.unload_location());

        static ILocation result;
        static IList<ILeg> the_collection_of_legs;
        static ILocation the_final_arrival_location;
        static ILeg the_last_leg;
    }

    public class when_asked_for_the_final_arrival_date : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_collection_of_legs = the_dependency<IList<ILeg>>();
            the_last_leg = an<ILeg>();
            the_final_arrival_date = an<IDate>();

            the_last_leg
                .Stub(x => x.unload_time())
                .Return(the_final_arrival_date);

            the_collection_of_legs[the_collection_of_legs.Count - 1] = the_last_leg;
        };

        Because of = () => result = sut.final_arrival_date();

        It should_return_the_date_of_the_last_element_of_the_legs_collection =
            () => result.ShouldEqual(the_final_arrival_date);

        It should_leverage_the_unload_location = () =>
            the_last_leg.received(x => x.unload_time());

        static IDate result;
        static IList<ILeg> the_collection_of_legs;
        static IDate the_final_arrival_date;
        static ILeg the_last_leg;
    }

    public class when_asked_if_two_equal_itineraries_have_the_same_value : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_collection_of_legs = the_dependency<IList<ILeg>>();
            the_same_itinerary = an<IItinerary>();

            //the_collection_of_legs
            //    .Stub(x => x.Equals(the_same_itinerary.legs()))
            //    .Return(true);

            the_same_itinerary
                .Stub(x => x.legs())
                .Return(the_collection_of_legs);

            
        };

        Because of = () => result = sut.has_the_same_value_as(the_same_itinerary);

        It should_confirm_they_have_the_same_value =
            () => result.ShouldBeTrue();

        //It should_leverage_the_list_equality = () =>
        //    the_collection_of_legs.received(x => x.Equals(the_same_itinerary.legs()));

        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IItinerary the_same_itinerary;
    }

    public class when_asked_if_two_different_itineraries_have_the_same_value : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_collection_of_legs = the_dependency<IList<ILeg>>();

            the_differente_collection_of_legs = an<IList<ILeg>>();
            a_different_itinerary = an<IItinerary>();

            //the_collection_of_legs
            //    .Stub(x => x.Equals(a_different_itinerary.legs()))
            //    .Return(true);

            a_different_itinerary
                .Stub(x => x.legs())
                .Return(the_differente_collection_of_legs);
        };

        Because of = () => result = sut.has_the_same_value_as(a_different_itinerary);

        It should_confirm_they_have_different_value =
            () => result.ShouldBeFalse();

        //It should_leverage_the_list_equality = () =>
        //    the_collection_of_legs.received(x => x.Equals(a_different_itinerary.legs()));

        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IItinerary a_different_itinerary;
        static IList<ILeg> the_differente_collection_of_legs;
    }

    public class when_asked_if_a_null_itinerary_has_the_same_value_as_any_other_itinerary : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_collection_of_legs = the_dependency<IList<ILeg>>();
            a_different_itinerary = null;
        };

        Because of = () => result = sut.has_the_same_value_as(a_different_itinerary);

        It should_confirm_they_have_different_value =
            () => result.ShouldBeFalse();
        
        static bool result;
        static IList<ILeg> the_collection_of_legs;
        static IItinerary a_different_itinerary;
    }

    public class when_asked_for_the_itinerary_hash_code : concern_for_itinerary
    {
        Establish context = () =>
        {
            the_collection_of_legs = the_dependency<IList<ILeg>>();
            //the_first_leg = an<ILeg>();
            //the_collection_of_legs.Add(the_first_leg);

            //create_sut_using(() => new Itinerary(the_collection_of_legs));

            //the_first_leg
            //    .Stub(x => x.GetHashCode())
            //    .Return(5);
            //the_collection_of_legs
            //    .Stub(x => x.GetHashCode())
            //    .Return(10);
        };

        Because of = () => result = sut.GetHashCode();

        It should_return_a_hash_code =
            () => result.ShouldBeOfType(typeof(int));

        //It should_leverage_the_collection_of_legs_hash_code =
        //    () => the_collection_of_legs.received(x => x.GetHashCode());

        //It should_leverage_the_first_leg_hash_code =
            //() => the_first_leg.received(x => x.GetHashCode());

        static int result;
        static IList<ILeg> the_collection_of_legs;
        static ILeg the_first_leg;
    }

    public class Itinerary : IItinerary
    {
        readonly IList<ILeg> underlying_collection_of_legs;

        public Itinerary(IList<ILeg> the_collection_of_legs)
        {
            this.underlying_collection_of_legs = the_collection_of_legs;
        }

        public ILocation initial_departure_location()
        {
            return underlying_collection_of_legs[0].load_location();
        }

        public ILocation final_arrival_location()
        {
            return underlying_collection_of_legs[underlying_collection_of_legs.Count - 1].unload_location();
        }

        public IDate final_arrival_date()
        {
            return underlying_collection_of_legs[underlying_collection_of_legs.Count - 1].unload_time();
        }

        public IList<ILeg> legs()
        {
            return underlying_collection_of_legs;
        }

        public bool has_the_same_value_as(IItinerary the_other_itinerary)
        {
            return the_other_itinerary != null &&
                   underlying_collection_of_legs.Equals(the_other_itinerary.legs());
        }

        public override int GetHashCode()
        {
            return underlying_collection_of_legs.GetHashCode();
        }
    }

   
}