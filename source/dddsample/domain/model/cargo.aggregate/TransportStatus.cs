using dddsample.domain.model.cargo.aggregate.interfaces;

namespace dddsample.domain.model.cargo.aggregate
{
    public class TransportStatus : ITransportStatus
    {
        public static readonly ITransportStatus NON_RECEIVED = new TransportStatus("NON_RECEIVED");
        public static readonly ITransportStatus IN_PORT = new TransportStatus("IN_PORT");
        public static readonly ITransportStatus ONBOARD_CARRIER = new TransportStatus("ONBOARD_CARRIER");
        public static readonly ITransportStatus CLAIMED = new TransportStatus("CLAIMED");
        public static readonly ITransportStatus UNKNOWN = new TransportStatus("UNKNOWN");
        
        readonly string underlying_display_name;

        TransportStatus(string the_injected_value)
        {
            underlying_display_name = the_injected_value;
        }

        public bool has_the_same_value_as(ITransportStatus the_other_value_object)
        {
            return underlying_display_name.Equals(the_other_value_object.display_name());
        }

        public string display_name()
        {
            return underlying_display_name;
        }
    }
}