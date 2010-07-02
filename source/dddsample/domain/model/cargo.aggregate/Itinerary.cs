using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using dddsample.domain.model.cargo.aggregate.interfaces;
using dddsample.domain.model.handling.aggregate;
using dddsample.domain.model.handling.aggregate.interfaces;
using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.location.aggregate.interfaces;

namespace dddsample.domain.model.cargo.aggregate
{
    /// <summary>
    /// An itinerary.
    /// Originally, a direct port of the java example in order to simulate legacy code 
    /// to support the argument presented in the Documentation.
    /// Currently, the refactored version driven by the argument presented in the Documentation.
    /// </summary>
    public class Itinerary : IItinerary
    {
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
        
        public IList<ILeg> associated_legs()
        {
            // TODO: Return an IEnumerable.
            return this.underlying_leg_collection;
        }

        public bool was_expecting(IHandlingEvent the_handling_event)
        {
            if (the_handling_event.type() == HandlingEventType.RECEIVE)
                return the_initial_leg().load_location().has_the_same_identity_as(the_handling_event.location());

            if (the_handling_event.type() == HandlingEventType.LOAD)
                return underlying_leg_collection.Any(leg => 
                           leg.load_location().has_the_same_identity_as(the_handling_event.location()) &&
                           leg.voyage().has_the_same_identity_as(the_handling_event.voyage()));

            if (the_handling_event.type() == HandlingEventType.UNLOAD)
                return underlying_leg_collection.Any(leg =>
                           leg.unload_location().has_the_same_identity_as(the_handling_event.location()) &&
                           leg.voyage().has_the_same_identity_as(the_handling_event.voyage()));

            if (the_handling_event.type() == HandlingEventType.CLAIM)
                return the_last_leg().unload_location().has_the_same_identity_as(the_handling_event.location());
            
            if (the_handling_event.type() == HandlingEventType.CUSTOMS)
                return true;
            
            return false;
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

        public IDate final_arrival_date()
        {
            return the_last_leg().unload_time();
        }
        
        public bool has_the_same_value_as(IItinerary the_other_itinerary)
        {
            return the_other_itinerary != null &&
                   underlying_leg_collection.Equals(the_other_itinerary.associated_legs());
        }

        public override int GetHashCode()
        {
            return underlying_leg_collection.GetHashCode();
        }
    }
}