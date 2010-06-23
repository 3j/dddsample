using System;
using System.Collections.Generic;
using System.Data;
using dddsample.domain.model.handling.aggregate;
using dddsample.domain.model.location.aggregate;

namespace dddsample.domain.model.cargo.aggregate
{
    /// <summary>
    /// An itinerary.
    /// Direct port of the java example in order to simulate legacy code 
    /// to support the argument presented in the Documentation. 
    /// </summary>
    public class Itinerary : IItinerary
    {
        /// <summary>
        /// NULL OBJECT PATTERN????
        /// </summary>
        public static readonly IItinerary EMPTY_ITINERARY = new Itinerary();
        private Itinerary(){}
        
        static readonly IDate END_OF_DAYS = new Date(DateTime.MaxValue);

        readonly IList<ILeg> underlying_leg_collection = new List<ILeg>();

        public Itinerary(IList<ILeg> the_associated_leg_collection)
        {
            if (the_associated_leg_collection.Count == 0)
                throw new ArgumentNullException("the_associated_leg_collection", "The injected leg collection cannot be empty.");

            ILeg a_null_leg = null;
            if (the_associated_leg_collection.Contains(a_null_leg))
                throw new NoNullAllowedException("The injected leg collection cannot contain null Leg elements.");

            this.underlying_leg_collection = the_associated_leg_collection;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The legs of this itinerary, as a list.</returns>
        public IList<ILeg> legs()
        {
            // TODO: Return an IEnumerable.
            return this.underlying_leg_collection;
        }

        /// <summary>
        /// Tests if the given handling event is expected when executing this itinerary.
        /// </summary>
        /// <param name="handling_event">Event to test.</param>
        /// <returns><code>true</code> if the event is expected.</returns>
        public bool isExpected(IHandlingEvent handling_event)
        {
            if (underlying_leg_collection.Count == 0)
            {
                return true;
            }

            if (handling_event.type() == HandlingEventType.RECEIVE)
            {
                //Check that the first leg's origin is the event's location
                var leg = underlying_leg_collection[0];
                return (leg.load_location().has_the_same_identity_as(handling_event.location()));
            }

            if (handling_event.type() == HandlingEventType.LOAD)
            {
                //Check that there is one leg with same load location and voyage
                foreach (var leg in underlying_leg_collection)
                {
                    if (leg.load_location().has_the_same_identity_as(handling_event.location()) &&
                        leg.voyage().has_the_same_identity_as(handling_event.voyage()))
                        return true;
                }
                return false;
            }

            if (handling_event.type() == HandlingEventType.UNLOAD)
            {
                //Check that the there is one leg with same unload location and voyage
                foreach (var leg in underlying_leg_collection)
                {
                    if (leg.unload_location().has_the_same_identity_as(handling_event.location()) &&
                        leg.voyage().has_the_same_identity_as(handling_event.voyage()))
                        return true;
                }
                return false;
            }

            if (handling_event.type() == HandlingEventType.CLAIM)
            {
                //Check that the last leg's destination is from the event's location
                var last_leg = lastLeg();
                return (last_leg.unload_location().has_the_same_identity_as(handling_event.location()));
            }

            //HandlingEvent.Type.CUSTOMS;
            return true;
        }
        
        public ILocation initial_departure_load_location()
        {
            return the_initial_leg().load_location();
        }

        ILeg the_initial_leg()
        {
            return underlying_leg_collection[0];
        }
        
        public ILocation final_arrival_unload_location()
        {
            return the_last_leg().unload_location();
        }

        ILeg the_last_leg()
        {
            return underlying_leg_collection[underlying_leg_collection.Count - 1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The last leg on the itinerary.</returns>
        ILeg lastLeg()
        {
            if (underlying_leg_collection.Count == 0)
                return null;
            return the_last_leg();
        }

        public IDate final_arrival_date()
        {
            return the_last_leg().unload_time();
        }
        
        public bool has_the_same_value_as(IItinerary the_other_itinerary)
        {
            return the_other_itinerary != null &&
                underlying_leg_collection.Equals(the_other_itinerary.legs());
        }

        public override int GetHashCode()
        {
            return underlying_leg_collection.GetHashCode();
        }
    }
}