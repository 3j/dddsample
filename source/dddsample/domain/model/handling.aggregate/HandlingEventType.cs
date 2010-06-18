namespace dddsample.domain.model.handling.aggregate
{
    public class HandlingEventType : IHandlingEventType
    {
        public static readonly IHandlingEventType RECEIVE = new HandlingEventType();
        public static readonly IHandlingEventType LOAD = new HandlingEventType();
        public static readonly IHandlingEventType UNLOAD = new HandlingEventType();
        public static readonly IHandlingEventType CLAIM = new HandlingEventType();
        public static readonly IHandlingEventType CUSTOMS = new HandlingEventType();

        private HandlingEventType(){}
    }
}