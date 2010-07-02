using System;
using dddsample.domain.model.handling.aggregate.interfaces;

namespace dddsample.domain.model.handling.aggregate
{
    public class HandlingEventType : IHandlingEventType
    {
        public static readonly IHandlingEventType RECEIVE = new HandlingEventType("RECEIVE");
        public static readonly IHandlingEventType LOAD = new HandlingEventType("LOAD");
        public static readonly IHandlingEventType UNLOAD = new HandlingEventType("UNLOAD");
        public static readonly IHandlingEventType CLAIM = new HandlingEventType("CLAIM");
        public static readonly IHandlingEventType CUSTOMS = new HandlingEventType("CUSTOMS");
        
        
        readonly string underlying_display_name;

        HandlingEventType(string the_display_name)
        {
            underlying_display_name = the_display_name;
        }

        public bool has_the_same_value_as(IHandlingEventType the_other_value_object)
        {
            return underlying_display_name.Equals(the_other_value_object.display_name());
        }

        public string display_name()
        {
            return underlying_display_name;
        }

        public override int GetHashCode()
        {
            return underlying_display_name.GetHashCode();
        }
    }
}