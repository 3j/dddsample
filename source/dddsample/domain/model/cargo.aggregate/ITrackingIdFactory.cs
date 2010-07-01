namespace dddsample.domain.model.cargo.aggregate
{
    public interface ITrackingIdFactory
    {
        ITrackingId create_tracking_id_using(string the_id);
    }
}