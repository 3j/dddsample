using dddsample.domain.shared;

namespace dddsample.scratchpad
{

    /// <summary>
    /// Represents the different transport statuses for a cargo.
    /// </summary>
    public class TransportStatus : IValueObject<TransportStatus>
    {
        public static readonly TransportStatus NOT_RECEIVED = new TransportStatus();
        public static readonly TransportStatus IN_PORT = new TransportStatus();
        public static readonly TransportStatus ONBOARD_CARRIER = new TransportStatus();
        public static readonly TransportStatus CLAIMED = new TransportStatus();
        public static readonly TransportStatus UNKNOWN = new TransportStatus();

        private TransportStatus() { }

        public bool has_the_same_value_as(TransportStatus the_other_transport_status)
        {
            // check if this is accurate with a test.
            return this.Equals(the_other_transport_status);
            //throw new NotImplementedException();
            
        }
    }

    public class Prueba
    {
        TransportStatus transport_status;

        public TransportStatus mas_pruebas()
        {
            // This doesn't make sense. I think.
            TransportStatus.UNKNOWN.has_the_same_value_as(TransportStatus.ONBOARD_CARRIER);
            return TransportStatus.IN_PORT;
        }

        public void aun_mas_pruebas()
        {
            transport_status = mas_pruebas();

            // This makes more sense
            transport_status.has_the_same_value_as(TransportStatus.IN_PORT);

            if (transport_status.has_the_same_value_as(TransportStatus.IN_PORT))
            {
                
            }
        }
    }
}