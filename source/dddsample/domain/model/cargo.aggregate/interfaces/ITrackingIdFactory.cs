namespace dddsample.domain.model.cargo.aggregate.interfaces
{
    public interface ITrackingIdFactory
    {
        ITrackingId create_tracking_id_using(string the_id);
    }
}