using System;
using dddsample.domain.model.handling.aggregate.interfaces;

namespace dddsample.domain.model.handling.aggregate
{
    public class HandlingEventType : IHandlingEventType
    {
        //public static readonly IHandlingEventType RECEIVE = new HandlingEventType("RECEIVE");
        //public static readonly IHandlingEventType LOAD = new HandlingEventType("LOAD");
        //public static readonly IHandlingEventType UNLOAD = new HandlingEventType("UNLOAD");
        //public static readonly IHandlingEventType CLAIM = new HandlingEventType("CLAIM");
        //public static readonly IHandlingEventType CUSTOMS = new HandlingEventType("CUSTOMS");

        public static readonly IHandlingEventType RECEIVE = new HandlingEventType();
        public static readonly IHandlingEventType LOAD = new HandlingEventType();
        public static readonly IHandlingEventType UNLOAD = new HandlingEventType();
        public static readonly IHandlingEventType CLAIM = new HandlingEventType();
        public static readonly IHandlingEventType CUSTOMS = new HandlingEventType();

        HandlingEventType(){}
        
        //HandlingEventType(string the_display_name)
        //{
        //    throw new NotImplementedException();
        //}

        public bool has_the_same_value_as(IHandlingEventType the_other_value_object)
        {
            throw new NotImplementedException();
        }

        public string display_name()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}